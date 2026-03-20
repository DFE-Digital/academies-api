namespace Dfe.Academies.DataLakePoc;

/// <summary>
/// Configuration for connecting to a Databricks SQL warehouse.
/// </summary>
public class DatabricksSqlOptions
{
    public const string SectionName = "DatabricksSql";

    /// <summary>
    /// Databricks workspace URL (e.g. https://adb-xxxx.azuredatabricks.net).
    /// </summary>
    public string WorkspaceUrl { get; set; } = string.Empty;

    /// <summary>
    /// SQL warehouse (endpoint) ID to execute statements against.
    /// </summary>
    public string WarehouseId { get; set; } = string.Empty;

    /// <summary>
    /// Bearer token for authentication (e.g. personal access token or OAuth token).
    /// Used when not using service principal (Azure AD) authentication.
    /// </summary>
    public string AccessToken { get; set; } = string.Empty;

    /// <summary>
    /// Default wait timeout for synchronous execution (e.g. "10s"). Use "0s" for async only.
    /// </summary>
    public string DefaultWaitTimeout { get; set; } = "10s";

    // ----- Service principal (Azure AD) authentication -----
    // When set, the client uses Azure AD client credentials instead of AccessToken.

    /// <summary>
    /// Azure AD tenant (directory) ID. Required for service principal authentication.
    /// </summary>
    public string AzureAdTenantId { get; set; } = string.Empty;

    /// <summary>
    /// Azure AD app (client) ID. Required for service principal authentication.
    /// </summary>
    public string AzureAdClientId { get; set; } = string.Empty;

    /// <summary>
    /// Azure AD client secret for the service principal. Required for service principal authentication.
    /// </summary>
    public string AzureAdClientSecret { get; set; } = string.Empty;

    /// <summary>
    /// True when service principal auth is configured (all of TenantId, ClientId, ClientSecret are set).
    /// </summary>
    internal bool UseServicePrincipal =>
        !string.IsNullOrWhiteSpace(AzureAdTenantId)
        && !string.IsNullOrWhiteSpace(AzureAdClientId)
        && !string.IsNullOrWhiteSpace(AzureAdClientSecret);
}
