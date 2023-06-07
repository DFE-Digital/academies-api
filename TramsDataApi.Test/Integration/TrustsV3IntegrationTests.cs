﻿using System;
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

namespace TramsDataApi.Test.Integration
{
    [Collection("Database")]
    public class TrustsV3IntegrationTests : IClassFixture<TramsDataApiFactory>, IDisposable
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
            result.Data.MasterTrustData.Should().BeEquivalentTo(expectedTrustData);
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
            result.Data.MasterTrustData.Should().BeNull();
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
            result.Data.MasterTrustData.NumberInTrust.Should().Be(trustMasterData.NumberInTrust.ToString());
            result.Data.GiasData.Ukprn.Should().Be(groupData.Ukprn);

            result.Data.Establishments.Should().HaveCount(1);
            var establishment = result.Data.Establishments[0];
            establishment.Ukprn.Should().Be(establishmentData.Ukprn);
        }

        [Fact]
        public async Task ShouldReturnAllTrusts_WhenSearchingTrusts_WithNoQueryParameters()
        {
            var groups = BuildGroups();
            _legacyDbContext.Group.AddRange(groups);

            _legacyDbContext.SaveChanges();

            var httpRequestMessage = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($"{_apiUrlPrefix}/trusts"),
            };

            var response = await _client.SendAsync(httpRequestMessage);
            var jsonString = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<ApiResponseV2<TrustSummaryResponse>>(jsonString);

            response.StatusCode.Should().Be(HttpStatusCode.OK);

            result.Data.Should().HaveCount(3);
        }

        [Fact]
        public async Task ShouldReturnAllTrusts_WhenSearchingTrusts_ByUniqueGroupName()
        {
            var groupData = BuildGroups().First();
            _legacyDbContext.Group.AddRange(groupData);

            var trustMasterData = BuildMasterTrustData(groupData);
            _legacyDbContext.TrustMasterData.AddRange(trustMasterData);

            _legacyDbContext.SaveChanges();

            var httpRequestMessage = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($"{_apiUrlPrefix}/trusts?groupName={groupData.GroupName}"),
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

        [Fact]
        public async Task ShouldReturnSubsetOfTrusts_WhenSearchingTrusts_ByCompaniesHouseNumber()
        {
            var companiesHouseNumber = _fixture.Create<string>();
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
                RequestUri = new Uri($"{_apiUrlPrefix}/trusts?companiesHouseNumber={companiesHouseNumber}&includeEstablishments=false"),
            };

            var response = await _client.SendAsync(httpRequestMessage);
            var jsonString = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<ApiResponseV2<TrustSummaryResponse>>(jsonString);

            result.Data.Should().HaveCount(1);

            var trustData = result.Data.First();

            trustData.CompaniesHouseNumber.Should().Be(companiesHouseNumber);

            trustData.Establishments.Should().HaveCount(0);
        }

        [Fact]
        public async Task ShouldReturnSubsetOfTrusts_WhenSearchingTrusts_ByUkPrn()
        {
            var ukPrn = _fixture.Create<string>();
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
                RequestUri = new Uri($"{_apiUrlPrefix}/trusts?ukprn={ukPrn}"),
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


        public void Dispose()
        {
            _legacyDbContext.Group.RemoveRange(_legacyDbContext.Group);
            _legacyDbContext.Establishment.RemoveRange(_legacyDbContext.Establishment);
            _legacyDbContext.TrustMasterData.RemoveRange(_legacyDbContext.TrustMasterData);

            _legacyDbContext.SaveChanges();
        }

        private static TrustMasterData BuildMasterTrustData(Group groupData)
        {
            var result = _fixture.Create<TrustMasterData>();
            result.RID = result.RID.Substring(0,10);
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
