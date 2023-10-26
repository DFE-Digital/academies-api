using Dfe.Academies.Contracts.Tests.Middleware;
using Dfe.Academies.Contracts.Tests.XUnitHelpers;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.AspNetCore.Mvc.ApplicationParts;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PactNet;
using PactNet.Infrastructure.Outputters;
using PactNet.Verifier;
using TramsDataApi.Controllers.V4;
using Xunit.Abstractions;

namespace Dfe.Academies.Contracts.Tests.Tests
{
    public class ProviderApiTest
    {
        private readonly ITestOutputHelper _output;
        private static readonly Uri ProviderUri = new("http://localhost:9332");
        private readonly PactVerifierConfig _config;
        public ProviderApiTest(ITestOutputHelper output)
        {
            _output = output;
            _config = new PactVerifierConfig
            {
                LogLevel = PactLogLevel.Debug,
                Outputters = new List<IOutput>
                {
                    new XUnitOutput(_output)
                },
            };

            var builder = WebApplication.CreateBuilder();

            builder.Services.AddControllers()
                .PartManager
                .ApplicationParts.Add(new AssemblyPart(typeof(TrustsController).Assembly));

            var startup = new PactStartup(builder.Configuration);

            startup.ConfigureServices(builder.Services);

            var app = builder.Build();

            app.MapControllers();

            app.Urls.Add(ProviderUri.ToString());
            app.UseMiddleware<ProviderMiddleware>();

            var provider = app.Services.GetRequiredService<IApiVersionDescriptionProvider>();

            startup.Configure(app, app.Environment, provider);

            app.Start();
        }

        [Fact]
        public void AcademiesApi_HonoursPactsWithConversions()
        {
            // TO-DO retrieve from pact broker
            string pactPath = Path.Combine("..",
                                           "..",
                                           "..",
                                           "pacts",
                                           "prepare-academy-conversions-academies-api.json");

            using var pactVerifier = new PactVerifier(_config);

            pactVerifier
                .ServiceProvider("academies-api", ProviderUri)
                .WithFileSource(new FileInfo(pactPath))
                .WithSslVerificationDisabled()
                .Verify();
        }
    }
}