using Dfe.Academies.Contracts.Tests.XUnitHelpers;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using PactNet;
using PactNet.Infrastructure.Outputters;
using PactNet.Verifier;
using Xunit.Abstractions;

namespace Dfe.Academies.Contracts.Tests.Tests
{
    public class ProviderApiTest : IDisposable
    {
        private readonly ITestOutputHelper _output;
        private static readonly Uri ProviderUri = new("http://localhost:9332");
        private readonly IHost _fixture;
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

            _fixture = Host.CreateDefaultBuilder()
                                .ConfigureWebHostDefaults(webBuilder =>
                                {
                                    webBuilder.UseUrls(ProviderUri.ToString());
                                    webBuilder.UseStartup<PactStartup>();
                                })
                                .Build();

            _fixture.Start();
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
                .Verify();
        }

        public void Dispose()
        {
            _fixture.Dispose();
        }
    }
}