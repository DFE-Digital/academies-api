using FizzWare.NBuilder;
using FluentAssertions;
using TramsDataApi.DatabaseModels;
using TramsDataApi.Factories;
using TramsDataApi.ResponseModels.ApplyToBecome;
using Xunit;

namespace TramsDataApi.Test.Factories
{
    public class A2BApplyingSchoolResponseFactoryTests
    {
        [Fact]
        public void Create_ReturnsNull_WhenA2BApplyingSchoolIsNull()
        {
            var response = A2BApplyingSchoolResponseFactory.Create(null);

            response.Should().BeNull();
        }

        [Fact]
        public void Create_ReturnsExpectedA2BApplyingSchoolResponse_WhenA2BApplyingSchoolIsProvided()
        {
            var request = Builder<A2BApplyingSchool>
                .CreateNew()
                .With(r => r.SchoolDeclarationBodyAgreeOption = new A2BSelectOption { Id = 907660000, Name = "Yes"})
                .With(r => r.SchoolDeclarationTeacherChairOption = new A2BSelectOption { Id = 907660000, Name = "Yes"})
                .With(r => r.SchoolLoanExistsOption = new A2BSelectOption { Id = 907660000, Name = "Yes"})
                .With(r => r.SchoolLeaseExistsOption = new A2BSelectOption { Id = 907660000, Name = "Yes"})
                .Build();

            var expectedResponse = new A2BApplyingSchoolResponse
            {
                ApplyingSchoolId = request.ApplyingSchoolId,
                Name = request.Name,
                UpdatedTrustFields = request.UpdatedTrustFields,
                SchoolDeclarationSignedById = request.SchoolDeclarationSignedById,
                SchoolDeclarationBodyAgree = request.SchoolDeclarationBodyAgreeOption,
                SchoolDeclarationTeacherChair = request.SchoolDeclarationTeacherChairOption,
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
                SchoolLoanExists = request.SchoolLoanExistsOption,
                SchoolLeaseExists = request.SchoolLeaseExistsOption,
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
                
            var response = A2BApplyingSchoolResponseFactory.Create(request);

            response.Should().BeEquivalentTo(expectedResponse);
        }
    }
}