using System.Collections.Generic;
using System.Linq;
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
        public void GetConversionProjectsByStatuses_ReturnsResponseWithListOfAcademyConversionProjects_WhenProjectsExist()
        {
            const string projectStatus = "AStatus";
            
            var mockUseCase = new Mock<IUseCase<GetAcademyConversionProjectsByStatusesRequest, IEnumerable<AcademyConversionProjectResponse>>>();
            
            var data = new List<AcademyConversionProjectResponse> { new AcademyConversionProjectResponse { ProjectStatus = projectStatus } };
            
            var expectedPaging = new PagingResponse {Page = 1, RecordCount = 1};
            var expected = new ApiResponseV2<AcademyConversionProjectResponse>(data, expectedPaging);

            mockUseCase
                .Setup(uc => uc.Execute(It.IsAny<GetAcademyConversionProjectsByStatusesRequest>()))
                .Returns(data);
            
            var controller = new AcademyConversionProjectController(
                mockUseCase.Object,
                new Mock<IUseCase<GetAllAcademyConversionProjectsRequest, IEnumerable<AcademyConversionProjectResponse>>>().Object,
                new Mock<IUseCase<GetAcademyConversionProjectByIdRequest, AcademyConversionProjectResponse>>().Object,
                new Mock<IUpdateAcademyConversionProject>().Object,
                _mockLogger.Object);
            
            var result = controller.GetConversionProjects(projectStatus);

            result.Result.Should().BeEquivalentTo(new OkObjectResult(expected));
        }
        
        [Fact]
        public void GetConversionProjectsByStatuses_ReturnsResponseWithEmptyList_WhenNoStatusProvidedAndNoResultsFound()
        {
            var controller = new AcademyConversionProjectController(
                new Mock<IUseCase<GetAcademyConversionProjectsByStatusesRequest, IEnumerable<AcademyConversionProjectResponse>>>().Object,
                new Mock<IUseCase<GetAllAcademyConversionProjectsRequest, IEnumerable<AcademyConversionProjectResponse>>>().Object,
                new Mock<IUseCase<GetAcademyConversionProjectByIdRequest, AcademyConversionProjectResponse>>().Object,
                new Mock<IUpdateAcademyConversionProject>().Object,
                _mockLogger.Object);

            var expectedPaging = new PagingResponse {Page = 1, RecordCount = 0};
            var expected = new ApiResponseV2<AcademyConversionProjectResponse> { Paging = expectedPaging };

            
            var result = controller.GetConversionProjects(It.IsAny<string>());

            result.Result.Should().BeEquivalentTo(new OkObjectResult(expected));
        }

        [Fact]
        public void GetConversionProjects_WithPaging_AndMultiplePages_ShouldHavePagingWithValuesSetAndNextPageURLProvided()
        {
            const string expectedNextPageUrl = "?page=2&count=1";
            
            var mockUseCase = new Mock<IUseCase<GetAllAcademyConversionProjectsRequest, IEnumerable<AcademyConversionProjectResponse>>>();
            var controllerContext = new ControllerContext { HttpContext = new DefaultHttpContext() };
            
            var data = new List<AcademyConversionProjectResponse>
            { 
                new AcademyConversionProjectResponse(), 
                new AcademyConversionProjectResponse()
            };
            
            mockUseCase
                .Setup(uc => uc.Execute(It.IsAny<GetAllAcademyConversionProjectsRequest>()))
                .Returns(data.Take(1));

            var controller = new AcademyConversionProjectController(
                new Mock<IUseCase<GetAcademyConversionProjectsByStatusesRequest,
                    IEnumerable<AcademyConversionProjectResponse>>>().Object,
                mockUseCase.Object,
                new Mock<IUseCase<GetAcademyConversionProjectByIdRequest, AcademyConversionProjectResponse>>().Object,
                new Mock<IUpdateAcademyConversionProject>().Object,
                _mockLogger.Object)
            {
                ControllerContext = controllerContext
            };
            
            var expectedPaging = new PagingResponse { Page = 1, RecordCount = 1, NextPageUrl = expectedNextPageUrl};
            var expected = new ApiResponseV2<AcademyConversionProjectResponse>(data.Take(1), expectedPaging);

            var result = controller.GetConversionProjects(null, 1, 1);
            
            result.Result.Should().BeEquivalentTo(new OkObjectResult(expected));
        }

        [Fact] public void GetConversionProjects_WithPaging_AndSinglePage_ShouldHavePagingWithValuesSetAndNextPageUrlAsNull()
        {
            const string expectedNextPageUrl = null;
            
            var mockUseCase = new Mock<IUseCase<GetAllAcademyConversionProjectsRequest, IEnumerable<AcademyConversionProjectResponse>>>();
            var controllerContext = new ControllerContext { HttpContext = new DefaultHttpContext() };
            
            var data = new List<AcademyConversionProjectResponse>
            { 
                new AcademyConversionProjectResponse(), 
                new AcademyConversionProjectResponse()
            };
            
            mockUseCase
                .Setup(uc => uc.Execute(It.IsAny<GetAllAcademyConversionProjectsRequest>()))
                .Returns(data);

            var controller = new AcademyConversionProjectController(
                new Mock<IUseCase<GetAcademyConversionProjectsByStatusesRequest, IEnumerable<AcademyConversionProjectResponse>>>().Object,
                mockUseCase.Object,
                new Mock<IUseCase<GetAcademyConversionProjectByIdRequest, AcademyConversionProjectResponse>>().Object,
                new Mock<IUpdateAcademyConversionProject>().Object,
                _mockLogger.Object)
            {
                ControllerContext = controllerContext
            };
            
            var expectedPaging = new PagingResponse { Page = 1, RecordCount = 2, NextPageUrl = expectedNextPageUrl};
            var expected = new ApiResponseV2<AcademyConversionProjectResponse>(data, expectedPaging);

            var result = controller.GetConversionProjects(null, 1, 10);
            
            result.Result.Should().BeEquivalentTo(new OkObjectResult(expected));
        }
        
         [Fact]
        public void GetConversionProjectById_ReturnsAcademyConversionProject_WhenIdExists()
        {
            var mockUseCase =
                new Mock<IUseCase<GetAcademyConversionProjectByIdRequest, AcademyConversionProjectResponse>>();
            
            
            var academyConversionProjectResponse = Builder<AcademyConversionProjectResponse>.CreateNew().Build();

            mockUseCase
                .Setup(x => x.Execute(It.IsAny<GetAcademyConversionProjectByIdRequest>()))
                .Returns(academyConversionProjectResponse);
            
            var controller = new AcademyConversionProjectController(
                new Mock<IUseCase<GetAcademyConversionProjectsByStatusesRequest, IEnumerable<AcademyConversionProjectResponse>>>().Object,
                new Mock<IUseCase<GetAllAcademyConversionProjectsRequest, IEnumerable<AcademyConversionProjectResponse>>>().Object,
                mockUseCase.Object,
                new Mock<IUpdateAcademyConversionProject>().Object,
                _mockLogger.Object
            );

            var expectedData = new List<AcademyConversionProjectResponse> {academyConversionProjectResponse};
            var expected = new ApiResponseV2<AcademyConversionProjectResponse>(expectedData, null);
            
            var result = controller.GetConversionProjectById(It.IsAny<int>());
            
            result.Result.Should().BeEquivalentTo(new OkObjectResult(expected));
        }
        
        [Fact]
        public void GetConversionProjectById_ReturnsNotFound_WhenNoConversionProjectExists()
        {
            var controller = new AcademyConversionProjectController(
                new Mock<IUseCase<GetAcademyConversionProjectsByStatusesRequest, IEnumerable<AcademyConversionProjectResponse>>>().Object,
                new Mock<IUseCase<GetAllAcademyConversionProjectsRequest, IEnumerable<AcademyConversionProjectResponse>>>().Object, 
                new Mock<IUseCase<GetAcademyConversionProjectByIdRequest, AcademyConversionProjectResponse>>().Object,
                new Mock<IUpdateAcademyConversionProject>().Object,
                _mockLogger.Object
            );

            var result = controller.GetConversionProjectById(It.IsAny<int>());
            
            result.Result.Should().BeEquivalentTo(new NotFoundResult());
        }

        [Fact]
        public void UpdateConversionProject_Returns_UpdatedConversionProject_WhenConversionProjectExists()
        {
            var mockUseCase = new Mock<IUpdateAcademyConversionProject>();
            
            var updatedAcademyConversionProjectResponse = Builder<AcademyConversionProjectResponse>.CreateNew().Build();

            mockUseCase
                .Setup(x => x.Execute(It.IsAny<int>(),It.IsAny<UpdateAcademyConversionProjectRequest>()))
                .Returns(updatedAcademyConversionProjectResponse);
            
            var controller = new AcademyConversionProjectController(
                new Mock<IUseCase<GetAcademyConversionProjectsByStatusesRequest, IEnumerable<AcademyConversionProjectResponse>>>().Object,
                new Mock<IUseCase<GetAllAcademyConversionProjectsRequest, IEnumerable<AcademyConversionProjectResponse>>>().Object, 
                new Mock<IUseCase<GetAcademyConversionProjectByIdRequest, AcademyConversionProjectResponse>>().Object,
                mockUseCase.Object,
                _mockLogger.Object
            );

            var expectedData = new List<AcademyConversionProjectResponse> { updatedAcademyConversionProjectResponse };
            var expectedResult = new ApiResponseV2<AcademyConversionProjectResponse>(expectedData, null);
            
            var result = controller.UpdateConversionProject(It.IsAny<int>(), It.IsAny<UpdateAcademyConversionProjectRequest>());
            
            result.Result.Should().BeEquivalentTo(new OkObjectResult(expectedResult));
        }

        [Fact]
        public void UpdateConversionProject_ReturnsNotFound_WhenConversionProjectExists()
        {
            var controller = new AcademyConversionProjectController(
                new Mock<IUseCase<GetAcademyConversionProjectsByStatusesRequest, IEnumerable<AcademyConversionProjectResponse>>>().Object,
                new Mock<IUseCase<GetAllAcademyConversionProjectsRequest, IEnumerable<AcademyConversionProjectResponse>>>().Object, 
                new Mock<IUseCase<GetAcademyConversionProjectByIdRequest, AcademyConversionProjectResponse>>().Object,
                new Mock<IUpdateAcademyConversionProject>().Object,
                _mockLogger.Object
            );

            var result =
                controller.UpdateConversionProject(It.IsAny<int>(), It.IsAny<UpdateAcademyConversionProjectRequest>());

            result.Result.Should().BeEquivalentTo(new NotFoundResult());
            
        }
    }
}