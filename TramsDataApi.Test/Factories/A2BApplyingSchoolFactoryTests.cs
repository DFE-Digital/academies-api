using FluentAssertions;
using FizzWare.NBuilder;
using TramsDataApi.DatabaseModels;
using TramsDataApi.Factories;
using TramsDataApi.Factories.A2BApplicationFactories;
using TramsDataApi.RequestModels.ApplyToBecome;
using Xunit;
using TramsDataApi.ServiceModels.ApplyToBecome;

namespace TramsDataApi.Test.Factories
{
    public class A2BApplyingSchoolFactoryTests
    {
        [Fact]
        public void Create_ReturnsExpectedA2BApplicationApplyingSchool_WhenA2BApplicationApplyingSchoolModelIsProvided()
        {
            var request = Builder<A2BApplyingSchoolServiceModel>
                .CreateNew()
                .Build();

            var expectedStatus = new A2BApplicationApplyingSchool
            {
                Name = request.SchoolName,
                //UpdatedTrustFields = request.UpdatedTrustFields,
                //SchoolDeclarationSignedById = request.SchoolDeclarationSignedById,
                SchoolDeclarationBodyAgree = request.SchoolApplicantDeclarationIsApplicationCorrect,
                //SchoolDeclarationTeacherChair = request.SchoolDeclarationTeacherChair,
                //SchoolDeclarationSignedByEmail = request.SchoolDeclarationSignedByEmail,
                //UpdatedSchoolFields = request.UpdatedSchoolFields,
                SchoolConversionReasonsForJoining = request.SchoolConversionReasonsForJoining,
                SchoolConversionTargetDateDifferent = request.SchoolConversionTargetDateSpecified,
                SchoolConversionTargetDateDate = request.SchoolConversionTargetDate,
                SchoolConversionTargetDateExplained = request.SchoolConversionTargetDateExplained,
                SchoolConversionChangeName = request.SchoolConversionChangeNamePlanned,
                SchoolConversionChangeNameValue = request.SchoolConversionProposedNewSchoolName,
                SchoolConversionContactHeadName = request.SchoolConversionContactHeadName,
                SchoolConversionContactHeadEmail = request.SchoolConversionContactHeadEmail,
                SchoolConversionContactHeadTel = request.SchoolConversionContactHeadTel,
                SchoolConversionContactChairName = request.SchoolConversionContactChairName,
                SchoolConversionContactChairEmail = request.SchoolConversionContactChairEmail,
                SchoolConversionContactChairTel = request.SchoolConversionContactChairTel,
                SchoolConversionContactRole = request.SchoolConversionContactRole,
                SchoolConversionMainContactOtherName = request.SchoolConversionMainContactOtherName,
                SchoolConversionMainContactOtherEmail = request.SchoolConversionMainContactOtherEmail,
                SchoolConversionMainContactOtherTelephone = request.SchoolConversionMainContactOtherTelephone,
                SchoolConversionMainContactOtherRole = request.SchoolConversionMainContactOtherRole,
                SchoolConversionApproverContactName = request.SchoolConversionApproverContactName,
                SchoolConversionApproverContactEmail = request.SchoolConversionApproverContactEmail,
                SchoolAdInspectedButReportNotPublished = request.SchoolAdInspectedButReportNotPublished,
                SchoolAdInspectedReportNotPublishedExplain = request.SchoolAdInspectedButReportNotPublishedExplain,
                SchoolLaReorganization = request.SchoolPartOfLaReorganizationPlan,
                SchoolLaReorganizationExplain = request.SchoolLaReorganizationDetails,
                SchoolLaClosurePlans = request.SchoolPartOfLaClosurePlan,
                SchoolLaClosurePlansExplain = request.SchoolLaClosurePlanDetails,
                SchoolPartOfFederation = request.SchoolIsPartOfFederation,
                SchoolAddFurtherInformation = request.SchoolAdditionalInformationAdded,
                SchoolFurtherInformation = request.SchoolAdditionalInformation,
                SchoolAdSchoolContributionToTrust = request.SchoolAdSchoolContributionToTrust,
                SchoolAdSafeguarding = request.SchoolOngoingSafeguardingInvestigations,
                SchoolAdSafeguardingExplained = request.SchoolOngoingSafeguardingDetails,
                SchoolSACREExemption = request.SchoolHasSACREException,
                SchoolSACREExemptionEndDate = request.SchoolSACREExemptionEndDate,
                SchoolFaithSchool = request.SchoolFaithSchool,
                SchoolFaithSchoolDioceseName = request.SchoolFaithSchoolDioceseName,
                SchoolSupportedFoundation = request.SchoolIsSupportedByFoundation,
                SchoolSupportedFoundationBodyName = request.SchoolSupportedFoundationBodyName,
                SchoolAdFeederSchools = request.SchoolAdFeederSchools,
                SchoolAdEqualitiesImpactAssessment = request.SchoolAdEqualitiesImpactAssessmentCompleted,
                SchoolPFYRevenue = request.PreviousFinancialYear.ActualRevenueCarryForward,
                SchoolPFYCapitalForward = request.PreviousFinancialYear.ActualCapitalCarryForward,
                SchoolPFYEndDate = request.PreviousFinancialYear.FYEndDate,
                SchoolPFYCapitalForwardStatusExplained = request.PreviousFinancialYear.CapitalStatusExplained,
                SchoolPFYRevenueStatusExplained = request.PreviousFinancialYear.RevenueStatusExplained,
                SchoolCFYRevenue = request.CurrentFinancialYear.ActualRevenueCarryForward,
                SchoolCFYCapitalForward = request.CurrentFinancialYear.ActualCapitalCarryForward,
                SchoolCFYCapitalForwardStatusExplained = request.CurrentFinancialYear.CapitalStatusExplained,
                SchoolCFYRevenueStatusExplained = request.CurrentFinancialYear.RevenueStatusExplained,
                SchoolCFYEndDate = request.CurrentFinancialYear.FYEndDate,
                SchoolNFYRevenue = request.NextFinancialYear.ActualRevenueCarryForward,
                SchoolNFYCapitalForward = request.NextFinancialYear.ActualRevenueCarryForward,
                SchoolNFYEndDate = request.NextFinancialYear.FYEndDate,
                SchoolNFYCapitalForwardStatusExplained = request.NextFinancialYear.CapitalStatusExplained,
                SchoolNFYRevenueStatusExplained = request.NextFinancialYear.RevenueStatusExplained,
                SchoolFinancialInvestigations = request.FinanceOngoingInvestigations,
                SchoolFinancialInvestigationsExplain = request.SchoolFinancialInvestigationsExplain,
                SchoolFinancialInvestigationsTrustAware = request.SchoolFinancialInvestigationsTrustAware,
                //SchoolLoanExists = request.SchoolLoanExists,
                //SchoolLeaseExists = request.SchoolLeaseExists,
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
                SchoolBuildLandWorksPlannedDate = request.SchoolBuildLandWorksPlannedCompletionDate,
                SchoolBuildLandGrants = request.SchoolBuildLandGrants,
                SchoolBuildLandGrantsBody = request.SchoolBuildLandGrantsExplained,
                SchoolBuildLandPriorityBuildingProgramme = request.SchoolBuildLandPriorityBuildingProgramme,
                SchoolBuildLandFutureProgramme = request.SchoolBuildLandFutureProgramme,
                SchoolBuildLandPFIScheme = request.SchoolBuildLandPFIScheme,
                SchoolBuildLandPFISchemeType = request.SchoolBuildLandPFISchemeType,
                SchoolConsultationStakeholders = request.SchoolHasConsultedStakeholders,
                SchoolConsultationStakeholdersConsult = request.SchoolPlanToConsultStakeholders,
                SchoolSupportGrantFundsPaidTo = request.SchoolSupportGrantFundsPaidTo,
                SchoolDeclarationSignedByName = request.SchoolDeclarationSignedByName
            };
                
            var response = A2BApplicationApplyingSchoolFactory.Create(request);

            response.Should().BeEquivalentTo(expectedStatus);
        }

        [Fact]
        public void Create_ReturnsExpectedA2BApplyingSchoolServiceModel_WhenA2BApplicationApplyingSchoolIsProvided()
        {
             var request = Builder<A2BApplicationApplyingSchool>
                .CreateNew()
                .Build();

            var expectedResponse = new A2BApplyingSchoolServiceModel
            {
                SchoolName = request.Name,
                //UpdatedTrustFields = request.UpdatedTrustFields,
                //SchoolDeclarationSignedById = request.SchoolDeclarationSignedById,
                SchoolApplicantDeclarationIsApplicationCorrect = request.SchoolDeclarationBodyAgree,
                //SchoolDeclarationTeacherChair = request.SchoolDeclarationTeacherChair,
                //SchoolDeclarationSignedByEmail = request.SchoolDeclarationSignedByEmail,
                //UpdatedSchoolFields = request.UpdatedSchoolFields,
                //SchoolConversionReasonsForJoining = request.SchoolConversionReasonsForJoining,
                SchoolConversionTargetDateSpecified = request.SchoolConversionTargetDateDifferent,
                SchoolConversionTargetDate = request.SchoolConversionTargetDateDate,
                SchoolConversionTargetDateExplained = request.SchoolConversionTargetDateExplained,
                SchoolConversionChangeNamePlanned = request.SchoolConversionChangeName,
                SchoolConversionProposedNewSchoolName = request.SchoolConversionChangeNameValue,
                SchoolConversionContactHeadName = request.SchoolConversionContactHeadName,
                SchoolConversionContactHeadEmail = request.SchoolConversionContactHeadEmail,
                SchoolConversionContactHeadTel = request.SchoolConversionContactHeadTel,
                SchoolConversionContactChairName = request.SchoolConversionContactChairName,
                SchoolConversionContactChairEmail = request.SchoolConversionContactChairEmail,
                SchoolConversionContactChairTel = request.SchoolConversionContactChairTel,
                SchoolConversionContactRole = request.SchoolConversionContactRole, // "headteacher", "chair of governing body", "someone else"
                SchoolConversionMainContactOtherName = request.SchoolConversionMainContactOtherName,
                SchoolConversionMainContactOtherEmail = request.SchoolConversionMainContactOtherEmail,
                SchoolConversionMainContactOtherTelephone = request.SchoolConversionMainContactOtherTelephone,
                SchoolConversionMainContactOtherRole = request.SchoolConversionMainContactOtherRole,
                SchoolConversionApproverContactName = request.SchoolConversionApproverContactName,
                SchoolConversionApproverContactEmail = request.SchoolConversionApproverContactEmail,
                SchoolAdInspectedButReportNotPublished = request.SchoolAdInspectedButReportNotPublished,
                SchoolAdInspectedReportNotPublishedExplain = request.SchoolAdInspectedReportNotPublishedExplain,
                SchoolPartOfLaReorganizationPlan = request.SchoolLaReorganization,
                SchoolLaReorganizationDetails = request.SchoolLaReorganizationExplain,
                SchoolPartOfLaClosurePlan = request.SchoolLaClosurePlans,
                SchoolLaClosurePlanDetails = request.SchoolLaClosurePlansExplain,
                SchoolIsPartOfFederation = request.SchoolPartOfFederation,
                SchoolAdditionalInformationAdded = request.SchoolAddFurtherInformation,
                SchoolAdditionalInformation = request.SchoolFurtherInformation,
                SchoolAdSchoolContributionToTrust = request.SchoolAdSchoolContributionToTrust,
                SchoolOngoingSafeguardingInvestigations = request.SchoolAdSafeguarding,
                SchoolOngoingSafeguardingDetails = request.SchoolAdSafeguardingExplained,
                SchoolHasSACREException = request.SchoolSACREExemption,
                SchoolSACREExemptionEndDate = request.SchoolSACREExemptionEndDate,
                SchoolFaithSchool = request.SchoolFaithSchool,
                SchoolFaithSchoolDioceseName = request.SchoolFaithSchoolDioceseName,
                SchoolIsSupportedByFoundation = request.SchoolSupportedFoundation,
                SchoolSupportedFoundationBodyName = request.SchoolSupportedFoundationBodyName,
                SchoolAdFeederSchools = request.SchoolAdFeederSchools,
                SchoolAdEqualitiesImpactAssessmentCompleted = request.SchoolAdEqualitiesImpactAssessment,
                PreviousFinancialYear = new FinancialYearServiceModel
                {
                    ActualRevenueCarryForward = request.SchoolPFYRevenue.Value,
                    RevenueStatusExplained = request.SchoolPFYRevenueStatusExplained,
                    ActualCapitalCarryForward = request.SchoolPFYCapitalForward.Value,
                    CapitalStatusExplained = request.SchoolPFYCapitalForwardStatusExplained,
                    FYEndDate = request.SchoolPFYEndDate
                },
                CurrentFinancialYear = new FinancialYearServiceModel
                {
                    ActualRevenueCarryForward = request.SchoolCFYRevenue.Value,
                    RevenueStatusExplained = request.SchoolCFYRevenueStatusExplained,
                    ActualCapitalCarryForward = request.SchoolCFYCapitalForward.Value,
                    CapitalStatusExplained = request.SchoolCFYCapitalForwardStatusExplained,
                    FYEndDate = request.SchoolCFYEndDate
                },
                NextFinancialYear = new FinancialYearServiceModel
                {
                    ActualRevenueCarryForward = request.SchoolNFYRevenue.Value,
                    RevenueStatusExplained = request.SchoolNFYRevenueStatusExplained,
                    ActualCapitalCarryForward = request.SchoolNFYCapitalForward.Value,
                    CapitalStatusExplained = request.SchoolNFYCapitalForwardStatusExplained,
                    FYEndDate = request.SchoolNFYEndDate
                },
                FinanceOngoingInvestigations = request.SchoolFinancialInvestigations,
                SchoolFinancialInvestigationsExplain = request.SchoolFinancialInvestigationsExplain,
                SchoolFinancialInvestigationsTrustAware = request.SchoolFinancialInvestigationsTrustAware,
                //SchoolLoanExists = request.SchoolLoanExists, // remove? just use whether it's an empty list?
                //SchoolLeaseExists = request.SchoolLeaseExists, // remove? just use whether it's an empty list?
                SchoolCapacityYear1 = (int)request.SchoolCapacityYear1,
                SchoolCapacityYear2 = (int)request.SchoolCapacityYear2,
                SchoolCapacityYear3 = (int)request.SchoolCapacityYear3,
                SchoolCapacityAssumptions = request.SchoolCapacityAssumptions,
                SchoolCapacityPublishedAdmissionsNumber = (int)request.SchoolCapacityPublishedAdmissionsNumber,
                SchoolBuildLandOwnerExplained = request.SchoolBuildLandOwnerExplained,
                SchoolBuildLandSharedFacilities = request.SchoolBuildLandSharedFacilities,
                SchoolBuildLandSharedFacilitiesExplained = request.SchoolBuildLandSharedFacilitiesExplained,
                SchoolBuildLandWorksPlanned = request.SchoolBuildLandWorksPlanned,
                SchoolBuildLandWorksPlannedExplained = request.SchoolBuildLandWorksPlannedExplained,
                SchoolBuildLandWorksPlannedCompletionDate = request.SchoolBuildLandWorksPlannedDate,
                SchoolBuildLandGrants = request.SchoolBuildLandGrants,
                SchoolBuildLandGrantsExplained = request.SchoolBuildLandGrantsBody,
                SchoolBuildLandPriorityBuildingProgramme = request.SchoolBuildLandPriorityBuildingProgramme,
                SchoolBuildLandFutureProgramme = request.SchoolBuildLandFutureProgramme,
                SchoolBuildLandPFIScheme = request.SchoolBuildLandPFIScheme,
                SchoolBuildLandPFISchemeType = request.SchoolBuildLandPFISchemeType,
                SchoolHasConsultedStakeholders = request.SchoolConsultationStakeholders,
                SchoolPlanToConsultStakeholders = request.SchoolConsultationStakeholdersConsult,
                SchoolSupportGrantFundsPaidTo = request.SchoolSupportGrantFundsPaidTo,
                SchoolDeclarationSignedByName = request.SchoolDeclarationSignedByName
            };
                
            var response = A2BApplicationApplyingSchoolFactory.Create(request);

            response.Should().BeEquivalentTo(expectedResponse);
        }
    }
}
