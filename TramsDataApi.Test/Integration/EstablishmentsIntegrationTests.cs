using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text.Json.Serialization;
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

        [Fact]
        public async Task CanSearchEstablishmentsByUrn()
        {
            var establishments = new Establishment[10]
                .Select(i => CreateEstablishment(_randomGenerator.Next(100000, 199999)))
                .ToList();
            
            _legacyDbContext.Establishment.AddRange(establishments);
            _legacyDbContext.SaveChanges();

            var expected = EstablishmentSummaryResponseFactory.Create(establishments[0]);
            
            var response = await _client.GetAsync($"/establishments?urn={establishments[0].Urn}");
            var jsonString = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<List<EstablishmentSummaryResponse>>(jsonString);

            response.StatusCode.Should().Be(HttpStatusCode.OK);
            result.Should().BeEquivalentTo(expected);
        }

        [Fact]
        public async Task CanSearchEstablishmentsByUkprn()
        {
            var establishments = new Establishment[10]
                .Select(i => CreateEstablishment(_randomGenerator.Next(100000, 199999)))
                .ToList();
            
            _legacyDbContext.Establishment.AddRange(establishments);
            _legacyDbContext.SaveChanges();

            var expected = EstablishmentSummaryResponseFactory.Create(establishments[0]);
            
            var response = await _client.GetAsync($"/establishments?ukprn={establishments[0].Ukprn}");
            var jsonString = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<List<EstablishmentSummaryResponse>>(jsonString);

            response.StatusCode.Should().Be(HttpStatusCode.OK);
            result.Should().BeEquivalentTo(expected);
        }

        [Fact]
        public async Task CanSearchEstablishmentsByName()
        {
            var establishments = new Establishment[10]
                .Select(i => CreateEstablishment(_randomGenerator.Next(100000, 199999)))
                .ToList();
            
            _legacyDbContext.Establishment.AddRange(establishments);
            _legacyDbContext.SaveChanges();

            var expected = EstablishmentSummaryResponseFactory.Create(establishments[0]);
            
            var response = await _client.GetAsync($"/establishments?name={establishments[0].EstablishmentName}");
            var jsonString = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<List<EstablishmentSummaryResponse>>(jsonString);

            response.StatusCode.Should().Be(HttpStatusCode.OK);
            result.Should().BeEquivalentTo(expected);
        }

        [Fact]
        public async Task CanSearchEstablishmentsByPartialCaseInsensitiveName()
        {
            var establishments = new Establishment[10]
                .Select(i => CreateEstablishment(_randomGenerator.Next(100000, 199999)))
                .ToList();
    
            establishments[9].EstablishmentName = "aFaKeESTABLISHMENT";

            _legacyDbContext.Establishment.AddRange(establishments);
            _legacyDbContext.SaveChanges();

            var expected = EstablishmentSummaryResponseFactory.Create(establishments[9]);
            
            var response = await _client.GetAsync($"/establishments?name=afakeestab");
            var jsonString = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<List<EstablishmentSummaryResponse>>(jsonString);

            response.StatusCode.Should().Be(HttpStatusCode.OK);
            result.Should().BeEquivalentTo(expected);
        }

        private Establishment CreateEstablishment(int urn)
        {
            return Builder<Establishment>.CreateNew()
                .With(e => e.Ukprn = "mockukprn")
                .With(e => e.Urn = urn)
                .Build();
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