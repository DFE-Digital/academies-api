using FluentAssertions;
using Moq;
using TramsDataApi.Controllers;
using TramsDataApi.Gateways;
using TramsDataApi.ResponseModels;
using Xunit;

namespace TramsDataApi.Test.Controllers
{
    public class TrustsControllerTests
    {
        [Fact]
        public void GetTrustsByUkPrn_ReturnsNull_WhenNoTrustsFound()
        {
            var gateway = new Mock<ITrustGateway>();
            var ukprn = "mockukprn";
            gateway.Setup(g => g.GetByUkprn(ukprn)).Returns(() => null);

            var controller = new TrustsController(gateway.Object);
            var result = controller.Get(ukprn);

            result.Should().BeNull();
        }
    }
}

