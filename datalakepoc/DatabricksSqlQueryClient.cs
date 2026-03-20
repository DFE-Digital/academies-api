using System.Text;
using System.Text.Json;
using Dfe.Academies.DataLakePoc.Models;
using Microsoft.Extensions.Options;

namespace Dfe.Academies.DataLakePoc;

/// <summary>
/// Client for executing SQL against Databricks SQL warehouses via the Statement Execution API.
/// </summary>
public class DatabricksSqlQueryClient
{
    private static readonly JsonSerializerOptions JsonOptions = new()
    {
        PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
        PropertyNameCaseInsensitive = true
    };

    private readonly HttpClient _httpClient;
    private readonly DatabricksSqlOptions _options;

    public DatabricksSqlQueryClient(HttpClient httpClient, IOptions<DatabricksSqlOptions> options)
    {
        _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
        _options = options?.Value ?? throw new ArgumentNullException(nameof(options));
    }

    /// <summary>
    /// Execute a SQL statement and wait for the result (synchronous mode).
    /// Returns a simplified result with column names and rows, or throws on failure.
    /// Best for small result sets (inline disposition, up to ~25 MiB).
    /// </summary>
    /// <param name="sql">The SQL statement to execute.</param>
    /// <param name="catalog">Optional default catalog (USE CATALOG).</param>
    /// <param name="schema">Optional default schema (USE SCHEMA).</param>
    /// <param name="waitTimeout">How long to wait for completion (e.g. "10s").</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>Query result with column names and rows.</returns>
    public async Task<DatabricksQueryResult> ExecuteQueryAsync(
        string sql,
        string? catalog = null,
        string? schema = null,
        string? waitTimeout = null,
        CancellationToken cancellationToken = default)
    {
        var response = await ExecuteStatementAsync(
            sql,
            catalog: catalog,
            schema: schema,
            waitTimeout: waitTimeout ?? _options.DefaultWaitTimeout,
            cancellationToken: cancellationToken).ConfigureAwait(false);

        if (response.Status?.State == "FAILED")
        {
            var msg = response.Status.Error?.Message ?? response.Status.Error?.ErrorCode ?? "Unknown error";
            throw new InvalidOperationException($"Databricks statement failed: {msg}");
        }

        if (response.Status?.State != "SUCCEEDED" && response.Status?.State != "CLOSED")
        {
            throw new InvalidOperationException(
                $"Databricks statement did not complete successfully. State: {response.Status?.State}");
        }

        var columnNames = response.Manifest?.Schema?.Columns?
            .OrderBy(c => c.Position)
            .Select(c => c.Name ?? string.Empty)
            .ToList() ?? new List<string>();

        var rows = response.Result?.DataArray ?? new List<List<object?>>();

        return new DatabricksQueryResult
        {
            ColumnNames = columnNames,
            Rows = rows,
            Truncated = response.Truncated
        };
    }

    /// <summary>
    /// Submit a SQL statement to the Databricks Statement Execution API.
    /// Use this for async execution (wait_timeout "0s") or when you need the raw response.
    /// </summary>
    /// <param name="sql">The SQL statement to execute.</param>
    /// <param name="catalog">Optional default catalog.</param>
    /// <param name="schema">Optional default schema.</param>
    /// <param name="waitTimeout">"0s" for async, or e.g. "10s" to wait for result.</param>
    /// <param name="disposition">"INLINE" (default) or "EXTERNAL_LINKS".</param>
    /// <param name="parameters">Optional named parameters for the statement.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>The API response including statement_id, status, and optionally manifest/result.</returns>
    public async Task<DatabricksStatementResponse> ExecuteStatementAsync(
        string sql,
        string? catalog = null,
        string? schema = null,
        string waitTimeout = "10s",
        string disposition = "INLINE",
        List<DatabricksStatementParameter>? parameters = null,
        CancellationToken cancellationToken = default)
    {
        var request = new DatabricksStatementRequest
        {
            Statement = sql,
            WarehouseId = _options.WarehouseId,
            WaitTimeout = waitTimeout,
            Disposition = disposition,
            Catalog = catalog,
            Schema = schema,
            Parameters = parameters
        };

        var json = JsonSerializer.Serialize(request, JsonOptions);
        var content = new StringContent(json, Encoding.UTF8, "application/json");

        var requestUri = "api/2.0/sql/statements";
        var response = await _httpClient.PostAsync(requestUri, content, cancellationToken)
            .ConfigureAwait(false);

        response.EnsureSuccessStatusCode();

        var responseJson = await response.Content.ReadAsStringAsync(cancellationToken)
            .ConfigureAwait(false);
        var result = JsonSerializer.Deserialize<DatabricksStatementResponse>(responseJson, JsonOptions)
            ?? throw new InvalidOperationException("Failed to deserialize Databricks API response.");

        return result;
    }

    /// <summary>
    /// Get the status and optionally the first result chunk for a statement (polling).
    /// </summary>
    /// <param name="statementId">Statement ID returned from ExecuteStatementAsync.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>Current status and result data if available.</returns>
    public async Task<DatabricksStatementResponse> GetStatementAsync(
        string statementId,
        CancellationToken cancellationToken = default)
    {
        var requestUri = $"api/2.0/sql/statements/{statementId}";
        var response = await _httpClient.GetAsync(requestUri, cancellationToken)
            .ConfigureAwait(false);
        response.EnsureSuccessStatusCode();

        var responseJson = await response.Content.ReadAsStringAsync(cancellationToken)
            .ConfigureAwait(false);
        var result = JsonSerializer.Deserialize<DatabricksStatementResponse>(responseJson, JsonOptions)
            ?? throw new InvalidOperationException("Failed to deserialize Databricks API response.");
        return result;
    }

    /// <summary>
    /// Cancel a running statement execution.
    /// </summary>
    public async Task CancelStatementAsync(string statementId, CancellationToken cancellationToken = default)
    {
        var requestUri = $"api/2.0/sql/statements/{statementId}/cancel";
        var response = await _httpClient.PostAsync(requestUri, null, cancellationToken)
            .ConfigureAwait(false);
        response.EnsureSuccessStatusCode();
    }
}
