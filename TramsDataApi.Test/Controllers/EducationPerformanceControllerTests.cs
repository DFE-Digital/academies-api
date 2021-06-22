using System.Linq;
using FizzWare.NBuilder;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using TramsDataApi.Controllers;
using TramsDataApi.ResponseModels.EducationalPerformance;
using TramsDataApi.UseCases;
using Xunit;

namespace TramsDataApi.Test.Controllers
{
    public class EducationPerformanceControllerTests
    {
        private readonly Mock<IGetKeyStagePerformanceByUrn> _getKeyStagePerformanceByUrn;
        private KeyStagePerformanceController _controller;

        public EducationPerformanceControllerTests()
        {
            _getKeyStagePerformanceByUrn = new Mock<IGetKeyStagePerformanceByUrn>();
            _controller = new KeyStagePerformanceController(_getKeyStagePerformanceByUrn.Object);
        }

        [Fact]
        public void GetEducationalPerformance_ReturnsNotFound_WhenAccountIsNotFound()
        {
            var urn = "10021231";
            
            _getKeyStagePerformanceByUrn
                .Setup(get => get.Execute(urn))
                .Returns(() => null);

            var result = _controller.GetEducationPerformanceByUrn(urn);

            result.Result.Should().BeEquivalentTo(new NotFoundResult());
        }
        
        [Fact]
        public void GetEducationalPerformance_ReturnsKS1PerformanceData_WhenAccountIsFound()
        {
            var urn = "11121277";

            var keyStage1Response = Builder<KeyStage1PerformanceResponse>.CreateListOfSize(3).Build().ToList();
            var educationalPerformanceResponse = new EducationalPerformanceResponse
            {
                SchoolName = "Test establishment",
                KeyStage1Responses = keyStage1Response
            };
            
            _getKeyStagePerformanceByUrn
                .Setup(get => get.Execute(urn))
                .Returns(() => educationalPerformanceResponse);

            var result = _controller.GetEducationPerformanceByUrn(urn);

            result.Result.Should().BeEquivalentTo(new OkObjectResult(educationalPerformanceResponse));
        }
    }
}