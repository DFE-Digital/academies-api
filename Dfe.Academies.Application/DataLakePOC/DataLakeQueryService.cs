using Dfe.Academies.DataLakePoc;
using Dfe.Academies.DataLakePoc.Models;
using Microsoft.Extensions.Options;

namespace Dfe.Academies.Application.DataLakePoc;

/// <inheritdoc />
public class DataLakeQueryService : IDataLakeQueryService
{
    private readonly DatabricksSqlQueryClient _sqlClient;
    private readonly DatabricksOdbcQueryClient? _odbcClient;
    private readonly DataLakeQueryOptions _options;

    public DataLakeQueryService(
        DatabricksSqlQueryClient databricksSqlClient,
        IOptions<DataLakeQueryOptions> queryOptions,
        DatabricksOdbcQueryClient? odbcClient = null)
    {
        _sqlClient = databricksSqlClient ?? throw new ArgumentNullException(nameof(databricksSqlClient));
        _options = queryOptions?.Value ?? throw new ArgumentNullException(nameof(queryOptions));
        _odbcClient = odbcClient;
    }

    /// <inheritdoc />
    public async Task<DatabricksQueryResult> ExecuteSqlAsync(
        string sql,
        string? catalog = null,
        string? schema = null,
        string? waitTimeout = null,
        CancellationToken cancellationToken = default)
    {
        if (_options.Transport == DataLakeQueryTransport.Odbc)
        {
            EnsureOdbcClient();
            // SQL Warehouse ODBC does not reliably honor USE CATALOG/USE SCHEMA for the following statement.
            // Callers must use three-part names in SQL (catalog.schema.object). Catalog/Schema on this method apply
            // only to the Statement Execution API path below.
            // waitTimeout applies to Statement API only; ODBC uses connection/command timeouts on DatabricksOdbcOptions.
            return await _odbcClient!.ExecuteQueryAsync(sql, cancellationToken).ConfigureAwait(false);
        }

        return await _sqlClient
            .ExecuteQueryAsync(sql, catalog, schema, waitTimeout, cancellationToken)
            .ConfigureAwait(false);
    }

    /// <inheritdoc />
    /// <exception cref="NotSupportedException">When <see cref="DataLakeQueryOptions.Transport"/> is <see cref="DataLakeQueryTransport.Odbc"/>.</exception>
    public Task<DatabricksStatementResponse> ExecuteStatementAsync(
        string sql,
        string? catalog = null,
        string? schema = null,
        string waitTimeout = "10s",
        string disposition = "INLINE",
        List<DatabricksStatementParameter>? parameters = null,
        CancellationToken cancellationToken = default)
    {
        ThrowIfOdbc(nameof(ExecuteStatementAsync));
        return _sqlClient.ExecuteStatementAsync(
            sql, catalog, schema, waitTimeout, disposition, parameters, cancellationToken);
    }

    /// <inheritdoc />
    /// <exception cref="NotSupportedException">When <see cref="DataLakeQueryOptions.Transport"/> is <see cref="DataLakeQueryTransport.Odbc"/>.</exception>
    public Task<DatabricksStatementResponse> GetStatementAsync(
        string statementId,
        CancellationToken cancellationToken = default)
    {
        ThrowIfOdbc(nameof(GetStatementAsync));
        return _sqlClient.GetStatementAsync(statementId, cancellationToken);
    }

    /// <inheritdoc />
    /// <exception cref="NotSupportedException">When <see cref="DataLakeQueryOptions.Transport"/> is <see cref="DataLakeQueryTransport.Odbc"/>.</exception>
    public Task CancelStatementAsync(string statementId, CancellationToken cancellationToken = default)
    {
        ThrowIfOdbc(nameof(CancelStatementAsync));
        return _sqlClient.CancelStatementAsync(statementId, cancellationToken);
    }

    private void EnsureOdbcClient()
    {
        if (_odbcClient == null)
        {
            throw new InvalidOperationException(
                "DataLakeQuery.Transport is Odbc but DatabricksOdbcQueryClient is not registered. " +
                "Call AddDatabricksOdbcQueryClient in the host (e.g. Startup) and install the Databricks ODBC driver.");
        }
    }

    private void ThrowIfOdbc(string operation)
    {
        if (_options.Transport == DataLakeQueryTransport.Odbc)
        {
            throw new NotSupportedException(
                $"{operation} is only available when DataLakeQuery.Transport is StatementApi. " +
                "The ODBC driver does not expose Databricks Statement Execution API semantics.");
        }
    }

}
