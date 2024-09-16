using Dfe.Academies.PersonsApi.Tests.Integration.Mocks;
using Dfe.Academies.Testing.Common.Helpers;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Data.Common;
using System.Net.Http.Headers;
using System.Security.Claims;

namespace Dfe.Academies.Testing.Common.Mocks
{
    public class CustomWebApplicationDbContextFactory<TProgram, TDbContext> : WebApplicationFactory<TProgram>
        where TProgram : class where TDbContext : DbContext
    {
        public List<Claim> TestClaims { get; set; } = [];

        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.ConfigureServices(services =>
            {
                var dbContextDescriptor = services.SingleOrDefault(
                    d => d.ServiceType == typeof(DbContextOptions<TDbContext>));
                services.Remove(dbContextDescriptor!);

                var dbConnectionDescriptor = services.SingleOrDefault(
                    d => d.ServiceType == typeof(DbConnection));
                services.Remove(dbConnectionDescriptor!);

                DbContextHelper<TDbContext>.CreateDbContext(services);

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

        public TDbContext GetDbContext()
        {
            var scopeFactory = Services.GetRequiredService<IServiceScopeFactory>();
            var scope = scopeFactory.CreateScope();
            return scope.ServiceProvider.GetRequiredService<TDbContext>();
        }

    }
}
