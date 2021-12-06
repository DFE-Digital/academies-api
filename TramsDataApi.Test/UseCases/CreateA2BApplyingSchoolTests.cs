using FizzWare.NBuilder;
using FluentAssertions;
using Moq;
using TramsDataApi.DatabaseModels;
using TramsDataApi.Gateways;
using TramsDataApi.RequestModels.ApplyToBecome;
using TramsDataApi.ResponseModels.ApplyToBecome;
using TramsDataApi.UseCases;
using Xunit;

namespace TramsDataApi.Test.UseCases
{
    public class CreateA2BApplyingSchoolTests
    {
        [Fact]
        public void CreateA2BApplyingSchool_ShouldCreateAndReturnA2BApplyingSchool_WhenGivenA2BApplyingSchool()
        {
            var request = Builder<A2BApplyingSchoolCreateRequest>
                .CreateNew()
                .With(a => a.ApplyingSchoolId = "10001")
                .With(a => a.SchoolDeclarationBodyAgree = 90760000)
                .With(a => a.SchoolDeclarationTeacherChair = 90760000)
                .With(a => a.SchoolLoanExists = 90760000)
                .With(a => a.SchoolLeaseExists = 90760000)
                .Build();

            var applyingSchool = new A2BApplyingSchool
            {
                ApplyingSchoolId = request.ApplyingSchoolId,
                Name = request.Name,
                UpdatedTrustFields = request.UpdatedTrustFields,
                SchoolDeclarationSignedById = request.SchoolDeclarationSignedById,
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
                SchoolDeclarationSignedByName = request.SchoolDeclarationSignedByName,
                SchoolDeclarationBodyAgree = 90760000,
                SchoolDeclarationTeacherChair = 907660000,
                SchoolDeclarationBodyAgreeOption = new A2BSelectOption {Id = 90760000, Name = "Yes"},
                SchoolDeclarationTeacherChairOption = new A2BSelectOption {Id = 90760000, Name = "Yes"},
                SchoolLoanExistsOption = new A2BSelectOption {Id = 90760000, Name = "Yes"},
                SchoolLeaseExistsOption = new A2BSelectOption {Id = 90760000, Name = "Yes"}
            };

            var expected = new A2BApplyingSchoolResponse
            {
                ApplyingSchoolId = request.ApplyingSchoolId,
                Name = request.Name,
                UpdatedTrustFields = request.UpdatedTrustFields,
                SchoolDeclarationSignedById = request.SchoolDeclarationSignedById,
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
                SchoolDeclarationSignedByName = request.SchoolDeclarationSignedByName,
                SchoolDeclarationBodyAgree = new A2BSelectOption {Id = 90760000, Name = "Yes"},
                SchoolDeclarationTeacherChair = new A2BSelectOption {Id = 90760000, Name = "Yes"},
                SchoolLoanExists = new A2BSelectOption {Id = 90760000, Name = "Yes"},
                SchoolLeaseExists = new A2BSelectOption {Id = 90760000, Name = "Yes"}
            };

            var mockGateway = new Mock<IA2BApplyingSchoolGateway>();

            mockGateway.Setup(g => g.CreateA2BApplyingSchool(It.IsAny<A2BApplyingSchool>()))
                .Returns(applyingSchool);

            var useCase = new CreateA2BApplyingSchool(mockGateway.Object);

            var result = useCase.Execute(request);

            result.Should().NotBeNull();
            result.Should().BeEquivalentTo(expected);
        }
    }
}