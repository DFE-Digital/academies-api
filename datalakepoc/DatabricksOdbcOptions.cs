namespace Dfe.Academies.DataLakePoc;

/// <summary>
/// Configuration for connecting to Databricks SQL via the Databricks ODBC driver (install from Databricks ODBC download / docs).
/// The legacy ODBC registration name <c>Simba Spark ODBC Driver</c> is deprecated; use <see cref="DefaultDriverName"/> unless you must stay on the old installer.
/// </summary>
public class DatabricksOdbcOptions
{
    public const string SectionName = "DatabricksOdbc";

    /// <summary>
    /// Registered name of the current Databricks ODBC driver (Windows ODBC Administrator: &quot;Databricks ODBC Driver&quot;).
    /// Set to <c>Simba Spark ODBC Driver</c> only if you must use the legacy Simba-branded installer.
    /// </summary>
    public const string DefaultDriverName = "Databricks ODBC Driver";

    /// <summary>
    /// ODBC driver name as registered with the OS (Windows: ODBC Data Source Administrator).
    /// </summary>
    public string Driver { get; set; } = DefaultDriverName;

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
    /// ODBC authentication mechanism. Use <see cref="DatabricksOdbcAuthMechanism.Token"/> (AuthMech=3) for Databricks PATs only.
    /// For Microsoft Entra ID or OAuth access tokens (including service principal), use
    /// <see cref="DatabricksOdbcAuthMechanism.MicrosoftEntraOrOAuthAccessToken"/> (AuthMech=11, <c>Auth_AccessToken</c>) — required by the Databricks ODBC driver (using AuthMech 3 with an Entra token causes 401).
    /// When <see cref="UseEntraTokenForOdbc"/> is true, the client forces AuthMech 11 automatically.
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
    /// Entra ID tenant (directory) ID for client-credentials token (sent via AuthMech 11 / <c>Auth_AccessToken</c> when using the token provider).
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
    /// When both catalog and schema are supplied to <see cref="DatabricksOdbcQueryClient.ExecuteQueryAsync(string, string?, string?, CancellationToken)"/>,
    /// rewrite simple unqualified <c>FROM</c>/<c>JOIN</c> table names to <c>catalog.schema.table</c> instead of relying on <c>USE</c>.
    /// SQL Warehouse ODBC often does not keep session context from <c>USE</c> for the following query (leading to <c>..table</c> resolution errors).
    /// Disable if you always pass fully qualified names and want to skip regex-based rewriting.
    /// </summary>
    public bool AutoQualifyCatalogSchemaInSql { get; set; } = true;

    /// <summary>
    /// Connection timeout in seconds (Driver property ConnTimeout or similar — passed as ConnTimeout if supported).
    /// </summary>
    public int ConnectionTimeoutSeconds { get; set; } = 30;

    /// <summary>
    /// If set, this connection string is used as-is and other properties except driver-specific overrides are ignored.
    /// Use when you need AuthMech 11 (Azure) or other advanced driver-specific settings.
    /// </summary>
    public string? RawConnectionString { get; set; }

    /// <summary>
    /// Extra semicolon-separated key=value pairs appended to the built connection string (e.g. ConnTimeout=60).
    /// </summary>
    public string? AdditionalProperties { get; set; }
}

/// <summary>
/// Databricks ODBC driver authentication modes (driver <c>AuthMech</c> values; see Azure Databricks ODBC authentication docs).
/// </summary>
public enum DatabricksOdbcAuthMechanism
{
    /// <summary>
    /// AuthMech=3 — <c>UID=token</c>, <c>PWD</c> = Databricks personal access token (dapi...) only. Do not use for Microsoft Entra ID tokens.
    /// </summary>
    Token = 3,

    /// <summary>
    /// AuthMech=11, <c>Auth_Flow=0</c>, <c>Auth_AccessToken</c> = Microsoft Entra ID or OAuth access token (driver 2.6.15+).
    /// </summary>
    MicrosoftEntraOrOAuthAccessToken = 11
}
