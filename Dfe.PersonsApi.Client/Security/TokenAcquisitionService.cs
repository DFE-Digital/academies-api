using Dfe.PersonsApi.Client.Settings;
using Microsoft.Identity.Client;
using System.Diagnostics.CodeAnalysis;

namespace Dfe.PersonsApi.Client.Security
{
    [ExcludeFromCodeCoverage]
    public class TokenAcquisitionService : ITokenAcquisitionService
    {
        private readonly PersonsApiClientSettings _settings;
        private readonly IConfidentialClientApplication _app;
        private AuthenticationResult? _authResult;

        public TokenAcquisitionService(PersonsApiClientSettings settings)
        {
            _settings = settings;

            _app = ConfidentialClientApplicationBuilder.Create(_settings.ClientId)
                .WithClientSecret(_settings.ClientSecret)
                .WithAuthority(new Uri(_settings.Authority!))
                .Build();
        }

        public async Task<string> GetTokenAsync()
        {
            // Check if the current token is about to expire
            if (_authResult == null || _authResult.ExpiresOn <= DateTimeOffset.UtcNow.AddMinutes(-1))
            {
                _authResult = await _app.AcquireTokenForClient(new[] { _settings.Scope })
                                        .ExecuteAsync();
            }

            return _authResult.AccessToken;
        }
    }
}
