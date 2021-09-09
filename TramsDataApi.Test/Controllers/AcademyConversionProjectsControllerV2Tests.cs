using System.Collections.Generic;
using FluentAssertions;
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
            var projectStatus = "AStatus";
            
            var mockUseCase = new Mock<IUseCase<GetAcademyConversionProjectsByStatusesRequest, IEnumerable<AcademyConversionProjectResponse>>>();

            var data = new List<AcademyConversionProjectResponse> { new AcademyConversionProjectResponse() { ProjectStatus = projectStatus } };
            var expectedResponse = new ApiResponseV2<AcademyConversionProjectResponse>(data);

            mockUseCase
                .Setup(uc => uc.Execute(It.IsAny<GetAcademyConversionProjectsByStatusesRequest>()))
                .Returns(data);
            
            var controller = new AcademyConversionProjectController(mockUseCase.Object, _mockLogger.Object);
            
            var result = controller.GetConversionProjectsByStatuses(projectStatus);

            result.Result.Should().BeEquivalentTo(new OkObjectResult(expectedResponse));
        }
        
        
        [Fact]
        public void GetConversionProjectsByStatuses_ReturnsResponseWithEmptyList_WhenNoStatusProvided()
        {
            var controller = new AcademyConversionProjectController(
                new Mock<IUseCase<GetAcademyConversionProjectsByStatusesRequest, IEnumerable<AcademyConversionProjectResponse>>>().Object,
                _mockLogger.Object);

            var expectedResponse = new ApiResponseV2<AcademyConversionProjectResponse>();
            
            var result = controller.GetConversionProjectsByStatuses(It.IsAny<string>());

            result.Result.Should().BeEquivalentTo(new OkObjectResult(expectedResponse));
        }
    }
}