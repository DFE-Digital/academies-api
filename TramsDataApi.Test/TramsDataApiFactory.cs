using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using TramsDataApi.DatabaseModels;

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