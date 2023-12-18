using AutoFixture;
using Dfe.Academies.Academisation.Data;
using Dfe.Academies.Contracts.V4.Establishments;
using Dfe.Academies.Domain.Establishment;
using Dfe.Academies.Domain.Trust;
using Dfe.Academies.Utils.Extensions;
using FluentAssertions;
using System.Collections.Generic;
using System.Linq;
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

            var trust = CreateDataSet(context);
            var establishmentDataSet = trust.Establishments.First();
            var establishment = establishmentDataSet.Establishment;
            var ifdPipeline = establishmentDataSet.IfdPipeline;

            // Matches a URN in the census
            establishment.URN = 100028;

            context.Update(establishment);
            context.SaveChanges();

            var getEstablishmentResponse = await _client.GetAsync($"{_apiUrlPrefix}/establishment/{establishment.UKPRN}");
            getEstablishmentResponse.StatusCode.Should().Be(HttpStatusCode.OK);

            var actual = await getEstablishmentResponse.Content.ReadFromJsonAsync<EstablishmentDto>();

            AssertEstablishmentResponse(actual, establishment, ifdPipeline);

            // Check data from the census
            AssertCensus(actual);
            actual.Census.PercentageFsmLastSixYears.Should().Be("5.70%");
            actual.Census.PercentageEnglishAsSecondLanguage.Should().Be("52.60%");
            actual.Census.PercentageSen.Should().Be("6.30%");
        }

        [Fact]
        public async Task Get_EstablishmentByUkPrn_EstablishmentHasMinimumFields_Returns_Ok()
        {
            using var context = _apiFixture.GetMstrContext();
            var establishment = new Establishment()
            {
                UKPRN = _autoFixture.Create<string>(),
                URN = _autoFixture.Create<int>(),
            };

            context.Establishments.Add(establishment);
            context.SaveChanges();

            var getEstablishmentResponse = await _client.GetAsync($"{_apiUrlPrefix}/establishment/{establishment.UKPRN}");
            getEstablishmentResponse.StatusCode.Should().Be(HttpStatusCode.OK);

            var actual = await getEstablishmentResponse.Content.ReadFromJsonAsync<EstablishmentDto>();
            actual.Ukprn.Should().Be(establishment.UKPRN);
            actual.Urn.Should().Be(establishment.URN.ToString());
        }

        [Fact]
        public async Task Get_EstablishmentByUrn_EstablishmentDoesNotExist_Returns_NotFound()
        {
            var urn = _autoFixture.Create<int>();
            var getEstablishmentResponse = await _client.GetAsync($"{_apiUrlPrefix}/establishment/urn/{urn}");
            getEstablishmentResponse.StatusCode.Should().Be(HttpStatusCode.NotFound);
        }

        [Fact]
        public async Task Get_EstablishmentByUrn_EstablishmentExists_Returns_Ok()
        {
            using var context = _apiFixture.GetMstrContext();

            var trust = CreateDataSet(context);
            var establishmentDataSet = trust.Establishments.First();
            var establishment = establishmentDataSet.Establishment;
            var ifdPipeline = establishmentDataSet.IfdPipeline;

            // Matches a URN in the census
            establishment.URN = 100270;

            context.Update(establishment);
            context.SaveChanges();

            var getEstablishmentResponse = await _client.GetAsync($"{_apiUrlPrefix}/establishment/urn/{establishment.URN}");
            getEstablishmentResponse.StatusCode.Should().Be(HttpStatusCode.OK);

            var establishmentContent = await getEstablishmentResponse.Content.ReadFromJsonAsync<EstablishmentDto>();

            AssertEstablishmentResponse(establishmentContent, establishment, ifdPipeline);
            AssertCensus(establishmentContent);
        }

        [Fact]
        public async Task Get_EstablishmentListByTrust_TrustDoesNotExist_Returns_Empty()
        {
            var getEstablishmentResponse = await _client.GetAsync($"{_apiUrlPrefix}/establishments/trust?trustUkPrn=NotExist");
            getEstablishmentResponse.StatusCode.Should().Be(HttpStatusCode.OK);

            var establishmentContent = await getEstablishmentResponse.Content.ReadFromJsonAsync<List<EstablishmentDto>>();

            establishmentContent.Should().BeEmpty();
        }

        [Fact]
        public async Task Get_EstablishmentListByTrust_TrustHasNoEstablishments_Returns_Empty()
        {
            using var context = _apiFixture.GetMstrContext();

            var trust = DatabaseModelBuilder.BuildTrust();

            context.Trusts.Add(trust);

            var getEstablishmentResponse = await _client.GetAsync($"{_apiUrlPrefix}/establishments/trust?trustUkPrn={trust.UKPRN}");
            getEstablishmentResponse.StatusCode.Should().Be(HttpStatusCode.OK);

            var establishmentContent = await getEstablishmentResponse.Content.ReadFromJsonAsync<List<EstablishmentDto>>();

            establishmentContent.Should().BeEmpty();
        }

        [Fact]
        public async Task Get_EstablishmentListByTrust_TrustExists_Returns_Ok()
        {
            using var context = _apiFixture.GetMstrContext();

            var trustOne = CreateDataSet(context);

            // Matches URNs in the census
            trustOne.Establishments.ElementAt(0).Establishment.URN = 100601;
            trustOne.Establishments.ElementAt(1).Establishment.URN = 100602;
            trustOne.Establishments.ElementAt(2).Establishment.URN = 100604;

            context.Establishments.UpdateRange(trustOne.Establishments.Select(x => x.Establishment));
            context.SaveChanges();

            var trustTwo = CreateDataSet(context);

            var getEstablishmentResponse = await _client.GetAsync($"{_apiUrlPrefix}/establishments/trust?trustUkPrn={trustOne.Trust.UKPRN}");
            getEstablishmentResponse.StatusCode.Should().Be(HttpStatusCode.OK);

            var establishmentContent = await getEstablishmentResponse.Content.ReadFromJsonAsync<List<EstablishmentDto>>();

            establishmentContent.Count.Should().Be(3);

            trustOne.Establishments.ForEach(establishmentDataSet =>
            {
                var matchingEstablishment = establishmentContent.FirstOrDefault(x => x.Urn == establishmentDataSet.Establishment.URN.ToString());

                AssertEstablishmentResponse(matchingEstablishment, establishmentDataSet.Establishment, establishmentDataSet.IfdPipeline);
                AssertCensus(matchingEstablishment);
            });
        }

        [Fact]
        public async Task Get_Search_NoEstablishmentsExist_Returns_Empty()
        {
            var getEstablishmentResponse = await _client.GetAsync($"{_apiUrlPrefix}/establishments?name=NotExist");
            getEstablishmentResponse.StatusCode.Should().Be(HttpStatusCode.OK);

            var establishmentContent = await getEstablishmentResponse.Content.ReadFromJsonAsync<List<EstablishmentDto>>();

            establishmentContent.Should().BeEmpty();
        }

        [Fact]
        public async Task Get_SearchEstablishmentsByName_Returns_Ok()
        {
            using var context = _apiFixture.GetMstrContext();

            var trustOne = CreateDataSet(context);
            var firstEstablishmentData = trustOne.Establishments.ElementAt(0);
            var secondEstablishmentData = trustOne.Establishments.ElementAt(1);
            firstEstablishmentData.Establishment.EstablishmentName = "West BANK queens School";
            secondEstablishmentData.Establishment.EstablishmentName = "West bank primary";
            context.Establishments.UpdateRange(trustOne.Establishments.Select(x => x.Establishment));
            context.SaveChanges();

            var getEstablishmentResponse = await _client.GetAsync($"{_apiUrlPrefix}/establishments?name=west bank");
            getEstablishmentResponse.StatusCode.Should().Be(HttpStatusCode.OK);

            var establishmentContent = await getEstablishmentResponse.Content.ReadFromJsonAsync<List<EstablishmentDto>>();

            establishmentContent.Count.Should().Be(2);

            var expectedEstablishments = new List<EstablishmentDataSet> { firstEstablishmentData, secondEstablishmentData };

            expectedEstablishments.ForEach(establishmentDataSet =>
            {
                var matchingEstablishment = establishmentContent.FirstOrDefault(x => x.Urn == establishmentDataSet.Establishment.URN.ToString());

                AssertEstablishmentResponse(matchingEstablishment, establishmentDataSet.Establishment, establishmentDataSet.IfdPipeline);
            });
        }

        [Fact]
        public async Task Get_SearchEstablishmentByUkPrn_Returns_Ok()
        {
            using var context = _apiFixture.GetMstrContext();

            var trustOne = CreateDataSet(context);
            var firstEstablishmentData = trustOne.Establishments.ElementAt(0);

            var getEstablishmentResponse = await _client.GetAsync($"{_apiUrlPrefix}/establishments?ukPrn={firstEstablishmentData.Establishment.UKPRN}");
            getEstablishmentResponse.StatusCode.Should().Be(HttpStatusCode.OK);

            var establishmentContent = await getEstablishmentResponse.Content.ReadFromJsonAsync<List<EstablishmentDto>>();

            establishmentContent.Count.Should().Be(1);

            establishmentContent.First().Ukprn.Should().Be(firstEstablishmentData.Establishment.UKPRN.ToString());
        }

        [Fact]
        public async Task Get_SearchEstablishmentByUrn_Returns_Ok()
        {
            using var context = _apiFixture.GetMstrContext();

            var trustOne = CreateDataSet(context);
            var firstEstablishmentData = trustOne.Establishments.ElementAt(0);

            var getEstablishmentResponse = await _client.GetAsync($"{_apiUrlPrefix}/establishments?urn={firstEstablishmentData.Establishment.URN}");
            getEstablishmentResponse.StatusCode.Should().Be(HttpStatusCode.OK);

            var establishmentContent = await getEstablishmentResponse.Content.ReadFromJsonAsync<List<EstablishmentDto>>();

            establishmentContent.Count.Should().Be(1);

            establishmentContent.First().Urn.Should().Be(firstEstablishmentData.Establishment.URN.ToString());
        }

        [Fact]
        public async Task Get_BulkEstablishment_NoEstablishmentsExist_Returns_Empty()
        {
            var getEstablishmentResponse = await _client.GetAsync($"{_apiUrlPrefix}/establishments/bulk?request=123");
            getEstablishmentResponse.StatusCode.Should().Be(HttpStatusCode.OK);

            var establishmentContent = await getEstablishmentResponse.Content.ReadFromJsonAsync<List<EstablishmentDto>>();

            establishmentContent.Should().BeEmpty();
        }

        [Fact]
        public async Task Get_BulkEstablishment_EstablishmentsExist_Returns_Ok()
        {
            using var context = _apiFixture.GetMstrContext();

            var trustOne = CreateDataSet(context);

            var establishmentOne = trustOne.Establishments.ElementAt(0);
            var establishmentTwo = trustOne.Establishments.ElementAt(1);

            var getEstablishmentResponse = await _client.GetAsync($"{_apiUrlPrefix}/establishments/bulk?request={establishmentOne.Establishment.URN}&request={establishmentTwo.Establishment.URN}");
            getEstablishmentResponse.StatusCode.Should().Be(HttpStatusCode.OK);

            var establishmentContent = await getEstablishmentResponse.Content.ReadFromJsonAsync<List<EstablishmentDto>>();

            establishmentContent.Count.Should().Be(2);

            var expectedEstablishments = new List<EstablishmentDataSet> { establishmentOne, establishmentTwo };

            expectedEstablishments.ForEach(establishmentDataSet =>
            {
                var matchingEstablishment = establishmentContent.FirstOrDefault(x => x.Urn == establishmentDataSet.Establishment.URN.ToString());

                AssertEstablishmentResponse(matchingEstablishment, establishmentDataSet.Establishment, establishmentDataSet.IfdPipeline);
            });
        }

        [Fact]
        public async Task Get_EstablishmentUrnsByRegion_NoEstablishmentsExist_Returns_NotFound()
        {
            var getEstablishmentResponse = await _client.GetAsync($"{_apiUrlPrefix}/establishment/regions?regions=123");
            getEstablishmentResponse.StatusCode.Should().Be(HttpStatusCode.OK);

            var establishmentContent = await getEstablishmentResponse.Content.ReadFromJsonAsync<List<EstablishmentDto>>();

            establishmentContent.Should().BeEmpty();
        }

        [Fact]
        public async Task Get_EstablishmentUrnsByRegion_EstablishmentsExist_Returns_Ok()
        {
            using var context = _apiFixture.GetMstrContext();

            var trustOne = CreateDataSet(context);

            var establishmentOne = trustOne.Establishments.ElementAt(0);
            var establishmentTwo = trustOne.Establishments.ElementAt(1);

            var getEstablishmentResponse = await _client.GetAsync($"{_apiUrlPrefix}/establishment/regions?regions={establishmentOne.Establishment.GORregion}&regions={establishmentTwo.Establishment.GORregion}");
            getEstablishmentResponse.StatusCode.Should().Be(HttpStatusCode.OK);

            var actual = await getEstablishmentResponse.Content.ReadFromJsonAsync<List<int>>();

            actual.Count.Should().Be(2);

            var expectedEstablishmentUrns = new List<int>() { establishmentOne.Establishment.URN.Value, establishmentTwo.Establishment.URN.Value };

            actual.Should().BeEquivalentTo(expectedEstablishmentUrns);
        }

        private static TrustDataSet CreateDataSet(MstrContext context)
        {
            var trust = DatabaseModelBuilder.BuildTrust();
            context.Add(trust);
            context.SaveChanges();

            var establishments = new List<EstablishmentDataSet>();

            for (var idx = 0; idx < 3; idx++)
            {
                var establishment = DatabaseModelBuilder.BuildEstablishment();
                var ifdPipeline = DatabaseModelBuilder.BuildIfdPipeline();
                ifdPipeline.GeneralDetailsUrn = establishment.PK_GIAS_URN;

                var establishmentDataSet = new EstablishmentDataSet()
                {
                    Establishment = establishment,
                    IfdPipeline = ifdPipeline
                };

                context.Establishments.Add(establishment);
                context.IfdPipelines.Add(ifdPipeline);

                establishments.Add(establishmentDataSet);
            }

            context.SaveChanges();

            var trustToEstablishmentLinks = LinkTrustToEstablishments(trust, establishments.Select(d => d.Establishment).ToList());

            context.EducationEstablishmentTrusts.AddRange(trustToEstablishmentLinks);

            context.SaveChanges();

            var result = new TrustDataSet()
            {
                Trust = trust,
                Establishments = establishments
            };

            return result;
        }

        private static List<EducationEstablishmentTrust> LinkTrustToEstablishments(Trust trust, List<Establishment> establishments)
        {
            var result = new List<EducationEstablishmentTrust>();

            establishments.ForEach(establishment =>
            {
                var educationEstablishmentTrust = new EducationEstablishmentTrust()
                {
                    TrustId = (int)trust.SK,
                    EducationEstablishmentId = (int)establishment.SK
                };

                result.Add(educationEstablishmentTrust);
            });

            return result;
        }

        private static void AssertEstablishmentResponse(EstablishmentDto actual, Establishment expected, IfdPipeline ifdPipeline)
        {
            actual.Ukprn.Should().Be(expected.UKPRN);
            actual.Urn.Should().Be(expected.URN.ToString());
            actual.Name.Should().Be(expected.EstablishmentName);
            actual.OfstedRating.Should().Be(expected.OfstedRating);
            actual.OfstedLastInspection.Should().Be(expected.OfstedLastInspection);
            actual.StatutoryLowAge.Should().Be(expected.StatutoryLowAge);
            actual.StatutoryHighAge.Should().Be(expected.StatutoryHighAge);
            actual.SchoolCapacity.Should().Be(expected.SchoolCapacity);
            actual.EstablishmentNumber.Should().Be(expected.EstablishmentNumber.ToString());
            actual.GiasLastChangedDate.Should().Be(expected.GiasLastChangedDate.ToResponseDate());
            actual.NoOfBoys.Should().Be(expected.NumberOfBoys.ToString());
            actual.NoOfGirls.Should().Be(expected.NumberOfGirls.ToString());
            actual.SenUnitCapacity.Should().Be(expected.SenUnitCapacity.ToString());
            actual.SenUnitOnRoll.Should().Be(expected.SenUnitOnRoll.ToString());
            actual.ReligousEthos.Should().Be(expected.ReligiousEthos);
            actual.HeadteacherTitle.Should().Be(expected.HeadTitle);
            actual.HeadteacherFirstName.Should().Be(expected.HeadFirstName);
            actual.HeadteacherLastName.Should().Be(expected.HeadLastName);
            actual.HeadteacherPreferredJobTitle.Should().Be(expected.HeadPreferredJobTitle);

            actual.LocalAuthorityCode.Should().Be("202");
            actual.LocalAuthorityName.Should().Be("Barnsley");

            actual.Diocese.Code.Should().Be(expected.DioceseCode);
            actual.Diocese.Name.Should().Be(expected.Diocese);

            actual.EstablishmentType.Code.Should().Be("18");
            actual.EstablishmentType.Name.Should().Be("Further education");

            actual.Gor.Code.Should().Be(expected.GORregionCode);
            actual.Gor.Name.Should().Be(expected.GORregion);

            actual.PhaseOfEducation.Code.Should().Be(expected.PhaseOfEducationCode.ToString());
            actual.PhaseOfEducation.Name.Should().Be(expected.PhaseOfEducation);

            actual.ReligiousCharacter.Code.Should().Be(expected.ReligiousCharacterCode);
            actual.ReligiousCharacter.Name.Should().Be(expected.ReligiousCharacter);

            actual.ParliamentaryConstituency.Code.Should().Be(expected.ParliamentaryConstituencyCode);
            actual.ParliamentaryConstituency.Name.Should().Be(expected.ParliamentaryConstituency);

            actual.Address.Street.Should().Be(expected.AddressLine1);
            actual.Address.Additional.Should().Be(expected.AddressLine2);
            actual.Address.Locality.Should().Be(expected.AddressLine3);
            actual.Address.Town.Should().Be(expected.Town);
            actual.Address.County.Should().Be(expected.County);
            actual.Address.Postcode.Should().Be(expected.Postcode);

            actual.MISEstablishment.DateOfLatestSection8Inspection.Should().Be(expected.DateOfLatestShortInspection.ToResponseDate());
            actual.MISEstablishment.InspectionEndDate.Should().Be(expected.InspectionEndDate.ToResponseDate());
            actual.MISEstablishment.OverallEffectiveness.Should().Be(expected.OverallEffectiveness.ToString());
            actual.MISEstablishment.QualityOfEducation.Should().Be(expected.QualityOfEducation.ToString());
            actual.MISEstablishment.BehaviourAndAttitudes.Should().Be(expected.BehaviourAndAttitudes.ToString());
            actual.MISEstablishment.PersonalDevelopment.Should().Be(expected.PersonalDevelopment.ToString());
            actual.MISEstablishment.EffectivenessOfLeadershipAndManagement.Should().Be(expected.EffectivenessOfLeadershipAndManagement.ToString());
            actual.MISEstablishment.EarlyYearsProvision.Should().Be(expected.EarlyYearsProvisionWhereApplicable.ToString());
            actual.MISEstablishment.SixthFormProvision.Should().Be(expected.SixthFormProvisionWhereApplicable.ToString());
            actual.MISEstablishment.Weblink.Should().Be(expected.Website);

            actual.Pan.Should().Be(ifdPipeline.DeliveryProcessPAN);
            actual.Pfi.Should().Be(ifdPipeline.DeliveryProcessPFI);
            actual.Deficit.Should().Be(ifdPipeline.ProjectTemplateInformationDeficit);
            actual.ViabilityIssue.Should().Be(ifdPipeline.ProjectTemplateInformationViabilityIssue);

            actual.Census.NumberOfPupils.Should().Be(expected.NumberOfPupils);
            actual.Census.PercentageFsm.Should().Be(expected.PercentageFSM);
        }

        private static void AssertCensus(EstablishmentDto actual)
        {
            actual.Census.PercentageFsmLastSixYears.Length.Should().BeGreaterThan(2);
            actual.Census.PercentageEnglishAsSecondLanguage.Length.Should().BeGreaterThan(2);
            actual.Census.PercentageSen.Length.Should().BeGreaterThan(2);
        }
    }

    internal record TrustDataSet
    {
        public Trust Trust { get; set; }
        public List<EstablishmentDataSet> Establishments { get; set; }
    }

    internal record EstablishmentDataSet
    {
        public Establishment Establishment { get; set; }
        public IfdPipeline IfdPipeline { get; set; }
    }
}
