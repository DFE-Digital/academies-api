using Dfe.Academies.Application.Queries.Trust;
using Dfe.Academies.Contracts.Tests.Middleware;
using Dfe.Academies.Contracts.Tests.Utils;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TramsDataApi;

namespace Dfe.Academies.Contracts.Tests
{
    public class PactStartup
    {
        private readonly Startup _proxy;

        public PactStartup (IConfiguration configuration)
        {
            _proxy = new Startup(configuration);
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<ITrustQueries, MockTrustQueries>();

            _proxy.ConfigureServices(services);
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IApiVersionDescriptionProvider provider)
        {
            app.UseMiddleware<ProviderMiddleware>();
            _proxy.Configure(app, env, provider);
        }
    }
}
