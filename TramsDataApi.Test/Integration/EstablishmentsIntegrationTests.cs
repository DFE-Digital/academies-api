using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using FizzWare.NBuilder;
using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using TramsDataApi.DatabaseModels;
using TramsDataApi.Factories;
using TramsDataApi.Gateways;
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
        private ICensusDataGateway _censusDataGateway;

        public EstablishmentsIntegrationTests(TramsDataApiFactory fixture)
        {
            _client = fixture.CreateClient();
            _client.DefaultRequestHeaders.Add("ApiKey", "testing-api-key");
            _legacyDbContext = fixture.Services.GetRequiredService<LegacyTramsDbContext>();
            _randomGenerator = new RandomGenerator();
            _censusDataGateway = new CensusDataGateway();
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
        public async Task CanGetEstablishmentsByBulkUrns()
        {
            const int urn1 = 12345;
            const int urn2 = 23456;
            var response1 = AddTestData(urn1);
            var response2 = AddTestData(urn2);
            var establishmentResponses = new List<EstablishmentResponse> { response1, response2 };

            var response = await _client.GetAsync($"/establishments/bulk?Urn={urn1}&Urn={urn2}");
            var jsonString = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<IList<EstablishmentResponse>>(jsonString);

            response.StatusCode.Should().Be(HttpStatusCode.OK);
            result.Should().BeEquivalentTo(establishmentResponses);
        }

        [Fact]
        public async Task CanGetEstablishmentURNsByRegion()
        {
            var urn = _randomGenerator.Next(100000, 199999);
            var expected = AddTestData(urn, "East");

            var response = await _client.GetAsync("/establishment/regions?regions=East");
            var jsonString = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<IEnumerable<int>>(jsonString);

            response.StatusCode.Should().Be(HttpStatusCode.OK);
            result.FirstOrDefault().ToString().Should().Be(expected.Urn);
        }

        [Fact]
        public async Task CanSearchEstablishmentsByUrn()
        {
            var establishments = Builder<Establishment>
                .CreateListOfSize(10)
                .All()
                .With(e => e.Urn = _randomGenerator.Next(100000, 199999))
                .Build();

            _legacyDbContext.Establishment.AddRange(establishments);
            _legacyDbContext.SaveChanges();

            var expected = new List<EstablishmentSummaryResponse>
            {
                EstablishmentSummaryResponseFactory.Create(establishments[0])
            };

            var response = await _client.GetAsync($"/establishments?urn={establishments[0].Urn}");
            var jsonString = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<List<EstablishmentSummaryResponse>>(jsonString);

            response.StatusCode.Should().Be(HttpStatusCode.OK);
            result.Should().BeEquivalentTo(expected);
        }

        [Fact]
        public async Task CanSearchEstablishmentsByUkprn()
        {
            var establishments = Builder<Establishment>
                .CreateListOfSize(8)
                .All()
                .With(e => e.Urn = _randomGenerator.Next(100000, 199999))
                .Build();

            _legacyDbContext.Establishment.AddRange(establishments);
            _legacyDbContext.SaveChanges();

            var expected = new List<EstablishmentSummaryResponse>
            {
                EstablishmentSummaryResponseFactory.Create(establishments[0])
            };

            var response = await _client.GetAsync($"/establishments?ukprn={establishments[0].Ukprn}");
            var jsonString = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<List<EstablishmentSummaryResponse>>(jsonString);

            response.StatusCode.Should().Be(HttpStatusCode.OK);
            result.Should().BeEquivalentTo(expected);
        }

        [Fact]
        public async Task CanSearchEstablishmentsByName()
        {
            var establishments = Builder<Establishment>
                .CreateListOfSize(8)
                .All()
                .With(e => e.Urn = _randomGenerator.Next(100000, 199999))
                .Build();


            _legacyDbContext.Establishment.AddRange(establishments);
            _legacyDbContext.SaveChanges();

            var expected = new List<EstablishmentSummaryResponse>
            {
                EstablishmentSummaryResponseFactory.Create(establishments[0])
            };

            var response = await _client.GetAsync($"/establishments?name={establishments[0].EstablishmentName}");
            var jsonString = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<List<EstablishmentSummaryResponse>>(jsonString);

            response.StatusCode.Should().Be(HttpStatusCode.OK);
            result.Should().BeEquivalentTo(expected);
        }

        [Fact]
        public async Task CanSearchEstablishmentsByPartialCaseInsensitiveName()
        {
            var establishments = Builder<Establishment>
                .CreateListOfSize(10)
                .All()
                .With(e => e.Urn = _randomGenerator.Next(100000, 199999))
                .Build();

            establishments[9].EstablishmentName = "aFaKeESTABLISHMENT";

            _legacyDbContext.Establishment.AddRange(establishments);
            _legacyDbContext.SaveChanges();

            var expected = new List<EstablishmentSummaryResponse>
            {
                EstablishmentSummaryResponseFactory.Create(establishments[9])
            };

            var response = await _client.GetAsync($"/establishments?name=afakeestab");
            var jsonString = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<List<EstablishmentSummaryResponse>>(jsonString);

            response.StatusCode.Should().Be(HttpStatusCode.OK);
            result.Should().BeEquivalentTo(expected);
        }


        [Fact]
        public async Task CanSearchEstablishmentsByPartialUrn()
        {
            var establishments = Builder<Establishment>
                .CreateListOfSize(10)
                .All()
                .With(e => e.Urn = _randomGenerator.Next(100000, 199000))
                .Build();


            establishments[5].Urn = 199954;
            establishments[9].Urn = 199999;

            _legacyDbContext.Establishment.AddRange(establishments);
            _legacyDbContext.SaveChanges();

            var expected = new List<EstablishmentSummaryResponse>
            {
                EstablishmentSummaryResponseFactory.Create(establishments[5]),
                EstablishmentSummaryResponseFactory.Create(establishments[9])
            };

            var response = await _client.GetAsync($"/establishments?urn=1999");
            var jsonString = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<List<EstablishmentSummaryResponse>>(jsonString);

            response.StatusCode.Should().Be(HttpStatusCode.OK);
            result.Should().BeEquivalentTo(expected);
        }


        [Fact]
        public async Task CanSearchEstablishmentsByPartialUkprn()
        {
            var establishments = Builder<Establishment>
                .CreateListOfSize(10)
                .All()
                .With(e => e.Urn = _randomGenerator.Next(100000, 199999))
                .Build();

            establishments[2].Ukprn = "testukprn1";
            establishments[6].Ukprn = "testukprn2";

            _legacyDbContext.Establishment.AddRange(establishments);
            _legacyDbContext.SaveChanges();

            var expected = new List<EstablishmentSummaryResponse>
            {
                EstablishmentSummaryResponseFactory.Create(establishments[2]),
                EstablishmentSummaryResponseFactory.Create(establishments[6])
            };

            var response = await _client.GetAsync($"/establishments?ukprn=testukprn");
            var jsonString = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<List<EstablishmentSummaryResponse>>(jsonString);

            response.StatusCode.Should().Be(HttpStatusCode.OK);
            result.Should().BeEquivalentTo(expected);
        }

        private EstablishmentResponse AddTestData(int urn, string region = default)
        {
            var establishment = Builder<Establishment>.CreateNew()
                .With(e => e.Ukprn = "mockukprn")
                .With(e => e.Urn = urn)
                .With(e => e.GorName = region)
                .Build();
            var misEstablishment = Builder<MisEstablishments>.CreateNew().With(m => m.Urn = establishment.Urn).Build();
            var furtherEducationEstablishment = Builder<FurtherEducationEstablishments>.CreateNew().With(f => f.ProviderUrn = establishment.Urn).Build();
            var smartData = Generators.GenerateSmartData(establishment.Urn);
            var viewAcademyConversionData = Generators.GenerateViewAcademyConversions(establishment.Urn);

            _legacyDbContext.Establishment.Add(establishment);
            _legacyDbContext.MisEstablishments.Add(misEstablishment);
            _legacyDbContext.SmartData.Add(smartData);
            _legacyDbContext.FurtherEducationEstablishments.Add(furtherEducationEstablishment);
            _legacyDbContext.ViewAcademyConversions.Add(viewAcademyConversionData);
            _legacyDbContext.SaveChanges();

            var censusData = _censusDataGateway.GetCensusDataByURN(urn.ToString());

            return EstablishmentResponseFactory.Create(establishment, misEstablishment, smartData, furtherEducationEstablishment, viewAcademyConversionData, censusData);
        }

        public void Dispose()
        {
            _legacyDbContext.Establishment.RemoveRange(_legacyDbContext.Establishment);
            _legacyDbContext.MisEstablishments.RemoveRange(_legacyDbContext.MisEstablishments);
            _legacyDbContext.SmartData.RemoveRange(_legacyDbContext.SmartData);
            _legacyDbContext.ViewAcademyConversions.RemoveRange(_legacyDbContext.ViewAcademyConversions);
            _legacyDbContext.FurtherEducationEstablishments.RemoveRange(_legacyDbContext.FurtherEducationEstablishments);
            _legacyDbContext.SaveChanges();
        }
    }
}