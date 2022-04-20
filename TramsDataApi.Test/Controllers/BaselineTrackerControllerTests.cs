using FizzWare.NBuilder;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using System.Collections.Generic;
using TramsDataApi.Controllers.V2;
using TramsDataApi.RequestModels;
using TramsDataApi.ResponseModels;
using TramsDataApi.UseCases;
using Xunit;

namespace TramsDataApi.Test.Controllers
{
    public class BaselineTrackerControllerTests
    {
        private readonly Mock<ILogger<BaselineTrackerController>> _mockLogger;

        public BaselineTrackerControllerTests()
        {
            _mockLogger = new Mock<ILogger<BaselineTrackerController>>();
        }

        [Fact]
        public void GetBaselineTrackerProjects_ReturnsListOfBaselineTrackerProjects_WhenExist()
        {
            var mockUseCase =
                new Mock<IUseCase<GetAllBaselineTrackerRequest, IEnumerable<BaselineTrackerResponse>>>();

            var response = Builder<BaselineTrackerResponse>
                .CreateListOfSize(10)
                .Build();

            mockUseCase
                .Setup(x => x.Execute(It.IsAny<GetAllBaselineTrackerRequest>()))
                .Returns(response);

            var controller = new BaselineTrackerController(_mockLogger.Object, mockUseCase.Object);

            var result = controller.Get();

            result.Result.Should().BeEquivalentTo(new OkObjectResult(response));
        }

        [Fact]
        public void GetBaselineTracker_ReturnsEmptyList_WhenThereAreNoBaselineTrackerProjects()
        {
            var mockUseCase =
                new Mock<IUseCase<GetAllBaselineTrackerRequest, IEnumerable<BaselineTrackerResponse>>>();

            mockUseCase
                .Setup(x => x.Execute(It.IsAny<GetAllBaselineTrackerRequest>()))
                .Returns(new List<BaselineTrackerResponse>());

            var controller = new BaselineTrackerController(_mockLogger.Object, mockUseCase.Object);

            var result = controller.Get();

            result.Result.Should().BeEquivalentTo(new OkObjectResult(new List<BaselineTrackerResponse>()));
        }
    }
}
