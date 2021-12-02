using FizzWare.NBuilder;
using Microsoft.Extensions.Logging;
using Moq;
using FluentAssertions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TramsDataApi.Controllers.V2;
using TramsDataApi.RequestModels.ApplyToBecome;
using TramsDataApi.ResponseModels;
using TramsDataApi.ResponseModels.ApplyToBecome;
using TramsDataApi.UseCases;
using Xunit;

namespace TramsDataApi.Test.Controllers
{
    public class A2BApplicationStatusControllerTests
    {
        private readonly Mock<ILogger<A2BApplicationStatusController>> _mockLogger;

        public A2BApplicationStatusControllerTests()
        {
            _mockLogger = new Mock<ILogger<A2BApplicationStatusController>>();
        }

        [Fact]
        public void GetApplicationStatusByStatusId_ReturnsApiSingleResponseWithA2BApplicationStatusWhenStatusExists()
        {
            var applicationStatusId = 10001;
            var mockUseCase = new Mock<IGetA2BApplicationStatus>();

            var response = Builder<A2BApplicationStatusResponse>
                .CreateNew()
                .With(r => r.ApplicationStatusId = applicationStatusId)
                .Build();

            var expectedResponse = new ApiSingleResponseV2<A2BApplicationStatusResponse>(response);

            mockUseCase
                .Setup(x => x.Execute(It.IsAny<int>()))
                .Returns(response);

            var controller = new A2BApplicationStatusController(_mockLogger.Object, mockUseCase.Object,new Mock<ICreateA2BApplicationStatus>().Object);

            var result = controller.GetApplicationStatusByStatusId(applicationStatusId);

            result.Result.Should().BeEquivalentTo(new OkObjectResult(expectedResponse));
        }

        [Fact]
        public void GetApplicationByStatusId_ReturnsNotFound_WhenApplicationStatusNotFound()
        {
            var expectedResponse = new NotFoundResult();
            var mockUseCase = new Mock<IGetA2BApplicationStatus>();

            var controller = new A2BApplicationStatusController(_mockLogger.Object, mockUseCase.Object, new Mock<ICreateA2BApplicationStatus>().Object);

            var result = controller.GetApplicationStatusByStatusId(10001);

            result.Result.Should().BeEquivalentTo(expectedResponse);
        }

        [Fact]
        public void Create_Returns201_WithCreatedObject_WhenApplicationStatusCreated()
        {
            var request = Builder<A2BApplicationStatusCreateRequest>.CreateNew().Build();
            var expectedStatusResponse =  new A2BApplicationStatusResponse
            {
                ApplicationStatusId = 10001, 
                Name = request.Name
            };

            var expectedResponse = new ApiSingleResponseV2<A2BApplicationStatusResponse>(expectedStatusResponse);
            var expectedResult = new ObjectResult(expectedResponse) {StatusCode = StatusCodes.Status201Created};
            
            var mockUseCase = new Mock<ICreateA2BApplicationStatus>();
            mockUseCase.Setup(u => u.Execute(It.IsAny<A2BApplicationStatusCreateRequest>())).Returns(expectedStatusResponse);
            
            var controller = new A2BApplicationStatusController(_mockLogger.Object, new Mock<IGetA2BApplicationStatus>().Object, mockUseCase.Object);

            var controllerResponse = controller.Create(request);

            controllerResponse.Result.Should().BeEquivalentTo(expectedResult);
        }
    }
}