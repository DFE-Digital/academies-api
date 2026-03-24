namespace Dfe.Academies.Application.DataLakePoc;

public class DataLakeQueryOptions
{
    public const string SectionName = "DataLakeQuery";

    /// <summary>
    /// Which client <see cref="DataLakeQueryService"/> uses for <see cref="IDataLakeQueryService.ExecuteSqlAsync"/>.
    /// Default is REST Statement API; set to <see cref="DataLakeQueryTransport.Odbc"/> when
    /// <see cref="Dfe.Academies.DataLakePoc.DatabricksOdbcQueryClient"/> is registered.
    /// </summary>
    public DataLakeQueryTransport Transport { get; set; } = DataLakeQueryTransport.StatementApi;
}

/// <summary>
/// Data lake SQL execution backends for <see cref="IDataLakeQueryService"/>.
/// </summary>
public enum DataLakeQueryTransport
{
    /// <summary>
    /// Databricks SQL Statement Execution HTTP API (<see cref="Dfe.Academies.DataLakePoc.DatabricksSqlQueryClient"/>).
    /// </summary>
    StatementApi = 0,

    /// <summary>
    /// Databricks ODBC driver (<see cref="Dfe.Academies.DataLakePoc.DatabricksOdbcQueryClient"/>).
    /// </summary>
    Odbc = 1
}
