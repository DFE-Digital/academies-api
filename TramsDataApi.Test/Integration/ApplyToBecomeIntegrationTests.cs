using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using FizzWare.NBuilder;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using TramsDataApi.DatabaseModels;
using TramsDataApi.Factories.A2BApplicationFactories;
using TramsDataApi.RequestModels.ApplyToBecome;
using TramsDataApi.ResponseModels;
using TramsDataApi.ResponseModels.ApplyToBecome;
using TramsDataApi.ServiceModels.ApplyToBecome;
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
                KeyPersonMember = _randomGenerator.Boolean(),
                KeyPersonOther = _randomGenerator.Boolean(),
                KeyPersonTrustee = _randomGenerator.Boolean(),
                DynamicsKeyPersonId = _randomGenerator.Guid()
            };

            var loan = new A2BSchoolLoan
            {
                SchoolLoanAmount = 1000,
                SchoolLoanInterestRate = _randomGenerator.NextString(2, 4),
                SchoolLoanProvider = _randomGenerator.NextString(2, 10),
                SchoolLoanPurpose = _randomGenerator.NextString(2, 10),
                SchoolLoanSchedule = _randomGenerator.NextString(2, 10),
                DynamicsSchoolLoanId = _randomGenerator.Guid()
            };
            var lease = new A2BSchoolLease
            {
                SchoolLeaseInterestRate = 10,
                SchoolLeasePaymentToDate = 100,
                SchoolLeasePurpose = _randomGenerator.NextString(2, 10),
                SchoolLeaseRepaymentValue = 1000,
                SchoolLeaseResponsibleForAssets = _randomGenerator.NextString(2, 10),
                SchoolLeaseTerm = _randomGenerator.NextString(2, 10),
                SchoolLeaseValueOfAssets = _randomGenerator.NextString(2, 10),
                DynamicsSchoolLeaseId = _randomGenerator.Guid()
            };

           var applyingSchool = new A2BApplicationApplyingSchool
            {
                SchoolDeclarationSignedById = _randomGenerator.NextString(2, 10),
                SchoolDeclarationBodyAgree = _randomGenerator.Boolean(),
                SchoolDeclarationTeacherChair = _randomGenerator.Boolean(),
                SchoolDeclarationSignedByEmail = _randomGenerator.NextString(2, 10),
                Name = _randomGenerator.NextString(2, 10),
                SchoolConversionReasonsForJoining = _randomGenerator.NextString(2, 10),
                SchoolConversionTargetDateDifferent = true,
                SchoolConversionTargetDateDate = _randomGenerator.DateTime(),
                SchoolConversionTargetDateExplained = _randomGenerator.NextString(2, 10),
                SchoolConversionChangeName = true,
                SchoolConversionChangeNameValue = _randomGenerator.NextString(2, 10),
                SchoolConversionContactHeadName = _randomGenerator.NextString(2, 10),
                SchoolConversionContactHeadEmail = _randomGenerator.NextString(2, 10),
                SchoolConversionContactHeadTel = _randomGenerator.NextString(2, 10),
                SchoolConversionContactChairName = _randomGenerator.NextString(2, 10),
                SchoolConversionContactChairEmail = _randomGenerator.NextString(2, 10),
                SchoolConversionContactChairTel = _randomGenerator.NextString(2, 10),
                SchoolConversionContactRole = _randomGenerator.NextString(2,10),
                SchoolConversionMainContactOtherName = _randomGenerator.NextString(2, 10),
                SchoolConversionMainContactOtherEmail = _randomGenerator.NextString(2, 10),
                SchoolConversionMainContactOtherTelephone = _randomGenerator.NextString(2, 10),
                SchoolConversionMainContactOtherRole = _randomGenerator.NextString(2, 10),
                SchoolConversionApproverContactName = _randomGenerator.NextString(2, 10),
                SchoolConversionApproverContactEmail = _randomGenerator.NextString(2, 10),
                SchoolAdInspectedButReportNotPublished = true,
                SchoolAdInspectedReportNotPublishedExplain = _randomGenerator.NextString(2, 10),
                SchoolLaReorganization = true,
                SchoolLaReorganizationExplain = _randomGenerator.NextString(2, 10),
                SchoolLaClosurePlans = true,
                SchoolLaClosurePlansExplain = _randomGenerator.NextString(2, 10),
                SchoolPartOfFederation = true,
                SchoolAddFurtherInformation = true,
                SchoolFurtherInformation = _randomGenerator.NextString(2, 10),
                SchoolAdSchoolContributionToTrust = _randomGenerator.NextString(2, 10),
                SchoolAdSafeguarding = true,
                SchoolAdSafeguardingExplained = _randomGenerator.NextString(2, 10),
                SchoolSACREExemption = true,
                SchoolSACREExemptionEndDate = _randomGenerator.DateTime(),
                SchoolFaithSchool = true,
                SchoolFaithSchoolDioceseName = _randomGenerator.NextString(2, 10),
                SchoolSupportedFoundation = true,
                SchoolSupportedFoundationBodyName = _randomGenerator.NextString(2, 10),
                SchoolAdFeederSchools = _randomGenerator.NextString(2, 10),
                SchoolAdEqualitiesImpactAssessment = true,
                SchoolPFYRevenue = 1000,
                SchoolPFYRevenueStatusExplained = _randomGenerator.NextString(2, 10),
                SchoolPFYCapitalForward = 1000,
                SchoolPFYCapitalForwardStatusExplained = _randomGenerator.NextString(2, 10),
                SchoolPFYCapitalIsDeficit = _randomGenerator.Boolean(),
                SchoolPFYRevenueIsDeficit = _randomGenerator.Boolean(),
                SchoolCFYRevenue = 1000,
                SchoolCFYRevenueStatusExplained = _randomGenerator.NextString(2, 10),
                SchoolCFYCapitalForward = 1000,
                SchoolCFYCapitalForwardStatusExplained = _randomGenerator.NextString(2, 10),
               SchoolCFYCapitalIsDeficit = _randomGenerator.Boolean(),
               SchoolCFYRevenueIsDeficit = _randomGenerator.Boolean(),
               SchoolNFYRevenue = 1000,
                SchoolNFYRevenueStatusExplained = _randomGenerator.NextString(2, 10),
                SchoolNFYCapitalForward = 1000,
                SchoolNFYCapitalForwardStatusExplained = _randomGenerator.NextString(2, 10),
               SchoolNFYCapitalIsDeficit = _randomGenerator.Boolean(),
               SchoolNFYRevenueIsDeficit = _randomGenerator.Boolean(),
               SchoolFinancialInvestigations = true,
                SchoolFinancialInvestigationsExplain = _randomGenerator.NextString(2, 10),
                SchoolFinancialInvestigationsTrustAware = true,
                SchoolNFYEndDate = _randomGenerator.DateTime(),
                SchoolPFYEndDate = _randomGenerator.DateTime(),
                SchoolCFYEndDate = _randomGenerator.DateTime(),
                ProjectedPupilNumbersYear1 = 1,
                ProjectedPupilNumbersYear2 = 1,
                ProjectedPupilNumbersYear3 = 1,
                SchoolCapacityAssumptions = _randomGenerator.NextString(2, 10),
                SchoolCapacityPublishedAdmissionsNumber = 100,
                SchoolBuildLandOwnerExplained = _randomGenerator.NextString(2, 10),
                SchoolBuildLandSharedFacilities = true,
                SchoolBuildLandSharedFacilitiesExplained = _randomGenerator.NextString(2, 10),
                SchoolBuildLandWorksPlanned = true,
                SchoolBuildLandWorksPlannedExplained = _randomGenerator.NextString(2, 10),
                SchoolBuildLandWorksPlannedDate = _randomGenerator.DateTime(),
                SchoolBuildLandGrants = true,
                SchoolBuildLandGrantsBody = _randomGenerator.NextString(2, 10),
                SchoolBuildLandPriorityBuildingProgramme = true,
                SchoolBuildLandFutureProgramme = true,
                SchoolBuildLandPFIScheme = true,
                SchoolBuildLandPFISchemeType = _randomGenerator.NextString(2, 10),
                SchoolConsultationStakeholders = true,
                SchoolConsultationStakeholdersConsult = _randomGenerator.NextString(2, 10),
                SchoolSupportGrantFundsPaidTo = _randomGenerator.NextString(2, 10),
                SchoolDeclarationSignedByName = _randomGenerator.NextString(2, 10),
                SchoolAdEqualitiesImpactAssessmentDetails = _randomGenerator.NextString(2,10),
               SchoolLeases = new List<A2BSchoolLease>() { lease },
               SchoolLoans = new List<A2BSchoolLoan>() { loan },
               DynamicsApplicationId = _randomGenerator.Guid(),
               DynamicsApplyingSchoolId = _randomGenerator.Guid(),
               Urn = _randomGenerator.Int(),
               LocalAuthorityName = _randomGenerator.NextString(2, 10)
           };

            var application = Builder<A2BApplication>
                .CreateNew()
                .With(a => a.ApplicationId = applicationId)
                .With(a => a.TrustApproverEmail = "test@test.com")
                .With(a => a.ApplicationType = "JoinMat")
                .With(a => a.KeyPersons = new List<A2BApplicationKeyPersons> {keyPerson})
                .With(a => a.ApplyingSchools = new List<A2BApplicationApplyingSchool> {applyingSchool})                
                .Build();

            _dbContext.A2BApplications.Add(application);
            await _dbContext.SaveChangesAsync();
            
            var expected = A2BApplicationFactory.Create(application);
            var expectedResponse = new ApiSingleResponseV2<A2BApplicationResponse>(expected);
            
            var response = await _client.GetAsync($"/v2/apply-to-become/application/{applicationId}");
     
        
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            
            var result = await response.Content.ReadFromJsonAsync<ApiSingleResponseV2<A2BApplicationResponse>>();
            result.Should().BeEquivalentTo(expectedResponse); 
            result.Data.ApplicationId.Should().Be(expectedResponse.Data.ApplicationId);
        }

        [Fact]
        public async Task CanCreateApplication()
        {
            var keyPerson = new A2BApplicationKeyPersonsServiceModel
            {
                Name = _randomGenerator.NextString(2, 10),
                KeyPersonDateOfBirth = _randomGenerator.DateTime(),
                KeyPersonBiography = _randomGenerator.NextString(2, 10),
                KeyPersonCeoExecutive = _randomGenerator.Boolean(),
                KeyPersonChairOfTrust = _randomGenerator.Boolean(),
                KeyPersonFinancialDirector = _randomGenerator.Boolean(),
                KeyPersonMember = _randomGenerator.Boolean(),
                KeyPersonOther = _randomGenerator.Boolean(),
                KeyPersonTrustee = _randomGenerator.Boolean(),
                DynamicsKeyPersonId = _randomGenerator.Guid()
            };

            var loan = new A2BSchoolLoanServiceModel
            {
                SchoolLoanAmount = 1000,
                SchoolLoanInterestRate = "15%",
                SchoolLoanProvider = "Provider",
                SchoolLoanPurpose = "Purpose",
                SchoolLoanSchedule = "£100 monthly for two years",
                DynamicsSchoolLoanId = _randomGenerator.Guid()
            };
            var lease = new A2BSchoolLeaseServiceModel
            {
                SchoolLeaseInterestRate = 20,
                SchoolLeasePaymentToDate = 300,
                SchoolLeasePurpose = "purpose",
                SchoolLeaseRepaymentValue = 1100,
                SchoolLeaseResponsibleForAssets = "who is responsible",
                SchoolLeaseTerm = " 18  months",
                SchoolLeaseValueOfAssets = "500",
                DynamicsSchoolLeaseId = _randomGenerator.Guid()
            };

            var applyingSchool = new A2BApplicationApplyingSchoolServiceModel
            {
                DeclarationBodyAgree = _randomGenerator.Boolean(),
                DeclarationSignedByName = _randomGenerator.NextString(2, 10),
                DeclarationIAmTheChairOrHeadteacher = _randomGenerator.Boolean(),
                SchoolName = _randomGenerator.NextString(2, 10),
                SchoolConversionReasonsForJoining = _randomGenerator.NextString(2, 10),
                SchoolConversionTargetDateSpecified = true,
                SchoolConversionTargetDate = _randomGenerator.DateTime(),
                SchoolConversionTargetDateExplained = _randomGenerator.NextString(2, 10),
                SchoolConversionChangeNamePlanned = true,
                SchoolConversionProposedNewSchoolName = _randomGenerator.NextString(2, 10),
                SchoolConversionContactHeadName = _randomGenerator.NextString(2, 10),
                SchoolConversionContactHeadEmail = _randomGenerator.NextString(2, 10),
                SchoolConversionContactHeadTel = _randomGenerator.NextString(2, 10),
                SchoolConversionContactChairName = _randomGenerator.NextString(2, 10),
                SchoolConversionContactChairEmail = _randomGenerator.NextString(2, 10),
                SchoolConversionContactChairTel = _randomGenerator.NextString(2, 10),
                SchoolConversionContactRole = _randomGenerator.NextString(2, 10),
                SchoolConversionMainContactOtherName = _randomGenerator.NextString(2, 10),
                SchoolConversionMainContactOtherEmail = _randomGenerator.NextString(2, 10),
                SchoolConversionMainContactOtherTelephone = _randomGenerator.NextString(2, 10),
                SchoolConversionMainContactOtherRole = _randomGenerator.NextString(2, 10),
                SchoolConversionApproverContactName = _randomGenerator.NextString(2, 10),
                SchoolConversionApproverContactEmail = _randomGenerator.NextString(2, 10),
                SchoolAdInspectedButReportNotPublished = true,
                SchoolAdInspectedButReportNotPublishedExplain = _randomGenerator.NextString(2, 10),
                SchoolPartOfLaReorganizationPlan = true,
                SchoolLaReorganizationDetails = _randomGenerator.NextString(2, 10),
                SchoolPartOfLaClosurePlan = true,
                SchoolLaClosurePlanDetails = _randomGenerator.NextString(2, 10),
                SchoolIsPartOfFederation = true,
                SchoolAdditionalInformationAdded = true,
                SchoolAdditionalInformation = _randomGenerator.NextString(2, 10),
                SchoolAdSchoolContributionToTrust = _randomGenerator.NextString(2, 10),
                SchoolOngoingSafeguardingInvestigations = true,
                SchoolOngoingSafeguardingDetails = _randomGenerator.NextString(2, 10),
                SchoolHasSACREException = true,
                SchoolSACREExemptionEndDate = _randomGenerator.DateTime(),
                SchoolFaithSchool = true,
                SchoolFaithSchoolDioceseName = _randomGenerator.NextString(2, 10),
                SchoolIsSupportedByFoundation = true,
                SchoolSupportedFoundationBodyName = _randomGenerator.NextString(2, 10),
                SchoolAdFeederSchools = _randomGenerator.NextString(2, 10),
                SchoolAdEqualitiesImpactAssessmentCompleted = true,
                PreviousFinancialYear = new FinancialYearServiceModel
                {
                    RevenueCarryForward = 1000,
                    RevenueIsDeficit = false,
                    RevenueStatusExplained = _randomGenerator.NextString(2, 10),
                    CapitalCarryForward = 1000,
                    CapitalIsDeficit = false,
                    CapitalStatusExplained = _randomGenerator.NextString(2, 10),
                    FYEndDate = _randomGenerator.DateTime()
                },
                CurrentFinancialYear = new FinancialYearServiceModel
                {
                    RevenueCarryForward = 1000,
                    RevenueIsDeficit = false,
                    RevenueStatusExplained = _randomGenerator.NextString(2, 10),
                    CapitalCarryForward = 1000,
                    CapitalIsDeficit = false,
                    CapitalStatusExplained = _randomGenerator.NextString(2, 10),
                    FYEndDate = _randomGenerator.DateTime()
                },
                NextFinancialYear = new FinancialYearServiceModel
                {
                    RevenueCarryForward = 1000,
                    RevenueIsDeficit = false,
                    RevenueStatusExplained = _randomGenerator.NextString(2, 10),
                    CapitalCarryForward = 1000,
                    CapitalIsDeficit = false,
                    CapitalStatusExplained = _randomGenerator.NextString(2, 10),
                    FYEndDate = _randomGenerator.DateTime()
                },

                SchoolFinancialInvestigationsExplain = _randomGenerator.NextString(2, 10),
                SchoolFinancialInvestigationsTrustAware =true,
                ProjectedPupilNumbersYear1 = 1,
                ProjectedPupilNumbersYear2 = 1,
                ProjectedPupilNumbersYear3 = 1,
                SchoolCapacityAssumptions = _randomGenerator.NextString(2, 10),
                SchoolCapacityPublishedAdmissionsNumber = 100,
                SchoolBuildLandOwnerExplained = _randomGenerator.NextString(2, 10),
                SchoolBuildLandSharedFacilities = true,
                SchoolBuildLandSharedFacilitiesExplained = _randomGenerator.NextString(2, 10),
                SchoolBuildLandWorksPlanned = true,
                SchoolBuildLandWorksPlannedExplained = _randomGenerator.NextString(2, 10),
                SchoolBuildLandWorksPlannedCompletionDate = _randomGenerator.DateTime(),
                SchoolBuildLandGrants = true,
                SchoolBuildLandGrantsExplained = _randomGenerator.NextString(2, 10),
                SchoolBuildLandPriorityBuildingProgramme = true,
                SchoolBuildLandFutureProgramme = true,
                SchoolBuildLandPFIScheme = true,
                SchoolBuildLandPFISchemeType = _randomGenerator.NextString(2, 10),
                SchoolHasConsultedStakeholders = true,
                SchoolPlanToConsultStakeholders = _randomGenerator.NextString(2, 10),
                SchoolSupportGrantFundsPaidTo = _randomGenerator.NextString(2, 10),
                SchoolLoans = new List<A2BSchoolLoanServiceModel>() { loan },
                SchoolLeases = new List<A2BSchoolLeaseServiceModel>() { lease },
                DynamicsApplicationId = _randomGenerator.Guid(),
                DynamicsApplyingSchoolId = _randomGenerator.Guid(),
                Urn = _randomGenerator.Int(),
                LocalAuthorityName = _randomGenerator.NextString(2, 10)
            };

            var application = new A2BApplicationCreateRequest
            {                
                ApplicationId = "10001",
                Name = _randomGenerator.NextString(2, 10),
                TrustName = _randomGenerator.NextString(2, 10),
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
                ApplicationType = "JoinMat",
                KeyPersons = new List<A2BApplicationKeyPersonsServiceModel> {keyPerson},
                ApplyingSchools = new List<A2BApplicationApplyingSchoolServiceModel> {applyingSchool},
                DynamicsApplicationId = _randomGenerator.Guid()
            };
            
            var response = await _client.PostAsJsonAsync("/v2/apply-to-become/application/", application);
            var result = await response.Content.ReadFromJsonAsync<ApiSingleResponseV2<A2BApplicationResponse>>();
            response.StatusCode.Should().Be(HttpStatusCode.Created);
            result.Should().NotBeNull();
        
            var createdApplication =
                _dbContext.A2BApplications
                    .Include(a => a.KeyPersons)
                    .Include(a => a.ApplyingSchools)
                    .ThenInclude(b => b.SchoolLoans)
                    .Include(a => a.ApplyingSchools)
                    .ThenInclude(b => b.SchoolLeases)
                    .FirstOrDefault(a => a.ApplicationId == result.Data.ApplicationId);

            createdApplication.Should().NotBeNull();

            var expectedResponse = A2BApplicationFactory.Create(createdApplication);
            
            result.Data.Should().BeEquivalentTo(expectedResponse);
        }

        public void Dispose()
        {
            _dbContext.A2BApplicationKeyPersons.RemoveRange(_dbContext.A2BApplicationKeyPersons);
            _dbContext.A2BApplicationApplyingSchools.RemoveRange(_dbContext.A2BApplicationApplyingSchools);
            _dbContext.A2BApplications.RemoveRange(_dbContext.A2BApplications);
            _dbContext.A2BSchoolLoans.RemoveRange(_dbContext.A2BSchoolLoans);
            _dbContext.A2BSchoolLeases.RemoveRange(_dbContext.A2BSchoolLeases);
            _dbContext.SaveChanges();
        }
    }
}