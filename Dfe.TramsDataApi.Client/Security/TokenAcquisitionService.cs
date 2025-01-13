using System.Diagnostics.CodeAnalysis;
using Dfe.TramsDataApi.Client.Settings;
using Microsoft.Identity.Client;

namespace Dfe.TramsDataApi.Client.Security
{
    [ExcludeFromCodeCoverage]
    public class TokenAcquisitionService : ITokenAcquisitionService
    {
        private readonly TramsDataApiClientSettings _settings;
        private readonly Lazy<IConfidentialClientApplication> _app;

        public TokenAcquisitionService(TramsDataApiClientSettings settings)
        {
            _settings = settings ?? throw new ArgumentNullException(nameof(settings));

            _app = new Lazy<IConfidentialClientApplication>(() =>
                ConfidentialClientApplicationBuilder.Create(_settings.ClientId)
                    .WithClientSecret(_settings.ClientSecret)
                    .WithAuthority(new Uri(_settings.Authority!))
                    .Build());
        }

        public async Task<string> GetTokenAsync()
        {
            var authResult = await _app.Value.AcquireTokenForClient(new[] { _settings.Scope })
                .ExecuteAsync();

            return authResult.AccessToken;
        }
    }
}