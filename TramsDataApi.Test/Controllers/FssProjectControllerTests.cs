using FizzWare.NBuilder;
using FizzWare.NBuilder.PropertyNaming;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using TramsDataApi.Controllers.V2;
using TramsDataApi.ResponseModels;
using TramsDataApi.UseCases;
using Xunit;

namespace TramsDataApi.Test.Controllers
{
    public class FssProjectControllerTests
    {
        private readonly Mock<ILogger<FssProjectController>> mockLogger;

        public FssProjectControllerTests()
        {
            BuilderSetup.SetDefaultPropertyName(new RandomValuePropertyNamer(new BuilderSettings()));
            mockLogger = new Mock<ILogger<FssProjectController>>();
        }

        [Fact]
        public void GetProjects_ReturnsEmptySetOfProjects_WhenNoTrustsFound()
        {
            var projects = new Mock<IGetAllFssProject>();
            projects.Setup(s => s.Execute(1, 10))
                .Returns(new List<FssProjectResponse>());

            var controller = new FssProjectController(mockLogger.Object, new Mock<IGetAllFssProject>().Object);
            var result = controller.GetAll();

            result.Result.Should().BeEquivalentTo(new OkObjectResult(new List<FssProjectResponse>()));
        }

        [Fact]
        public void GetProjects_ReturnsAllProjects_WithPagination()
        {
            var expectedProjectss = Builder<FssProjectResponse>.CreateListOfSize(5).Build();

            var projects = new Mock<IGetAllFssProject>();
            projects.Setup(s => s.Execute(1, 10))
                .Returns(expectedProjectss);

            var controller = new FssProjectController(mockLogger.Object, new Mock<IGetAllFssProject>().Object);
            var result = controller.GetAll();

            result.Result.Should().BeEquivalentTo(new OkObjectResult(expectedProjectss));
        }
    }
}
