using FizzWare.NBuilder;
using Microsoft.Extensions.Logging;
using Moq;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using TramsDataApi.Controllers.V2;
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
            var applicationId = "ApplicationId";
            var mockUseCase = new Mock<IUseCase<A2BApplicationByIdRequest, A2BApplicationResponse>>();

            var response = Builder<A2BApplicationResponse>
                .CreateNew()
                .With(r => r.ApplicationId = applicationId)
                .Build();

            var expectedResponse = new ApiSingleResponseV2<A2BApplicationResponse>(response);

            mockUseCase
                .Setup(x => x.Execute(It.IsAny<A2BApplicationByIdRequest>()))
                .Returns(response);

            var controller = new A2BApplicationController(_mockLogger.Object, mockUseCase.Object);

            var result = controller.GetApplicationByApplicationId("applicationId");

            result.Result.Should().BeEquivalentTo(new OkObjectResult(expectedResponse));
        }

        [Fact]
        public void GetApplicationByApplicationId_ReturnsNotFound_WhenApplicationNotFound()
        {
            var expectedResponse = new NotFoundResult();
            var mockUseCase = new Mock<IUseCase<A2BApplicationByIdRequest, A2BApplicationResponse>>();

            var controller = new A2BApplicationController(_mockLogger.Object, mockUseCase.Object);

            var result = controller.GetApplicationByApplicationId("applicationId");

            result.Result.Should().BeEquivalentTo(expectedResponse);
        }
    }
}