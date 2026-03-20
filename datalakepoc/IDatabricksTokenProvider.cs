namespace Dfe.Academies.DataLakePoc;

/// <summary>
/// Provides a Bearer token for Databricks API requests (e.g. from Azure AD for service principal auth).
/// </summary>
public interface IDatabricksTokenProvider
{
    /// <summary>
    /// Returns a valid access token for the Databricks workspace.
    /// Implementations should cache and refresh tokens as needed.
    /// </summary>
    Task<string> GetAccessTokenAsync(CancellationToken cancellationToken = default);
}
