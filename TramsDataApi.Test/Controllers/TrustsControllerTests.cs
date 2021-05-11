using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
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
        public void GetTrustsByUkPrn_ReturnsNotFoundResult_WhenNoTrustsFound()
        {
            var gateway = new Mock<ITrustGateway>();
            var ukprn = "mockukprn";
            gateway.Setup(g => g.GetByUkprn(ukprn)).Returns(() => null);

            var controller = new TrustsController(gateway.Object);
            var result = controller.Get(ukprn);

            result.Result.Should().BeOfType(typeof(NotFoundResult));
        }

        [Fact]
        public void GetTrustsByUkprn_ReturnsTrustResponse_WhenTrustFound()
        {
            var ukprn = "mockukprn";

            var trustResponse = new TrustResponse
            {
                IfdData = new IFDDataResponse(),
                GiasData = new GIASDataResponse
                {
                    GroupId = "Test group ID",
                    GroupName = "Test group name",
                    CompaniesHouseNumber = "Test CH Number",
                    GroupContactAddress = new AddressResponse
                    {
                        Street = "Test street",
                        AdditionalLine = "Test additional line",
                        Locality = "Test locality",
                        Town = "Test town",
                        County = "Test county",
                        Postcode = "P05TC0D"
                    },
                    Ukprn = ukprn
                }
            };
            var gateway = new Mock<ITrustGateway>();
            gateway.Setup(g => g.GetByUkprn(ukprn)).Returns(trustResponse);
            
            var controller = new TrustsController(gateway.Object);
            var result = controller.Get(ukprn);

            result.Result.Should().BeEquivalentTo(new OkObjectResult(trustResponse));
        }
    }
}

