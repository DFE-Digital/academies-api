using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using FizzWare.NBuilder;
using FizzWare.NBuilder.PropertyNaming;
using TramsDataApi.DatabaseModels;
using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using TramsDataApi.Factories;
using TramsDataApi.ResponseModels;
using TramsDataApi.Test.Utils;
using Xunit;
using Xunit.Sdk;

namespace TramsDataApi.Test.Integration
{
    [Collection("Database")]
    public class TrustsIntegrationTests : IClassFixture<TramsDataApiFactory>
    {
        private readonly HttpClient _client;
        private readonly TramsDbContext _dbContext;
        private readonly RandomGenerator _randomGenerator;

        public TrustsIntegrationTests(TramsDataApiFactory fixture)
        {
            _client = fixture.CreateClient();
            _client.BaseAddress = new Uri("https://trams-api.com/");
            _dbContext = fixture.Services.GetRequiredService<TramsDbContext>();
            _randomGenerator = new RandomGenerator();
        }

        [Fact]
        public async Task ShouldReturnNull_WhenSearchingByUkprn_AndTrustDoesNotExist()
        {
            var httpRequestMessage = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://trams-api.com/trust/mockukprn"),
                Headers = { 
                    { "ApiKey", "testing-api-key" }
                }
            };
            
            var response = await _client.SendAsync(httpRequestMessage);

            response.StatusCode.Should().Be (HttpStatusCode.NotFound);
        }

        [Fact]
        public async Task  ShouldReturnTrust_WhenSearchingByUkprn_AndTrustExists()
        {
            var testGroupData = GenerateTestGroup();
            var testTrustData = GenerateTestTrust();
            _dbContext.Group.Add(testGroupData);
            _dbContext.Trust.Add(testTrustData);
            _dbContext.SaveChanges();

            var httpRequestMessage = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://trams-api.com/trust/testukprn"),
                Headers =
                {
                    {"ApiKey", "testing-api-key"}
                }
            };

            var expected = new TrustResponse
            {
                IfdData = new IFDDataResponse
                {
                    TrustOpenDate = testTrustData.TrustsTrustOpenDate?.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture),
                    LeadRSCRegion = testTrustData.LeadRscRegion,
                    TrustContactPhoneNumber = testTrustData.TrustContactDetailsTrustContactPhoneNumber,
                    PerformanceAndRiskDateOfMeeting =
                        testTrustData.TrustPerformanceAndRiskDateOfMeeting?.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture),
                    PrioritisedAreaOfReview = testTrustData.TrustPerformanceAndRiskPrioritisedForAReview,
                    CurrentSingleListGrouping = testTrustData.TrustPerformanceAndRiskSingleListGrouping,
                    DateOfGroupingDecision =
                        testTrustData.TrustPerformanceAndRiskDateOfGroupingDecision?.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture),
                    DateEnteredOntoSingleList =
                        testTrustData.TrustPerformanceAndRiskDateEnteredOntoSingleList?.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture),
                    TrustReviewWriteup = testTrustData.TrustPerformanceAndRiskTrustReviewWriteUp,
                    DateOfTrustReviewMeeting = testTrustData.TrustPerformanceAndRiskDateOfMeeting?.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture),
                    FollowupLetterSent = testTrustData.TrustPerformanceAndRiskFollowUpLetterSent,
                    DateActionPlannedFor = testTrustData.TrustPerformanceAndRiskDateActionPlannedFor?.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture),
                    WIPSummaryGoesToMinister = testTrustData.TrustPerformanceAndRiskWipSummaryGoesToMinister,
                    ExternalGovernanceReviewDate =
                        testTrustData.TrustPerformanceAndRiskExternalGovernanceReviewDate?.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture),
                    EfficiencyICFPreviewCompleted =
                        testTrustData.TrustPerformanceAndRiskEfficiencyIcfpReviewCompleted,
                    EfficiencyICFPreviewOther = testTrustData.TrustPerformanceAndRiskEfficiencyIcfpReviewOther,
                    LinkToWorkplaceForEfficiencyICFReview = testTrustData
                        .TrustPerformanceAndRiskLinkToWorkplaceForEfficiencyIcfpReview,
                    NumberInTrust = testTrustData.NumberInTrust.ToString()
                },
                Establishments = new List<EstablishmentResponse>(),
                GiasData = new GIASDataResponse
                {
                    GroupId = testGroupData.GroupId,
                    GroupName = testGroupData.GroupName,
                    CompaniesHouseNumber = testGroupData.CompaniesHouseNumber,
                    GroupContactAddress = new AddressResponse
                    {
                        Street = testGroupData.GroupContactStreet,
                        AdditionalLine = testGroupData.GroupContactAddress3,
                        Locality = testGroupData.GroupContactLocality,
                        Town = testGroupData.GroupContactTown,
                        County = testGroupData.GroupContactCounty,
                        Postcode = testGroupData.GroupContactPostcode
                    },
                    Ukprn = testGroupData.Ukprn
                }
            };

            var response = await _client.SendAsync(httpRequestMessage);
            var jsonString = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<TrustResponse>(jsonString);

            response.StatusCode.Should().Be(HttpStatusCode.OK);
            result.Should().BeEquivalentTo(expected); 
            _dbContext.Group.Remove(testGroupData);
            _dbContext.Trust.Remove(testTrustData);
            _dbContext.SaveChanges();
        }
        
        [Fact]
        public async Task  ShouldReturnNullForIfdData_WhenNoCorrespondingIfdTrustIsFound()
        {
            var testGroupData = new Group
            {
                GroupUid = "2",
                GroupId = "TR00000",
                GroupName = "Test Group",
                CompaniesHouseNumber = "011013254",
                GroupTypeCode = "5",
                GroupType = "FS",
                ClosedDate = "01/01/1970",
                GroupStatusCode = "45",
                GroupStatus = "CS",
                GroupContactStreet = "Street Name",
                GroupContactLocality = "Locality",
                GroupContactAddress3 = "Address 3",
                GroupContactTown = "Town Name",
                GroupContactCounty = "County Name",
                GroupContactPostcode = "P05 7CD",
                HeadOfGroupTitle = "Mx",
                HeadOfGroupFirstName = "First Name",
                HeadOfGroupLastName = "Last Name",
                Ukprn = "testukprn",
                IncorporatedOnOpenDate = "01/01/1970",
                OpenDate = "01/01/1970"
            };
            _dbContext.Group.Add(testGroupData);
            _dbContext.SaveChanges();

            var httpRequestMessage = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://trams-api.com/trust/testukprn"),
                Headers =
                {
                    {"ApiKey", "testing-api-key"}
                }
            };

            var expected = new TrustResponse
            {
                IfdData = null,
                Establishments = new List<EstablishmentResponse>(),
                GiasData = new GIASDataResponse
                {
                    GroupId = testGroupData.GroupId,
                    GroupName = testGroupData.GroupName,
                    CompaniesHouseNumber = testGroupData.CompaniesHouseNumber,
                    GroupContactAddress = new AddressResponse
                    {
                        Street = testGroupData.GroupContactStreet,
                        AdditionalLine = testGroupData.GroupContactAddress3,
                        Locality = testGroupData.GroupContactLocality,
                        Town = testGroupData.GroupContactTown,
                        County = testGroupData.GroupContactCounty,
                        Postcode = testGroupData.GroupContactPostcode
                    },
                    Ukprn = testGroupData.Ukprn
                }
            };

            var response = await _client.SendAsync(httpRequestMessage);
            var jsonString = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<TrustResponse>(jsonString);

            response.StatusCode.Should().Be(HttpStatusCode.OK);
            result.Should().BeEquivalentTo(expected);
            
            _dbContext.Group.Remove(testGroupData);
            _dbContext.SaveChanges();
        }

        [Fact]
        public async Task ShouldReturnEstablishmentData_WhenTrustHasAnEstablishment()
        {
            var testGroupData = new Group
            {
                GroupUid = "345",
                GroupId = "TR45322",
                GroupName = "Test Group",
                CompaniesHouseNumber = "011013254",
                GroupTypeCode = "5",
                GroupType = "FS",
                ClosedDate = "01/01/1970",
                GroupStatusCode = "45",
                GroupStatus = "CS",
                GroupContactStreet = "Street Name",
                GroupContactLocality = "Locality",
                GroupContactAddress3 = "Address 3",
                GroupContactTown = "Town Name",
                GroupContactCounty = "County Name",
                GroupContactPostcode = "P05 7CD",
                HeadOfGroupTitle = "Mx",
                HeadOfGroupFirstName = "First Name",
                HeadOfGroupLastName = "Last Name",
                Ukprn = "testukprn",
                IncorporatedOnOpenDate = "01/01/1970",
                OpenDate = "01/01/1970"
            };

            var testEstablishment = GenerateEstablishment();
            var misEstablishment =
                Builder<MisEstablishments>.CreateNew().With(m => m.Urn = testEstablishment.Urn).Build();
            var smartData = Generators.GenerateSmartData(testEstablishment.Urn);
            var nonTrustAcademies = Builder<Establishment>.CreateListOfSize(5)
                .All().With(e => e.TrustsCode = "000")
                .Build();
            
            _dbContext.Group.Add(testGroupData);
            _dbContext.Establishment.Add(testEstablishment);
            _dbContext.Establishment.AddRange(nonTrustAcademies);
            _dbContext.MisEstablishments.Add(misEstablishment);
            _dbContext.SmartData.Add(smartData);
            _dbContext.SaveChanges();
            
             var establishmentResponses = new List<EstablishmentResponse>
             {
                 EstablishmentResponseFactory.Create(testEstablishment, misEstablishment, smartData)
             };

            var httpRequestMessage = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://trams-api.com/trust/testukprn"),
                Headers =
                {
                    {"ApiKey", "testing-api-key"}
                }
            };

            var expected = new TrustResponse
            {
                IfdData = null,
                Establishments = establishmentResponses,
                GiasData = new GIASDataResponse
                {
                    GroupId = testGroupData.GroupId,
                    GroupName = testGroupData.GroupName,
                    CompaniesHouseNumber = testGroupData.CompaniesHouseNumber,
                    GroupContactAddress = new AddressResponse
                    {
                        Street = testGroupData.GroupContactStreet,
                        AdditionalLine = testGroupData.GroupContactAddress3,
                        Locality = testGroupData.GroupContactLocality,
                        Town = testGroupData.GroupContactTown,
                        County = testGroupData.GroupContactCounty,
                        Postcode = testGroupData.GroupContactPostcode
                    },
                    Ukprn = testGroupData.Ukprn
                }
            };

            var response = await _client.SendAsync(httpRequestMessage);
            var jsonString = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<TrustResponse>(jsonString);

            response.StatusCode.Should().Be(HttpStatusCode.OK);
            result.Should().BeEquivalentTo(expected);
            
            _dbContext.Group.Remove(testGroupData);
            _dbContext.Establishment.Remove(testEstablishment);
            _dbContext.SaveChanges();
        }

        [Fact]
        public async Task ShouldReturnAllTrusts_WhenSearchingTrusts_WithNoQueryParameters()
        {
            var groupLinks = Builder<GroupLink>.CreateListOfSize(10)
                .All()
                .With(e => e.Urn = _randomGenerator.Int().ToString())
                .Build();

            _dbContext.GroupLink.AddRange(groupLinks);
            _dbContext.SaveChanges();

            var expected = groupLinks
                .Select(g => TrustListItemResponseFactory.Create(g, new List<Establishment>()))
                .ToList();

            var httpRequestMessage = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://trams-api.com/trusts"),
                Headers =
                {
                    {"ApiKey", "testing-api-key"}
                }
            };
            
            var response = await _client.SendAsync(httpRequestMessage);
            var jsonString = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<List<TrustListItemResponse>>(jsonString);

            response.StatusCode.Should().Be(HttpStatusCode.OK);
            result.Should().BeEquivalentTo(expected);
            
            _dbContext.GroupLink.RemoveRange(groupLinks);
            _dbContext.SaveChanges();
        }
        
        [Fact]
        public async Task ShouldReturnSubsetOfTrusts_WhenSearchingTrusts_ByGroupName()
        {
            var groupName = "Mygroupname";
            var groupLinks = (List<GroupLink>) Builder<GroupLink>.CreateListOfSize(15)
                .All()
                .With(e => e.Urn = _randomGenerator.Int().ToString())
                .Build();

            var groupLinksWithGroupName = groupLinks.GetRange(0, 5);
            var groupLinksWithoutGroupName = groupLinks.GetRange(5, 10);

            groupLinksWithGroupName = groupLinksWithGroupName.Select(g =>
            {
                g.GroupName = groupName;
                return g;
            }).ToList();
                
            _dbContext.GroupLink.AddRange(groupLinksWithGroupName);
            _dbContext.GroupLink.AddRange(groupLinksWithoutGroupName);
            _dbContext.SaveChanges();

            var expected = groupLinksWithGroupName
                .Select(g => TrustListItemResponseFactory.Create(g, new List<Establishment>()))
                .ToList();

            var httpRequestMessage = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://trams-api.com/trusts?groupName=" + groupName),
                Headers =
                {
                    {"ApiKey", "testing-api-key"}
                }
            };
            
            var response = await _client.SendAsync(httpRequestMessage);
            var jsonString = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<List<TrustListItemResponse>>(jsonString);

            response.StatusCode.Should().Be(HttpStatusCode.OK);
            result.Should().BeEquivalentTo(expected);
            
            _dbContext.GroupLink.RemoveRange(groupLinksWithGroupName);
            _dbContext.GroupLink.RemoveRange(groupLinksWithoutGroupName);
            _dbContext.SaveChanges();
        }
        
        [Fact]
        public async Task ShouldReturnSubsetOfTrusts_WhenSearchingTrusts_ByCompaniesHouseNumber()
        {
            var companiesHouseNumber = "MyCompaniesHouseNumber";
            var groupLinks = (List<GroupLink>) Builder<GroupLink>.CreateListOfSize(15)
                .All()
                .With(e => e.Urn = _randomGenerator.Int().ToString())
                .Build();

            var groupLinksWithCompaniesHouseNumber = groupLinks.GetRange(0, 5);
            var groupLinksWithoutCompaniesHouseNumber = groupLinks.GetRange(5, 10);

            groupLinksWithCompaniesHouseNumber = groupLinksWithCompaniesHouseNumber.Select(g =>
            {
                g.CompaniesHouseNumber = companiesHouseNumber;
                return g;
            }).ToList();
                
            _dbContext.GroupLink.AddRange(groupLinksWithCompaniesHouseNumber);
            _dbContext.GroupLink.AddRange(groupLinksWithoutCompaniesHouseNumber);
            _dbContext.SaveChanges();

            var expected = groupLinksWithCompaniesHouseNumber
                .Select(g => TrustListItemResponseFactory.Create(g, new List<Establishment>()))
                .ToList();

            var httpRequestMessage = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://trams-api.com/trusts?companiesHouseNumber=" + companiesHouseNumber),
                Headers =
                {
                    {"ApiKey", "testing-api-key"}
                }
            };
            
            var response = await _client.SendAsync(httpRequestMessage);
            var jsonString = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<List<TrustListItemResponse>>(jsonString);

            response.StatusCode.Should().Be(HttpStatusCode.OK);
            result.Should().BeEquivalentTo(expected);
            
            _dbContext.GroupLink.RemoveRange(groupLinksWithCompaniesHouseNumber);
            _dbContext.GroupLink.RemoveRange(groupLinksWithoutCompaniesHouseNumber);
            _dbContext.SaveChanges();
        }
        
        [Fact]
        public async Task ShouldReturnSubsetOfTrusts_WhenSearchingTrusts_ByUrn()
        {
            var urn = "mockurn";
            var groupLinks = (List<GroupLink>) Builder<GroupLink>.CreateListOfSize(15)
                .All()
                .With(e => e.Urn = _randomGenerator.Int().ToString())
                .Build();

            groupLinks[0].Urn = urn;
            
            _dbContext.GroupLink.AddRange(groupLinks);
            _dbContext.SaveChanges();

            var expected = new List<TrustListItemResponse>
            {
                TrustListItemResponseFactory.Create(groupLinks[0], new List<Establishment>())
            };

            var httpRequestMessage = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://trams-api.com/trusts?urn=" + urn),
                Headers =
                {
                    {"ApiKey", "testing-api-key"}
                }
            };
            
            var response = await _client.SendAsync(httpRequestMessage);
            var jsonString = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<List<TrustListItemResponse>>(jsonString);

            response.StatusCode.Should().Be(HttpStatusCode.OK);
            result.Should().BeEquivalentTo(expected);
            
            _dbContext.GroupLink.RemoveRange(groupLinks);
            _dbContext.SaveChanges();
        }
        
        [Fact]
        public async Task ShouldReturnSubsetOfTrusts_WhenSearchingTrusts_ByAllFields()
        {
            var urn = "mockurn";
            var companiesHouseNumber = "mockcompanieshousenumber";
            var groupName = "mockgroupname";
            
            var groupLinks = (List<GroupLink>) Builder<GroupLink>.CreateListOfSize(15)
                .All()
                .With(e => e.Urn = _randomGenerator.Int().ToString())
                .Build();

            groupLinks[0].Urn = urn;
            groupLinks[0].CompaniesHouseNumber = companiesHouseNumber;
            groupLinks[0].GroupName = groupName;
            
            _dbContext.GroupLink.AddRange(groupLinks);
            _dbContext.SaveChanges();

            var expected = new List<TrustListItemResponse>
            {
                TrustListItemResponseFactory.Create(groupLinks[0], new List<Establishment>())
            };

            var httpRequestMessage = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($"https://trams-api.com/trusts?groupName={groupName}&urn={urn}&companiesHouseNumber={companiesHouseNumber}"),
                Headers =
                {
                    {"ApiKey", "testing-api-key"}
                }
            };
            
            var response = await _client.SendAsync(httpRequestMessage);
            var jsonString = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<List<TrustListItemResponse>>(jsonString);

            response.StatusCode.Should().Be(HttpStatusCode.OK);
            result.Should().BeEquivalentTo(expected);
            
            _dbContext.GroupLink.RemoveRange(groupLinks);
            _dbContext.SaveChanges();
        }
        
        [Fact]
        public async Task ShouldReturnSubsetOfTrusts_WithEstablishments_WhenSearchingTrusts()
        {
            var urn = "mockurn";
            
            var groupLinks = (List<GroupLink>) Builder<GroupLink>.CreateListOfSize(15)
                .All()
                .With(e => e.Urn = _randomGenerator.Int().ToString())
                .Build();
            groupLinks[0].Urn = urn;

            var establishments = Builder<Establishment>.CreateListOfSize(4)
                .All()
                .With(e => e.TrustsCode = groupLinks[0].GroupUid)
                .With(e => e.Urn = _randomGenerator.Int())
                .Build();
            
            _dbContext.GroupLink.AddRange(groupLinks);
            _dbContext.Establishment.AddRange(establishments);
            _dbContext.SaveChanges();

            var expected = new List<TrustListItemResponse>
            {
                TrustListItemResponseFactory.Create(groupLinks[0], establishments)
            };

            var httpRequestMessage = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($"https://trams-api.com/trusts?urn={urn}"),
                Headers =
                {
                    {"ApiKey", "testing-api-key"}
                }
            };
            
            var response = await _client.SendAsync(httpRequestMessage);
            var jsonString = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<List<TrustListItemResponse>>(jsonString);

            response.StatusCode.Should().Be(HttpStatusCode.OK);
            result.Should().BeEquivalentTo(expected);
            
            _dbContext.GroupLink.RemoveRange(groupLinks);
            _dbContext.Establishment.RemoveRange(establishments);
            _dbContext.SaveChanges();
        }

        private Group GenerateTestGroup()
        {
            return new Group
            {
                GroupUid = "1",
                GroupId = "TR12345",
                GroupName = "Test Group",
                CompaniesHouseNumber = "011013254",
                GroupTypeCode = "5",
                GroupType = "FS",
                ClosedDate = "01/01/1970",
                GroupStatusCode = "45",
                GroupStatus = "CS",
                GroupContactStreet = "Street Name",
                GroupContactLocality = "Locality",
                GroupContactAddress3 = "Address 3",
                GroupContactTown = "Town Name",
                GroupContactCounty = "County Name",
                GroupContactPostcode = "P05 7CD",
                HeadOfGroupTitle = "Mx",
                HeadOfGroupFirstName = "First Name",
                HeadOfGroupLastName = "Last Name",
                Ukprn = "testukprn",
                IncorporatedOnOpenDate = "01/01/1970",
                OpenDate = "01/01/1970"
            };
        }

        private Trust GenerateTestTrust()
        {
            return new Trust
            {   
                Rid = "1",
                TrustRef = "TR12345",
                TrustsTrustOpenDate = DateTime.ParseExact("21/05/2001", "dd/MM/yyyy", CultureInfo.InvariantCulture),
                LeadRscRegion = "Lead RSC Region",
                TrustContactDetailsTrustContactPhoneNumber = "6",
                TrustPerformanceAndRiskDateOfMeeting = DateTime.ParseExact("18/04/2019", "dd/MM/yyyy", CultureInfo.InvariantCulture),
                TrustPerformanceAndRiskPrioritisedForAReview = "Trust Performance And Risk Prioritised For A Review",
                TrustPerformanceAndRiskSingleListGrouping = "Single List Grouping",
                TrustPerformanceAndRiskDateOfGroupingDecision = DateTime.ParseExact("13/09/2018", "dd/MM/yyyy", CultureInfo.InvariantCulture),
                TrustPerformanceAndRiskDateEnteredOntoSingleList = DateTime.ParseExact("19/02/2017", "dd/MM/yyyy", CultureInfo.InvariantCulture),
                TrustPerformanceAndRiskTrustReviewWriteUp = "Trust Review Write Up",
                TrustPerformanceAndRiskFollowUpLetterSent = "Follow Up Letter SenT",
                TrustPerformanceAndRiskDateActionPlannedFor = DateTime.ParseExact("19/05/2010", "dd/MM/yyyy", CultureInfo.InvariantCulture),
                TrustPerformanceAndRiskWipSummaryGoesToMinister = "WIP Summary goes to Minister",
                TrustPerformanceAndRiskExternalGovernanceReviewDate = DateTime.ParseExact("16/08/2012", "dd/MM/yyyy", CultureInfo.InvariantCulture),
                TrustPerformanceAndRiskEfficiencyIcfpReviewCompleted = "ICFP Review Completed",
                TrustPerformanceAndRiskEfficiencyIcfpReviewOther = "ICFP Review other",
                TrustPerformanceAndRiskLinkToWorkplaceForEfficiencyIcfpReview = "Link to ICFP Review",
                NumberInTrust = 1
                
            }; 
        }

        private Establishment GenerateEstablishment()
        {
            return new Establishment
            {
                Urn = 100000,
                LaCode = "203",
                LaName = "Greenwich",
                EstablishmentNumber = "4100",
                EstablishmentName = "Plum Village School",
                TypeOfEstablishmentCode = "02",
                TypeOfEstablishmentName = "Voluntary added school",
                EstablishmentTypeGroupCode = "4",
                EstablishmentTypeGroupName = "Local authority maintained schools",
                EstablishmentStatusCode = "1",
                EstablishmentStatusName = "Open",
                ReasonEstablishmentOpenedCode = "00",
                ReasonEstablishmentOpenedName = "Not applicable",
                OpenDate = "01-01-1999",
                ReasonEstablishmentClosedCode = "00",
                ReasonEstablishmentClosedName = "Not applicable",
                CloseDate = null,
                PhaseOfEducationCode = "2",
                PhaseOfEducationName = "Primary",
                StatutoryLowAge = "3",
                StatutoryHighAge = "11",
                BoardersCode = "1",
                BoardersName = "No boarders",
                NurseryProvisionName = "Has Nursery Classes",
                OfficialSixthFormCode = "2",
                OfficialSixthFormName = "Doers not have a sixth form",
                GenderCode = "3",
                GenderName = "Mixed",
                ReligiousCharacterCode = "02",
                ReligiousCharacterName = "Church of England",
                ReligiousEthosName = "Does not apply",
                DioceseCode = "CE23",
                DioceseName = "Diocese of London",
                AdmissionsPolicyCode = "0",
                AdmissionsPolicyName = "Not applicable",
                SchoolCapacity = "300",
                SpecialClassesCode = "2",
                SpecialClassesName = "No Special Classes",
                CensusDate = "16-01-2020",
                NumberOfPupils = "276",
                NumberOfBoys = "136",
                NumberOfGirls = "140",
                PercentageFsm = "10.2",
                TrustSchoolFlagCode = "0",
                TrustSchoolFlagName = "Not applicable",
                TrustsCode = "345",
                TrustsName = "Test Group",
                SchoolSponsorFlagName = "Not applicable",
                SchoolSponsorsName = null,
                FederationFlagName = "Not under a federation",
                FederationsCode = null,
                FederationsName = null,
                Ukprn = "10000000",
                Feheidentifier = null,
                FurtherEducationTypeName = "Not applicable",
                OfstedLastInsp = "19-04-2013",
                OfstedSpecialMeasuresCode = "0",
                OfstedSpecialMeasuresName = "Not applicable",
                LastChangedDate =  "04-02-2021",
                Street = "St Jame's Passage",
                Locality = "Duke's Place",
                Address3 = null,
                Town = "London",
                CountyName = null,
                Postcode = "EC3A 9DA",
                SchoolWebsite = "www.test-school.com",
                TelephoneNum = "02072342211",
                HeadTitleName = "Miss",
                HeadFirstName = "Jenny",
                HeadLastName = "Bloggs",
                HeadPreferredJobTitle = "Headteacher",
                InspectorateNameName = "ISI",
                InspectorateReport = null,
                DateOfLastInspectionVisit = null,
                NextInspectionVisit = null,
                TeenMothName = "Not applicable",
                TeenMothPlaces = null,
                CcfName = "Not applicable",
                SenpruName = "Not applicable",
                EbdName = "Not applicable",
                PlacesPru = null,
                FtprovName = null,
                EdByOtherName = "Not applicable",
                Section41ApprovedName = "Not applicable",
                Sen1Name = null,
                Sen2Name = null,
                Sen3Name = null,
                Sen4Name = null,
                Sen5Name = null,
                Sen6Name = null,
                Sen7Name = null,
                Sen8Name = null,
                Sen9Name = null,
                Sen10Name = null,
                Sen11Name = null,
                Sen12Name = null,
                Sen13Name = null,
                TypeOfResourcedProvisionName = null,
                ResourcedProvisionOnRoll = null,
                ResourcedProvisionCapacity = null,
                SenUnitOnRoll = null,
                SenUnitCapacity = null,
                GorCode = "H",
                GorName = "London",
                DistrictAdministrativeCode = "E09000001",
                DistrictAdministrativeName = "City of London",
                AdministrativeWardCode = "E05009293",
                AdministrativeWardName = "Cripplegate",
                ParliamentaryConstituencyCode = "E14000639",
                ParliamentaryConstituencyName = "Cities of London and Westminster",
                UrbanRuralCode = "A1",
                UrbanRuralName = "(England/Wales) Urban major conurbation",
                GsslacodeName = "E09000001",
                Easting = "533498",
                Northing = "181201",
                CensusAreaStatisticWardName = null,
                MsoaName = "City of London 001",
                LsoaName = "City of London 001F",
                Senstat = "0",
                SennoStat = "63",
                BoardingEstablishmentName = "Does not have boarders",
                PropsName = "Corporation of London",
                PreviousLaCode = "000",
                PreviousLaName = "Not applicable",
                PreviousEstablishmentNumber = null,
                OfstedRatingName = "Outstanding",
                RscregionName = "North-West London and South-Central England",
                CountryName = "United Kingdom",
                Uprn = "20000007192",
                SiteName = null,
                MsoaCode = null,
                LsoaCode = null,
                BsoinspectorateNameName = null,
                Chnumber = null,
                EstablishmentAccreditedCode = null,
                EstablishmentAccreditedName = null,
                QabnameCode = null,
                QabnameName = null,
                Qabreport = null
            };
        }
    }
}