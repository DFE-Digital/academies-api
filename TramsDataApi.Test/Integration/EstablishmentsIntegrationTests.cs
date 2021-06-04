using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using FizzWare.NBuilder;
using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using TramsDataApi.DatabaseModels;
using TramsDataApi.Factories;
using TramsDataApi.ResponseModels;
using TramsDataApi.Test.Utils;
using Xunit;

namespace TramsDataApi.Test.Integration
{
    [Collection("Database")]
    public class EstablishmentsIntegrationTests : IClassFixture<TramsDataApiFactory>, IDisposable
    {
        private readonly HttpClient _client;
        private readonly LegacyTramsDbContext _legacyDbContext;
        private readonly RandomGenerator _randomGenerator;

        public EstablishmentsIntegrationTests(TramsDataApiFactory fixture)
        {
            _client = fixture.CreateClient();
            _client.DefaultRequestHeaders.Add("ApiKey", "testing-api-key");
            _legacyDbContext = fixture.Services.GetRequiredService<LegacyTramsDbContext>();
            _randomGenerator = new RandomGenerator();
        }

        [Fact]
        public async Task CanGetEstablishmentByUkprn()
        {
            var urn = _randomGenerator.Next(100000, 199999);
            var expected = AddTestData(urn);

            var response = await _client.GetAsync("/establishment/mockukprn");
            var jsonString = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<EstablishmentResponse>(jsonString);
            
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            result.Should().BeEquivalentTo(expected);
        }

        [Fact]
        public async Task CanGetEstablishmentByUrn()
        {
            var urn = _randomGenerator.Next(100000, 199999);
            var expected = AddTestData(urn);

            var response = await _client.GetAsync($"/establishment/urn/{urn}");
            var jsonString = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<EstablishmentResponse>(jsonString);

            response.StatusCode.Should().Be(HttpStatusCode.OK);
            result.Should().BeEquivalentTo(expected);
        }

        private EstablishmentResponse AddTestData(int urn)
        {
            var establishment = Builder<Establishment>.CreateNew()
                .With(e => e.Ukprn = "mockukprn")
                .With(e => e.Urn = urn)
                .Build();
            var misEstablishment = Builder<MisEstablishments>.CreateNew().With(m => m.Urn = establishment.Urn).Build();
            var smartData = Generators.GenerateSmartData(establishment.Urn);

            _legacyDbContext.Establishment.Add(establishment);
            _legacyDbContext.MisEstablishments.Add(misEstablishment);
            _legacyDbContext.SmartData.Add(smartData);
            _legacyDbContext.SaveChanges();

            return EstablishmentResponseFactory.Create(establishment, misEstablishment, smartData);
        }

        public void Dispose()
        {
            _legacyDbContext.Establishment.RemoveRange(_legacyDbContext.Establishment);
            _legacyDbContext.MisEstablishments.RemoveRange(_legacyDbContext.MisEstablishments);
            _legacyDbContext.SmartData.RemoveRange(_legacyDbContext.SmartData);
            _legacyDbContext.SaveChanges();
        }
    }
}