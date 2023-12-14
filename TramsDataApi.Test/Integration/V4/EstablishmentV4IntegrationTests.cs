using AutoFixture;
using Dfe.Academies.Contracts.V4.Establishments;
using Dfe.Academies.Domain.Establishment;
using FizzWare.NBuilder.Extensions;
using FluentAssertions;
using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using TramsDataApi.Test.Fixtures;
using TramsDataApi.Test.Helpers;
using Xunit;

namespace TramsDataApi.Test.Integration.V4
{
    [Collection(ApiTestCollection.ApiTestCollectionName)]
    public class EstablishmentV4IntegrationTests
    {
        private readonly HttpClient _client;
        private static readonly Fixture _autoFixture = new Fixture();
        private readonly ApiTestFixture _apiFixture;

        private readonly string _apiUrlPrefix = "/v4";

        public EstablishmentV4IntegrationTests(ApiTestFixture fixture)
        {
            _apiFixture = fixture;
            _client = fixture.Client;
        }

        [Fact]
        public async Task Get_EstablishmentByUkPrn_NoEstablishmentExists_Returns_NotFound()
        {
            var ukPrn = _autoFixture.Create<int>();
            var getEstablishmentResponse = await _client.GetAsync($"{_apiUrlPrefix}/establishment/{ukPrn}");
            getEstablishmentResponse.StatusCode.Should().Be(HttpStatusCode.NotFound);
        }

        [Fact]
        public async Task Get_EstablishmentByUkPrn_EstablishmentExists_Returns_Ok()
        {
            using var context = _apiFixture.GetMstrContext();

            var establishment = DatabaseModelBuilder.BuildEstablishment();

            context.Establishments.Add(establishment);
            context.SaveChanges();

            var getEstablishmentResponse = await _client.GetAsync($"{_apiUrlPrefix}/establishment/{establishment.UKPRN}");
            getEstablishmentResponse.StatusCode.Should().Be(HttpStatusCode.OK);

            var establishmentContent = await getEstablishmentResponse.Content.ReadFromJsonAsync<EstablishmentDto>();

            //{
            //      "diocese": {
            //                        "name": "string",
            //        "code": "string"
            //      },
            //      "establishmentType": {
            //                        "name": "string",
            //        "code": "string"
            //      },
            //      "gor": {
            //                        "name": "string",
            //        "code": "string"
            //      },
            //      "phaseOfEducation": {
            //                        "name": "string",
            //        "code": "string"
            //      },
            //      "religiousCharacter": {
            //                        "name": "string",
            //        "code": "string"
            //      },
            //      "parliamentaryConstituency": {
            //                        "name": "string",
            //        "code": "string"
            //      },
            //      "census": {
            //                        "numberOfPupils": "string",
            //        "percentageFsm": "string",
            //        "percentageFsmLastSixYears": "string",
            //        "percentageEnglishAsSecondLanguage": "string",
            //        "percentageSen": "string"
            //      },
            //      "misEstablishment": {
            //                        "dateOfLatestSection8Inspection": "string",
            //        "inspectionEndDate": "string",
            //        "overallEffectiveness": "string",
            //        "qualityOfEducation": "string",
            //        "behaviourAndAttitudes": "string",
            //        "personalDevelopment": "string",
            //        "effectivenessOfLeadershipAndManagement": "string",
            //        "earlyYearsProvision": "string",
            //        "sixthFormProvision": "string",
            //        "weblink": "string"
            //      },
            //      "address": {
            //                        "street": "string",
            //        "town": "string",
            //        "county": "string",
            //        "postcode": "string",
            //        "locality": "string",
            //        "additional": "string"
            //    }
            //}

            //      "giasLastChangedDate": "string",
            //      "noOfBoys": "string",
            //      "noOfGirls": "string",
            //      "senUnitCapacity": "string",
            //      "senUnitOnRoll": "string",
            //      "religousEthos": "string",
            //      "headteacherTitle": "string",
            //      "headteacherFirstName": "string",
            //      "headteacherLastName": "string",
            //      "headteacherPreferredJobTitle": "string",

            establishmentContent.Ukprn.Should().Be(establishment.UKPRN);
            establishmentContent.Urn.Should().Be(establishment.URN.ToString());
            establishmentContent.Name.Should().Be(establishment.EstablishmentName);
            establishmentContent.OfstedRating.Should().Be(establishment.OfstedRating);
            establishmentContent.OfstedLastInspection.Should().Be(establishment.OfstedLastInspection);
            establishmentContent.StatutoryLowAge.Should().Be(establishment.StatutoryLowAge);
            establishmentContent.StatutoryHighAge.Should().Be(establishment.StatutoryHighAge);
            establishmentContent.SchoolCapacity.Should().Be(establishment.SchoolCapacity);
            establishment.EstablishmentNumber.Should().Be(establishment.EstablishmentNumber);
            establishment.GiasLastChangedDate.Should().Be(establishment.GiasLastChangedDate);
            establishment.NumberOfBoys.Should().Be(establishment.NumberOfBoys);
            establishment.NumberOfGirls.Should().Be(establishment.NumberOfGirls);
            establishment.SenUnitCapacity.Should().Be(establishment.SenUnitCapacity);
            establishment.SenUnitOnRoll.Should().Be(establishment.SenUnitOnRoll);
            establishment.ReligiousEthos.Should().Be(establishment.ReligiousEthos);

            // establishmentContent.Pan.Should().Be(establishment.);
            //establishmentContent.Pfi.Should().Be(establishment.PreviousFullInspectionOverallEffectiveness);
            //establishmentContent.LocalAuthorityCode.Should().Be(establishment.LocalAuthority.Code);
            //establishmentContent.LocalAuthorityName.Should().Be(establishment.LocalAuthority.Name);
            // establishmentContent.Deficit.Should().Be(establishment.Deficit);
            // establishment.IsDefaultValue.Should().Be(establishment.Something);
            //establishment.HeadteacherTitle.Should().Be(establishment.HeadteacherTitle);
            //establishment.HeadteacherFirstName.Should().Be(establishment.HeadteacherFirstName);
            //establishment.HeadteacherLastName.Should().Be(establishment.HeadteacherLastName);
            //establishment.HeadteacherPreferredJobTitle.Should().Be(establishment.HeadteacherPreferredJobTitle);
        }
    }
}
