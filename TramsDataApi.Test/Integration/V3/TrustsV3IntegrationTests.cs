using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using AutoFixture;
using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using TramsDataApi.DatabaseModels;
using TramsDataApi.ResponseModels;
using Xunit;

namespace TramsDataApi.Test.Integration.V3
{
    [Collection("Database")]
    public class TrustsV3IntegrationTests : IClassFixture<TramsDataApiFactory>
    {
        private readonly HttpClient _client;
        private readonly LegacyTramsDbContext _legacyDbContext;
        private static readonly Fixture _fixture = new Fixture();

        private readonly string _apiUrlPrefix = "https://trams-api.com/v3";

        public TrustsV3IntegrationTests(TramsDataApiFactory fixture)
        {
            _client = fixture.CreateClient();
            _client.DefaultRequestHeaders.Add("ApiKey", "testing-api-key");
            _client.BaseAddress = new Uri("https://trams-api.com/");
            _legacyDbContext = fixture.Services.GetRequiredService<LegacyTramsDbContext>();

            _legacyDbContext.Group.RemoveRange(_legacyDbContext.Group);
            _legacyDbContext.Establishment.RemoveRange(_legacyDbContext.Establishment);
            _legacyDbContext.TrustMasterData.RemoveRange(_legacyDbContext.TrustMasterData);

            _legacyDbContext.SaveChanges();
        }

        [Fact]
        public async Task ShouldReturnNull_WhenSearchingByUkprn_AndTrustDoesNotExist()
        {
            var httpRequestMessage = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($"{_apiUrlPrefix}/trust/mockukprn"),
                Headers = {
                    { "ApiKey", "testing-api-key" }
                }
            };

            var response = await _client.SendAsync(httpRequestMessage);

            response.StatusCode.Should().Be(HttpStatusCode.NotFound);
        }

        [Fact]
        public async Task ShouldReturnTrust_WhenSearchingByUkprn_AndTrustExists()
        {
            var groupData = _fixture.Create<Group>();
            _legacyDbContext.Group.Add(groupData);

            var trustMasterData = BuildMasterTrustData(groupData);
            _legacyDbContext.TrustMasterData.Add(trustMasterData);

            _legacyDbContext.SaveChanges();

            var httpRequestMessage = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($"{_apiUrlPrefix}/trust/{trustMasterData.UKPRN}"),
            };

            var expectedTrustData = new MasterTrustDataResponse
            {

                TrustContactPhoneNumber = trustMasterData.MainPhone,
                PerformanceAndRiskDateOfMeeting = trustMasterData.TrustPerformanceAndRiskDateOfMeeting?.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture),
                PrioritisedAreaOfReview = trustMasterData.PrioritisedForReview,
                CurrentSingleListGrouping = trustMasterData.CurrentSingleListGrouping,
                DateOfGroupingDecision = trustMasterData.DateOfGroupingDecision?.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture),
                DateEnteredOntoSingleList = trustMasterData.DateEnteredOntoSingleList?.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture),
                TrustReviewWriteup = trustMasterData.TrustReviewWriteUp,
                DateOfTrustReviewMeeting = trustMasterData.TrustPerformanceAndRiskDateOfMeeting?.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture),
                DateActionPlannedFor = trustMasterData.DateActionPlannedFor?.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture),
                WIPSummaryGoesToMinister = trustMasterData.WIPSummaryGoesToMinister,
                ExternalGovernanceReviewDate =
                        trustMasterData.ExternalGovernanceReviewDate?.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture),
                EfficiencyICFPreviewCompleted = trustMasterData.EfficiencyICFPReviewCompleted,
                EfficiencyICFPreviewOther = trustMasterData.EfficiencyICFPReviewOther,
                LinkToWorkplaceForEfficiencyICFReview =
                        trustMasterData.LinkToWorkplaceForEfficiencyICFPReview,
                FollowupLetterSent = trustMasterData.FollowUpLetterSent,
                NumberInTrust = trustMasterData.NumberInTrust.ToString(),
                TrustType = trustMasterData.TrustsTrustType.ToString(),
                TrustAddress = new AddressResponse
                {
                    Street = trustMasterData.AddressLine1,
                    AdditionalLine = trustMasterData.AddressLine2,
                    Locality = trustMasterData.AddressLine3,
                    Town = trustMasterData.Town,
                    County = trustMasterData.County,
                    Postcode = trustMasterData.Postcode
                }
            };

            var expectedGiasData = BuildExpectedGias(groupData);

            var response = await _client.SendAsync(httpRequestMessage);
            var jsonString = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<ApiSingleResponseV2<MasterTrustResponse>>(jsonString);


            response.StatusCode.Should().Be(HttpStatusCode.OK);
            result.Data.TrustData.Should().BeEquivalentTo(expectedTrustData);
            result.Data.GiasData.Should().BeEquivalentTo(expectedGiasData);
            result.Data.Establishments.Should().BeEmpty();
        }

        [Fact]
        public async Task ShouldReturnNullForIfdData_WhenNoCorrespondingIfdTrustIsFound()
        {
            var groupData = _fixture.Create<Group>();
            _legacyDbContext.Group.Add(groupData);

            var trustMasterData = BuildMasterTrustData(groupData);
            trustMasterData.GroupID = "NotAGroupId";

            _legacyDbContext.TrustMasterData.Add(trustMasterData);

            _legacyDbContext.SaveChanges();

            var httpRequestMessage = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($"{_apiUrlPrefix}/trust/{trustMasterData.UKPRN}"),
            };

            var expectedGiasData = BuildExpectedGias(groupData);

            var response = await _client.SendAsync(httpRequestMessage);
            var jsonString = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<ApiSingleResponseV2<MasterTrustResponse>>(jsonString);


            response.StatusCode.Should().Be(HttpStatusCode.OK);
            result.Data.TrustData.Should().BeNull();
            result.Data.GiasData.Should().BeEquivalentTo(expectedGiasData);
            result.Data.Establishments.Should().BeEmpty();
        }

        [Fact]
        public async Task ShouldReturnEstablishmentData_WhenTrustHasAnEstablishment()
        {
            var groupData = _fixture.Create<Group>();
            _legacyDbContext.Group.Add(groupData);

            var trustMasterData = BuildMasterTrustData(groupData);
            _legacyDbContext.TrustMasterData.Add(trustMasterData);

            var establishmentData = _fixture.Create<Establishment>();
            establishmentData.TrustsCode = groupData.GroupUid;
            _legacyDbContext.Establishment.Add(establishmentData);

            _legacyDbContext.SaveChanges();

            var httpRequestMessage = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($"{_apiUrlPrefix}/trust/{trustMasterData.UKPRN}"),
            };

            var response = await _client.SendAsync(httpRequestMessage);
            var jsonString = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<ApiSingleResponseV2<MasterTrustResponse>>(jsonString);

            response.StatusCode.Should().Be(HttpStatusCode.OK);
            result.Data.TrustData.NumberInTrust.Should().Be(trustMasterData.NumberInTrust.ToString());
            result.Data.GiasData.Ukprn.Should().Be(groupData.Ukprn);

            result.Data.Establishments.Should().HaveCount(1);
            var establishment = result.Data.Establishments[0];
            establishment.Ukprn.Should().Be(establishmentData.Ukprn);
        }

        /// <summary>
        /// Test covers data scenario where we have two records in the group table with nearly identical information. Assumption made that primary key of Open Trusts is higher than closed record.
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task ShouldReturnEstablishmentDataAgainstOpenTrust_WhenTrustHasAnEstablishmentAndHasBeenOpenedAndClosedWithSameUKPRN()
        {
            //Arrange
            string groupID = "TR02545";
            string TrustName = "Trust A";
            string TrustUKPRN = "123456789";

            var closedTrustGroup = _fixture.Build<Group>()
                .With(f => f.GroupUid, "234")
                .With(f => f.GroupId, groupID)
                .With(f => f.GroupName, TrustName)
                .With(f => f.Ukprn, TrustUKPRN)
                .With(f => f.GroupStatus, "Closed")
                .With(f => f.GroupStatusCode, "CLOSED")
                .With(f => f.GroupType, "Single-academy trust")
                .Without(p => p.CompaniesHouseNumber)
                .Create();

            var openTrustGroup = _fixture.Build<Group>()
                .With(f => f.GroupUid, "1234")
                .With(f => f.GroupId, groupID)
                .With(f => f.GroupName, TrustName)
                .With(f => f.Ukprn, TrustUKPRN)
                .With(f => f.GroupStatus, "Open")
                .With(f => f.GroupStatusCode, "OPEN")
                .With(f => f.GroupType, "Multi-academy trust")
                .Create();

            _legacyDbContext.Group.AddRange(closedTrustGroup, openTrustGroup);


            var trustMasterData = BuildMasterTrustData(openTrustGroup);
            _legacyDbContext.TrustMasterData.Add(trustMasterData);

            var establishmentData = _fixture.Create<Establishment>();
            establishmentData.TrustsCode = openTrustGroup.GroupUid;
            _legacyDbContext.Establishment.Add(establishmentData);

            _legacyDbContext.SaveChanges();

            //Act
            var httpRequestMessage = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($"{_apiUrlPrefix}/trust/{trustMasterData.UKPRN}"),
            };

            var response = await _client.SendAsync(httpRequestMessage);
            var jsonString = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<ApiSingleResponseV2<MasterTrustResponse>>(jsonString);

            //Assert
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            result.Data.TrustData.NumberInTrust.Should().Be(trustMasterData.NumberInTrust.ToString());
            result.Data.GiasData.Ukprn.Should().Be(openTrustGroup.Ukprn);

            result.Data.Establishments.Should().HaveCount(1);
            var establishment = result.Data.Establishments[0];
            establishment.Ukprn.Should().Be(establishmentData.Ukprn);
        }

        [Fact]
        public async Task ShouldReturnAllTrusts_WhenSearchingTrusts_WithNoQueryParametersAndPagination()
        {
            var allGroups = new List<Group>();

            for (var idx = 0; idx < 10; idx++)
            {
                var groups = BuildGroups();
                _legacyDbContext.Group.AddRange(groups);
                allGroups.AddRange(groups);
            }
            var allTrustsSorted = allGroups.OrderBy(group => group.GroupUid).ToList();

            _legacyDbContext.SaveChanges();

            var httpRequestMessage = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($"{_apiUrlPrefix}/trusts?page=2&count=10"),
            };

            var response = await _client.SendAsync(httpRequestMessage);
            var jsonString = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<ApiResponseV2<TrustSummaryResponse>>(jsonString);

            response.StatusCode.Should().Be(HttpStatusCode.OK);

            result.Data.Should().HaveCount(10);

            var expectedTrusts = allTrustsSorted.Skip(10).Take(10).Select(t => t.Ukprn).ToList();
            var actualTrusts = result.Data.Select(t => t.Ukprn).ToList();

            actualTrusts.Should().BeEquivalentTo(expectedTrusts);
        }

        [Theory]
        [InlineData("My Group Name")]
        [InlineData("my group")]
        public async Task ShouldReturnAllTrusts_WhenSearchingTrusts_ByUniqueGroupName(string searchString)
        {
            var groupData = BuildGroups().First();
            groupData.GroupName = "My Group Name";
            _legacyDbContext.Group.AddRange(groupData);

            var trustMasterData = BuildMasterTrustData(groupData);
            _legacyDbContext.TrustMasterData.AddRange(trustMasterData);

            var groupsWithoutGroupName = BuildGroups();
            _legacyDbContext.Group.AddRange(groupsWithoutGroupName);

            _legacyDbContext.SaveChanges();

            var httpRequestMessage = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($"{_apiUrlPrefix}/trusts?groupName={searchString}"),
            };

            var response = await _client.SendAsync(httpRequestMessage);
            var jsonString = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<ApiResponseV2<TrustSummaryResponse>>(jsonString);

            response.StatusCode.Should().Be(HttpStatusCode.OK);

            result.Data.Should().HaveCountGreaterOrEqualTo(1);

            var trustResult = result.Data.First(d => d.Ukprn == groupData.Ukprn);

            trustResult.Should().BeEquivalentTo(BuildExpectedMasterTrustSummary(groupData, trustMasterData));
        }

        [Fact]
        public async Task ShouldReturnSubsetOfTrusts_WhenSearchingTrusts_ByGroupName()
        {
            var groupName = _fixture.Create<string>();
            var groupWithGroupName = BuildGroups();
            groupWithGroupName.ToList().ForEach(g => g.GroupName = groupName);
            _legacyDbContext.Group.AddRange(groupWithGroupName);

            var groupsWithoutGroupName = BuildGroups();
            _legacyDbContext.Group.AddRange(groupsWithoutGroupName);

            _legacyDbContext.SaveChanges();

            var httpRequestMessage = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($"{_apiUrlPrefix}/trusts?groupName={groupName}"),
            };

            var response = await _client.SendAsync(httpRequestMessage);
            var jsonString = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<ApiResponseV2<TrustSummaryResponse>>(jsonString);

            result.Data.Should().HaveCount(groupWithGroupName.Count());

            groupWithGroupName.ForEach(g =>
            {
                var matchingGroup = result.Data.First(r => r.Ukprn == g.Ukprn);
                matchingGroup.GroupName.Should().Be(groupName);
            });
        }

        [Theory]
        [InlineData("123456789")]
        [InlineData("12345")]
        public async Task ShouldReturnSubsetOfTrusts_WhenSearchingTrusts_ByCompaniesHouseNumber(string searchString)
        {
            var companiesHouseNumber = "123456789";
            var groupWithCompaniesHouse = BuildGroups().First();
            groupWithCompaniesHouse.CompaniesHouseNumber = companiesHouseNumber;
            _legacyDbContext.Group.Add(groupWithCompaniesHouse);

            var groupsWithoutCompaniesHouse = BuildGroups();
            _legacyDbContext.Group.AddRange(groupsWithoutCompaniesHouse);

            var establishmentData = _fixture.Create<Establishment>();
            establishmentData.TrustsCode = groupWithCompaniesHouse.GroupUid;
            _legacyDbContext.Establishment.Add(establishmentData);

            _legacyDbContext.SaveChanges();

            var httpRequestMessage = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($"{_apiUrlPrefix}/trusts?companiesHouseNumber={searchString}&includeEstablishments=false"),
            };

            var response = await _client.SendAsync(httpRequestMessage);
            var jsonString = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<ApiResponseV2<TrustSummaryResponse>>(jsonString);

            result.Data.Should().HaveCount(1);

            var trustData = result.Data.First();

            trustData.CompaniesHouseNumber.Should().Be(companiesHouseNumber);

            trustData.Establishments.Should().HaveCount(0);
        }

        [Theory]
        [InlineData("126434676534")]
        [InlineData("1264")]
        public async Task ShouldReturnSubsetOfTrusts_WhenSearchingTrusts_ByUkPrn(string searchString)
        {
            var ukPrn = "126434676534";
            var groupWithUkPrn = BuildGroups().First();
            groupWithUkPrn.Ukprn = ukPrn;
            _legacyDbContext.Group.Add(groupWithUkPrn);

            var groupsWithoutUkPrn = BuildGroups();
            _legacyDbContext.Group.AddRange(groupsWithoutUkPrn);

            var establishmentData = _fixture.Create<Establishment>();
            establishmentData.TrustsCode = groupWithUkPrn.GroupUid;
            _legacyDbContext.Establishment.Add(establishmentData);

            _legacyDbContext.SaveChanges();

            var httpRequestMessage = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($"{_apiUrlPrefix}/trusts?ukprn={searchString}"),
            };

            var response = await _client.SendAsync(httpRequestMessage);
            var jsonString = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<ApiResponseV2<TrustSummaryResponse>>(jsonString);

            result.Data.Should().HaveCount(1);

            var trustData = result.Data.First();

            trustData.Ukprn.Should().Be(ukPrn);

            trustData.Establishments.Should().HaveCount(1);
            var establishment = trustData.Establishments[0];
            establishment.Ukprn.Should().Be(establishmentData.Ukprn);
        }

        [Fact]
        public async Task ShouldReturnNoResults_WhenSearchingTrusts_ByTrustThatDoesNotExist()
        {
            var groups = BuildGroups();
            _legacyDbContext.Group.AddRange(groups);

            _legacyDbContext.SaveChanges();

            var httpRequestMessage = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($"{_apiUrlPrefix}/trusts?ukprn=NotExist"),
            };

            var response = await _client.SendAsync(httpRequestMessage);
            var jsonString = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<ApiResponseV2<TrustSummaryResponse>>(jsonString);

            result.Data.Should().HaveCount(0);
        }

        private static TrustMasterData BuildMasterTrustData(Group groupData)
        {
            var result = _fixture.Create<TrustMasterData>();
            result.RID = result.RID.Substring(0, 10);
            result.CurrentSingleListGrouping = "Auto";
            result.FollowUpLetterSent = "yes";
            result.PrioritisedForReview = "no";
            result.Region = null;
            result.TrustBanding = null;
            result.FK_TrustStatus = null;
            result.TrustsTrustType = null;
            result.UKPRN = groupData.Ukprn;
            result.GroupID = groupData.GroupId;

            return result;
        }

        private static List<Group> BuildGroups()
        {
            var result = _fixture.CreateMany<Group>().ToList();

            result.ForEach(g => g.GroupType = "Multi-academy trust");

            return result;
        }

        private static GIASDataResponse BuildExpectedGias(Group groupData)
        {
            return new GIASDataResponse
            {
                GroupId = groupData.GroupId,
                GroupName = groupData.GroupName,
                GroupType = groupData.GroupType,
                CompaniesHouseNumber = groupData.CompaniesHouseNumber,
                GroupContactAddress = new AddressResponse
                {
                    Street = groupData.GroupContactStreet,
                    AdditionalLine = groupData.GroupContactAddress3,
                    Locality = groupData.GroupContactLocality,
                    Town = groupData.GroupContactTown,
                    County = groupData.GroupContactCounty,
                    Postcode = groupData.GroupContactPostcode
                },
                Ukprn = groupData.Ukprn
            };
        }

        private static TrustSummaryResponse BuildExpectedMasterTrustSummary(Group group, TrustMasterData trust)
        {
            return new TrustSummaryResponse
            {
                Ukprn = group.Ukprn,
                GroupName = group.GroupName,
                CompaniesHouseNumber = group.CompaniesHouseNumber,
                TrustType = trust?.TrustsTrustType.ToString(),
                TrustAddress = new AddressResponse
                {
                    Street = trust?.AddressLine1,
                    AdditionalLine = trust?.AddressLine2,
                    Locality = trust?.AddressLine3,
                    Town = trust?.Town,
                    County = trust?.County,
                    Postcode = trust?.Postcode
                },
                Establishments = new List<EstablishmentSummaryResponse>()
            };
        }
    }
}
