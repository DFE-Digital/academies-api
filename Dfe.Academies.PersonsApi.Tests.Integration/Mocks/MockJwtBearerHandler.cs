using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System.Security.Claims;
using System.Text.Encodings.Web;

namespace Dfe.Academies.PersonsApi.Tests.Integration.Mocks
{
    public class MockJwtBearerHandler : AuthenticationHandler<AuthenticationSchemeOptions>
    {
        private readonly IEnumerable<Claim> _claims;

        public MockJwtBearerHandler(
            IOptionsMonitor<AuthenticationSchemeOptions> options,
            ILoggerFactory logger,
            UrlEncoder encoder,
            ISystemClock clock,
            IEnumerable<Claim> claims)
            : base(options, logger, encoder, clock)
        {
            _claims = claims;
        }

        protected override Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            var identity = new ClaimsIdentity(_claims, "mock");
            var principal = new ClaimsPrincipal(identity);
            var ticket = new AuthenticationTicket(principal, "mock");

            return Task.FromResult(AuthenticateResult.Success(ticket));
        }
    }
}
