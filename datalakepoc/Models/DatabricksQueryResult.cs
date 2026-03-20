namespace Dfe.Academies.DataLakePoc.Models;

/// <summary>
/// Simplified query result with column names and rows for consumption by callers.
/// </summary>
public class DatabricksQueryResult
{
    public IReadOnlyList<string> ColumnNames { get; init; } = [];
    public IReadOnlyList<IReadOnlyList<object?>> Rows { get; init; } = [];
    public bool Truncated { get; init; }
}
