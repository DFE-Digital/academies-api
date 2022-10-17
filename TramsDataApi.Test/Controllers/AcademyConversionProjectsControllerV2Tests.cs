using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FizzWare.NBuilder;
using FluentAssertions;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Moq;
using Microsoft.AspNetCore.Mvc;
using TramsDataApi.Controllers.V2;
using TramsDataApi.RequestModels.AcademyConversionProject;
using TramsDataApi.ResponseModels;
using TramsDataApi.ResponseModels.AcademyConversionProject;
using TramsDataApi.UseCases;
using Xunit;
using TramsDataApi.DatabaseModels;

namespace TramsDataApi.Test.Controllers
{
    public class AcademyConversionProjectsControllerV2Tests
    {
        private readonly Mock<ILogger<AcademyConversionProjectController>> _mockLogger;

        public AcademyConversionProjectsControllerV2Tests()
        {
            _mockLogger= new Mock<ILogger<AcademyConversionProjectController>>();
        }

        [Fact]
        public async Task GetConversionProjects_ReturnsResponseWithListOfAcademyConversionProjects_WhenFiltersAppliedAndProjectsExist()
        {
            const string projectStatus = "AStatus";
            const int urn = 10001;
            
            var mockUseCase = new Mock<ISearchAcademyConversionProjects>();
            
            var data = new List<AcademyConversionProjectResponse> { new AcademyConversionProjectResponse { ProjectStatus = projectStatus, Urn = urn } };
            
            var expectedPaging = new PagingResponse {Page = 1, RecordCount = 1};
            var expected = new ApiResponseV2<AcademyConversionProjectResponse>(data, expectedPaging);

            mockUseCase
                .Setup(uc => uc.Execute(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<IEnumerable<string>>(), urn))
                .ReturnsAsync(new PagedResult<AcademyConversionProjectResponse>(data, 1));
            
            var controller = new AcademyConversionProjectController(
                mockUseCase.Object,
                new Mock<IGetAcademyConversionProject>().Object,
                new Mock<IUpdateAcademyConversionProject>().Object,
                _mockLogger.Object);
            
            var result = await controller.GetConversionProjects(projectStatus, urn: urn);

            result.Result.Should().BeEquivalentTo(new OkObjectResult(expected));
        }
        
        [Fact]
        public async Task GetConversionProjects_ReturnsResponseWithEmptyList_WhenNoFiltersAndNoResultsFound()
        {
            var mockUseCase = new Mock<ISearchAcademyConversionProjects>();
            
            mockUseCase
                .Setup(uc => uc.Execute(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<List<string>>(), It.IsAny<int?>()))
                .ReturnsAsync(new PagedResult<AcademyConversionProjectResponse>(new List<AcademyConversionProjectResponse>()));
            
            var controller = new AcademyConversionProjectController(
                mockUseCase.Object,
                new Mock<IGetAcademyConversionProject>().Object,
                new Mock<IUpdateAcademyConversionProject>().Object,
                _mockLogger.Object);

            var expectedPaging = new PagingResponse {Page = 1, RecordCount = 0};
            var expected = new ApiResponseV2<AcademyConversionProjectResponse> { Paging = expectedPaging };

            
            var result = await controller.GetConversionProjects(string.Empty);

            result.Result.Should().BeEquivalentTo(new OkObjectResult(expected));
        }

        [Fact]
        public async Task GetConversionProjects_WithPaging_AndMultiplePages_ShouldHavePagingWithValuesSetAndNextPageURLProvided()
        {
            const string expectedNextPageUrl = "?page=2&count=1";

            var mockUseCase = new Mock<ISearchAcademyConversionProjects>();

            var controllerContext = new ControllerContext { HttpContext = new DefaultHttpContext() };
            
            var data = new List<AcademyConversionProjectResponse>
            { 
                new AcademyConversionProjectResponse(), 
                new AcademyConversionProjectResponse()
            };
            
            mockUseCase
                .Setup(uc => uc.Execute(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<List<string>>(), It.IsAny<int?>()))
                .ReturnsAsync(new PagedResult<AcademyConversionProjectResponse>(data.Take(1).ToList(), 1));

            var controller = new AcademyConversionProjectController(
                mockUseCase.Object,                
                new Mock<IGetAcademyConversionProject>().Object,
                new Mock<IUpdateAcademyConversionProject>().Object,
                _mockLogger.Object)
            {
                ControllerContext = controllerContext
            };
            
            var expectedPaging = new PagingResponse { Page = 1, RecordCount = 1, NextPageUrl = expectedNextPageUrl};
            var expected = new ApiResponseV2<AcademyConversionProjectResponse>(data.Take(1), expectedPaging);

            var result = await controller.GetConversionProjects(null, 1, 1);
            
            result.Result.Should().BeEquivalentTo(new OkObjectResult(expected));
        }

        [Fact] 
        public async Task GetConversionProjects_WithPaging_AndSinglePage_ShouldHavePagingWithValuesSetAndNextPageUrlAsNull()
        {
            const string expectedNextPageUrl = null;

            var mockUseCase = new Mock<ISearchAcademyConversionProjects>();
            var controllerContext = new ControllerContext { HttpContext = new DefaultHttpContext() };
            
            var data = new List<AcademyConversionProjectResponse>
            { 
                new AcademyConversionProjectResponse(), 
                new AcademyConversionProjectResponse()
            };

            mockUseCase
                .Setup(uc => uc.Execute(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<IEnumerable<string>>(), It.IsAny<int?>()))
                .ReturnsAsync(new PagedResult<AcademyConversionProjectResponse>(data, 2));

            var controller = new AcademyConversionProjectController(
               mockUseCase.Object,
               new Mock<IGetAcademyConversionProject>().Object,
               new Mock<IUpdateAcademyConversionProject>().Object,
               _mockLogger.Object)
            {
                ControllerContext = controllerContext
            };

            var expectedPaging = new PagingResponse { Page = 1, RecordCount = 2, NextPageUrl = expectedNextPageUrl};
            var expected = new ApiResponseV2<AcademyConversionProjectResponse>(data, expectedPaging);

            var result = await controller.GetConversionProjects(null, 1, 10);
            
            result.Result.Should().BeEquivalentTo(new OkObjectResult(expected));
        }
        
        [Fact]
        public async Task GetConversionProjectById_ReturnsAcademyConversionProject_WhenIdExists()
        {
            var mockUseCase = new Mock<IGetAcademyConversionProject>();
            
            var academyConversionProjectResponse = Builder<AcademyConversionProjectResponse>.CreateNew().Build();

            mockUseCase
                .Setup(x => x.Execute(It.IsAny<int>()))
                .Returns(Task.FromResult(academyConversionProjectResponse));
            
            var controller = new AcademyConversionProjectController(
                new Mock<ISearchAcademyConversionProjects>().Object,                
                mockUseCase.Object,
                new Mock<IUpdateAcademyConversionProject>().Object,
                _mockLogger.Object
            );

            var expectedData = new List<AcademyConversionProjectResponse> {academyConversionProjectResponse};
            var expected = new ApiResponseV2<AcademyConversionProjectResponse>(expectedData, null);
            
            var result = await controller.GetConversionProjectById(It.IsAny<int>());
            
            result.Result.Should().BeEquivalentTo(new OkObjectResult(expected));
        }
        
        [Fact]
        public async Task GetConversionProjectById_ReturnsNotFound_WhenNoConversionProjectExists()
        {
            var controller = new AcademyConversionProjectController(
                new Mock<ISearchAcademyConversionProjects>().Object,
                new Mock<IGetAcademyConversionProject>().Object,
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
                new Mock<ISearchAcademyConversionProjects>().Object,
                new Mock<IGetAcademyConversionProject>().Object,
                mockUseCase.Object,
                _mockLogger.Object
            );

            var expectedData = new List<AcademyConversionProjectResponse> { updatedAcademyConversionProjectResponse };
            var expectedResult = new ApiResponseV2<AcademyConversionProjectResponse>(expectedData, null);
            
            var result = await controller.UpdateConversionProject(It.IsAny<int>(), It.IsAny<UpdateAcademyConversionProjectRequest>());
            
            result.Result.Should().BeEquivalentTo(new OkObjectResult(expectedResult));
        }

        [Fact]
        public async Task UpdateConversionProject_ReturnsNotFound_WhenConversionProjectExists()
        {
            var controller = new AcademyConversionProjectController(
                new Mock<ISearchAcademyConversionProjects>().Object,
                new Mock<IGetAcademyConversionProject>().Object,
                new Mock<IUpdateAcademyConversionProject>().Object,
                _mockLogger.Object
            );

            var result = await
                controller.UpdateConversionProject(It.IsAny<int>(), It.IsAny<UpdateAcademyConversionProjectRequest>());

            result.Result.Should().BeEquivalentTo(new NotFoundResult());
            
        }
    }
}