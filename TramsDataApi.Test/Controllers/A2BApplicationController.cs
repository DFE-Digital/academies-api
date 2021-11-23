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
    public class A2BApplicationControllerTests
    {
        private readonly Mock<ILogger<A2BApplicationController>> _mockLogger;

        public A2BApplicationControllerTests()
        {
            _mockLogger = new Mock<ILogger<A2BApplicationController>>();
        }

        [Fact]
        public void GetApplicationByApplicationId_ReturnsApiSingleResponseWithApplicationWhenApplicationExists()
        {
            var applicationId = 10001;
            var mockUseCase = new Mock<IGetA2BApplication>();

            var response = Builder<A2BApplicationResponse>
                .CreateNew()
                .With(r => r.ApplicationId = applicationId)
                .Build();

            var expectedResponse = new ApiSingleResponseV2<A2BApplicationResponse>(response);

            mockUseCase
                .Setup(x => x.Execute(It.IsAny<A2BApplicationByIdRequest>()))
                .Returns(response);

            var controller = new A2BApplicationController(_mockLogger.Object, mockUseCase.Object, new Mock<ICreateA2BApplication>().Object);

            var result = controller.GetApplicationByApplicationId(applicationId);

            result.Result.Should().BeEquivalentTo(new OkObjectResult(expectedResponse));
        }

        [Fact]
        public void GetApplicationByApplicationId_ReturnsNotFound_WhenApplicationNotFound()
        {

            var expectedResponse = new NotFoundResult();
            var mockUseCase = new Mock<IGetA2BApplication>();

            var controller = new A2BApplicationController(_mockLogger.Object, mockUseCase.Object, new Mock<ICreateA2BApplication>().Object);

            var result = controller.GetApplicationByApplicationId(10001);

            result.Result.Should().BeEquivalentTo(expectedResponse);
        }

        [Fact]
        public void xxxx_Returns201_WithCreatedObject_WhenApplicationCreated()
        {
            var request = Builder<A2BApplicationCreateRequest>.CreateNew().Build();
            var expectedApplicationResponse =  new A2BApplicationResponse
            {
                ApplicationId = 10001,
                Name = request.Name,
                ApplicationType = request.ApplicationType,
                TrustId = request.TrustId,
                FormTrustProposedNameOfTrust = request.FormTrustProposedNameOfTrust,
                ApplicationSubmitted = request.ApplicationSubmitted,
                ApplicationLeadAuthorId = request.ApplicationLeadAuthorId,
                ApplicationVersion = request.ApplicationVersion,
                ApplicationLeadAuthorName = request.ApplicationLeadAuthorName,
                ApplicationRole = request.ApplicationRole,
                ApplicationRoleOtherDescription = request.ApplicationRoleOtherDescription,
                ChangesToTrust = request.ChangesToTrust,
                ChangesToTrustExplained = request.ChangesToTrustExplained,
                FormTrustOpeningDate = request.FormTrustOpeningDate,
                TrustApproverName = request.TrustApproverName,
                TrustApproverEmail = request.TrustApproverEmail,
                FormTrustReasonApprovalToConvertAsSat = request.FormTrustReasonApprovalToConvertAsSat,
                FormTrustReasonApprovedPerson = request.FormTrustReasonApprovedPerson,
                FormTrustReasonForming = request.FormTrustReasonForming,
                FormTrustReasonVision = request.FormTrustReasonVision,
                FormTrustReasonGeoAreas = request.FormTrustReasonGeoAreas,
                FormTrustReasonFreedom = request.FormTrustReasonFreedom,
                FormTrustReasonImproveTeaching = request.FormTrustReasonImproveTeaching,
                FormTrustPlanForGrowth = request.FormTrustPlanForGrowth,
                FormTrustPlansForNoGrowth = request.FormTrustPlansForNoGrowth,
                FormTrustGrowthPlansYesNo = request.FormTrustGrowthPlansYesNo,
                FormTrustImprovementSupport = request.FormTrustImprovementSupport,
                FormTrustImprovementStrategy = request.FormTrustImprovementStrategy,
                FormTrustImprovementApprovedSponsor = request.FormTrustImprovementApprovedSponsor
            };

            var expectedResponse = new ApiSingleResponseV2<A2BApplicationResponse>(expectedApplicationResponse);
            var expectedResult = new ObjectResult(expectedResponse) {StatusCode = StatusCodes.Status201Created};
            
            var mockUseCase = new Mock<ICreateA2BApplication>();
            mockUseCase.Setup(u => u.Execute(It.IsAny<A2BApplicationCreateRequest>())).Returns(expectedApplicationResponse);
            
            var controller = new A2BApplicationController(_mockLogger.Object, new Mock<IGetA2BApplication>().Object, mockUseCase.Object);

            var controllerResponse = controller.Create(request);

            controllerResponse.Result.Should().BeEquivalentTo(expectedResult);
        }
    }
}