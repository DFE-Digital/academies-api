using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FizzWare.NBuilder;
using Microsoft.Extensions.Logging;
using Moq;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using TramsDataApi.Controllers;
using TramsDataApi.RequestModels.AcademyConversionProject;
using TramsDataApi.ResponseModels.AcademyConversionProject;
using TramsDataApi.UseCases;
using Xunit;

namespace TramsDataApi.Test.Controllers
{
    public class AcademyConversionProjectsControllerTests
    {
        private readonly Mock<ILogger<AcademyConversionProjectController>> _mockLogger;

        public AcademyConversionProjectsControllerTests()
        {
            _mockLogger= new Mock<ILogger<AcademyConversionProjectController>>();
        }

        [Fact]
        public async Task GetConversionProjects_ReturnsListOfAcademyConversionProjects_WhenProjectsExist()
        {
            var mockUseCase = new Mock<IGetAcademyConversionProjects>();

            var academyConversionProjectResponse = Builder<AcademyConversionProjectResponse>
                .CreateListOfSize(10)
                .Build();

            mockUseCase
                .Setup(x => x.Execute(It.IsAny<int>(), It.IsAny<int>()))
                .Returns(Task.FromResult(academyConversionProjectResponse.ToList()));
            
            var controller = new AcademyConversionProjectController(
                new Mock<IGetAcademyConversionProject>().Object,
                mockUseCase.Object,
                new Mock<IUpdateAcademyConversionProject>().Object,
                _mockLogger.Object
            );

            var result = await controller.GetConversionProjects();

            result.Result.Should().BeEquivalentTo(new OkObjectResult(academyConversionProjectResponse));
        }
        
        [Fact]
        public async Task GetConversionProjects_ReturnsEmptyList_WhenThereAreNoConversionProjects()
        {
            var mockUseCase = new Mock<IGetAcademyConversionProjects>();
            
            mockUseCase
                .Setup(x => x.Execute(It.IsAny<int>(), It.IsAny<int>()))
                .Returns(Task.FromResult(new List<AcademyConversionProjectResponse>()));
            
            var controller = new AcademyConversionProjectController(
                new Mock<IGetAcademyConversionProject>().Object,
                mockUseCase.Object,
                new Mock<IUpdateAcademyConversionProject>().Object,
                _mockLogger.Object
            );

            var result = await controller.GetConversionProjects();

            result.Result.Should().BeEquivalentTo(new OkObjectResult(new List<AcademyConversionProjectResponse>()));
        }

        [Fact]
        public async Task GetConversionProjectById_ReturnsAcademyConversionProject_WhenIdExists()
        {
            var mockUseCase =
                new Mock<IGetAcademyConversionProject>();

            var academyConversionProjectResponse = Builder<AcademyConversionProjectResponse>.CreateNew().Build();

            mockUseCase
                .Setup(x => x.Execute(It.IsAny<int>()))
                .Returns(Task.FromResult(academyConversionProjectResponse));
            
            var controller = new AcademyConversionProjectController(
                mockUseCase.Object,
                new Mock<IGetAcademyConversionProjects>().Object,
                new Mock<IUpdateAcademyConversionProject>().Object,
                _mockLogger.Object
            );

            var result = await controller.GetConversionProjectById(It.IsAny<int>());
            
            result.Result.Should().BeEquivalentTo(new OkObjectResult(academyConversionProjectResponse));
        }
        
        [Fact]
        public async Task GetConversionProjectById_ReturnsNotFound_WhenConversionProjectExists()
        {
            var controller = new AcademyConversionProjectController(
                new Mock<IGetAcademyConversionProject>().Object,
                new Mock<IGetAcademyConversionProjects>().Object,
                new Mock<IUpdateAcademyConversionProject>().Object,
                _mockLogger.Object
            );

            var result = await controller.GetConversionProjectById(It.IsAny<int>());
            
            result.Result.Should().BeEquivalentTo(new NotFoundResult());
        }

        [Fact]
        public async Task UpdateConversionProject_Returns_UpdatedConversionProject_WhenConversionProjectExists()
        {
            var mockUseCase = new Mock<IUpdateAcademyConversionProject>();
            
            var updatedAcademyConversionProjectResponse = Builder<AcademyConversionProjectResponse>.CreateNew().Build();

            mockUseCase
                .Setup(x => x.Execute(It.IsAny<int>(),It.IsAny<UpdateAcademyConversionProjectRequest>()))
                .Returns(Task.FromResult(updatedAcademyConversionProjectResponse));
            
            var controller = new AcademyConversionProjectController(
                new Mock<IGetAcademyConversionProject>().Object,
                new Mock<IGetAcademyConversionProjects>().Object,mockUseCase.Object,
                _mockLogger.Object
            );

            var result = await controller.UpdateConversionProject(It.IsAny<int>(), It.IsAny<UpdateAcademyConversionProjectRequest>());
            
            result.Result.Should().BeEquivalentTo(new OkObjectResult(updatedAcademyConversionProjectResponse));
        }

        [Fact]
        public async Task UpdateConversionProject_ReturnsNotFound_WhenConversionProjectDoesNotExist()
        {
            var controller = new AcademyConversionProjectController(
                new Mock<IGetAcademyConversionProject>().Object,
                new Mock<IGetAcademyConversionProjects>().Object,
                new Mock<IUpdateAcademyConversionProject>().Object,
                _mockLogger.Object
            );

            var result =
                await controller.UpdateConversionProject(It.IsAny<int>(), It.IsAny<UpdateAcademyConversionProjectRequest>());

            result.Result.Should().BeEquivalentTo(new NotFoundResult());
        }
    }
}