using AutoFixture;
using Dfe.Academies.Academisation.Data;
using Dfe.Academies.Contracts.V4;
using Dfe.Academies.Contracts.V4.Trusts;
using Dfe.Academies.Domain.Trust;
using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using TramsDataApi.DatabaseModels;
using TramsDataApi.Test.Helpers;
using Xunit;

namespace TramsDataApi.Test.Integration.V4
{
    public class TrustV4IntegrationTests
    {
        [Collection("Database")]
        public class TrustsV4IntegrationTests : IClassFixture<TramsDataApiFactory>
        {
            private readonly HttpClient _client;
            private static readonly Fixture _autoFixture = new Fixture();
            private readonly TramsDataApiFactory _apiFixture;

            private readonly string _apiUrlPrefix = "https://trams-api.com/v4";

            public TrustsV4IntegrationTests(TramsDataApiFactory fixture)
            {
                _apiFixture = fixture;
                _client = fixture.CreateClient();
                _client.DefaultRequestHeaders.Add("ApiKey", "testing-api-key");
                _client.BaseAddress = new Uri("https://trams-api.com/");

                using var context = _apiFixture.GetMstrContext();

                context.Trusts.RemoveRange(context.Trusts);
                context.TrustTypes.RemoveRange(context.TrustTypes);

                context.TrustTypes.Add(new TrustType() { SK = 30, Code = "06", Name = "Multi-academy trust" });
                context.TrustTypes.Add(new TrustType() { SK = 32, Code = "10", Name = "Single-academy trust" });
                context.SaveChanges();
            }

            [Fact]
            public async Task Get_TrustByUkPrn_AndTrustDoesNotExist_Returns_NotFound()
            {
                var response = await _client.GetAsync($"{_apiUrlPrefix}/trust/mockukprn");

                response.StatusCode.Should().Be(HttpStatusCode.NotFound);
            }

            [Fact]
            public async Task Get_TrustByUkPrn_AndTrustExists_Returns_Ok()
            {
                var trustData = DatabaseModelBuilder.BuildTrust();

                using var context = _apiFixture.GetMstrContext();

                context.Trusts.Add(trustData);
                context.SaveChanges();

                var trustResponse = await _client.GetAsync($"{_apiUrlPrefix}/trust/{trustData.UKPRN}");
                trustResponse.StatusCode.Should().Be(HttpStatusCode.OK);

                var trustContent = await trustResponse.Content.ReadFromJsonAsync<TrustDto>();

                AssertTrustResponse(trustContent, trustData);
            }

            [Fact]
            public async Task Get_TrustByCompaniesHouse_AndTrustDoesNotExist_Returns_NotFound()
            {
                var response = await _client.GetAsync($"{_apiUrlPrefix}/trust/companiesHouseNumber/mockukprn");

                response.StatusCode.Should().Be(HttpStatusCode.NotFound);
            }

            [Fact]
            public async Task Get_TrustByCompaniesHouse_AndTrustExists_Returns_Ok()
            {
                var trustData = DatabaseModelBuilder.BuildTrust();

                using var context = _apiFixture.GetMstrContext();

                context.Trusts.Add(trustData);
                context.SaveChanges();

                var trustResponse = await _client.GetAsync($"{_apiUrlPrefix}/trust/companiesHouseNumber/{trustData.CompaniesHouseNumber}");
                trustResponse.StatusCode.Should().Be(HttpStatusCode.OK);

                var trustContent = await trustResponse.Content.ReadFromJsonAsync<TrustDto>();

                AssertTrustResponse(trustContent, trustData);
            }

            [Fact]
            public async Task Get_TrustByTrustReferenceNumber_AndTrustDoesNotExist_Returns_NotFound()
            {
                var response = await _client.GetAsync($"{_apiUrlPrefix}/trust/trustReferenceNumber/mockukprn");

                response.StatusCode.Should().Be(HttpStatusCode.NotFound);
            }

            [Fact]
            public async Task Get_TrustByTrustReferenceNumber_AndTrustExists_Returns_Ok()
            {
                var trustData = DatabaseModelBuilder.BuildTrust();

                using var context = _apiFixture.GetMstrContext();

                context.Trusts.Add(trustData);
                context.SaveChanges();

                var trustResponse = await _client.GetAsync($"{_apiUrlPrefix}/trust/trustReferenceNumber/{trustData.GroupID}");
                trustResponse.StatusCode.Should().Be(HttpStatusCode.OK);

                var trustContent = await trustResponse.Content.ReadFromJsonAsync<TrustDto>();

                AssertTrustResponse(trustContent, trustData);
            }

            [Fact]
            public async Task Get_TrustBulk_AndTrustDoesNotExist_Returns_Empty_Ok()
            {
                var response = await _client.GetAsync($"{_apiUrlPrefix}/trusts/bulk?ukprns=mockukprn");

                response.StatusCode.Should().Be(HttpStatusCode.OK);

                var trusts = await response.Content.ReadFromJsonAsync<List<TrustDto>>();

                trusts.Should().HaveCount(0);
            }

            [Fact]
            public async Task Get_TrustBulk_AndTrustsExist_Returns_Ok()
            {
                var firstTrust = DatabaseModelBuilder.BuildTrust();
                var secondTrust = DatabaseModelBuilder.BuildTrust();

                using var context = _apiFixture.GetMstrContext();

                context.Trusts.Add(firstTrust);
                context.Trusts.Add(secondTrust);
                context.SaveChanges();

                var trustResponse = await _client.GetAsync($"{_apiUrlPrefix}/trusts/bulk?ukprns={firstTrust.UKPRN}&ukprns={secondTrust.UKPRN}");
                trustResponse.StatusCode.Should().Be(HttpStatusCode.OK);

                var trustContent = await trustResponse.Content.ReadFromJsonAsync<List<TrustDto>>();

                trustContent.Should().HaveCount(2);

                var actualFirstTrust = trustContent.First(t => t.Ukprn == firstTrust.UKPRN);
                AssertTrustResponse(actualFirstTrust, firstTrust);

                var actualSecondTrust = trustContent.First(t => t.Ukprn == secondTrust.UKPRN);
                AssertTrustResponse(actualSecondTrust, secondTrust);
            }

            // This will be covered when support for searching closed trusts is added
            ///// <summary>
            ///// Test covers data scenario where we have two records in the group table with nearly identical information. Assumption made that primary key of Open Trusts is higher than closed record.
            ///// </summary>
            ///// <returns></returns>
            //[Fact]
            //public async Task ShouldReturnEstablishmentDataAgainstOpenTrust_WhenTrustHasAnEstablishmentAndHasBeenOpenedAndClosedWithSameUKPRN()
            //{
            //    //Arrange
            //    string groupID = "TR02545";
            //    string TrustName = "Trust A";
            //    string TrustUKPRN = "123456789";

            //    var closedTrustGroup = _fixture.Build<Group>()
            //        .With(f => f.GroupUid, "1")
            //        .With(f => f.GroupId, groupID)
            //        .With(f => f.GroupName, TrustName)
            //        .With(f => f.Ukprn, TrustUKPRN)
            //        .With(f => f.GroupStatus, "Closed")
            //        .With(f => f.GroupStatusCode, "CLOSED")
            //        .With(f => f.GroupType, "Single-academy trust")
            //        .Without(p => p.CompaniesHouseNumber)
            //        .Create();

            //    var openTrustGroup = _fixture.Build<Group>()
            //        .With(f => f.GroupUid, "2")
            //        .With(f => f.GroupId, groupID)
            //         .With(f => f.GroupName, TrustName)
            //         .With(f => f.Ukprn, TrustUKPRN)
            //         .With(f => f.GroupStatus, "Open")
            //         .With(f => f.GroupStatusCode, "OPEN")
            //         .With(f => f.GroupType, "Multi-academy trust")
            //         .Create();

            //    _legacyDbContext.Group.AddRange(closedTrustGroup, openTrustGroup);


            //    var trustMasterData = BuildMasterTrustData(openTrustGroup);
            //    _legacyDbContext.TrustMasterData.Add(trustMasterData);

            //    var establishmentData = _fixture.Create<Establishment>();
            //    establishmentData.TrustsCode = openTrustGroup.GroupUid;
            //    _legacyDbContext.Establishment.Add(establishmentData);

            //    _legacyDbContext.SaveChanges();

            //    //Act
            //    var httpRequestMessage = new HttpRequestMessage
            //    {
            //        Method = HttpMethod.Get,
            //        RequestUri = new Uri($"{_apiUrlPrefix}/trust/{trustMasterData.UKPRN}"),
            //    };

            //    var response = await _client.SendAsync(httpRequestMessage);
            //    var jsonString = await response.Content.ReadAsStringAsync();
            //    var result = JsonConvert.DeserializeObject<ApiSingleResponseV2<MasterTrustResponse>>(jsonString);

            //    //Assert
            //    response.StatusCode.Should().Be(HttpStatusCode.OK);
            //    result.Data.TrustData.NumberInTrust.Should().Be(trustMasterData.NumberInTrust.ToString());
            //    result.Data.GiasData.Ukprn.Should().Be(openTrustGroup.Ukprn);

            //    result.Data.Establishments.Should().HaveCount(1);
            //    var establishment = result.Data.Establishments[0];
            //    establishment.Ukprn.Should().Be(establishmentData.Ukprn);
            //}

            [Fact]
            public async Task Get_SearchByCriteria_Pagination_Returns_Ok()
            {
                using var context = _apiFixture.GetMstrContext();

                var groupName = _autoFixture.Create<string>();
                var trustsWithName = BuildLargeTrustSet();
                trustsWithName.ToList().ForEach(t => 
                {
                    t.Name = groupName;
                    context.Trusts.Add(t);
                    context.SaveChanges();
                });

                var allTrustsSorted = trustsWithName.OrderBy(trust => trust.GroupUID).ToList();

                var distinctIds = trustsWithName.Select(t => t.SK).Distinct().ToList();

                var totalTrusts = context.Trusts.Count();
                var trustIds = context.Trusts.Select(t => t.SK).ToList();
                var missing = trustIds.Where(t => !distinctIds.Contains(t)).ToList();

                // Page one
                var pageOneTrustResponse = await _client.GetAsync($"{_apiUrlPrefix}/trusts?groupName={groupName}&page=1&count=5");
                pageOneTrustResponse.StatusCode.Should().Be(HttpStatusCode.OK);

                var pageOneTrustContent = await pageOneTrustResponse.Content.ReadFromJsonAsync<PagedDataResponse<TrustDto>>();

                pageOneTrustContent.Data.Should().HaveCount(5);
                pageOneTrustContent.Paging.RecordCount.Should().Be(20);
                pageOneTrustContent.Paging.Page.Should().Be(1);

                var pageOneExpectedTrusts = allTrustsSorted.Skip(0).Take(5).Select(t => t.UKPRN).ToList();
                var pageOneActualTrusts = pageOneTrustContent.Data.Select(t => t.Ukprn).ToList();
                pageOneActualTrusts.Should().BeEquivalentTo(pageOneExpectedTrusts);

                // Page 3
                var pageThreeTrustResponse = await _client.GetAsync($"{_apiUrlPrefix}/trusts?groupName={groupName}&page=3&count=5");
                pageThreeTrustResponse.StatusCode.Should().Be(HttpStatusCode.OK);

                var pageThreeTrustContent = await pageThreeTrustResponse.Content.ReadFromJsonAsync<PagedDataResponse<TrustDto>>();

                pageThreeTrustContent.Data.Should().HaveCount(5);
                pageThreeTrustContent.Paging.RecordCount.Should().Be(20);
                pageThreeTrustContent.Paging.Page.Should().Be(3);

                var pageThreeExpectedTrusts = allTrustsSorted.Skip(10).Take(5).Select(t => t.UKPRN).ToList();
                var pageThreeActualTrusts = pageThreeTrustContent.Data.Select(t => t.Ukprn).ToList();
                pageThreeActualTrusts.Should().BeEquivalentTo(pageThreeExpectedTrusts);
            }

            [Theory]
            [InlineData("My first trust", "My first trust")]
            [InlineData("my second trust", "My SECOND")]
            public async Task Get_SearchByCriteria_ByUniqueGroupName_Returns_Ok(string trustName, string searchString)
            {
                var trustData = DatabaseModelBuilder.BuildTrust();
                trustData.Name = trustName;

                using var context = _apiFixture.GetMstrContext();

                context.Trusts.Add(trustData);
                context.SaveChanges();

                var trustResponse = await _client.GetAsync($"{_apiUrlPrefix}/trusts?groupName={searchString}");
                trustResponse.StatusCode.Should().Be(HttpStatusCode.OK);

                var trustContent = await trustResponse.Content.ReadFromJsonAsync<PagedDataResponse<TrustDto>>();

                trustContent.Data.Should().HaveCount(1);

                var trustResult = trustContent.Data.First(d => d.Ukprn == trustData.UKPRN);

                trustResult.Name.Should().Be(trustData.Name);
                trustResult.CompaniesHouseNumber.Should().Be(trustData.CompaniesHouseNumber);
                trustResult.ReferenceNumber.Should().Be(trustData.GroupID);
                trustResult.Ukprn.Should().Be(trustData.UKPRN);
                trustResult.Type.Code.Should().Be("06");
                trustResult.Type.Name.Should().Be("Multi-academy trust");
                trustResult.Address.Street.Should().Be(trustData.AddressLine1);
                trustResult.Address.Town.Should().Be(trustData.Town);
                trustResult.Address.Postcode.Should().Be(trustData.Postcode);
                trustResult.Address.County.Should().Be(trustData.County);
                trustResult.Address.Additional.Should().Be(trustData.AddressLine2);
            }

            [Theory]
            [InlineData("123456789")]
            [InlineData("12345")]
            public async Task Get_SearchByCriteria_ByCompaniesHouse_Returns_Ok(string searchString)
            {
                var companiesHouseNumber = "123456789";
                var trustWithCompaniesHouse = DatabaseModelBuilder.BuildTrust();
                trustWithCompaniesHouse.CompaniesHouseNumber = companiesHouseNumber;

                var trustWithoutCompaniesHouse = DatabaseModelBuilder.BuildTrust();

                using var context = _apiFixture.GetMstrContext();

                context.Trusts.AddRange(trustWithCompaniesHouse, trustWithoutCompaniesHouse);
                context.SaveChanges();

                var trustResponse = await _client.GetAsync($"{_apiUrlPrefix}/trusts?companiesHouseNumber={searchString}");
                trustResponse.StatusCode.Should().Be(HttpStatusCode.OK);

                var trustContent = await trustResponse.Content.ReadFromJsonAsync<PagedDataResponse<TrustDto>>();

                trustContent.Data.Should().HaveCount(1);

                var trustData = trustContent.Data.First();

                trustData.CompaniesHouseNumber.Should().Be(companiesHouseNumber);
            }

            [Theory]
            [InlineData("126434676534")]
            [InlineData("1264")]
            public async Task Get_SearchByCriteria_ByUkPrn_Returns_Ok(string searchString)
            {
                var ukPrn = "126434676534";
                var trustWithUkPrn = DatabaseModelBuilder.BuildTrust();
                trustWithUkPrn.UKPRN = ukPrn;

                var trustWithoutUkPrn = DatabaseModelBuilder.BuildTrust();

                using var context = _apiFixture.GetMstrContext();

                context.Trusts.AddRange(trustWithUkPrn, trustWithoutUkPrn);

                context.SaveChanges();

                var trustResponse = await _client.GetAsync($"{_apiUrlPrefix}/trusts?ukprn={searchString}");
                trustResponse.StatusCode.Should().Be(HttpStatusCode.OK);


                var trustContent = await trustResponse.Content.ReadFromJsonAsync<PagedDataResponse<TrustDto>>();

                trustContent.Data.Should().HaveCount(1);

                var trustData = trustContent.Data.First();

                trustData.Ukprn.Should().Be(ukPrn);
            }

            [Fact]
            public async Task Get_SearchByCriteria_NoTrustExists_Returns_Empty_Ok()
            {
                var trustResponse = await _client.GetAsync($"{_apiUrlPrefix}/trusts?ukprn=NotExist");
                trustResponse.StatusCode.Should().Be(HttpStatusCode.OK);

                var trustContent = await trustResponse.Content.ReadFromJsonAsync<PagedDataResponse<TrustDto>>();

                trustContent.Data.Should().HaveCount(0);
            }

            private static List<Dfe.Academies.Domain.Trust.Trust> BuildLargeTrustSet()
            {
                var result = new List<Dfe.Academies.Domain.Trust.Trust>();

                for (var idx = 0; idx < 20; idx++)
                {
                    var trust = DatabaseModelBuilder.BuildTrust();
                    trust.SK = idx + 1;
                    result.Add(trust);
                }

                return result;

            }

            private static void AssertTrustResponse(TrustDto actual, Dfe.Academies.Domain.Trust.Trust expected)
            {
                actual.Name.Should().Be(expected.Name);
                actual.CompaniesHouseNumber.Should().Be(expected.CompaniesHouseNumber);
                actual.ReferenceNumber.Should().Be(expected.GroupID);
                actual.Ukprn.Should().Be(expected.UKPRN);
                actual.Type.Code.Should().Be("06");
                actual.Type.Name.Should().Be("Multi-academy trust");
                actual.Address.Street.Should().Be(expected.AddressLine1);
                actual.Address.Town.Should().Be(expected.Town);
                actual.Address.Postcode.Should().Be(expected.Postcode);
                actual.Address.County.Should().Be(expected.County);
                actual.Address.Additional.Should().Be(expected.AddressLine2);
            }
        }
    }
}
