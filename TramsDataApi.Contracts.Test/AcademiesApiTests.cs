using PactNet.Infrastructure.Outputters;
using PactNet.Verifier;
using TramsDataApi.DatabaseModels;
using Xunit.Abstractions;

namespace TramsDataApi.Contracts.Test
{
    public class AcademiesApiTests : IClassFixture<AcademiesApiFixture>
    {
        private readonly AcademiesApiFixture _fixture;
        private readonly ITestOutputHelper _output;

        public AcademiesApiTests(AcademiesApiFixture fixture, ITestOutputHelper testOutputHelper)
        {
            _fixture = fixture;
            _output = testOutputHelper;
        }

        [Fact]
        public void AcademiesApi_HonoursPactsWithConversions()
        {
            var config = new PactVerifierConfig
            {
                Outputters = new List<IOutput>
                {
                    new XUnitOutput(_output),
                },
            };

            // TO-DO retrieve from pact broker
            string pactPath = Path.Combine("..",
                                           "..",
                                           "..",
                                           "pacts",
                                           "prepare-academy-conversions-academies-api.json");

            using var pactVerifier = new PactVerifier(config);

            pactVerifier
                .ServiceProvider("academies-api", _fixture.ServerUri)
                .WithFileSource(new FileInfo(pactPath))
                .Verify();
        }
    }
}