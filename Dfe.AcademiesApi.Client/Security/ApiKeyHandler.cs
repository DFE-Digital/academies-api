using Dfe.AcademiesApi.Client.Settings;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http.Headers;

namespace Dfe.AcademiesApi.Client.Security
{
    [ExcludeFromCodeCoverage]
    public class ApiKeyHandler(AcademiesApiClientSettings apiClientSettings) : DelegatingHandler
    {
        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            if (!string.IsNullOrEmpty(apiClientSettings.ApiKey))
            {
                request.Headers.TryAddWithoutValidation("ApiKey", apiClientSettings.ApiKey);
            }

            return await base.SendAsync(request, cancellationToken);
        }
    }
}