using FizzWare.NBuilder;
using FluentAssertions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using TramsDataApi.Controllers.V2;
using TramsDataApi.RequestModels.ApplyToBecome;
using TramsDataApi.ResponseModels;
using TramsDataApi.ResponseModels.ApplyToBecome;
using TramsDataApi.UseCases;
using Xunit;

namespace TramsDataApi.Test.Controllers
{
    public class A2BContributorControllerTests
    {
        private readonly Mock<ILogger<A2BContributorController>> _mockLogger;

        public A2BContributorControllerTests()
        {
            _mockLogger = new Mock<ILogger<A2BContributorController>>();
        }

        [Fact]
        public void GetContributorByContributorId_ReturnsApiSingleResponseWithA2BContributorWhenStatusExists()
        {
            const string contributorId = "10001";
            var mockUseCase = new Mock<IGetA2BContributor>();

            var response = Builder<A2BContributorResponse>
                .CreateNew()
                .With(r => r.ContributorUserId = contributorId)
                .Build();

            var expectedResponse = new ApiSingleResponseV2<A2BContributorResponse>(response);

            mockUseCase
                .Setup(x => x.Execute(It.IsAny<string>()))
                .Returns(response);

            var controller = new A2BContributorController(_mockLogger.Object, mockUseCase.Object,new Mock<ICreateA2BContributor>().Object);

            var result = controller.GetContributorByContributorId(contributorId);

            result.Result.Should().BeEquivalentTo(new OkObjectResult(expectedResponse));
        }

        [Fact]
        public void GetContributorByContributorId_ReturnsNotFound_WhenContributorNotFound()
        {
            const string contributorId = "10001";
            var expectedResponse = new NotFoundResult();
            var mockUseCase = new Mock<IGetA2BContributor>();

            var controller = new A2BContributorController(_mockLogger.Object, mockUseCase.Object, new Mock<ICreateA2BContributor>().Object);

            var result = controller.GetContributorByContributorId(contributorId);

            result.Result.Should().BeEquivalentTo(expectedResponse);
        }

        [Fact]
        public void Create_Returns201_WithCreatedObject_WhenContributorCreated()
        {
            var request = Builder<A2BContributorCreateRequest>.CreateNew().Build();
            var expectedStatusResponse =  new A2BContributorResponse
            {
                ContributorUserId = "10001",
                ApplicationTypeId = "10001",
                ContributorAppIdTest = "10001",
                ContributorUserName = "Username"
            };

            var expectedResponse = new ApiSingleResponseV2<A2BContributorResponse>(expectedStatusResponse);
            var expectedResult = new ObjectResult(expectedResponse) {StatusCode = StatusCodes.Status201Created};
            
            var mockUseCase = new Mock<ICreateA2BContributor>();
            mockUseCase.Setup(u => u.Execute(It.IsAny<A2BContributorCreateRequest>())).Returns(expectedStatusResponse);
            
            var controller = new A2BContributorController(_mockLogger.Object, new Mock<IGetA2BContributor>().Object, mockUseCase.Object);

            var controllerResponse = controller.Create(request);

            controllerResponse.Result.Should().BeEquivalentTo(expectedResult);
        }
    }
}