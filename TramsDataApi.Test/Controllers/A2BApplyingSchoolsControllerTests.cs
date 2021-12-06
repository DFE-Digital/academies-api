using System;
using FizzWare.NBuilder;
using Microsoft.Extensions.Logging;
using Moq;
using FluentAssertions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TramsDataApi.Controllers.V2;
using TramsDataApi.DatabaseModels;
using TramsDataApi.RequestModels.ApplyToBecome;
using TramsDataApi.ResponseModels;
using TramsDataApi.ResponseModels.ApplyToBecome;
using TramsDataApi.UseCases;
using Xunit;

namespace TramsDataApi.Test.Controllers
{
    public class A2BApplyingSchoolControllerTests
    {
        private readonly Mock<ILogger<A2BApplyingSchoolController>> _mockLogger;

        public A2BApplyingSchoolControllerTests()
        {
            _mockLogger = new Mock<ILogger<A2BApplyingSchoolController>>();
        }

        [Fact]
        public void GetApplyingSchoolByApplyingSchoolId_ReturnsApiSingleResponseWithA2BApplyingSchoolWhenApplyingSchoolExists()
        {
            const string applyingSchoolId = "10001";
            var mockUseCase = new Mock<IGetA2BApplyingSchool>();
            var response = new A2BApplyingSchoolResponse
            {
                ApplyingSchoolId = applyingSchoolId,
                Name = "test",
                UpdatedTrustFields = "test",
                SchoolDeclarationSignedById = "test",
                SchoolDeclarationBodyAgree = new A2BSelectOption { Id = 90760001, Name = "No"},
                SchoolDeclarationTeacherChair = new A2BSelectOption { Id = 90760001, Name = "No"},
                SchoolDeclarationSignedByEmail = "test",
                UpdatedSchoolFields = "test",
                SchoolConversionReasonsForJoining = "test",
                SchoolConversionTargetDateDifferent = 1000,
                SchoolConversionTargetDateDate = DateTime.Now,
                SchoolConversionTargetDateExplained = "test",
                SchoolConversionChangeName = 1000,
                SchoolConversionChangeNameValue = "test",
                SchoolConversionContactHeadName = "test",
                SchoolConversionContactHeadEmail = "test",
                SchoolConversionContactHeadTel = "test",
                SchoolConversionContactChairName = "test",
                SchoolConversionContactChairEmail = "test",
                SchoolConversionContactChairTel = "test",
                SchoolConversionMainContact = 1000,
                SchoolConversionMainContactOtherName = "test",
                SchoolConversionMainContactOtherEmail = "test",
                SchoolConversionMainContactOtherTelephone = "test",
                SchoolConversionMainContactOtherRole = "test",
                SchoolConversionApproverContactName = "test",
                SchoolConversionApproverContactEmail = "test",
                SchoolAdInspectedButReportNotPublished = 1000,
                SchoolAdInspectedReportNotPublishedExplain = "test",
                SchoolLaReorganization = 1000,
                SchoolLaReorganizationExplain = "test",
                SchoolLaClosurePlans = 1000,
                SchoolLaClosurePlansExplain = "test",
                SchoolPartOfFederation = 1000,
                SchoolAddFurtherInformation = 1000,
                SchoolFurtherInformation = "test",
                SchoolAdSchoolContributionToTrust = "test",
                SchoolAdSafeguarding = 1000,
                SchoolAdSafeguardingExplained = "test",
                SchoolSACREExemption = 1000,
                SchoolSACREExemptionEndDate = DateTime.Now,
                SchoolFaithSchool = 1000,
                SchoolFaithSchoolDioceseName = "test",
                SchoolSupportedFoundation = 1000,
                SchoolSupportedFoundationBodyName = "test",
                SchoolAdFeederSchools = "test",
                SchoolAdEqualitiesImpactAssessment = 1000,
                SchoolPFYRevenue = 1000,
                SchoolPFYRevenueStatus = 1000,
                SchoolPFYRevenueStatusExplained = "test",
                SchoolPFYCapitalForward = 1000,
                SchoolPFYCapitalForwardStatus = 1000,
                SchoolPFYCapitalForwardStatusExplained = "test",
                SchoolCFYRevenue = 1000,
                SchoolCFYRevenueStatus = 1000,
                SchoolCFYRevenueStatusExplained = "test",
                SchoolCFYCapitalForward = 1000,
                SchoolCFYCapitalForwardStatus = 1000,
                SchoolCFYCapitalForwardStatusExplained = "test",
                SchoolNFYRevenue = 1000,
                SchoolNFYRevenueStatus = 1000,
                SchoolNFYRevenueStatusExplained = "test",
                SchoolNFYCapitalForward = 1000,
                SchoolNFYCapitalForwardStatus = 1000,
                SchoolNFYCapitalForwardStatusExplained = "test",
                SchoolFinancialInvestigations = 1000,
                SchoolFinancialInvestigationsExplain = "test",
                SchoolFinancialInvestigationsTrustAware = 1000,
                SchoolNFYEndDate = DateTime.Now,
                SchoolPFYEndDate = DateTime.Now,
                SchoolCFYEndDate = DateTime.Now,
                SchoolLoanExists = new A2BSelectOption { Id = 90760001, Name = "No"},
                SchoolLeaseExists = new A2BSelectOption { Id = 90760001, Name = "No"},
                SchoolCapacityYear1 = 1000,
                SchoolCapacityYear2 = 1000,
                SchoolCapacityYear3 = 1000,
                SchoolCapacityAssumptions = "test",
                SchoolCapacityPublishedAdmissionsNumber = "test",
                SchoolBuildLandOwnerExplained = "test",
                SchoolBuildLandSharedFacilities = 1000,
                SchoolBuildLandSharedFacilitiesExplained = "test",
                SchoolBuildLandWorksPlanned = 1000,
                SchoolBuildLandWorksPlannedExplained = "test",
                SchoolBuildLandWorksPlannedDate = DateTime.Now,
                SchoolBuildLandGrants = 1000,
                SchoolBuildLandGrantsBody = "test",
                SchoolBuildLandPriorityBuildingProgramme = 1000,
                SchoolBuildLandFutureProgramme = 1000,
                SchoolBuildLandPFIScheme = 1000,
                SchoolBuildLandPFISchemeType = "test",
                SchoolConsultationStakeholders = 1000,
                SchoolConsultationStakeholdersConsult = "test",
                SchoolSupportGrantFundsPaidTo = 1000,
                SchoolDeclarationSignedByName = "test"
            };
            
            var expectedResponse = new ApiSingleResponseV2<A2BApplyingSchoolResponse>(response);

            mockUseCase
                .Setup(x => x.Execute(It.IsAny<string>()))
                .Returns(response);

            var controller = new A2BApplyingSchoolController(_mockLogger.Object, mockUseCase.Object,new Mock<ICreateA2BApplyingSchool>().Object);
            var result = controller.GetApplyingSchoolByApplyingSchoolId(applyingSchoolId);

            result.Result.Should().BeEquivalentTo(new OkObjectResult(expectedResponse));
        }

        [Fact]
        public void GetApplyingSchoolByApplyingSchoolId_ReturnsNotFound_WhenApplyingSchoolNotFound()
        {
            var applyingSchoolId = "10001";
            var expectedResponse = new NotFoundResult();
            var mockUseCase = new Mock<IGetA2BApplyingSchool>();

            var controller = new A2BApplyingSchoolController(_mockLogger.Object, mockUseCase.Object, new Mock<ICreateA2BApplyingSchool>().Object);

            var result = controller.GetApplyingSchoolByApplyingSchoolId(applyingSchoolId);

            result.Result.Should().BeEquivalentTo(expectedResponse);
        }

        [Fact]
        public void Create_Returns201_WithCreatedObject_WhenApplyingSchoolCreated()
        {
            var request = Builder<A2BApplyingSchoolCreateRequest>.CreateNew().Build();
            var expectedStatusResponse =  new A2BApplyingSchoolResponse
            {
                Name = request.Name
            };

            var expectedResponse = new ApiSingleResponseV2<A2BApplyingSchoolResponse>(expectedStatusResponse);
            var expectedResult = new ObjectResult(expectedResponse) {StatusCode = StatusCodes.Status201Created};
            
            var mockUseCase = new Mock<ICreateA2BApplyingSchool>();
            mockUseCase.Setup(u => u.Execute(It.IsAny<A2BApplyingSchoolCreateRequest>())).Returns(expectedStatusResponse);
            
            var controller = new A2BApplyingSchoolController(_mockLogger.Object, new Mock<IGetA2BApplyingSchool>().Object, mockUseCase.Object);

            var controllerResponse = controller.Create(request);

            controllerResponse.Result.Should().BeEquivalentTo(expectedResult);
        }
    }
}