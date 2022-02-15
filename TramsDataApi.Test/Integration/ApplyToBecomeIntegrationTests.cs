using System;
using System.Collections.Generic;
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
using TramsDataApi.Enums;
using TramsDataApi.Factories;
using TramsDataApi.Factories.A2BApplicationFactories;
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
        private readonly RandomGenerator _randomGenerator;

        public ApplyToBecomeIntegrationTests(TramsDataApiFactory fixture)
        {
            _client = fixture.CreateClient();
            _client.DefaultRequestHeaders.Add("ApiKey", "testing-api-key");
            _dbContext = fixture.Services.GetRequiredService<TramsDbContext>();
            _randomGenerator = new RandomGenerator();
        }

        [Fact]
        public async Task CanGetApplicationByApplicationId()
        {
            const string applicationId = "100001";

            var keyPerson = new A2BApplicationKeyPersons
            {
                Name = _randomGenerator.NextString(2, 10),
                KeyPersonDateOfBirth = _randomGenerator.DateTime(),
                KeyPersonBiography = _randomGenerator.NextString(2, 10),
                KeyPersonCeoExecutive = _randomGenerator.Boolean(),
                KeyPersonChairOfTrust = _randomGenerator.Boolean(),
                KeyPersonFinancialDirector = _randomGenerator.Boolean(),
                KeyPersonFinancialDirectorTime = _randomGenerator.NextString(2, 10),
                KeyPersonMember = _randomGenerator.NextString(2, 10),
                KeyPersonOther = _randomGenerator.NextString(2, 10),
                KeyPersonTrustee = _randomGenerator.NextString(2, 10)
            };
            
           var applyingSchool = new A2BApplicationApplyingSchool
            {
                UpdatedTrustFields = _randomGenerator.NextString(2, 10),
                SchoolDeclarationSignedById = _randomGenerator.NextString(2, 10),
                SchoolDeclarationBodyAgree = _randomGenerator.Boolean(),
                SchoolDeclarationTeacherChair = _randomGenerator.Boolean(),
                SchoolDeclarationSignedByEmail = _randomGenerator.NextString(2, 10),
                Name = _randomGenerator.NextString(2, 10),
                UpdatedSchoolFields = _randomGenerator.NextString(2, 10),
                SchoolConversionReasonsForJoining = _randomGenerator.NextString(2, 10),
                SchoolConversionTargetDateDifferent = 1,
                SchoolConversionTargetDateDate = _randomGenerator.DateTime(),
                SchoolConversionTargetDateExplained = _randomGenerator.NextString(2, 10),
                SchoolConversionChangeName = 1,
                SchoolConversionChangeNameValue = _randomGenerator.NextString(2, 10),
                SchoolConversionContactHeadName = _randomGenerator.NextString(2, 10),
                SchoolConversionContactHeadEmail = _randomGenerator.NextString(2, 10),
                SchoolConversionContactHeadTel = _randomGenerator.NextString(2, 10),
                SchoolConversionContactChairName = _randomGenerator.NextString(2, 10),
                SchoolConversionContactChairEmail = _randomGenerator.NextString(2, 10),
                SchoolConversionContactChairTel = _randomGenerator.NextString(2, 10),
                SchoolConversionMainContact = 1,
                SchoolConversionMainContactOtherName = _randomGenerator.NextString(2, 10),
                SchoolConversionMainContactOtherEmail = _randomGenerator.NextString(2, 10),
                SchoolConversionMainContactOtherTelephone = _randomGenerator.NextString(2, 10),
                SchoolConversionMainContactOtherRole = _randomGenerator.NextString(2, 10),
                SchoolConversionApproverContactName = _randomGenerator.NextString(2, 10),
                SchoolConversionApproverContactEmail = _randomGenerator.NextString(2, 10),
                SchoolAdInspectedButReportNotPublished = 1,
                SchoolAdInspectedReportNotPublishedExplain = _randomGenerator.NextString(2, 10),
                SchoolLaReorganization = 1,
                SchoolLaReorganizationExplain = _randomGenerator.NextString(2, 10),
                SchoolLaClosurePlans = 1,
                SchoolLaClosurePlansExplain = _randomGenerator.NextString(2, 10),
                SchoolPartOfFederation = 1,
                SchoolAddFurtherInformation = 1,
                SchoolFurtherInformation = _randomGenerator.NextString(2, 10),
                SchoolAdSchoolContributionToTrust = _randomGenerator.NextString(2, 10),
                SchoolAdSafeguarding = 1,
                SchoolAdSafeguardingExplained = _randomGenerator.NextString(2, 10),
                SchoolSACREExemption = 1,
                SchoolSACREExemptionEndDate = _randomGenerator.DateTime(),
                SchoolFaithSchool = 1,
                SchoolFaithSchoolDioceseName = _randomGenerator.NextString(2, 10),
                SchoolSupportedFoundation = 1,
                SchoolSupportedFoundationBodyName = _randomGenerator.NextString(2, 10),
                SchoolAdFeederSchools = _randomGenerator.NextString(2, 10),
                SchoolAdEqualitiesImpactAssessment = 1,
                SchoolPFYRevenue = 1000,
                SchoolPFYRevenueStatus = 1,
                SchoolPFYRevenueStatusExplained = _randomGenerator.NextString(2, 10),
                SchoolPFYCapitalForward = 1000,
                SchoolPFYCapitalForwardStatus = 1,
                SchoolPFYCapitalForwardStatusExplained = _randomGenerator.NextString(2, 10),
                SchoolCFYRevenue = 1000,
                SchoolCFYRevenueStatus = 1,
                SchoolCFYRevenueStatusExplained = _randomGenerator.NextString(2, 10),
                SchoolCFYCapitalForward = 1000,
                SchoolCFYCapitalForwardStatus = 1,
                SchoolCFYCapitalForwardStatusExplained = _randomGenerator.NextString(2, 10),
                SchoolNFYRevenue = 1000,
                SchoolNFYRevenueStatus = 1,
                SchoolNFYRevenueStatusExplained = _randomGenerator.NextString(2, 10),
                SchoolNFYCapitalForward = 1000,
                SchoolNFYCapitalForwardStatus = 1,
                SchoolNFYCapitalForwardStatusExplained = _randomGenerator.NextString(2, 10),
                SchoolFinancialInvestigations = 1,
                SchoolFinancialInvestigationsExplain = _randomGenerator.NextString(2, 10),
                SchoolFinancialInvestigationsTrustAware = 1,
                SchoolNFYEndDate = _randomGenerator.DateTime(),
                SchoolPFYEndDate = _randomGenerator.DateTime(),
                SchoolCFYEndDate = _randomGenerator.DateTime(),
                SchoolLoanExists = _randomGenerator.Boolean(),
                SchoolLeaseExists = _randomGenerator.Boolean(),
                SchoolCapacityYear1 = 1,
                SchoolCapacityYear2 = 1,
                SchoolCapacityYear3 = 1,
                SchoolCapacityAssumptions = _randomGenerator.NextString(2, 10),
                SchoolCapacityPublishedAdmissionsNumber = _randomGenerator.NextString(2, 10),
                SchoolBuildLandOwnerExplained = _randomGenerator.NextString(2, 10),
                SchoolBuildLandSharedFacilities = 1,
                SchoolBuildLandSharedFacilitiesExplained = _randomGenerator.NextString(2, 10),
                SchoolBuildLandWorksPlanned = 1,
                SchoolBuildLandWorksPlannedExplained = _randomGenerator.NextString(2, 10),
                SchoolBuildLandWorksPlannedDate = _randomGenerator.DateTime(),
                SchoolBuildLandGrants = 1,
                SchoolBuildLandGrantsBody = _randomGenerator.NextString(2, 10),
                SchoolBuildLandPriorityBuildingProgramme = 1,
                SchoolBuildLandFutureProgramme = 1,
                SchoolBuildLandPFIScheme = 1,
                SchoolBuildLandPFISchemeType = _randomGenerator.NextString(2, 10),
                SchoolConsultationStakeholders = 1,
                SchoolConsultationStakeholdersConsult = _randomGenerator.NextString(2, 10),
                SchoolSupportGrantFundsPaidTo = 1,
                SchoolDeclarationSignedByName = _randomGenerator.NextString(2, 10)
            };

            
            var application = Builder<A2BApplication>
                .CreateNew()
                .With(a => a.ApplicationId = applicationId)
                .With(a => a.TrustApproverEmail = "test@test.com")
                .With(a => a.ApplicationType = (int?) A2BApplicationTypeEnum.FormSat)
                .With(a => a.KeyPersons = new List<A2BApplicationKeyPersons> {keyPerson})
                .With(a => a.ApplyingSchools = new List<A2BApplicationApplyingSchool> {applyingSchool})
                .Build();

            _dbContext.A2BApplications.Add(application);
            await _dbContext.SaveChangesAsync();
            
            var expected = A2BApplicationFactory.Create(application);
            var expectedResponse = new ApiSingleResponseV2<A2BApplicationResponse>(expected);
            
            var response = await _client.GetAsync($"/v2/apply-to-become/application/{applicationId}");
        
        
            response.StatusCode.Should().Be(200);
            
            var result = await response.Content.ReadFromJsonAsync<ApiSingleResponseV2<A2BApplicationResponse>>();
            result.Should().BeEquivalentTo(expectedResponse); 
            result.Data.ApplicationId.Should().Be(expectedResponse.Data.ApplicationId);
        }

        [Fact]
        public async Task CanCreateApplication()
        {
            var keyPerson = new A2BApplicationKeyPersonsModel
            {
                Name = _randomGenerator.NextString(2, 10),
                KeyPersonDateOfBirth = _randomGenerator.DateTime(),
                KeyPersonBiography = _randomGenerator.NextString(2, 10),
                KeyPersonCeoExecutive = _randomGenerator.Boolean(),
                KeyPersonChairOfTrust = _randomGenerator.Boolean(),
                KeyPersonFinancialDirector = _randomGenerator.Boolean(),
                KeyPersonFinancialDirectorTime = _randomGenerator.NextString(2, 10),
                KeyPersonMember = _randomGenerator.NextString(2, 10),
                KeyPersonOther = _randomGenerator.NextString(2, 10),
                KeyPersonTrustee = _randomGenerator.NextString(2, 10)
            };

            var applyingSchool = new A2BApplicationApplyingSchoolModel
            {
                UpdatedTrustFields = _randomGenerator.NextString(2, 10),
                SchoolDeclarationSignedById = _randomGenerator.NextString(2, 10),
                SchoolDeclarationBodyAgree = _randomGenerator.Boolean(),
                SchoolDeclarationTeacherChair = _randomGenerator.Boolean(),
                SchoolDeclarationSignedByEmail = _randomGenerator.NextString(2, 10),
                Name = _randomGenerator.NextString(2, 10),
                UpdatedSchoolFields = _randomGenerator.NextString(2, 10),
                SchoolConversionReasonsForJoining = _randomGenerator.NextString(2, 10),
                SchoolConversionTargetDateDifferent = 1,
                SchoolConversionTargetDateDate = _randomGenerator.DateTime(),
                SchoolConversionTargetDateExplained = _randomGenerator.NextString(2, 10),
                SchoolConversionChangeName = 1,
                SchoolConversionChangeNameValue = _randomGenerator.NextString(2, 10),
                SchoolConversionContactHeadName = _randomGenerator.NextString(2, 10),
                SchoolConversionContactHeadEmail = _randomGenerator.NextString(2, 10),
                SchoolConversionContactHeadTel = _randomGenerator.NextString(2, 10),
                SchoolConversionContactChairName = _randomGenerator.NextString(2, 10),
                SchoolConversionContactChairEmail = _randomGenerator.NextString(2, 10),
                SchoolConversionContactChairTel = _randomGenerator.NextString(2, 10),
                SchoolConversionMainContact = 1,
                SchoolConversionMainContactOtherName = _randomGenerator.NextString(2, 10),
                SchoolConversionMainContactOtherEmail = _randomGenerator.NextString(2, 10),
                SchoolConversionMainContactOtherTelephone = _randomGenerator.NextString(2, 10),
                SchoolConversionMainContactOtherRole = _randomGenerator.NextString(2, 10),
                SchoolConversionApproverContactName = _randomGenerator.NextString(2, 10),
                SchoolConversionApproverContactEmail = _randomGenerator.NextString(2, 10),
                SchoolAdInspectedButReportNotPublished = 1,
                SchoolAdInspectedReportNotPublishedExplain = _randomGenerator.NextString(2, 10),
                SchoolLaReorganization = 1,
                SchoolLaReorganizationExplain = _randomGenerator.NextString(2, 10),
                SchoolLaClosurePlans = 1,
                SchoolLaClosurePlansExplain = _randomGenerator.NextString(2, 10),
                SchoolPartOfFederation = 1,
                SchoolAddFurtherInformation = 1,
                SchoolFurtherInformation = _randomGenerator.NextString(2, 10),
                SchoolAdSchoolContributionToTrust = _randomGenerator.NextString(2, 10),
                SchoolAdSafeguarding = 1,
                SchoolAdSafeguardingExplained = _randomGenerator.NextString(2, 10),
                SchoolSACREExemption = 1,
                SchoolSACREExemptionEndDate = _randomGenerator.DateTime(),
                SchoolFaithSchool = 1,
                SchoolFaithSchoolDioceseName = _randomGenerator.NextString(2, 10),
                SchoolSupportedFoundation = 1,
                SchoolSupportedFoundationBodyName = _randomGenerator.NextString(2, 10),
                SchoolAdFeederSchools = _randomGenerator.NextString(2, 10),
                SchoolAdEqualitiesImpactAssessment = 1,
                SchoolPFYRevenue = 1000,
                SchoolPFYRevenueStatus = 1,
                SchoolPFYRevenueStatusExplained = _randomGenerator.NextString(2, 10),
                SchoolPFYCapitalForward = 1000,
                SchoolPFYCapitalForwardStatus = 1,
                SchoolPFYCapitalForwardStatusExplained = _randomGenerator.NextString(2, 10),
                SchoolCFYRevenue = 1000,
                SchoolCFYRevenueStatus = 1,
                SchoolCFYRevenueStatusExplained = _randomGenerator.NextString(2, 10),
                SchoolCFYCapitalForward = 1000,
                SchoolCFYCapitalForwardStatus = 1,
                SchoolCFYCapitalForwardStatusExplained = _randomGenerator.NextString(2, 10),
                SchoolNFYRevenue = 1000,
                SchoolNFYRevenueStatus = 1,
                SchoolNFYRevenueStatusExplained = _randomGenerator.NextString(2, 10),
                SchoolNFYCapitalForward = 1000,
                SchoolNFYCapitalForwardStatus = 1,
                SchoolNFYCapitalForwardStatusExplained = _randomGenerator.NextString(2, 10),
                SchoolFinancialInvestigations = 1,
                SchoolFinancialInvestigationsExplain = _randomGenerator.NextString(2, 10),
                SchoolFinancialInvestigationsTrustAware = 1,
                SchoolNFYEndDate = _randomGenerator.DateTime(),
                SchoolPFYEndDate = _randomGenerator.DateTime(),
                SchoolCFYEndDate = _randomGenerator.DateTime(),
                SchoolLoanExists = _randomGenerator.Boolean(),
                SchoolLeaseExists = _randomGenerator.Boolean(),
                SchoolCapacityYear1 = 1,
                SchoolCapacityYear2 = 1,
                SchoolCapacityYear3 = 1,
                SchoolCapacityAssumptions = _randomGenerator.NextString(2, 10),
                SchoolCapacityPublishedAdmissionsNumber = _randomGenerator.NextString(2, 10),
                SchoolBuildLandOwnerExplained = _randomGenerator.NextString(2, 10),
                SchoolBuildLandSharedFacilities = 1,
                SchoolBuildLandSharedFacilitiesExplained = _randomGenerator.NextString(2, 10),
                SchoolBuildLandWorksPlanned = 1,
                SchoolBuildLandWorksPlannedExplained = _randomGenerator.NextString(2, 10),
                SchoolBuildLandWorksPlannedDate = _randomGenerator.DateTime(),
                SchoolBuildLandGrants = 1,
                SchoolBuildLandGrantsBody = _randomGenerator.NextString(2, 10),
                SchoolBuildLandPriorityBuildingProgramme = 1,
                SchoolBuildLandFutureProgramme = 1,
                SchoolBuildLandPFIScheme = 1,
                SchoolBuildLandPFISchemeType = _randomGenerator.NextString(2, 10),
                SchoolConsultationStakeholders = 1,
                SchoolConsultationStakeholdersConsult = _randomGenerator.NextString(2, 10),
                SchoolSupportGrantFundsPaidTo = 1,
                SchoolDeclarationSignedByName = _randomGenerator.NextString(2, 10)
            };

            var application = new A2BApplicationCreateRequest
            {
                
                ApplicationId = "10001",
                Name = _randomGenerator.NextString(2, 10),
                FormTrustProposedNameOfTrust = _randomGenerator.NextString(2, 10),
                ApplicationSubmitted = _randomGenerator.Boolean(),
                ApplicationLeadAuthorId = _randomGenerator.NextString(2, 10),
                ApplicationVersion = _randomGenerator.NextString(2, 10),
                ApplicationLeadAuthorName = _randomGenerator.NextString(2, 10),
                ApplicationLeadEmail = _randomGenerator.NextString(2, 10),
                ApplicationRole = _randomGenerator.NextString(2, 10),
                ApplicationRoleOtherDescription = _randomGenerator.NextString(2, 10),
                ChangesToTrust = _randomGenerator.Boolean(),
                ChangesToTrustExplained = _randomGenerator.NextString(2, 10),
                ChangesToLaGovernance = _randomGenerator.Boolean(),
                ChangesToLaGovernanceExplained = _randomGenerator.NextString(2, 10),
                FormTrustOpeningDate = _randomGenerator.DateTime(),
                TrustApproverName = _randomGenerator.NextString(2, 10),
                FormTrustReasonApprovalToConvertAsSat = _randomGenerator.Boolean(),
                FormTrustReasonApprovedPerson = _randomGenerator.NextString(2, 10),
                FormTrustReasonForming = _randomGenerator.NextString(2, 10),
                FormTrustReasonVision = _randomGenerator.NextString(2, 10),
                FormTrustReasonGeoAreas = _randomGenerator.NextString(2, 10),
                FormTrustReasonFreedom = _randomGenerator.NextString(2, 10),
                FormTrustReasonImproveTeaching = _randomGenerator.NextString(2, 10),
                FormTrustPlanForGrowth = _randomGenerator.NextString(2, 10),
                FormTrustPlansForNoGrowth = _randomGenerator.NextString(2, 10),
                FormTrustGrowthPlansYesNo = _randomGenerator.Boolean(),
                FormTrustImprovementSupport = _randomGenerator.NextString(2, 10),
                FormTrustImprovementStrategy = _randomGenerator.NextString(2, 10),
                FormTrustImprovementApprovedSponsor = _randomGenerator.NextString(2, 10),
                TrustId = _randomGenerator.NextString(2, 10),
                ApplicationStatusId = _randomGenerator.NextString(2, 10),
                TrustApproverEmail = "test@test.com",
                ApplicationType = (int?) A2BApplicationTypeEnum.FormSat,
                KeyPersons = new List<A2BApplicationKeyPersonsModel> {keyPerson},
                ApplyingSchools = new List<A2BApplicationApplyingSchoolModel> {applyingSchool}
            };
            
            var response = await _client.PostAsJsonAsync("/v2/apply-to-become/application/", application);
            var result = await response.Content.ReadFromJsonAsync<ApiSingleResponseV2<A2BApplicationResponse>>();
            response.StatusCode.Should().Be(201);
            result.Should().NotBeNull();
        
            var createdApplication =
                _dbContext.A2BApplications
                    .Include(a => a.KeyPersons)
                    .Include(a => a.ApplyingSchools)
                    .FirstOrDefault(a => a.ApplicationId == result.Data.ApplicationId);

            createdApplication.Should().NotBeNull();

            var expectedResponse = A2BApplicationFactory.Create(createdApplication);
            
            result.Data.Should().BeEquivalentTo(expectedResponse);
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

        [Fact]
        public async Task CanGetSchoolLoanByLoanId()
        {
            SetupA2BSchoolLoanData();
            
            var loan = _dbContext.A2BSchoolLoans.First();
            var expected = A2BSchoolLoanResponseFactory.Create(loan);
            var expectedResponse = new ApiSingleResponseV2<A2BSchoolLoanResponse>(expected);
            
            var response = await _client.GetAsync($"/v2/apply-to-become/school-loans/{loan.SchoolLoanId}");

            response.StatusCode.Should().Be(200);
            
            var result = await response.Content.ReadFromJsonAsync<ApiSingleResponseV2<A2BSchoolLoanResponse>>();
            result.Should().BeEquivalentTo(expectedResponse); 
            result.Data.SchoolLoanId.Should().Be(expectedResponse.Data.SchoolLoanId);
        }
        
        [Fact]
        public async Task CanCreateSchoolLease()
        {
            var schoolLeaseRequest = new A2BSchoolLeaseCreateRequest
            {
                SchoolLeaseId = "1000",
                SchoolLeaseTerm = "Test LeaseTerm",
                SchoolLeaseRepaymentValue = "Test LeaseRepaymentValue",
                SchoolLeaseInterestRate = "Test LeaseInterestRate",
                SchoolLeasePaymentToDate = "Test LeasePaymentToDate",
                SchoolLeasePurpose = "Test LeasePurpose",
                SchoolLeaseValueOfAssets = "Test LeaseValueOfAssets",
                SchoolLeaseResponsibleForAssets = "Test LeaseResponsibleForAssets"
            };
   
            var response = await _client.PostAsJsonAsync("/v2/apply-to-become/school-leases/", schoolLeaseRequest);

            response.StatusCode.Should().Be(201);
            
            var result = await response.Content.ReadFromJsonAsync<ApiSingleResponseV2<A2BSchoolLeaseResponse>>();

            result.Should().NotBeNull();

            var createdSchoolLease =
                _dbContext.A2BSchoolLeases.FirstOrDefault(a => a.SchoolLeaseId == result.Data.SchoolLeaseId);

            createdSchoolLease.Should().NotBeNull();
            result.Data.Should().BeEquivalentTo(createdSchoolLease);
        }
        
        [Fact]
        public async Task CanGetSchoolLeaseByLeaseId()
        {
            SetupA2BSchoolLeaseData();
            
            var lease = _dbContext.A2BSchoolLeases.First();
            var expected = A2BSchoolLeaseResponseFactory.Create(lease);
            var expectedResponse = new ApiSingleResponseV2<A2BSchoolLeaseResponse>(expected);
            
            var response = await _client.GetAsync($"/v2/apply-to-become/school-leases/{lease.SchoolLeaseId}");

            response.StatusCode.Should().Be(200);
            
            var result = await response.Content.ReadFromJsonAsync<ApiSingleResponseV2<A2BSchoolLeaseResponse>>();
            result.Should().BeEquivalentTo(expectedResponse); 
            result.Data.SchoolLeaseId.Should().Be(expectedResponse.Data.SchoolLeaseId);
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
        
        private void SetupA2BSchoolLoanData()
        {
            var loans = Enumerable.Range(1, 10).Select(key => new A2BSchoolLoan
                {
                    SchoolLoanId = $"1000{key}",
                    SchoolLoanAmount = new decimal(2.66),
                    SchoolLoanPurpose = _randomGenerator.NextString(3, 10),
                    SchoolLoanProvider = _randomGenerator.NextString(3, 10),
                    SchoolLoanInterestRate = _randomGenerator.NextString(3, 10),
                    SchoolLoanSchedule = _randomGenerator.NextString(3, 10),
                });

            _dbContext.A2BSchoolLoans.AddRange(loans);
            _dbContext.SaveChanges();
        }
        
        private void SetupA2BSchoolLeaseData()
        {
            var leases = Enumerable.Range(1, 10).Select(key => new A2BSchoolLease
            {
                SchoolLeaseId = $"1000{key}",
                SchoolLeaseTerm = _randomGenerator.NextString(3, 10),
                SchoolLeaseRepaymentValue = _randomGenerator.NextString(3, 10),
                SchoolLeaseInterestRate = _randomGenerator.NextString(3, 10),
                SchoolLeasePaymentToDate = _randomGenerator.NextString(3, 10),
                SchoolLeasePurpose = _randomGenerator.NextString(3, 10),
                SchoolLeaseValueOfAssets = _randomGenerator.NextString(3, 10),
                SchoolLeaseResponsibleForAssets = _randomGenerator.NextString(3, 10)
            });

            _dbContext.A2BSchoolLeases.AddRange(leases);
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

        public void Dispose()
        {
            _dbContext.A2BApplicationKeyPersons.RemoveRange(_dbContext.A2BApplicationKeyPersons);
            _dbContext.A2BApplicationApplyingSchools.RemoveRange(_dbContext.A2BApplicationApplyingSchools);
            _dbContext.A2BApplications.RemoveRange(_dbContext.A2BApplications);
            _dbContext.A2BApplicationStatus.RemoveRange(_dbContext.A2BApplicationStatus);
            
            _dbContext.A2BContributors.RemoveRange(_dbContext.A2BContributors);
            _dbContext.A2BSchoolLoans.RemoveRange(_dbContext.A2BSchoolLoans);
            _dbContext.A2BSchoolLeases.RemoveRange(_dbContext.A2BSchoolLeases);
            _dbContext.SaveChanges();
        }
    }
}