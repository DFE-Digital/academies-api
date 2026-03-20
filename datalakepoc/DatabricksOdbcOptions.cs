namespace Dfe.Academies.DataLakePoc;

/// <summary>
/// Configuration for connecting to Databricks SQL via the Databricks (Simba) ODBC driver.
/// Install the driver from https://www.databricks.com/spark/odbc-drivers-download and register it on the machine.
/// </summary>
public class DatabricksOdbcOptions
{
    public const string SectionName = "DatabricksOdbc";

    /// <summary>
    /// ODBC driver name as registered with the OS (Windows: ODBC Data Source Administrator).
    /// Default matches the typical Simba installer registration.
    /// </summary>
    public string Driver { get; set; } = "Simba Spark ODBC Driver";

    /// <summary>
    /// Databricks workspace URL (e.g. https://adb-xxxx.azuredatabricks.net) or hostname only.
    /// Used to derive <see cref="Host"/> when <see cref="Host"/> is empty.
    /// </summary>
    public string WorkspaceUrl { get; set; } = string.Empty;

    /// <summary>
    /// Server hostname (e.g. adb-xxxx.azuredatabricks.net). If empty, derived from <see cref="WorkspaceUrl"/>.
    /// </summary>
    public string Host { get; set; } = string.Empty;

    /// <summary>
    /// TCP port (HTTPS). Default 443.
    /// </summary>
    public int Port { get; set; } = 443;

    /// <summary>
    /// SQL warehouse ID. When set (and <see cref="HttpPath"/> is empty), HTTP path is built as
    /// <c>/sql/1.0/warehouses/{WarehouseId}</c>.
    /// </summary>
    public string WarehouseId { get; set; } = string.Empty;

    /// <summary>
    /// Full HTTP path for the warehouse or cluster (e.g. /sql/1.0/warehouses/abc123).
    /// Overrides the path built from <see cref="WarehouseId"/> when non-empty.
    /// </summary>
    public string HttpPath { get; set; } = string.Empty;

    /// <summary>
    /// ODBC authentication mechanism. <see cref="DatabricksOdbcAuthMechanism.Token"/> (AuthMech=3) is used for PATs
    /// and for Microsoft Entra ID access tokens (including service principal) passed as <c>PWD</c> with <c>UID=token</c>.
    /// </summary>
    public DatabricksOdbcAuthMechanism AuthMechanism { get; set; } = DatabricksOdbcAuthMechanism.Token;

    /// <summary>
    /// Personal access token (dapi...) or OAuth access token for Databricks, depending on <see cref="AuthMechanism"/>.
    /// For <see cref="DatabricksOdbcAuthMechanism.Token"/>, this is the PAT used as PWD with UID "token".
    /// </summary>
    public string AccessToken { get; set; } = string.Empty;

    /// <summary>
    /// When true, the ODBC client obtains the password token from <see cref="IDatabricksTokenProvider"/>
    /// instead of <see cref="AccessToken"/>. Use with a registered <see cref="AzureAdDatabricksTokenProvider"/>
    /// (credentials on <see cref="DatabricksSqlOptions"/> or this section).
    /// </summary>
    public bool UseAzureAdTokenProvider { get; set; }

    // ----- Service principal (Microsoft Entra ID) — ODBC-only or shared with REST -----

    /// <summary>
    /// Entra ID tenant (directory) ID for client-credentials token used as ODBC password (AuthMech 3).
    /// </summary>
    public string AzureAdTenantId { get; set; } = string.Empty;

    /// <summary>
    /// Entra ID application (client) ID.
    /// </summary>
    public string AzureAdClientId { get; set; } = string.Empty;

    /// <summary>
    /// Entra ID client secret for the service principal.
    /// </summary>
    public string AzureAdClientSecret { get; set; } = string.Empty;

    /// <summary>
    /// True when all Entra ID client credential fields are set on this section (service principal auth for ODBC).
    /// When true, this library registers <see cref="IDatabricksTokenProvider"/> if not already registered,
    /// and the ODBC client will use it (same as <see cref="UseAzureAdTokenProvider"/>).
    /// </summary>
    public bool UseOdbcServicePrincipal =>
        !string.IsNullOrWhiteSpace(AzureAdTenantId)
        && !string.IsNullOrWhiteSpace(AzureAdClientId)
        && !string.IsNullOrWhiteSpace(AzureAdClientSecret);

    /// <summary>
    /// Whether ODBC should acquire an Entra token via <see cref="IDatabricksTokenProvider"/>.
    /// </summary>
    internal bool UseEntraTokenForOdbc => UseAzureAdTokenProvider || UseOdbcServicePrincipal;

    /// <summary>
    /// Optional default catalog (Spark: initial catalog).
    /// </summary>
    public string? Catalog { get; set; }

    /// <summary>
    /// Optional default schema.
    /// </summary>
    public string? Schema { get; set; }

    /// <summary>
    /// Connection timeout in seconds (Driver property ConnTimeout or similar — passed as ConnTimeout if supported).
    /// </summary>
    public int ConnectionTimeoutSeconds { get; set; } = 30;

    /// <summary>
    /// If set, this connection string is used as-is and other properties except driver-specific overrides are ignored.
    /// Use when you need AuthMech 11 (Azure) or other advanced Simba settings.
    /// </summary>
    public string? RawConnectionString { get; set; }

    /// <summary>
    /// Extra semicolon-separated key=value pairs appended to the built connection string (e.g. ConnTimeout=60).
    /// </summary>
    public string? AdditionalProperties { get; set; }
}

/// <summary>
/// Databricks ODBC driver authentication modes (Simba AuthMech).
/// </summary>
public enum DatabricksOdbcAuthMechanism
{
    /// <summary>
    /// AuthMech=3 — UID "token", PWD = personal access token or bearer token (common for PAT).
    /// </summary>
    Token = 3
}
