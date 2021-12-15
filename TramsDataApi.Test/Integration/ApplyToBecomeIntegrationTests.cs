using System;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using AutoFixture;
using FizzWare.NBuilder;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using TramsDataApi.DatabaseModels;
using TramsDataApi.Factories;
using TramsDataApi.RequestModels.ApplyToBecome;
using TramsDataApi.ResponseModels;
using TramsDataApi.ResponseModels.ApplyToBecome;
using Xunit;

namespace TramsDataApi.Test.Integration
{
    [Collection("Database")]
    public class ApplyToBecomeIntegrationTests: IClassFixture<TramsDataApiFactory>, IDisposable
    {
        
        private readonly HttpClient _client;
        private readonly TramsDbContext _dbContext;
        private readonly Fixture _fixture;
        private readonly RandomGenerator _randomGenerator;

        public ApplyToBecomeIntegrationTests(TramsDataApiFactory fixture)
        {
            _client = fixture.CreateClient();
            _client.DefaultRequestHeaders.Add("ApiKey", "testing-api-key");
            _dbContext = fixture.Services.GetRequiredService<TramsDbContext>();
            _fixture = new Fixture();
            _randomGenerator = new RandomGenerator();
        }

        [Fact]
        public async Task CanGetApplicationByApplicationId()
        {
            SetupA2BApplicationData();
            
            var application = _dbContext.A2BApplications.First();
            var expected = A2BApplicationResponseFactory.Create(application, null);
            var expectedResponse = new ApiSingleResponseV2<A2BApplicationResponse>(expected);
            
            var response = await _client.GetAsync($"/v2/apply-to-become/application/{application.ApplicationId}");

            response.StatusCode.Should().Be(200);
            
            var result = await response.Content.ReadFromJsonAsync<ApiSingleResponseV2<A2BApplicationResponse>>();
            result.Should().BeEquivalentTo(expectedResponse); 
            result.Data.ApplicationId.Should().Be(expectedResponse.Data.ApplicationId);
        }

        [Fact]
        public async Task CanCreateApplication()
        {
            var application = Builder<A2BApplicationCreateRequest>
                .CreateNew()
                .Build();

            var response = await _client.PostAsJsonAsync($"/v2/apply-to-become/application/", application);

            response.StatusCode.Should().Be(201);
            
            var result = await response.Content.ReadFromJsonAsync<ApiSingleResponseV2<A2BApplicationResponse>>();

            result.Should().NotBeNull();
            result.Data.ApplicationId.Should().BeGreaterThan(0);
            
            var createdApplication =
                _dbContext.A2BApplications.FirstOrDefault(a => a.ApplicationId == result.Data.ApplicationId);

            createdApplication.Should().NotBeNull();
            
            result.Data.Should().BeEquivalentTo(createdApplication);
        }
        
        [Fact]
        public async Task CanGetApplicationKeyPersonsByKeyPersonId()
        {
            SetupA2BApplicationKeyPersonsData();
            
            var keyPerson = _dbContext.A2BApplicationKeyPersons.First();
            var expected = A2BApplicationKeyPersonsResponseFactory.Create(keyPerson);
            var expectedResponse = new ApiSingleResponseV2<A2BApplicationKeyPersonsResponse>(expected);
            
            var response = await _client.GetAsync($"/v2/apply-to-become/keyPersons/{keyPerson.KeyPersonId}");

            response.StatusCode.Should().Be(200);
            
            var result = await response.Content.ReadFromJsonAsync<ApiSingleResponseV2<A2BApplicationKeyPersonsResponse>>();
            result.Should().BeEquivalentTo(expectedResponse); 
            result.Data.KeyPersonId.Should().Be(expectedResponse.Data.KeyPersonId);
        }

        [Fact]
        public async Task CanCreateApplicationKeyPerson()
        {
            SetupA2BApplicationKeyPersonsData();
            
            var keyPerson = Builder<A2BApplicationKeyPersonsCreateRequest>.CreateNew().Build();
   
            var response = await _client.PostAsJsonAsync($"/v2/apply-to-become/keyPersons/", keyPerson);

            response.StatusCode.Should().Be(201);
            
            var result = await response.Content.ReadFromJsonAsync<ApiSingleResponseV2<A2BApplicationKeyPersonsResponse>>();

            result.Should().NotBeNull();
            result.Data.KeyPersonId.Should().BeGreaterThan(0);
            
            var createdKeyPerson =
                _dbContext.A2BApplicationKeyPersons.FirstOrDefault(a => a.KeyPersonId == result.Data.KeyPersonId);

            createdKeyPerson.Should().NotBeNull();
            
            result.Data.Should().BeEquivalentTo(createdKeyPerson);
        }
        
        [Fact]
        public async Task CanGetApplicationStatusByApplicationStatusId()
        {
            SetupA2BApplicationStatusData();
            
            var status = _dbContext.A2BApplicationStatus.First();
            var expected = A2BApplicationStatusResponseFactory.Create(status);
            var expectedResponse = new ApiSingleResponseV2<A2BApplicationStatusResponse>(expected);
            
            var response = await _client.GetAsync($"/v2/apply-to-become/status/{status.ApplicationStatusId}");

            response.StatusCode.Should().Be(200);
            
            var result = await response.Content.ReadFromJsonAsync<ApiSingleResponseV2<A2BApplicationStatusResponse>>();
            result.Should().BeEquivalentTo(expectedResponse); 
            result.Data.ApplicationStatusId.Should().Be(expectedResponse.Data.ApplicationStatusId);
        }

        [Fact]
        public async Task CanCreateApplicationStatus()
        {
            SetupA2BApplicationStatusData();

            var status = new A2BApplicationStatusCreateRequest
            {
                Name = "Test001"
            };
   
            var response = await _client.PostAsJsonAsync("/v2/apply-to-become/status/", status);

            response.StatusCode.Should().Be(201);
            
            var result = await response.Content.ReadFromJsonAsync<ApiSingleResponseV2<A2BApplicationStatusResponse>>();

            result.Should().NotBeNull();
            result.Data.ApplicationStatusId.Should().BeGreaterThan(0);
            
            var createdStatus =
                _dbContext.A2BApplicationStatus.FirstOrDefault(a => a.ApplicationStatusId == result.Data.ApplicationStatusId);

            createdStatus.Should().NotBeNull();
            
            result.Data.Should().BeEquivalentTo(createdStatus);
        }
        
        [Fact]
        public async Task CanGetApplyingSchoolByApplyingSchoolId()
        {
            SetupA2BApplyingSchoolData();
            
            var applyingSchool = _dbContext.A2BApplyingSchools
                .Include(k => k.SchoolDeclarationBodyAgreeOption)
                .Include(k => k.SchoolDeclarationTeacherChairOption)
                .Include(k => k.SchoolLoanExistsOption)
                .Include(k => k.SchoolLeaseExistsOption)
                .First();
            
            var expected = A2BApplyingSchoolResponseFactory.Create(applyingSchool);
            var expectedResponse = new ApiSingleResponseV2<A2BApplyingSchoolResponse>(expected);
            
            var response = await _client.GetAsync($"/v2/apply-to-become/applyingSchool/{applyingSchool.ApplyingSchoolId}");

            response.StatusCode.Should().Be(200);
            
            var result = await response.Content.ReadFromJsonAsync<ApiSingleResponseV2<A2BApplyingSchoolResponse>>();
            result.Should().BeEquivalentTo(expectedResponse); 
            result.Data.ApplyingSchoolId.Should().Be(expectedResponse.Data.ApplyingSchoolId);
        }

        [Fact]
        public async Task CanCreateApplyingSchool()
        {
            var request = new A2BApplyingSchoolCreateRequest
            {
                ApplyingSchoolId = "10001",
                Name = _randomGenerator.NextString(3, 10),
                UpdatedTrustFields = _randomGenerator.NextString(3, 10),
                SchoolDeclarationSignedById = _randomGenerator.NextString(3, 10),
                SchoolDeclarationBodyAgree = 907660000,
                SchoolDeclarationTeacherChair = 907660001,
                SchoolDeclarationSignedByEmail = _randomGenerator.NextString(3, 10),
                UpdatedSchoolFields = _randomGenerator.NextString(3, 10),
                SchoolConversionReasonsForJoining = _randomGenerator.NextString(3, 10),
                SchoolConversionTargetDateDifferent = 10001,
                SchoolConversionTargetDateDate = _randomGenerator.DateTime(),
                SchoolConversionTargetDateExplained = _randomGenerator.NextString(3, 10),
                SchoolConversionChangeName = 10001,
                SchoolConversionChangeNameValue = _randomGenerator.NextString(3, 10),
                SchoolConversionContactHeadName = _randomGenerator.NextString(3, 10),
                SchoolConversionContactHeadEmail = _randomGenerator.NextString(3, 10),
                SchoolConversionContactHeadTel = _randomGenerator.NextString(3, 10),
                SchoolConversionContactChairName = _randomGenerator.NextString(3, 10),
                SchoolConversionContactChairEmail = _randomGenerator.NextString(3, 10),
                SchoolConversionContactChairTel = _randomGenerator.NextString(3, 10),
                SchoolConversionMainContact = 10001,
                SchoolConversionMainContactOtherName = _randomGenerator.NextString(3, 10),
                SchoolConversionMainContactOtherEmail = _randomGenerator.NextString(3, 10),
                SchoolConversionMainContactOtherTelephone = _randomGenerator.NextString(3, 10),
                SchoolConversionMainContactOtherRole = _randomGenerator.NextString(3, 10),
                SchoolConversionApproverContactName = _randomGenerator.NextString(3, 10),
                SchoolConversionApproverContactEmail = _randomGenerator.NextString(3, 10),
                SchoolAdInspectedButReportNotPublished = 10001,
                SchoolAdInspectedReportNotPublishedExplain = _randomGenerator.NextString(3, 10),
                SchoolLaReorganization = 10001,
                SchoolLaReorganizationExplain = _randomGenerator.NextString(3, 10),
                SchoolLaClosurePlans = 10001,
                SchoolLaClosurePlansExplain = _randomGenerator.NextString(3, 10),
                SchoolPartOfFederation = 10001,
                SchoolAddFurtherInformation = 10001,
                SchoolFurtherInformation = _randomGenerator.NextString(3, 10),
                SchoolAdSchoolContributionToTrust = _randomGenerator.NextString(3, 10),
                SchoolAdSafeguarding = 10001,
                SchoolAdSafeguardingExplained = _randomGenerator.NextString(3, 10),
                SchoolSACREExemption = 10001,
                SchoolSACREExemptionEndDate = _randomGenerator.DateTime(),
                SchoolFaithSchool = 10001,
                SchoolFaithSchoolDioceseName = _randomGenerator.NextString(3, 10),
                SchoolSupportedFoundation = 10001,
                SchoolSupportedFoundationBodyName = _randomGenerator.NextString(3, 10),
                SchoolAdFeederSchools = _randomGenerator.NextString(3, 10),
                SchoolAdEqualitiesImpactAssessment = 10001,
                SchoolPFYRevenue = 10001,
                SchoolPFYRevenueStatus = 10001,
                SchoolPFYRevenueStatusExplained = _randomGenerator.NextString(3, 10),
                SchoolPFYCapitalForward = 10001,
                SchoolPFYCapitalForwardStatus = 10001,
                SchoolPFYCapitalForwardStatusExplained = _randomGenerator.NextString(3, 10),
                SchoolCFYRevenue = 10001,
                SchoolCFYRevenueStatus = 10001,
                SchoolCFYRevenueStatusExplained = _randomGenerator.NextString(3, 10),
                SchoolCFYCapitalForward = 10001,
                SchoolCFYCapitalForwardStatus = 10001,
                SchoolCFYCapitalForwardStatusExplained = _randomGenerator.NextString(3, 10),
                SchoolNFYRevenue = 10001,
                SchoolNFYRevenueStatus = 10001,
                SchoolNFYRevenueStatusExplained = _randomGenerator.NextString(3, 10),
                SchoolNFYCapitalForward = 10001,
                SchoolNFYCapitalForwardStatus = 10001,
                SchoolNFYCapitalForwardStatusExplained = _randomGenerator.NextString(3, 10),
                SchoolFinancialInvestigations = 10001,
                SchoolFinancialInvestigationsExplain = _randomGenerator.NextString(3, 10),
                SchoolFinancialInvestigationsTrustAware = 10001,
                SchoolNFYEndDate = _randomGenerator.DateTime(),
                SchoolPFYEndDate = _randomGenerator.DateTime(),
                SchoolCFYEndDate = _randomGenerator.DateTime(),
                SchoolLoanExists = 907660000,
                SchoolLeaseExists = 907660001,
                SchoolCapacityYear1 = 10001,
                SchoolCapacityYear2 = 10001,
                SchoolCapacityYear3 = 10001,
                SchoolCapacityAssumptions = _randomGenerator.NextString(3, 10),
                SchoolCapacityPublishedAdmissionsNumber = _randomGenerator.NextString(3, 10),
                SchoolBuildLandOwnerExplained = _randomGenerator.NextString(3, 10),
                SchoolBuildLandSharedFacilities = 10001,
                SchoolBuildLandSharedFacilitiesExplained = _randomGenerator.NextString(3, 10),
                SchoolBuildLandWorksPlanned = 10001,
                SchoolBuildLandWorksPlannedExplained = _randomGenerator.NextString(3, 10),
                SchoolBuildLandWorksPlannedDate = _randomGenerator.DateTime(),
                SchoolBuildLandGrants = 10001,
                SchoolBuildLandGrantsBody = _randomGenerator.NextString(3, 10),
                SchoolBuildLandPriorityBuildingProgramme = 10001,
                SchoolBuildLandFutureProgramme = 10001,
                SchoolBuildLandPFIScheme = 10001,
                SchoolBuildLandPFISchemeType = _randomGenerator.NextString(3, 10),
                SchoolConsultationStakeholders = 10001,
                SchoolConsultationStakeholdersConsult = _randomGenerator.NextString(3, 10),
                SchoolSupportGrantFundsPaidTo = 10001,
                SchoolDeclarationSignedByName = _randomGenerator.NextString(3, 10)
            };

            var expectedData = new A2BApplyingSchoolResponse
            {
                ApplyingSchoolId = request.ApplyingSchoolId,
                Name = request.Name,
                UpdatedTrustFields = request.UpdatedTrustFields,
                SchoolDeclarationSignedById = request.SchoolDeclarationSignedById,
                SchoolDeclarationBodyAgree = new A2BSelectOption { Id = 907660000, Name = "Yes"},
                SchoolDeclarationTeacherChair = new A2BSelectOption { Id = 907660001, Name = "No"},
                SchoolDeclarationSignedByEmail = request.SchoolDeclarationSignedByEmail,
                UpdatedSchoolFields = request.UpdatedSchoolFields,
                SchoolConversionReasonsForJoining = request.SchoolConversionReasonsForJoining,
                SchoolConversionTargetDateDifferent = request.SchoolConversionTargetDateDifferent,
                SchoolConversionTargetDateDate = request.SchoolConversionTargetDateDate,
                SchoolConversionTargetDateExplained = request.SchoolConversionTargetDateExplained,
                SchoolConversionChangeName = request.SchoolConversionChangeName,
                SchoolConversionChangeNameValue = request.SchoolConversionChangeNameValue,
                SchoolConversionContactHeadName = request.SchoolConversionContactHeadName,
                SchoolConversionContactHeadEmail = request.SchoolConversionContactHeadEmail,
                SchoolConversionContactHeadTel = request.SchoolConversionContactHeadTel,
                SchoolConversionContactChairName = request.SchoolConversionContactChairName,
                SchoolConversionContactChairEmail = request.SchoolConversionContactChairEmail,
                SchoolConversionContactChairTel = request.SchoolConversionContactChairTel,
                SchoolConversionMainContact = request.SchoolConversionMainContact,
                SchoolConversionMainContactOtherName = request.SchoolConversionMainContactOtherName,
                SchoolConversionMainContactOtherEmail = request.SchoolConversionMainContactOtherEmail,
                SchoolConversionMainContactOtherTelephone = request.SchoolConversionMainContactOtherTelephone,
                SchoolConversionMainContactOtherRole = request.SchoolConversionMainContactOtherRole,
                SchoolConversionApproverContactName = request.SchoolConversionApproverContactName,
                SchoolConversionApproverContactEmail = request.SchoolConversionApproverContactEmail,
                SchoolAdInspectedButReportNotPublished = request.SchoolAdInspectedButReportNotPublished,
                SchoolAdInspectedReportNotPublishedExplain = request.SchoolAdInspectedReportNotPublishedExplain,
                SchoolLaReorganization = request.SchoolLaReorganization,
                SchoolLaReorganizationExplain = request.SchoolLaReorganizationExplain,
                SchoolLaClosurePlans = request.SchoolLaClosurePlans,
                SchoolLaClosurePlansExplain = request.SchoolLaClosurePlansExplain,
                SchoolPartOfFederation = request.SchoolPartOfFederation,
                SchoolAddFurtherInformation = request.SchoolAddFurtherInformation,
                SchoolFurtherInformation = request.SchoolFurtherInformation,
                SchoolAdSchoolContributionToTrust = request.SchoolAdSchoolContributionToTrust,
                SchoolAdSafeguarding = request.SchoolAdSafeguarding,
                SchoolAdSafeguardingExplained = request.SchoolAdSafeguardingExplained,
                SchoolSACREExemption = request.SchoolSACREExemption,
                SchoolSACREExemptionEndDate = request.SchoolSACREExemptionEndDate,
                SchoolFaithSchool = request.SchoolFaithSchool,
                SchoolFaithSchoolDioceseName = request.SchoolFaithSchoolDioceseName,
                SchoolSupportedFoundation = request.SchoolSupportedFoundation,
                SchoolSupportedFoundationBodyName = request.SchoolSupportedFoundationBodyName,
                SchoolAdFeederSchools = request.SchoolAdFeederSchools,
                SchoolAdEqualitiesImpactAssessment = request.SchoolAdEqualitiesImpactAssessment,
                SchoolPFYRevenue = request.SchoolPFYRevenue,
                SchoolPFYRevenueStatus = request.SchoolPFYRevenueStatus,
                SchoolPFYRevenueStatusExplained = request.SchoolPFYRevenueStatusExplained,
                SchoolPFYCapitalForward = request.SchoolPFYCapitalForward,
                SchoolPFYCapitalForwardStatus = request.SchoolPFYCapitalForwardStatus,
                SchoolPFYCapitalForwardStatusExplained = request.SchoolPFYCapitalForwardStatusExplained,
                SchoolCFYRevenue = request.SchoolCFYRevenue,
                SchoolCFYRevenueStatus = request.SchoolCFYRevenueStatus,
                SchoolCFYRevenueStatusExplained = request.SchoolCFYRevenueStatusExplained,
                SchoolCFYCapitalForward = request.SchoolCFYCapitalForward,
                SchoolCFYCapitalForwardStatus = request.SchoolCFYCapitalForwardStatus,
                SchoolCFYCapitalForwardStatusExplained = request.SchoolCFYCapitalForwardStatusExplained,
                SchoolNFYRevenue = request.SchoolNFYRevenue,
                SchoolNFYRevenueStatus = request.SchoolNFYRevenueStatus,
                SchoolNFYRevenueStatusExplained = request.SchoolNFYRevenueStatusExplained,
                SchoolNFYCapitalForward = request.SchoolNFYCapitalForward,
                SchoolNFYCapitalForwardStatus = request.SchoolNFYCapitalForwardStatus,
                SchoolNFYCapitalForwardStatusExplained = request.SchoolNFYCapitalForwardStatusExplained,
                SchoolFinancialInvestigations = request.SchoolFinancialInvestigations,
                SchoolFinancialInvestigationsExplain = request.SchoolFinancialInvestigationsExplain,
                SchoolFinancialInvestigationsTrustAware = request.SchoolFinancialInvestigationsTrustAware,
                SchoolNFYEndDate = request.SchoolNFYEndDate,
                SchoolPFYEndDate = request.SchoolPFYEndDate,
                SchoolCFYEndDate = request.SchoolCFYEndDate,
                SchoolLoanExists = new A2BSelectOption { Id = 907660000, Name = "Yes"},
                SchoolLeaseExists = new A2BSelectOption { Id = 907660001, Name = "No"},
                SchoolCapacityYear1 = request.SchoolCapacityYear1,
                SchoolCapacityYear2 = request.SchoolCapacityYear2,
                SchoolCapacityYear3 = request.SchoolCapacityYear3,
                SchoolCapacityAssumptions = request.SchoolCapacityAssumptions,
                SchoolCapacityPublishedAdmissionsNumber = request.SchoolCapacityPublishedAdmissionsNumber,
                SchoolBuildLandOwnerExplained = request.SchoolBuildLandOwnerExplained,
                SchoolBuildLandSharedFacilities = request.SchoolBuildLandSharedFacilities,
                SchoolBuildLandSharedFacilitiesExplained = request.SchoolBuildLandSharedFacilitiesExplained,
                SchoolBuildLandWorksPlanned = request.SchoolBuildLandWorksPlanned,
                SchoolBuildLandWorksPlannedExplained = request.SchoolBuildLandWorksPlannedExplained,
                SchoolBuildLandWorksPlannedDate = request.SchoolBuildLandWorksPlannedDate,
                SchoolBuildLandGrants = request.SchoolBuildLandGrants,
                SchoolBuildLandGrantsBody = request.SchoolBuildLandGrantsBody,
                SchoolBuildLandPriorityBuildingProgramme = request.SchoolBuildLandPriorityBuildingProgramme,
                SchoolBuildLandFutureProgramme = request.SchoolBuildLandFutureProgramme,
                SchoolBuildLandPFIScheme = request.SchoolBuildLandPFIScheme,
                SchoolBuildLandPFISchemeType = request.SchoolBuildLandPFISchemeType,
                SchoolConsultationStakeholders = request.SchoolConsultationStakeholders,
                SchoolConsultationStakeholdersConsult = request.SchoolConsultationStakeholdersConsult,
                SchoolSupportGrantFundsPaidTo = request.SchoolSupportGrantFundsPaidTo,
                SchoolDeclarationSignedByName = request.SchoolDeclarationSignedByName
            };
        
            var response = await _client.PostAsJsonAsync($"/v2/apply-to-become/applyingSchool/", request);
        
            response.StatusCode.Should().Be(201);
            
            var result = await response.Content.ReadFromJsonAsync<ApiSingleResponseV2<A2BApplyingSchoolResponse>>();
        
            result.Should().NotBeNull();
            
            result.Data.Should().BeEquivalentTo(expectedData);
        }
        
        
        [Fact]
        public async Task CanGetContributorByContributorId()
        {
            SetupA2BContributorData();
            
            var contributor = _dbContext.A2BContributors.First();
            var expected = A2BContributorResponseFactory.Create(contributor);
            var expectedResponse = new ApiSingleResponseV2<A2BContributorResponse>(expected);
            
            var response = await _client.GetAsync($"/v2/apply-to-become/contributor/{contributor.ContributorUserId}");

            response.StatusCode.Should().Be(200);
            
            var result = await response.Content.ReadFromJsonAsync<ApiSingleResponseV2<A2BContributorResponse>>();
            result.Should().BeEquivalentTo(expectedResponse); 
            result.Data.ContributorUserId.Should().Be(expectedResponse.Data.ContributorUserId);
        }

        [Fact]
        public async Task CanCreateContributor()
        {
            var contributor = new A2BContributorCreateRequest
            {
                ContributorUserId = "10001",
                ContributorUserName = "Username",
                ContributorAppIdTest = "10001",
                ApplicationTypeId = "10001"
            };
   
            var response = await _client.PostAsJsonAsync("/v2/apply-to-become/contributor/", contributor);

            response.StatusCode.Should().Be(201);
            
            var result = await response.Content.ReadFromJsonAsync<ApiSingleResponseV2<A2BContributorResponse>>();

            result.Should().NotBeNull();

            var createdStatus =
                _dbContext.A2BContributors.FirstOrDefault(a => a.ContributorUserId == result.Data.ContributorUserId);

            createdStatus.Should().NotBeNull();
            
            result.Data.Should().BeEquivalentTo(createdStatus);
        }
        
        [Fact]
        public async Task CanCreateSchoolLoan()
        {
            var schoolLoanRequest = new A2BSchoolLoanCreateRequest
            {
                SchoolLoanId = "123",
                SchoolLoanAmount = new decimal(3.50),
                SchoolLoanPurpose = "Test purpose",
                SchoolLoanProvider = "Test Provider",
                SchoolLoanInterestRate = "15.4",
                SchoolLoanSchedule = "Wednesdays"
            };
   
            var response = await _client.PostAsJsonAsync("/v2/apply-to-become/school-loans/", schoolLoanRequest);

            response.StatusCode.Should().Be(201);
            
            var result = await response.Content.ReadFromJsonAsync<ApiSingleResponseV2<A2BSchoolLoanResponse>>();

            result.Should().NotBeNull();

            var createdSchoolLoan =
                _dbContext.A2BSchoolLoans.FirstOrDefault(a => a.SchoolLoanId == result.Data.SchoolLoanId);

            createdSchoolLoan.Should().NotBeNull();
            result.Data.Should().BeEquivalentTo(createdSchoolLoan);
        }

        private void SetupA2BContributorData()
        {
            var contributors = Enumerable.Range(1, 10).Select(key => new A2BContributor
            {
                ContributorUserId = $"1000{key}",
                ApplicationTypeId = _randomGenerator.NextString(3, 10),
                ContributorAppIdTest = _randomGenerator.NextString(3, 10),
                ContributorUserName = _randomGenerator.NextString(3, 10)
            });
            
            _dbContext.A2BContributors.AddRange(contributors);
            _dbContext.SaveChanges();
        }
        
        private void SetupA2BApplyingSchoolData()
        {
            var applyingSchools = Enumerable.Range(1, 10).Select(key => new A2BApplyingSchool
            {
                ApplyingSchoolId = $"1000{key}",
                Name = _randomGenerator.NextString(3, 10),
                UpdatedTrustFields = _randomGenerator.NextString(3, 10),
                SchoolDeclarationSignedById = _randomGenerator.NextString(3, 10),
                SchoolDeclarationBodyAgree = 907660000,
                SchoolDeclarationTeacherChair = 907660001,
                SchoolDeclarationSignedByEmail = _randomGenerator.NextString(3, 10),
                UpdatedSchoolFields = _randomGenerator.NextString(3, 10),
                SchoolConversionReasonsForJoining = _randomGenerator.NextString(3, 10),
                SchoolConversionTargetDateDifferent = key,
                SchoolConversionTargetDateDate = _randomGenerator.DateTime(),
                SchoolConversionTargetDateExplained = _randomGenerator.NextString(3, 10),
                SchoolConversionChangeName = key,
                SchoolConversionChangeNameValue = _randomGenerator.NextString(3, 10),
                SchoolConversionContactHeadName = _randomGenerator.NextString(3, 10),
                SchoolConversionContactHeadEmail = _randomGenerator.NextString(3, 10),
                SchoolConversionContactHeadTel = _randomGenerator.NextString(3, 10),
                SchoolConversionContactChairName = _randomGenerator.NextString(3, 10),
                SchoolConversionContactChairEmail = _randomGenerator.NextString(3, 10),
                SchoolConversionContactChairTel = _randomGenerator.NextString(3, 10),
                SchoolConversionMainContact = key,
                SchoolConversionMainContactOtherName = _randomGenerator.NextString(3, 10),
                SchoolConversionMainContactOtherEmail = _randomGenerator.NextString(3, 10),
                SchoolConversionMainContactOtherTelephone = _randomGenerator.NextString(3, 10),
                SchoolConversionMainContactOtherRole = _randomGenerator.NextString(3, 10),
                SchoolConversionApproverContactName = _randomGenerator.NextString(3, 10),
                SchoolConversionApproverContactEmail = _randomGenerator.NextString(3, 10),
                SchoolAdInspectedButReportNotPublished = key,
                SchoolAdInspectedReportNotPublishedExplain = _randomGenerator.NextString(3, 10),
                SchoolLaReorganization = key,
                SchoolLaReorganizationExplain = _randomGenerator.NextString(3, 10),
                SchoolLaClosurePlans = key,
                SchoolLaClosurePlansExplain = _randomGenerator.NextString(3, 10),
                SchoolPartOfFederation = key,
                SchoolAddFurtherInformation = key,
                SchoolFurtherInformation = _randomGenerator.NextString(3, 10),
                SchoolAdSchoolContributionToTrust = _randomGenerator.NextString(3, 10),
                SchoolAdSafeguarding = key,
                SchoolAdSafeguardingExplained = _randomGenerator.NextString(3, 10),
                SchoolSACREExemption = key,
                SchoolSACREExemptionEndDate = _randomGenerator.DateTime(),
                SchoolFaithSchool = key,
                SchoolFaithSchoolDioceseName = _randomGenerator.NextString(3, 10),
                SchoolSupportedFoundation = key,
                SchoolSupportedFoundationBodyName = _randomGenerator.NextString(3, 10),
                SchoolAdFeederSchools = _randomGenerator.NextString(3, 10),
                SchoolAdEqualitiesImpactAssessment = key,
                SchoolPFYRevenue = key,
                SchoolPFYRevenueStatus = key,
                SchoolPFYRevenueStatusExplained = _randomGenerator.NextString(3, 10),
                SchoolPFYCapitalForward = key,
                SchoolPFYCapitalForwardStatus = key,
                SchoolPFYCapitalForwardStatusExplained = _randomGenerator.NextString(3, 10),
                SchoolCFYRevenue = key,
                SchoolCFYRevenueStatus = key,
                SchoolCFYRevenueStatusExplained = _randomGenerator.NextString(3, 10),
                SchoolCFYCapitalForward = key,
                SchoolCFYCapitalForwardStatus = key,
                SchoolCFYCapitalForwardStatusExplained = _randomGenerator.NextString(3, 10),
                SchoolNFYRevenue = key,
                SchoolNFYRevenueStatus = key,
                SchoolNFYRevenueStatusExplained = _randomGenerator.NextString(3, 10),
                SchoolNFYCapitalForward = key,
                SchoolNFYCapitalForwardStatus = key,
                SchoolNFYCapitalForwardStatusExplained = _randomGenerator.NextString(3, 10),
                SchoolFinancialInvestigations = key,
                SchoolFinancialInvestigationsExplain = _randomGenerator.NextString(3, 10),
                SchoolFinancialInvestigationsTrustAware = key,
                SchoolNFYEndDate = _randomGenerator.DateTime(),
                SchoolPFYEndDate = _randomGenerator.DateTime(),
                SchoolCFYEndDate = _randomGenerator.DateTime(),
                SchoolLoanExists = 907660000,
                SchoolLeaseExists = 907660001,
                SchoolCapacityYear1 = key,
                SchoolCapacityYear2 = key,
                SchoolCapacityYear3 = key,
                SchoolCapacityAssumptions = _randomGenerator.NextString(3, 10),
                SchoolCapacityPublishedAdmissionsNumber = _randomGenerator.NextString(3, 10),
                SchoolBuildLandOwnerExplained = _randomGenerator.NextString(3, 10),
                SchoolBuildLandSharedFacilities = key,
                SchoolBuildLandSharedFacilitiesExplained = _randomGenerator.NextString(3, 10),
                SchoolBuildLandWorksPlanned = key,
                SchoolBuildLandWorksPlannedExplained = _randomGenerator.NextString(3, 10),
                SchoolBuildLandWorksPlannedDate = _randomGenerator.DateTime(),
                SchoolBuildLandGrants = key,
                SchoolBuildLandGrantsBody = _randomGenerator.NextString(3, 10),
                SchoolBuildLandPriorityBuildingProgramme = key,
                SchoolBuildLandFutureProgramme = key,
                SchoolBuildLandPFIScheme = key,
                SchoolBuildLandPFISchemeType = _randomGenerator.NextString(3, 10),
                SchoolConsultationStakeholders = key,
                SchoolConsultationStakeholdersConsult = _randomGenerator.NextString(3, 10),
                SchoolSupportGrantFundsPaidTo = key,
                SchoolDeclarationSignedByName = _randomGenerator.NextString(3, 10)
            });

            _dbContext.A2BApplyingSchools.AddRange(applyingSchools);
            _dbContext.SaveChanges();
        }
        
        private void SetupA2BApplicationStatusData()
        {
            var statuses = Enumerable.Range(1, 10).Select(k => new A2BApplicationStatus
            {
                Name = _randomGenerator.NextString(3, 10)
            });

            _dbContext.A2BApplicationStatus.AddRange(statuses);
            _dbContext.SaveChanges();
        }
        
        private void SetupA2BApplicationData()
        {
            var applications = Enumerable.Range(1, 10).Select(a => new A2BApplication
            {
                Name = _randomGenerator.NextString(3,10),
                ApplicationType = _randomGenerator.NextString(3,10),
                TrustId = _randomGenerator.NextString(3,10),
                FormTrustProposedNameOfTrust = _randomGenerator.NextString(3,10),
                ApplicationSubmitted = _randomGenerator.Boolean(),
                ApplicationLeadAuthorId = _randomGenerator.NextString(3,10),
                ApplicationVersion = _randomGenerator.NextString(3,10),
                ApplicationLeadAuthorName = _randomGenerator.NextString(3,10),
                ApplicationRole = _randomGenerator.NextString(3,10),
                ApplicationRoleOtherDescription = _randomGenerator.NextString(3,10),
                ChangesToTrust = _randomGenerator.Int(),
                ChangesToTrustExplained = _randomGenerator.NextString(3,10),
                FormTrustOpeningDate = _randomGenerator.DateTime(),
                TrustApproverName = _randomGenerator.NextString(3,10),
                TrustApproverEmail = _randomGenerator.NextString(3,10),
                FormTrustReasonApprovalToConvertAsSat = _randomGenerator.Int(),
                FormTrustReasonApprovedPerson = _randomGenerator.NextString(3,10),
                FormTrustReasonForming = _randomGenerator.NextString(3,10),
                FormTrustReasonVision = _randomGenerator.NextString(3,10),
                FormTrustReasonGeoAreas = _randomGenerator.NextString(3,10),
                FormTrustReasonFreedom = _randomGenerator.NextString(3,10),
                FormTrustReasonImproveTeaching = _randomGenerator.NextString(3,10),
                FormTrustPlanForGrowth = _randomGenerator.NextString(3,10),
                FormTrustPlansForNoGrowth = _randomGenerator.NextString(3,10),
                FormTrustGrowthPlansYesNo = _randomGenerator.Int(),
                FormTrustImprovementSupport = _randomGenerator.NextString(3,10),
                FormTrustImprovementStrategy = _randomGenerator.NextString(3,10),
                FormTrustImprovementApprovedSponsor = _randomGenerator.NextString(3,10),
            });

            _dbContext.A2BApplications.AddRange(applications);
            _dbContext.SaveChanges();
        }


        private void SetupA2BApplicationKeyPersonsData()
        {
            var keyPersons = Enumerable.Range(1, 10).Select(k => new A2BApplicationKeyPersons
            {
                Name = _randomGenerator.NextString(3, 10),
                KeyPersonDateOfBirth = _randomGenerator.NextString(3, 10),
                KeyPersonBiography = _randomGenerator.NextString(3, 10),
                KeyPersonCeoExecutive = _randomGenerator.NextString(3, 10),
                KeyPersonChairOfTrust = _randomGenerator.NextString(3, 10),
                KeyPersonFinancialDirector = _randomGenerator.NextString(3, 10),
                KeyPersonFinancialDirectorTime = _randomGenerator.NextString(3, 10),
                KeyPersonMember = _randomGenerator.NextString(3, 10),
                KeyPersonOther = _randomGenerator.NextString(3, 10),
                KeyPersonTrustee = _randomGenerator.NextString(3, 10)
            });
            
            _dbContext.A2BApplicationKeyPersons.AddRange(keyPersons);
            _dbContext.SaveChanges();
        }
        public void Dispose()
        {
            _dbContext.A2BApplications.RemoveRange(_dbContext.A2BApplications);
            _dbContext.A2BApplicationKeyPersons.RemoveRange(_dbContext.A2BApplicationKeyPersons);
            _dbContext.A2BApplicationStatus.RemoveRange(_dbContext.A2BApplicationStatus);
            _dbContext.A2BApplyingSchools.RemoveRange(_dbContext.A2BApplyingSchools);
            _dbContext.A2BContributors.RemoveRange(_dbContext.A2BContributors);
            _dbContext.A2BSchoolLoans.RemoveRange(_dbContext.A2BSchoolLoans);
            _dbContext.SaveChanges();
        }
    }
}