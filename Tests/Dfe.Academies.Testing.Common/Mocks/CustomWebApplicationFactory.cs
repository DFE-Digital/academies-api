using Dfe.Academies.PersonsApi.Tests.Integration.Mocks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using System.Net.Http.Headers;
using System.Security.Claims;

namespace Dfe.Academies.Testing.Common.Mocks
{
    public class CustomWebApplicationFactory<TProgram>(List<Claim> testClaims) : WebApplicationFactory<TProgram>
        where TProgram : class
    {

        public List<Claim> TestClaims { get; set; } = testClaims ?? new List<Claim>();

        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.ConfigureServices(services =>
            {
                services.PostConfigure<AuthenticationOptions>(options =>
                {
                    options.DefaultAuthenticateScheme = "TestScheme";
                    options.DefaultChallengeScheme = "TestScheme";
                });

                services.AddAuthentication("TestScheme")
                    .AddScheme<AuthenticationSchemeOptions, MockJwtBearerHandler>("TestScheme", options => { });

                services.AddSingleton<IEnumerable<Claim>>(sp => TestClaims);
            });

            builder.UseEnvironment("Development");
        }

        protected override void ConfigureClient(HttpClient client)
        {
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", "mock-token");

            base.ConfigureClient(client);
        }
    }
}
