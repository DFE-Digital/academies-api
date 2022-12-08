using FluentAssertions;
using FizzWare.NBuilder;
using TramsDataApi.DatabaseModels;
using TramsDataApi.Factories;
using TramsDataApi.Factories.A2BApplicationFactories;
using TramsDataApi.RequestModels.ApplyToBecome;
using Xunit;
using TramsDataApi.ServiceModels.ApplyToBecome;
using System.Collections.Generic;
using System.Linq;

namespace TramsDataApi.Test.Factories
{
    public class A2BApplyingSchoolFactoryTests
    {
        [Fact]
        public void Create_ReturnsExpectedA2BApplicationApplyingSchool_WhenA2BApplicationApplyingSchoolModelIsProvided()
        {
            var financialYear = Builder<FinancialYearServiceModel>
                .CreateNew()
                .Build();
            var loans = Builder<A2BSchoolLoanServiceModel>
                .CreateNew()
                .Build();
            var leases = Builder<A2BSchoolLeaseServiceModel>
                .CreateNew()
                .Build();
            var request = Builder<A2BApplicationApplyingSchoolServiceModel>
                .CreateNew()
                .With(r => r.PreviousFinancialYear = financialYear)
                .With(r => r.CurrentFinancialYear = financialYear)
                .With(r => r.NextFinancialYear = financialYear)
                .With(r => r.SchoolLoans = new List<A2BSchoolLoanServiceModel>() { loans })
                .With(r => r.SchoolLeases = new List<A2BSchoolLeaseServiceModel>() { leases })
                .Build();

            var expectedStatus = new A2BApplicationApplyingSchool
            {
                Name = request.SchoolName,
                SchoolDeclarationBodyAgree = request.DeclarationBodyAgree,
                SchoolDeclarationTeacherChair = request.DeclarationIAmTheChairOrHeadteacher,
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
                SchoolAdEqualitiesImpactAssessmentDetails = request.SchoolAdEqualitiesImpactAssessmentDetails,
                SchoolPFYRevenue = request.PreviousFinancialYear.RevenueCarryForward,
                SchoolPFYRevenueIsDeficit = request.PreviousFinancialYear.RevenueIsDeficit,
                SchoolPFYCapitalForward = request.PreviousFinancialYear.CapitalCarryForward,
                SchoolPFYCapitalIsDeficit = request.PreviousFinancialYear.CapitalIsDeficit,
                SchoolPFYEndDate = request.PreviousFinancialYear.FYEndDate,
                SchoolPFYCapitalForwardStatusExplained = request.PreviousFinancialYear.CapitalStatusExplained,
                SchoolPFYRevenueStatusExplained = request.PreviousFinancialYear.RevenueStatusExplained,
                SchoolCFYRevenue = request.CurrentFinancialYear.RevenueCarryForward,
                SchoolCFYRevenueIsDeficit = request.CurrentFinancialYear.RevenueIsDeficit,
                SchoolCFYCapitalForward = request.CurrentFinancialYear.CapitalCarryForward,
                SchoolCFYCapitalIsDeficit = request.CurrentFinancialYear.CapitalIsDeficit,
                SchoolCFYCapitalForwardStatusExplained = request.CurrentFinancialYear.CapitalStatusExplained,
                SchoolCFYRevenueStatusExplained = request.CurrentFinancialYear.RevenueStatusExplained,
                SchoolCFYEndDate = request.CurrentFinancialYear.FYEndDate,
                SchoolNFYRevenue = request.NextFinancialYear.RevenueCarryForward,
                SchoolNFYRevenueIsDeficit = request.NextFinancialYear.RevenueIsDeficit,
                SchoolNFYCapitalForward = request.NextFinancialYear.CapitalCarryForward,
                SchoolNFYCapitalIsDeficit = request.NextFinancialYear.CapitalIsDeficit,
                SchoolNFYEndDate = request.NextFinancialYear.FYEndDate,
                SchoolNFYCapitalForwardStatusExplained = request.NextFinancialYear.CapitalStatusExplained,
                SchoolNFYRevenueStatusExplained = request.NextFinancialYear.RevenueStatusExplained,
                SchoolFinancialInvestigations = request.FinanceOngoingInvestigations,
                SchoolFinancialInvestigationsExplain = request.SchoolFinancialInvestigationsExplain,
                SchoolFinancialInvestigationsTrustAware = request.SchoolFinancialInvestigationsTrustAware,
                ProjectedPupilNumbersYear1 = request.ProjectedPupilNumbersYear1,
                ProjectedPupilNumbersYear2 = request.ProjectedPupilNumbersYear2,
                ProjectedPupilNumbersYear3 = request.ProjectedPupilNumbersYear3,
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
                SchoolDeclarationSignedByName = request.DeclarationSignedByName,
                DiocesePermissionEvidenceDocumentLink = request.DiocesePermissionEvidenceDocumentLink,
                GoverningBodyConsentEvidenceDocumentLink = request.GoverningBodyConsentEvidenceDocumentLink,
                FoundationEvidenceDocumentLink = request.FoundationEvidenceDocumentLink,
                SchoolLeases = request.SchoolLeases.Select(A2BSchoolLeaseFactory.Create).ToList(),
                SchoolLoans = request.SchoolLoans.Select(A2BSchoolLoanFactory.Create).ToList(),
                DynamicsApplicationId = request.DynamicsApplicationId,
                DynamicsApplyingSchoolId = request.DynamicsApplyingSchoolId,
                Urn = request.Urn,
                LocalAuthorityName = request.LocalAuthorityName
            };
                
            var response = A2BApplicationApplyingSchoolFactory.Create(request);

            response.Should().BeEquivalentTo(expectedStatus);
        }

        [Fact]
        public void Create_ReturnsExpectedA2BApplyingSchoolServiceModel_WhenA2BApplicationApplyingSchoolIsProvided()
        {
            var loans = Builder<A2BSchoolLoan>
                .CreateNew()
                .Build();
            var leases = Builder<A2BSchoolLease>
                .CreateNew()
                .Build();
            var request = Builder<A2BApplicationApplyingSchool>
                .CreateNew()
                .With(r => r.SchoolLoans = new List<A2BSchoolLoan>() { loans })
                .With(r => r.SchoolLeases = new List<A2BSchoolLease>() { leases })
                .Build();

            var expectedResponse = new A2BApplicationApplyingSchoolServiceModel
            {
                SchoolName = request.Name,
                DeclarationBodyAgree = request.SchoolDeclarationBodyAgree,
                DeclarationIAmTheChairOrHeadteacher = request.SchoolDeclarationTeacherChair,
                DeclarationSignedByName = request.SchoolDeclarationSignedByName,
                SchoolConversionReasonsForJoining = request.SchoolConversionReasonsForJoining,
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
                SchoolAdInspectedButReportNotPublishedExplain = request.SchoolAdInspectedReportNotPublishedExplain,
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
                SchoolAdEqualitiesImpactAssessmentDetails = request.SchoolAdEqualitiesImpactAssessmentDetails,
                PreviousFinancialYear = new FinancialYearServiceModel
                {
                    RevenueCarryForward = request.SchoolPFYRevenue.Value,
                    RevenueIsDeficit = request.SchoolPFYRevenueIsDeficit,
                    RevenueStatusExplained = request.SchoolPFYRevenueStatusExplained,
                    CapitalCarryForward = request.SchoolPFYCapitalForward.Value,
                    CapitalIsDeficit = request.SchoolPFYCapitalIsDeficit,
                    CapitalStatusExplained = request.SchoolPFYCapitalForwardStatusExplained,
                    FYEndDate = request.SchoolPFYEndDate
                },
                CurrentFinancialYear = new FinancialYearServiceModel
                {
                    RevenueCarryForward = request.SchoolCFYRevenue.Value,
                    RevenueIsDeficit = request.SchoolCFYRevenueIsDeficit,
                    RevenueStatusExplained = request.SchoolCFYRevenueStatusExplained,
                    CapitalCarryForward = request.SchoolCFYCapitalForward.Value,
                    CapitalIsDeficit = request.SchoolCFYCapitalIsDeficit,
                    CapitalStatusExplained = request.SchoolCFYCapitalForwardStatusExplained,
                    FYEndDate = request.SchoolCFYEndDate
                },
                NextFinancialYear = new FinancialYearServiceModel
                {
                    RevenueCarryForward = request.SchoolNFYRevenue.Value,
                    RevenueIsDeficit = request.SchoolNFYRevenueIsDeficit,
                    RevenueStatusExplained = request.SchoolNFYRevenueStatusExplained,
                    CapitalCarryForward = request.SchoolNFYCapitalForward.Value,
                    CapitalIsDeficit = request.SchoolNFYCapitalIsDeficit,
                    CapitalStatusExplained = request.SchoolNFYCapitalForwardStatusExplained,
                    FYEndDate = request.SchoolNFYEndDate
                },
                FinanceOngoingInvestigations = request.SchoolFinancialInvestigations,
                SchoolFinancialInvestigationsExplain = request.SchoolFinancialInvestigationsExplain,
                SchoolFinancialInvestigationsTrustAware = request.SchoolFinancialInvestigationsTrustAware,
                ProjectedPupilNumbersYear1 = (int)request.ProjectedPupilNumbersYear1,
                ProjectedPupilNumbersYear2 = (int)request.ProjectedPupilNumbersYear2,
                ProjectedPupilNumbersYear3 = (int)request.ProjectedPupilNumbersYear3,
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
                DiocesePermissionEvidenceDocumentLink = request.DiocesePermissionEvidenceDocumentLink,
                FoundationEvidenceDocumentLink = request.FoundationEvidenceDocumentLink,
                GoverningBodyConsentEvidenceDocumentLink = request.GoverningBodyConsentEvidenceDocumentLink,
                SchoolLoans = request.SchoolLoans
                    .Select(A2BSchoolLoanServiceModelFactory.Create)
                    .ToList(),
                SchoolLeases = request.SchoolLeases
                    .Select(A2BSchoolLeaseServiceModelFactory.Create)
                    .ToList(),
                DynamicsApplicationId = request.DynamicsApplicationId,
                DynamicsApplyingSchoolId = request.DynamicsApplyingSchoolId,
                Urn = request.Urn,
                LocalAuthorityName = request.LocalAuthorityName
            };
                
            var response = A2BApplicationApplyingSchoolFactory.Create(request);

            response.Should().BeEquivalentTo(expectedResponse);
        }
    }
}
