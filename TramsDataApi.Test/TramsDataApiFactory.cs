using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TramsDataApi.ApplyToBecome;
using TramsDataApi.Test.ApplyToBecome;

namespace TramsDataApi.Test
{
    public class TramsDataApiFactory : WebApplicationFactory<TramsDataApi.Startup>
    {
        private readonly DbFixture _dbFixture;
        
        public TramsDataApiFactory(DbFixture dbFixture)
            => _dbFixture = dbFixture;

        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.UseEnvironment("Test");
            builder.ConfigureTestServices(services =>
            {
                var syncAcpService = services.Single(sd => sd.ImplementationType == typeof(SyncAcademyConversionProjectsService));
                services.Remove(syncAcpService);
                services.AddDbContext<ApplyToBecomeDbContextMock>();
            });
            builder.ConfigureAppConfiguration((context, config) =>
            {
                config.AddInMemoryCollection(new[]
                {
                    new KeyValuePair<string, string>(
                        "ConnectionStrings:DefaultConnection", _dbFixture.ConnString),
                    new KeyValuePair<string, string>("ApiKey", "testing-api-key")
                });
            });
        }
    }
}