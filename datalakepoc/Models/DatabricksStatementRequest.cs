using System.Text.Json.Serialization;

namespace Dfe.Academies.DataLakePoc.Models;

/// <summary>
/// Request body for Databricks SQL Statement Execution API (POST /api/2.0/sql/statements).
/// </summary>
public class DatabricksStatementRequest
{
    [JsonPropertyName("statement")]
    public required string Statement { get; init; }

    [JsonPropertyName("warehouse_id")]
    public required string WarehouseId { get; init; }

    [JsonPropertyName("wait_timeout")]
    public string WaitTimeout { get; init; } = "10s";

    [JsonPropertyName("on_wait_timeout")]
    public string OnWaitTimeout { get; init; } = "CONTINUE";

    [JsonPropertyName("disposition")]
    public string Disposition { get; init; } = "INLINE";

    [JsonPropertyName("format")]
    public string Format { get; init; } = "JSON_ARRAY";

    [JsonPropertyName("catalog")]
    public string? Catalog { get; init; }

    [JsonPropertyName("schema")]
    public string? Schema { get; init; }

    [JsonPropertyName("row_limit")]
    public long? RowLimit { get; init; }

    [JsonPropertyName("byte_limit")]
    public long? ByteLimit { get; init; }

    [JsonPropertyName("parameters")]
    public List<DatabricksStatementParameter>? Parameters { get; init; }
}

public class DatabricksStatementParameter
{
    [JsonPropertyName("name")]
    public required string Name { get; init; }

    [JsonPropertyName("value")]
    public string? Value { get; init; }

    [JsonPropertyName("type")]
    public string? Type { get; init; }
}
