using System.Collections.Generic;
using Dfe.Academies.Academisation.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.Configuration;

namespace TramsDataApi.Test
{
    public class TramsDataApiFactory : WebApplicationFactory<Startup>
    {
        private readonly DbFixture _dbFixture;
        
        public TramsDataApiFactory(DbFixture dbFixture) => _dbFixture = dbFixture;
        
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.UseEnvironment("Test");
            builder.ConfigureAppConfiguration((context, config) =>
            {
                config.AddInMemoryCollection(new[]
                {
                    new KeyValuePair<string, string>(
                        "ConnectionStrings:DefaultConnection", _dbFixture.ConnString),
                    new KeyValuePair<string, string>(
                        "ApiKeys:0", "{\"userName\": \"Test User\", \"apiKey\": \"testing-api-key\"}"
                        ),
                });
            });
        }
    }
}