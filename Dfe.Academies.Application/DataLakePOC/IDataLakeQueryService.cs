using Dfe.Academies.DataLakePoc.Models;

namespace Dfe.Academies.Application.DataLakePoc;

/// <summary>
/// Application-layer service for running SQL against the Databricks data lake (via <see cref="Dfe.Academies.DataLakePoc.DatabricksSqlQueryClient"/>).
/// </summary>
public interface IDataLakeQueryService
{
    /// <summary>
    /// Executes SQL and returns a tabular result (suitable for small inline result sets).
    /// </summary>
    Task<DatabricksQueryResult> ExecuteSqlAsync(
        string sql,
        string? catalog = null,
        string? schema = null,
        string? waitTimeout = null,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Submits a statement and returns the raw Databricks API response (async execution, custom disposition, etc.).
    /// </summary>
    Task<DatabricksStatementResponse> ExecuteStatementAsync(
        string sql,
        string? catalog = null,
        string? schema = null,
        string waitTimeout = "10s",
        string disposition = "INLINE",
        List<DatabricksStatementParameter>? parameters = null,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Polls statement status and first result chunk by statement id.
    /// </summary>
    Task<DatabricksStatementResponse> GetStatementAsync(
        string statementId,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Cancels a running statement.
    /// </summary>
    Task CancelStatementAsync(string statementId, CancellationToken cancellationToken = default);
}
