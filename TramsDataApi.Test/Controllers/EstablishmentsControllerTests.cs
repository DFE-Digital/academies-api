using FizzWare.NBuilder;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using TramsDataApi.Controllers;
using TramsDataApi.RequestModels;
using TramsDataApi.ResponseModels;
using TramsDataApi.UseCases;
using Xunit;

namespace TramsDataApi.Test.Controllers
{
    public class EstablishmentsControllerTests
    {
        private readonly EstablishmentsController _controller;
        private readonly Mock<IGetEstablishmentByUkprn> _getEstablishmentByUkprn;
        private readonly Mock<IUseCase<GetEstablishmentByUrnRequest, EstablishmentResponse>> _getEstablishmentByUrn;
        private const string UKPRN = "mockukprn";
        private const int URN = 123456789;

        public EstablishmentsControllerTests()
        {
            _getEstablishmentByUkprn = new Mock<IGetEstablishmentByUkprn>();
            _getEstablishmentByUrn = new Mock<IUseCase<GetEstablishmentByUrnRequest, EstablishmentResponse>>();

            _controller = new EstablishmentsController(_getEstablishmentByUkprn.Object, _getEstablishmentByUrn.Object);
        }

        [Fact]
        public void GetEstablishmentByUkprn_ReturnsNotFoundResult_WhenNoEstablishmentFound()
        {
            _getEstablishmentByUkprn.Setup(g => g.Execute(UKPRN)).Returns(() => null);

            var result = _controller.GetByUkprn(UKPRN);

            result.Result.Should().BeOfType(typeof(NotFoundResult));
        }

        [Fact]
        public void GetEstablishmentByUkprn_ReturnsEstablishmentResponse_WhenEstablishmentFound()
        {
            var establishmentResponse = Builder<EstablishmentResponse>.CreateNew().With(a => a.Ukprn = UKPRN).Build();
            _getEstablishmentByUkprn.Setup(g => g.Execute(UKPRN)).Returns(() => establishmentResponse);

            var result = _controller.GetByUkprn(UKPRN);
            
            result.Result.Should().BeEquivalentTo(new OkObjectResult(establishmentResponse));
        }

        [Fact]
        public void GetEstablishmentByUrn_ReturnsNotFoundResult_WhenNoEstablishmentFound()
        {
            _getEstablishmentByUrn.Setup(g => g.Execute(It.IsAny<GetEstablishmentByUrnRequest>())).Returns(() => null);

            var result = _controller.GetByUrn(URN);

            result.Result.Should().BeOfType(typeof(NotFoundResult));
        }

        [Fact]
        public void GetEstablishmentByUrn_ReturnsEstablishmentResponse_WhenEstablishmentFound()
        {
            var establishmentResponse = Builder<EstablishmentResponse>.CreateNew().With(a => a.Urn = URN.ToString()).Build();
            _getEstablishmentByUrn.Setup(g => g.Execute(It.Is<GetEstablishmentByUrnRequest>(req => req.URN == URN))).Returns(() => establishmentResponse);

            var result = _controller.GetByUrn(URN);

            result.Result.Should().BeEquivalentTo(new OkObjectResult(establishmentResponse));
        }
    }
}