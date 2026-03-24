using System.Data.Odbc;
using System.Text.RegularExpressions;
using Dfe.Academies.DataLakePoc.Models;
using Microsoft.Extensions.Options;

namespace Dfe.Academies.DataLakePoc;

/// <summary>
/// Executes SQL against Databricks using the Databricks ODBC driver and ADO.NET <see cref="OdbcConnection"/>.
/// Requires the ODBC driver to be installed on the host.
/// </summary>
public partial class DatabricksOdbcQueryClient
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
    public Task<DatabricksQueryResult> ExecuteQueryAsync(
        string sql,
        CancellationToken cancellationToken = default) =>
        ExecuteQueryAsync(sql, catalog: null, schema: null, cancellationToken);

    /// <summary>
    /// Optional catalog/schema handling then runs <paramref name="sql"/>.
    /// For SQL Warehouse, <c>USE</c> often does not apply to the next command; prefer three-part names in <paramref name="sql"/>
    /// or enable <see cref="DatabricksOdbcOptions.AutoQualifyCatalogSchemaInSql"/> when both catalog and schema are set.
    /// Databricks ODBC does not accept multiple statements in one batch; each <c>USE</c> is a separate execute.
    /// </summary>
    public async Task<DatabricksQueryResult> ExecuteQueryAsync(
        string sql,
        string? catalog,
        string? schema,
        CancellationToken cancellationToken = default)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(sql);

        var connectionString = await BuildConnectionStringAsync(cancellationToken).ConfigureAwait(false);

        var catalogTrim = catalog?.Trim();
        var schemaTrim = schema?.Trim();
        var bothContext = !string.IsNullOrWhiteSpace(catalogTrim) && !string.IsNullOrWhiteSpace(schemaTrim);

        if (bothContext && _options.AutoQualifyCatalogSchemaInSql)
            sql = QualifyFromAndJoinWithCatalogSchema(sql, catalogTrim!, schemaTrim!);

        await using var connection = new OdbcConnection(connectionString);
        await connection.OpenAsync(cancellationToken).ConfigureAwait(false);

        // USE often does not persist for the next execute on SQL Warehouse ODBC; prefer three-part names (above) when both catalog+schema are set.
        if (!bothContext || !_options.AutoQualifyCatalogSchemaInSql)
        {
            if (!string.IsNullOrWhiteSpace(catalogTrim))
            {
                await using (var useCatalog = new OdbcCommand(
                                 $"USE CATALOG {FormatUseIdentifier(catalogTrim!)}",
                                 connection))
                {
                    await useCatalog.ExecuteNonQueryAsync(cancellationToken).ConfigureAwait(false);
                }
            }

            if (!string.IsNullOrWhiteSpace(schemaTrim))
            {
                await using (var useSchema = new OdbcCommand(
                                 $"USE SCHEMA {FormatUseIdentifier(schemaTrim!)}",
                                 connection))
                {
                    await useSchema.ExecuteNonQueryAsync(cancellationToken).ConfigureAwait(false);
                }
            }
        }

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

    /// <summary>Backtick-quote a Unity Catalog / Spark identifier (escape embedded backticks).</summary>
    private static string QuoteSqlIdentifier(string name) =>
        "`" + name.Replace("`", "``", StringComparison.Ordinal) + "`";

    /// <summary>
    /// Spark <c>USE CATALOG</c>/<c>USE SCHEMA</c>: simple identifiers are usually unquoted; quote only when needed.
    /// </summary>
    private static string FormatUseIdentifier(string name) =>
        SimpleSqlIdentifierRegex().IsMatch(name) ? name : QuoteSqlIdentifier(name);

    /// <summary>
    /// Qualifies <c>FROM x</c> / <c>JOIN x</c> when <paramref name="x"/> is a single unqualified identifier (not already <c>a.b</c>).
    /// </summary>
    private static string QualifyFromAndJoinWithCatalogSchema(string sql, string catalog, string schema)
    {
        var cat = QuoteSqlIdentifier(catalog);
        var sch = QuoteSqlIdentifier(schema);
        var prefix = $"{cat}.{sch}.";

        sql = FromJoinQualifierRegex().Replace(
            sql,
            m => $"{m.Groups[1].Value} {prefix}{QuoteSqlIdentifier(m.Groups[2].Value)}");

        return sql;
    }

    [GeneratedRegex(@"\b(FROM|JOIN)\s+([a-zA-Z_][a-zA-Z0-9_]*)\b(?!\s*\.)", RegexOptions.IgnoreCase | RegexOptions.CultureInvariant)]
    private static partial Regex FromJoinQualifierRegex();

    [GeneratedRegex(@"^[a-zA-Z_][a-zA-Z0-9_]*$", RegexOptions.CultureInvariant)]
    private static partial Regex SimpleSqlIdentifierRegex();

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

        // Microsoft Entra / OAuth tokens must use AuthMech 11 + Auth_AccessToken (not UID/PWD), or the driver returns 401.
        var authMech = _options.AuthMechanism;
        if (_options.UseEntraTokenForOdbc)
            authMech = DatabricksOdbcAuthMechanism.MicrosoftEntraOrOAuthAccessToken;

        return DatabricksOdbcConnectionStringBuilder.Build(_options, tokenOverride, authMech);
    }
}
