namespace TramsDataApi.RequestModels;

/// <summary>
/// Request body for executing SQL against the Databricks data lake (POC).
/// </summary>
public class DataLakeSqlQueryRequest
{
    /// <summary>
    /// SQL statement to execute (small result sets recommended; inline disposition).
    /// </summary>
    public string Sql { get; set; } = string.Empty;

    /// <summary>
    /// Optional catalog for the Statement Execution API only. Ignored when <c>DataLakeQuery:Transport</c> is <c>Odbc</c>;
    /// for ODBC, include the catalog in <see cref="Sql"/> (three-part names).
    /// </summary>
    public string Catalog { get; set; }

    /// <summary>
    /// Optional schema for the Statement Execution API only. Ignored when transport is ODBC; for ODBC, include the
    /// schema in <see cref="Sql"/>.
    /// </summary>
    public string Schema { get; set; }

    /// <summary>
    /// Optional wait timeout for the statement API (e.g. "10s").
    /// </summary>
    public string WaitTimeout { get; set; }
}
