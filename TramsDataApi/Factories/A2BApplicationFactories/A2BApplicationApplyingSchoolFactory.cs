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
                    SchoolConversionMainContactRole = request.SchoolConversionMainContactRole,
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
                    SchoolPFYRevenueStatusExplained = request.SchoolPFYRevenueStatusExplained,
                    SchoolPFYCapitalForward = request.SchoolPFYCapitalForward,
                    SchoolPFYCapitalForwardStatusExplained = request.SchoolPFYCapitalForwardStatusExplained,
                    SchoolCFYRevenue = request.SchoolCFYRevenue,
                    SchoolCFYRevenueStatusExplained = request.SchoolCFYRevenueStatusExplained,
                    SchoolCFYCapitalForward = request.SchoolCFYCapitalForward,
                     SchoolCFYCapitalForwardStatusExplained = request.SchoolCFYCapitalForwardStatusExplained,
                    SchoolNFYRevenue = request.SchoolNFYRevenue,
                    SchoolNFYRevenueStatusExplained = request.SchoolNFYRevenueStatusExplained,
                    SchoolNFYCapitalForward = request.SchoolNFYCapitalForward,
                    SchoolNFYCapitalForwardStatusExplained = request.SchoolNFYCapitalForwardStatusExplained,
                    SchoolFinancialInvestigations = request.SchoolFinancialInvestigations,
                    SchoolFinancialInvestigationsExplain = request.SchoolFinancialInvestigationsExplain,
                    SchoolFinancialInvestigationsTrustAware = request.SchoolFinancialInvestigationsTrustAware,
                    SchoolNFYEndDate = request.SchoolNFYEndDate,
                    SchoolPFYEndDate = request.SchoolPFYEndDate,
                    SchoolCFYEndDate = request.SchoolCFYEndDate,
                    SchoolLoanExists = request.SchoolLoanExists,
                    SchoolLeaseExists = request.SchoolLeaseExists,
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
        }

        // CML - casting nullables into non-nullables in the code below for now
        // will throw InvalidOperationException if value is null
        public static A2BApplyingSchoolServiceModel Create(A2BApplicationApplyingSchool request)
	    { 
		    return request is null ? null : new A2BApplyingSchoolServiceModel
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
                    MainContactForApplicationRole = request.SchoolConversionMainContactRole, // "headteacher", "chair of governing body", "someone else"
                    SchoolConversionMainContactOtherName = request.SchoolConversionMainContactOtherName,
                    SchoolConversionMainContactOtherEmail = request.SchoolConversionMainContactOtherEmail,
                    SchoolConversionMainContactOtherTelephone = request.SchoolConversionMainContactOtherTelephone,
                    SchoolConversionMainContactOtherRole = request.SchoolConversionMainContactOtherRole,
                    SchoolConversionApproverContactName = request.SchoolConversionApproverContactName,
                    SchoolConversionApproverContactEmail = request.SchoolConversionApproverContactEmail,
                    SchoolAdInspectedButReportNotPublished = request.SchoolAdInspectedButReportNotPublished,
                //                    SchoolAdInspectedReportNotPublishedExplain = request.SchoolAdInspectedReportNotPublishedExplain,
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
                        ActualRevenueCarryForward = (decimal)request.SchoolPFYRevenue,
                         RevenueStatusExplained = request.SchoolPFYRevenueStatusExplained,
                        ActualCapitalCarryForward = (decimal)request.SchoolPFYCapitalForward,
                        CapitalStatusExplained = request.SchoolPFYCapitalForwardStatusExplained,
                        FYEndDate = request.SchoolPFYEndDate
                    },
                    CurrentFinancialYear = new FinancialYearServiceModel
                    {
                        ActualRevenueCarryForward = (decimal)request.SchoolCFYRevenue,
                         RevenueStatusExplained = request.SchoolCFYRevenueStatusExplained,
                        ActualCapitalCarryForward = (decimal)request.SchoolCFYCapitalForward,
                        CapitalStatusExplained = request.SchoolCFYCapitalForwardStatusExplained,
                        FYEndDate = request.SchoolCFYEndDate
                    },
                NextFinancialYear = new FinancialYearServiceModel
                {
                    ActualRevenueCarryForward = (decimal)request.SchoolNFYRevenue,
                    RevenueStatusExplained = request.SchoolNFYRevenueStatusExplained,
                    ActualCapitalCarryForward = (decimal)request.SchoolNFYCapitalForward,
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
//                    SchoolBuildLandGrantsBody = request.SchoolBuildLandGrantsBody,
                    SchoolBuildLandPriorityBuildingProgramme = request.SchoolBuildLandPriorityBuildingProgramme,
                    SchoolBuildLandFutureProgramme = request.SchoolBuildLandFutureProgramme,
                    SchoolBuildLandPFIScheme = request.SchoolBuildLandPFIScheme,
                    SchoolBuildLandPFISchemeType = request.SchoolBuildLandPFISchemeType,
                SchoolHasConsultedStakeholders = request.SchoolConsultationStakeholders,
                SchoolPlanToConsultStakeholders = request.SchoolConsultationStakeholdersConsult,
                    SchoolSupportGrantFundsPaidTo = request.SchoolSupportGrantFundsPaidTo,
                    SchoolDeclarationSignedByName = request.SchoolDeclarationSignedByName
		    };
	    }
    }
}