using TramsDataApi.DatabaseModels;
using TramsDataApi.Enums;
using TramsDataApi.Extensions;
using TramsDataApi.RequestModels.ApplyToBecome;
using TramsDataApi.ResponseModels.ApplyToBecome;
using TramsDataApi.ServiceModels.ApplyToBecome;

namespace TramsDataApi.Factories.A2BApplicationFactories
{
    public static class A2BApplicationApplyingSchoolFactory
    {
        public static A2BApplicationApplyingSchool Create(A2BApplyingSchoolServiceModel request)
        {
            return request == null
                ? null
                : new A2BApplicationApplyingSchool
                {
	                Name = request.SchoolName,
                    //UpdatedTrustFields = request.UpdatedTrustFields,
                    //SchoolDeclarationSignedById = request.SchoolDeclarationSignedById,
                    SchoolDeclarationBodyAgree = request.DeclarationBodyAgree, // or should be 
                    SchoolDeclarationTeacherChair = request.DeclarationIAmTheChairOrHeadteacher,
                    SchoolDeclarationSignedByName = request.DeclarationSignedByName,
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
                    SchoolNFYCapitalForward = request.NextFinancialYear.RevenueCarryForward,
                    SchoolNFYCapitalIsDeficit = request.NextFinancialYear.CapitalIsDeficit,
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
                    SchoolSupportGrantFundsPaidTo = request.SchoolSupportGrantFundsPaidTo
                };
        }

        // CML - converting nullables into non-nullables in the code below for now
        // will throw InvalidOperationException if value is null
        public static A2BApplyingSchoolServiceModel Create(A2BApplicationApplyingSchool request)
	    { 
		    return request is null ? null : new A2BApplyingSchoolServiceModel
		    {	
					SchoolName = request.Name,
                //UpdatedTrustFields = request.UpdatedTrustFields,
                //UpdatedSchoolFields = request.UpdatedSchoolFields,
                DeclarationBodyAgree = request.SchoolDeclarationBodyAgree,
                DeclarationIAmTheChairOrHeadteacher = request.SchoolDeclarationTeacherChair,
                DeclarationSignedByName = request.SchoolDeclarationSignedByName,
                // DeclarationApplicationIsCorrect
                // request.SchoolDeclarationSignedById,
                // request.SchoolDeclarationSignedByEmail
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
		    };
	    }
    }
}