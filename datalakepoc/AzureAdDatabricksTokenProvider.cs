using Azure.Core;
using Azure.Identity;
using Microsoft.Extensions.Options;

namespace Dfe.Academies.DataLakePoc;

/// <summary>
/// Gets Azure AD (Microsoft Entra ID) access tokens for Azure Databricks using a service principal
/// (client credentials flow). Use when authenticating with TenantId + ClientId + ClientSecret.
/// </summary>
/// <remarks>
/// The service principal must have access to the Databricks workspace (e.g. added via the
/// Databricks Service Principals API or granted the Contributor/Owner role on the workspace).
/// Ensure the app registration has the Azure Databricks API permission (e.g. user_impersonation).
/// Tokens are used as bearer tokens for the REST API and as the ODBC password (AuthMech 3, UID token)
/// for the Simba driver.
/// </remarks>
public class AzureAdDatabricksTokenProvider : IDatabricksTokenProvider
{
    /// <summary>
    /// Azure Databricks resource ID used as the token scope/audience (all Azure clouds).
    /// </summary>
    public const string DatabricksResourceScope = "2ff814a6-3304-4ab8-85cb-cd0e6f879c1d/.default";

    private static readonly TokenRequestContext s_requestContext = new([DatabricksResourceScope]);

    private readonly ClientSecretCredential _credential;

    /// <summary>
    /// Uses Entra ID credentials from <see cref="DatabricksSqlOptions"/> when <see cref="DatabricksSqlOptions.UseServicePrincipal"/>
    /// is true; otherwise from <see cref="DatabricksOdbcOptions"/> when <see cref="DatabricksOdbcOptions.UseOdbcServicePrincipal"/> is true.
    /// </summary>
    public AzureAdDatabricksTokenProvider(
        IOptions<DatabricksSqlOptions> sqlOptions,
        IOptions<DatabricksOdbcOptions> odbcOptions)
    {
        ArgumentNullException.ThrowIfNull(sqlOptions);
        ArgumentNullException.ThrowIfNull(odbcOptions);

        var sql = sqlOptions.Value;
        var odbc = odbcOptions.Value;

        string tenantId;
        string clientId;
        string clientSecret;

        if (sql.UseServicePrincipal)
        {
            tenantId = sql.AzureAdTenantId.Trim();
            clientId = sql.AzureAdClientId.Trim();
            clientSecret = sql.AzureAdClientSecret.Trim();
        }
        else if (odbc.UseOdbcServicePrincipal)
        {
            tenantId = odbc.AzureAdTenantId.Trim();
            clientId = odbc.AzureAdClientId.Trim();
            clientSecret = odbc.AzureAdClientSecret.Trim();
        }
        else
        {
            throw new InvalidOperationException(
                "Entra ID service principal credentials must be set on DatabricksSql " +
                "(AzureAdTenantId, AzureAdClientId, AzureAdClientSecret) or on DatabricksOdbc with the same properties.");
        }

        if (string.IsNullOrWhiteSpace(tenantId))
            throw new InvalidOperationException("AzureAdTenantId is required for service principal authentication.");
        if (string.IsNullOrWhiteSpace(clientId))
            throw new InvalidOperationException("AzureAdClientId is required for service principal authentication.");
        if (string.IsNullOrWhiteSpace(clientSecret))
            throw new InvalidOperationException("AzureAdClientSecret is required for service principal authentication.");

        _credential = new ClientSecretCredential(tenantId, clientId, clientSecret);
    }

    /// <summary>
    /// Uses Entra ID credentials from the <c>DatabricksSql</c> configuration section only.
    /// </summary>
    public AzureAdDatabricksTokenProvider(IOptions<DatabricksSqlOptions> options)
        : this(options, Microsoft.Extensions.Options.Options.Create(new DatabricksOdbcOptions()))
    {
    }

    public AzureAdDatabricksTokenProvider(string tenantId, string clientId, string clientSecret)
    {
        if (string.IsNullOrWhiteSpace(tenantId)) throw new ArgumentNullException(nameof(tenantId));
        if (string.IsNullOrWhiteSpace(clientId)) throw new ArgumentNullException(nameof(clientId));
        if (string.IsNullOrWhiteSpace(clientSecret)) throw new ArgumentNullException(nameof(clientSecret));

        _credential = new ClientSecretCredential(tenantId, clientId, clientSecret);
    }

    /// <inheritdoc />
    public async Task<string> GetAccessTokenAsync(CancellationToken cancellationToken = default)
    {
        var result = await _credential.GetTokenAsync(s_requestContext, cancellationToken).ConfigureAwait(false);
        return result.Token;
    }
}
