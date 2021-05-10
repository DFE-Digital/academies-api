using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using TramsDataApi.Controllers;
using TramsDataApi.Gateways;
using Xunit;

namespace TramsDataApi.Test.Controllers
{
    public class AcademiesControllerTests
    {
        [Fact]
        public void GetAcademyByUkprn_ReturnsNotFoundResult_WhenNoAcademyFound()
        {
            var gateway = new Mock<IAcademyGateway>();
            var ukprn = "mockukprn";
            gateway.Setup(g => g.GetByUkprn(ukprn)).Returns(() => null);

            var controller = new AcademiesController(gateway.Object);
            var result = controller.GetByUkprn(ukprn);

            result.Should().BeOfType(typeof(NotFoundResult));
        }
    }
}