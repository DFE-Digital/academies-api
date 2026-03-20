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
    /// Optional default catalog (USE CATALOG).
    /// </summary>
    public string Catalog { get; set; }

    /// <summary>
    /// Optional default schema (USE SCHEMA).
    /// </summary>
    public string Schema { get; set; }

    /// <summary>
    /// Optional wait timeout for the statement API (e.g. "10s").
    /// </summary>
    public string WaitTimeout { get; set; }
}
