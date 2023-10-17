using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TramsDataApi.Contracts.Test.Middleware;

namespace TramsDataApi.Contracts.Test
{
    public class PactStartup
    {
        private readonly Startup _startup;
        public PactStartup(IConfiguration configuration)
        {
            // Specify the app settings for the test project
            configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json").Build();

            _startup = new Startup(configuration);
        }

        public void ConfigureServices(IServiceCollection services)
        {
            _startup.ConfigureServices(services);
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IApiVersionDescriptionProvider provider)
        {
            // Add custom middleware for Pact testing
            app.UseMiddleware<ProviderMiddleware>();

            // Call the parent class's Configure method
            _startup.Configure(app, env, provider);
        }
    }
}
