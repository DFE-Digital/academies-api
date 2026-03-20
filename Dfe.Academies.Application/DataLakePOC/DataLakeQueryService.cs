using Dfe.Academies.DataLakePoc;
using Dfe.Academies.DataLakePoc.Models;

namespace Dfe.Academies.Application.DataLakePoc;

/// <inheritdoc />
public class DataLakeQueryService : IDataLakeQueryService
{
    private readonly DatabricksSqlQueryClient _databricksClient;

    public DataLakeQueryService(DatabricksSqlQueryClient databricksClient)
    {
        _databricksClient = databricksClient ?? throw new ArgumentNullException(nameof(databricksClient));
    }

    /// <inheritdoc />
    public Task<DatabricksQueryResult> ExecuteSqlAsync(
        string sql,
        string? catalog = null,
        string? schema = null,
        string? waitTimeout = null,
        CancellationToken cancellationToken = default) =>
        _databricksClient.ExecuteQueryAsync(sql, catalog, schema, waitTimeout, cancellationToken);

    /// <inheritdoc />
    public Task<DatabricksStatementResponse> ExecuteStatementAsync(
        string sql,
        string? catalog = null,
        string? schema = null,
        string waitTimeout = "10s",
        string disposition = "INLINE",
        List<DatabricksStatementParameter>? parameters = null,
        CancellationToken cancellationToken = default) =>
        _databricksClient.ExecuteStatementAsync(
            sql, catalog, schema, waitTimeout, disposition, parameters, cancellationToken);

    /// <inheritdoc />
    public Task<DatabricksStatementResponse> GetStatementAsync(
        string statementId,
        CancellationToken cancellationToken = default) =>
        _databricksClient.GetStatementAsync(statementId, cancellationToken);

    /// <inheritdoc />
    public Task CancelStatementAsync(string statementId, CancellationToken cancellationToken = default) =>
        _databricksClient.CancelStatementAsync(statementId, cancellationToken);
}
