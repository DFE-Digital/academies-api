using FizzWare.NBuilder;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using TramsDataApi.Controllers;
using TramsDataApi.Gateways;
using TramsDataApi.ResponseModels;
using Xunit;

namespace TramsDataApi.Test.Controllers
{
    public class EstablishmentsControllerTests
    {
        [Fact]
        public void GetEstablishmentByUkprn_ReturnsNotFoundResult_WhenNoAcademyFound()
        {
            var gateway = new Mock<IEstablishmentGateway>();
            var ukprn = "mockukprn";
            gateway.Setup(g => g.GetByUkprn(ukprn)).Returns(() => null);

            var controller = new AcademiesController(gateway.Object);
            var result = controller.GetByUkprn(ukprn);

            result.Should().BeOfType(typeof(NotFoundResult));
        }

        [Fact]
        public void GetEstablishmentByUkprn_ReturnsAcademyResponse_WhenAcademyFound()
        {
            var gateway = new Mock<IEstablishmentGateway>();
            var ukprn = "mockukprn";
            var academyResponse = Builder<EstablishmentResponse>.CreateNew().With(a => a.Ukprn = ukprn).Build();
            gateway.Setup(g => g.GetByUkprn(ukprn)).Returns(() => academyResponse);

            var controller = new AcademiesController(gateway.Object);
            var result = controller.GetByUkprn(ukprn);
            
            result.Should().BeEquivalentTo(new OkObjectResult(academyResponse));
        }
    }
}