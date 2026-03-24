using Dfe.Academies.DataLakePoc.Models;

namespace Dfe.Academies.Application.DataLakePoc;

/// <summary>
/// Application-layer service for running SQL against the Databricks data lake using either the
/// Statement Execution REST API (<see cref="Dfe.Academies.DataLakePoc.DatabricksSqlQueryClient"/>)
/// or ODBC (<see cref="Dfe.Academies.DataLakePoc.DatabricksOdbcQueryClient"/>), per <see cref="DataLakeQueryOptions"/>.
/// </summary>
public interface IDataLakeQueryService
{
    /// <summary>
    /// Executes SQL and returns a tabular result.
    /// When transport is the Statement Execution API, optional <paramref name="catalog"/> and <paramref name="schema"/>
    /// are sent to Databricks with the statement. When transport is ODBC, those parameters are ignored: use fully
    /// qualified identifiers in <paramref name="sql"/> (e.g. <c>my_catalog.my_schema.my_table</c>).
    /// <paramref name="waitTimeout"/> is ignored for ODBC (use connection/command timeouts on <c>DatabricksOdbc</c> options).
    /// </summary>
    Task<DatabricksQueryResult> ExecuteSqlAsync(
        string sql,
        string? catalog = null,
        string? schema = null,
        string? waitTimeout = null,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Submits a statement and returns the raw Databricks API response (async execution, custom disposition, etc.).
    /// Not supported when data lake transport is ODBC.
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
    /// Not supported when data lake transport is ODBC.
    /// </summary>
    Task<DatabricksStatementResponse> GetStatementAsync(
        string statementId,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Cancels a running statement.
    /// Not supported when data lake transport is ODBC.
    /// </summary>
    Task CancelStatementAsync(string statementId, CancellationToken cancellationToken = default);
}
