using FizzWare.NBuilder;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using TramsDataApi.Controllers;
using TramsDataApi.DatabaseModels;
using TramsDataApi.Gateways;
using TramsDataApi.ResponseModels;
using TramsDataApi.UseCases;
using Xunit;

namespace TramsDataApi.Test.Controllers
{
    public class EstablishmentsControllerTests
    {
        [Fact]
        public void GetEstablishmentByUkprn_ReturnsNotFoundResult_WhenNoAcademyFound()
        {
            var gateway = new Mock<IGetEstablishmentByUkprn>();
            var ukprn = "mockukprn";
            gateway.Setup(g => g.Execute(ukprn)).Returns(() => null);

            var controller = new AcademiesController(gateway.Object);
            var result = controller.GetByUkprn(ukprn);

            result.Should().BeOfType(typeof(NotFoundResult));
        }

        [Fact]
        public void GetEstablishmentByUkprn_ReturnsAcademyResponse_WhenAcademyFound()
        {
            var gateway = new Mock<IGetEstablishmentByUkprn>();
            var ukprn = "mockukprn";
            var academyResponse = Builder<EstablishmentResponse>.CreateNew().With(a => a.Ukprn = ukprn).Build();
            gateway.Setup(g => g.Execute(ukprn)).Returns(() => academyResponse);

            var controller = new AcademiesController(gateway.Object);
            var result = controller.GetByUkprn(ukprn);
            
            result.Should().BeEquivalentTo(new OkObjectResult(academyResponse));
        }
    }
}