using System.Text.Json.Serialization;

namespace Dfe.Academies.DataLakePoc.Models;

/// <summary>
/// Response from Databricks SQL Statement Execution API.
/// </summary>
public class DatabricksStatementResponse
{
    [JsonPropertyName("statement_id")]
    public string? StatementId { get; init; }

    [JsonPropertyName("status")]
    public DatabricksStatementStatus? Status { get; init; }

    [JsonPropertyName("manifest")]
    public DatabricksResultManifest? Manifest { get; init; }

    [JsonPropertyName("result")]
    public DatabricksResultData? Result { get; init; }

    [JsonPropertyName("truncated")]
    public bool Truncated { get; init; }
}

public class DatabricksStatementStatus
{
    [JsonPropertyName("state")]
    public string? State { get; init; }

    [JsonPropertyName("error")]
    public DatabricksStatementError? Error { get; init; }
}

public class DatabricksStatementError
{
    [JsonPropertyName("error_code")]
    public string? ErrorCode { get; init; }

    [JsonPropertyName("message")]
    public string? Message { get; init; }
}

public class DatabricksResultManifest
{
    [JsonPropertyName("schema")]
    public DatabricksResultSchema? Schema { get; init; }

    [JsonPropertyName("total_chunk_count")]
    public int TotalChunkCount { get; init; }
}

public class DatabricksResultSchema
{
    [JsonPropertyName("columns")]
    public List<DatabricksColumnInfo>? Columns { get; init; }
}

public class DatabricksColumnInfo
{
    [JsonPropertyName("name")]
    public string? Name { get; init; }

    [JsonPropertyName("type_name")]
    public string? TypeName { get; init; }

    [JsonPropertyName("position")]
    public int Position { get; init; }
}

public class DatabricksResultData
{
    /// <summary>
    /// Inline result rows when disposition is INLINE. Each element is a row (array of column values as strings or null).
    /// </summary>
    [JsonPropertyName("data_array")]
    public List<List<object?>>? DataArray { get; init; }

    [JsonPropertyName("next_chunk_index")]
    public long? NextChunkIndex { get; init; }

    [JsonPropertyName("next_chunk_internal_link")]
    public string? NextChunkInternalLink { get; init; }
}
