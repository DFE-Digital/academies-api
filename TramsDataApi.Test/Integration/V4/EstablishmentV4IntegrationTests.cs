using AutoFixture;
using Dfe.Academies.Contracts.V4.Establishments;
using Dfe.Academies.Domain.Establishment;
using FizzWare.NBuilder.Extensions;
using FluentAssertions;
using Microsoft.OpenApi.Extensions;
using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using TramsDataApi.Test.Fixtures;
using TramsDataApi.Test.Helpers;
using Xunit;
using Dfe.Academies.Utils.Extensions;

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
            var idfPipeline = DatabaseModelBuilder.BuildIfdPipeline();

            // Sets the URN to match the census data, which is statically checked in this test
            establishment.URN = 100028;
            establishment.PK_GIAS_URN = idfPipeline.GeneralDetailsUrn;

            context.Establishments.Add(establishment);
            context.IfdPipelines.Add(idfPipeline);
            context.SaveChanges();

            var getEstablishmentResponse = await _client.GetAsync($"{_apiUrlPrefix}/establishment/{establishment.UKPRN}");
            getEstablishmentResponse.StatusCode.Should().Be(HttpStatusCode.OK);

            var establishmentContent = await getEstablishmentResponse.Content.ReadFromJsonAsync<EstablishmentDto>();

            establishmentContent.Ukprn.Should().Be(establishment.UKPRN);
            establishmentContent.Urn.Should().Be(establishment.URN.ToString());
            establishmentContent.Name.Should().Be(establishment.EstablishmentName);
            establishmentContent.OfstedRating.Should().Be(establishment.OfstedRating);
            establishmentContent.OfstedLastInspection.Should().Be(establishment.OfstedLastInspection);
            establishmentContent.StatutoryLowAge.Should().Be(establishment.StatutoryLowAge);
            establishmentContent.StatutoryHighAge.Should().Be(establishment.StatutoryHighAge);
            establishmentContent.SchoolCapacity.Should().Be(establishment.SchoolCapacity);
            establishmentContent.EstablishmentNumber.Should().Be(establishment.EstablishmentNumber.ToString());
            establishmentContent.GiasLastChangedDate.Should().Be(establishment.GiasLastChangedDate.ToResponseDate());
            establishmentContent.NoOfBoys.Should().Be(establishment.NumberOfBoys.ToString());
            establishmentContent.NoOfGirls.Should().Be(establishment.NumberOfGirls.ToString());
            establishmentContent.SenUnitCapacity.Should().Be(establishment.SenUnitCapacity.ToString());
            establishmentContent.SenUnitOnRoll.Should().Be(establishment.SenUnitOnRoll.ToString());
            establishmentContent.ReligousEthos.Should().Be(establishment.ReligiousEthos);
            establishmentContent.HeadteacherTitle.Should().Be(establishment.HeadTitle);
            establishmentContent.HeadteacherFirstName.Should().Be(establishment.HeadFirstName);
            establishmentContent.HeadteacherLastName.Should().Be(establishment.HeadLastName);
            establishmentContent.HeadteacherPreferredJobTitle.Should().Be(establishment.HeadPreferredJobTitle);

            establishmentContent.LocalAuthorityCode.Should().Be("202");
            establishmentContent.LocalAuthorityName.Should().Be("Barnsley");

            establishmentContent.Diocese.Code.Should().Be(establishment.DioceseCode);
            establishmentContent.Diocese.Name.Should().Be(establishment.Diocese);

            establishmentContent.EstablishmentType.Code.Should().Be("18");
            establishmentContent.EstablishmentType.Name.Should().Be("Further education");

            establishmentContent.Gor.Code.Should().Be(establishment.GORregionCode);
            establishmentContent.Gor.Name.Should().Be(establishment.GORregion);

            establishmentContent.PhaseOfEducation.Code.Should().Be(establishment.PhaseOfEducationCode.ToString());
            establishmentContent.PhaseOfEducation.Name.Should().Be(establishment.PhaseOfEducation);

            establishmentContent.ReligiousCharacter.Code.Should().Be(establishment.ReligiousCharacterCode);
            establishmentContent.ReligiousCharacter.Name.Should().Be(establishment.ReligiousCharacter);

            establishmentContent.ParliamentaryConstituency.Code.Should().Be(establishment.ParliamentaryConstituencyCode);
            establishmentContent.ParliamentaryConstituency.Name.Should().Be(establishment.ParliamentaryConstituency);

            establishmentContent.Address.Street.Should().Be(establishment.AddressLine1);
            establishmentContent.Address.Additional.Should().Be(establishment.AddressLine2);
            establishmentContent.Address.Locality.Should().Be(establishment.AddressLine3);
            establishmentContent.Address.Town.Should().Be(establishment.Town);
            establishmentContent.Address.County.Should().Be(establishment.County);
            establishmentContent.Address.Postcode.Should().Be(establishment.Postcode);

            establishmentContent.MISEstablishment.DateOfLatestSection8Inspection.Should().Be(establishment.DateOfLatestShortInspection.ToResponseDate());
            establishmentContent.MISEstablishment.InspectionEndDate.Should().Be(establishment.InspectionEndDate.ToResponseDate());
            establishmentContent.MISEstablishment.OverallEffectiveness.Should().Be(establishment.OverallEffectiveness.ToString());
            establishmentContent.MISEstablishment.QualityOfEducation.Should().Be(establishment.QualityOfEducation.ToString());
            establishmentContent.MISEstablishment.BehaviourAndAttitudes.Should().Be(establishment.BehaviourAndAttitudes.ToString());
            establishmentContent.MISEstablishment.PersonalDevelopment.Should().Be(establishment.PersonalDevelopment.ToString());
            establishmentContent.MISEstablishment.EffectivenessOfLeadershipAndManagement.Should().Be(establishment.EffectivenessOfLeadershipAndManagement.ToString());
            establishmentContent.MISEstablishment.EarlyYearsProvision.Should().Be(establishment.EarlyYearsProvisionWhereApplicable.ToString());
            establishmentContent.MISEstablishment.SixthFormProvision.Should().Be(establishment.SixthFormProvisionWhereApplicable.ToString());
            establishmentContent.MISEstablishment.Weblink.Should().Be(establishment.Website);

            establishmentContent.Census.NumberOfPupils.Should().Be(establishment.NumberOfPupils);
            establishmentContent.Census.PercentageFsm.Should().Be(establishment.PercentageFSM);
            establishmentContent.Census.PercentageFsmLastSixYears.Should().Be("5.70%");
            establishmentContent.Census.PercentageEnglishAsSecondLanguage.Should().Be("52.60%");
            establishmentContent.Census.PercentageSen.Should().Be("6.30%");

            // IDF Pipeline
            establishmentContent.Pan.Should().Be(idfPipeline.DeliveryProcessPAN);
            establishmentContent.Pfi.Should().Be(idfPipeline.DeliveryProcessPFI);
            establishmentContent.Deficit.Should().Be(idfPipeline.ProjectTemplateInformationDeficit);
            establishmentContent.ViabilityIssue.Should().Be(idfPipeline.ProjectTemplateInformationViabilityIssue);
        }
    }
}
