using System.Data.Odbc;
using Dfe.Academies.DataLakePoc.Models;
using Microsoft.Extensions.Options;

namespace Dfe.Academies.DataLakePoc;

/// <summary>
/// Executes SQL against Databricks using the Databricks (Simba) ODBC driver and ADO.NET <see cref="OdbcConnection"/>.
/// Requires the ODBC driver to be installed on the host.
/// </summary>
public class DatabricksOdbcQueryClient
{
    private readonly DatabricksOdbcOptions _options;
    private readonly IDatabricksTokenProvider? _tokenProvider;

    public DatabricksOdbcQueryClient(
        IOptions<DatabricksOdbcOptions> options,
        IDatabricksTokenProvider? tokenProvider = null)
    {
        _options = options?.Value ?? throw new ArgumentNullException(nameof(options));
        _tokenProvider = tokenProvider;
    }

    /// <summary>
    /// Executes a SQL query and reads the full result set into memory (POC-style; not for huge results).
    /// </summary>
    public async Task<DatabricksQueryResult> ExecuteQueryAsync(
        string sql,
        CancellationToken cancellationToken = default)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(sql);

        var connectionString = await BuildConnectionStringAsync(cancellationToken).ConfigureAwait(false);

        await using var connection = new OdbcConnection(connectionString);
        await connection.OpenAsync(cancellationToken).ConfigureAwait(false);

        await using var command = new OdbcCommand(sql, connection);
        await using var reader = await command.ExecuteReaderAsync(cancellationToken).ConfigureAwait(false);

        var columnNames = new List<string>(reader.FieldCount);
        for (var i = 0; i < reader.FieldCount; i++)
            columnNames.Add(reader.GetName(i));

        var rows = new List<IReadOnlyList<object?>>();
        while (await reader.ReadAsync(cancellationToken).ConfigureAwait(false))
        {
            var row = new List<object?>(reader.FieldCount);
            for (var i = 0; i < reader.FieldCount; i++)
                row.Add(reader.IsDBNull(i) ? null : reader.GetValue(i));
            rows.Add(row);
        }

        return new DatabricksQueryResult
        {
            ColumnNames = columnNames,
            Rows = rows,
            Truncated = false
        };
    }

    /// <summary>
    /// Runs a command that does not return a result set (e.g. USE CATALOG).
    /// </summary>
    public async Task<int> ExecuteNonQueryAsync(string sql, CancellationToken cancellationToken = default)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(sql);

        var connectionString = await BuildConnectionStringAsync(cancellationToken).ConfigureAwait(false);

        await using var connection = new OdbcConnection(connectionString);
        await connection.OpenAsync(cancellationToken).ConfigureAwait(false);

        await using var command = new OdbcCommand(sql, connection);
        return await command.ExecuteNonQueryAsync(cancellationToken).ConfigureAwait(false);
    }

    /// <summary>
    /// Returns the effective ODBC connection string (resolves Azure AD token when configured).
    /// </summary>
    public async Task<string> BuildConnectionStringAsync(CancellationToken cancellationToken = default)
    {
        string? tokenOverride = null;
        if (_options.UseEntraTokenForOdbc)
        {
            if (_tokenProvider == null)
                throw new InvalidOperationException(
                    "Databricks ODBC: service principal / Entra token auth is enabled but no IDatabricksTokenProvider is registered. " +
                    "Call AddDatabricksOdbcQueryClient(configuration) with AzureAdTenantId, AzureAdClientId, and AzureAdClientSecret on DatabricksOdbc, " +
                    "or register AzureAdDatabricksTokenProvider and ensure DatabricksSql or DatabricksOdbc has Entra credentials.");

            tokenOverride = await _tokenProvider.GetAccessTokenAsync(cancellationToken).ConfigureAwait(false);
        }

        return DatabricksOdbcConnectionStringBuilder.Build(_options, tokenOverride);
    }
}
