using AutoFixture;
using Dfe.Academies.Contracts.V4.Establishments;
using Dfe.Academies.Domain.Establishment;
using FluentAssertions;
using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Xunit;

namespace TramsDataApi.Test.Integration.V4
{
    [Collection("Database")]
    public class EstablishmentV4IntegrationTests : IClassFixture<TramsDataApiFactory>
    {
        private readonly HttpClient _client;
        private static readonly Fixture _autoFixture = new Fixture();
        private readonly TramsDataApiFactory _apiFixture;

        private readonly string _apiUrlPrefix = "https://trams-api.com/v4";

        public EstablishmentV4IntegrationTests(TramsDataApiFactory apiFixture)
        {
            _apiFixture = apiFixture;
            _client = _apiFixture.CreateClient();
            _client.DefaultRequestHeaders.Add("ApiKey", "testing-api-key");
            _client.BaseAddress = new Uri(_apiUrlPrefix);
        }

        [Fact]
        public async Task Get_EstablishmentByUkPrn_NoEstablishmentExists_Returns_NotFound()
        {
            var ukPrn = _autoFixture.Create<int>();
            var getEstablishmentResponse = await _client.GetAsync($"/establishment/{ukPrn}");
            getEstablishmentResponse.StatusCode.Should().Be(HttpStatusCode.NotFound);
        }

        [Fact]
        public async Task Get_EstablishmentByUkPrn_EstablishmentExists_Returns_Ok()
        {
            using var context = _apiFixture.GetMstrContext();

            var establishment = new Establishment();
            establishment.LocalAuthority = null;
            establishment.UKPRN = _autoFixture.Create<string>();
            establishment.FK_LocalAuthority = 1;

            context.Establishments.Add(establishment);
            context.SaveChanges();

            var getEstablishmentResponse = await _client.GetAsync($"/establishment/{establishment.UKPRN}");
            getEstablishmentResponse.StatusCode.Should().Be(HttpStatusCode.OK);

            var establishmentContent = await getEstablishmentResponse.Content.ReadFromJsonAsync<EstablishmentDto>();

            //  "ukprn": "string",
            //  "urn": "string",
            //  "name": "string",
            //  "localAuthorityCode": "string",
            //  "localAuthorityName": "string",
            //  "ofstedRating": "string",
            //  "ofstedLastInspection": "string",
            //  "statutoryLowAge": "string",
            //  "statutoryHighAge": "string",
            //  "schoolCapacity": "string",
            //  "pfi": "string",
            //  "establishmentNumber": "string",
            //  "pan": "string",
            //  "deficit": "string",
            //  "viabilityIssue": "string",
            //  "giasLastChangedDate": "string",
            //  "noOfBoys": "string",
            //  "noOfGirls": "string",
            //  "senUnitCapacity": "string",
            //  "senUnitOnRoll": "string",
            //  "religousEthos": "string",
            //  "headteacherTitle": "string",
            //  "headteacherFirstName": "string",
            //  "headteacherLastName": "string",
            //  "headteacherPreferredJobTitle": "string",

            establishmentContent.Ukprn.Should().Be(establishment.UKPRN);
            establishmentContent.Urn.Should().Be(establishment.URN.ToString());
            establishmentContent.Name.Should().Be(establishment.EstablishmentName);
            establishmentContent.LocalAuthorityCode.Should().Be(establishment.LocalAuthority.Code);
            establishmentContent.LocalAuthorityName.Should().Be(establishment.LocalAuthority.Name);

        }
    }
}
