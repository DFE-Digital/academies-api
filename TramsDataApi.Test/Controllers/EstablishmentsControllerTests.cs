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
        public void GetEstablishmentByUkprn_ReturnsNotFoundResult_WhenNoEstablishmentFound()
        {
            var gateway = new Mock<IGetEstablishmentByUkprn>();
            var ukprn = "mockukprn";
            gateway.Setup(g => g.Execute(ukprn)).Returns(() => null);

            var controller = new EstablishmentsController(gateway.Object);
            var result = controller.GetByUkprn(ukprn);

            result.Result.Should().BeOfType(typeof(NotFoundResult));
        }

        [Fact]
        public void GetEstablishmentByUkprn_ReturnsEstablishmentResponse_WhenEstablishmentFound()
        {
            var gateway = new Mock<IGetEstablishmentByUkprn>();
            var ukprn = "mockukprn";
            var establishmentResponse = Builder<EstablishmentResponse>.CreateNew().With(a => a.Ukprn = ukprn).Build();
            gateway.Setup(g => g.Execute(ukprn)).Returns(() => establishmentResponse);

            var controller = new EstablishmentsController(gateway.Object);
            var result = controller.GetByUkprn(ukprn);
            
            result.Result.Should().BeEquivalentTo(new OkObjectResult(establishmentResponse));
        }
    }
}