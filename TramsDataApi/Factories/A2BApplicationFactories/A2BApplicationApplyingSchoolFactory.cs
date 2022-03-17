using System.Collections.Generic;
using System.Linq;
using TramsDataApi.DatabaseModels;
using TramsDataApi.ServiceModels.ApplyToBecome;

namespace TramsDataApi.Factories.A2BApplicationFactories
{
    public static class A2BApplicationApplyingSchoolFactory
    {
        public static A2BApplicationApplyingSchool Create(A2BApplicationApplyingSchoolServiceModel request)
        {
            return request == null
                ? null
                : new A2BApplicationApplyingSchool
                {
	                Name = request.SchoolName,
                    SchoolDeclarationBodyAgree = request.DeclarationBodyAgree,
                    SchoolDeclarationTeacherChair = request.DeclarationIAmTheChairOrHeadteacher,
                    SchoolDeclarationSignedByName = request.DeclarationSignedByName,
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
                    SchoolCFYCapitalForward = request. CurrentFinancialYear.CapitalCarryForward,
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
                    SchoolCapacityYear1 = request.SchoolCapacityYear1,
                    SchoolCapacityYear2 = request.SchoolCapacityYear2,
                    SchoolCapacityYear3 = request.SchoolCapacityYear3,
                    SchoolCapacityAssumptions = request.SchoolCapacityAssumptions,
                    SchoolCapacityPublishedAdmissionsNumber =  request.SchoolCapacityPublishedAdmissionsNumber,
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
                    DiocesePermissionEvidenceDocumentLink = request.DiocesePermissionEvidenceDocumentLink,
                    GoverningBodyConsentEvidenceDocumentLink = request.GoverningBodyConsentEvidenceDocumentLink,
                    FoundationEvidenceDocumentLink = request.FoundationEvidenceDocumentLink,
                    SchoolLoans = request.SchoolLoans?
                        .Select(A2BSchoolLoanFactory.Create)
                        .ToList(),
                    SchoolLeases = request.SchoolLeases?
                        .Select(A2BSchoolLeaseFactory.Create)
                        .ToList()
                };
        }

        // converting nullables into non-nullables in the code below for now
        // will throw InvalidOperationException if value is null
        // validation to come 
        public static A2BApplicationApplyingSchoolServiceModel Create(A2BApplicationApplyingSchool request)
	    { 
		    return request is null ? null : new A2BApplicationApplyingSchoolServiceModel
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
                    RevenueCarryForward = request.SchoolPFYRevenue,
                    RevenueIsDeficit = request.SchoolPFYRevenueIsDeficit,
                    RevenueStatusExplained = request.SchoolPFYRevenueStatusExplained,
                    CapitalCarryForward = request.SchoolPFYCapitalForward,
                    CapitalIsDeficit = request.SchoolPFYCapitalIsDeficit,
                    CapitalStatusExplained = request.SchoolPFYCapitalForwardStatusExplained,
                    FYEndDate = request.SchoolPFYEndDate
                },
                CurrentFinancialYear = new FinancialYearServiceModel
                {
                    RevenueCarryForward = request.SchoolCFYRevenue,
                    RevenueIsDeficit = request.SchoolCFYRevenueIsDeficit,
                    RevenueStatusExplained = request.SchoolCFYRevenueStatusExplained,
                    CapitalCarryForward = request.SchoolCFYCapitalForward,
                    CapitalIsDeficit = request.SchoolCFYCapitalIsDeficit,
                    CapitalStatusExplained = request.SchoolCFYCapitalForwardStatusExplained,
                    FYEndDate = request.SchoolCFYEndDate
                },
                NextFinancialYear = new FinancialYearServiceModel
                {
                    RevenueCarryForward = request.SchoolNFYRevenue,
                    RevenueIsDeficit = request.SchoolNFYRevenueIsDeficit,
                    RevenueStatusExplained = request.SchoolNFYRevenueStatusExplained,
                    CapitalCarryForward = request.SchoolNFYCapitalForward,
                    CapitalIsDeficit = request.SchoolNFYCapitalIsDeficit,
                    CapitalStatusExplained = request.SchoolNFYCapitalForwardStatusExplained,
                    FYEndDate = request.SchoolNFYEndDate
                },
                FinanceOngoingInvestigations = request.SchoolFinancialInvestigations,
                SchoolFinancialInvestigationsExplain = request.SchoolFinancialInvestigationsExplain,
                SchoolFinancialInvestigationsTrustAware = request.SchoolFinancialInvestigationsTrustAware,
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
                SchoolLeases = request.SchoolLeases == null
                    ? new List<A2BSchoolLeaseServiceModel>()
                    : request.SchoolLeases.Select(A2BSchoolLeaseServiceModelFactory.Create)
                    .ToList(),
                SchoolLoans = request.SchoolLoans == null
                    ? new List<A2BSchoolLoanServiceModel>()
                    : request.SchoolLoans.Select(A2BSchoolLoanServiceModelFactory.Create)
                    .ToList()
             };
	    }
    }
}