using Dfe.Academies.Tests.Common.Customizations;
using Dfe.AcademiesApi.Client.Contracts;
using GovUK.Dfe.CoreLibs.Testing.AutoFixture.Attributes;
using GovUK.Dfe.CoreLibs.Testing.Mocks.WebApplicationFactory;
using TramsDataApi;

namespace Dfe.Academies.TramsDataApi.Tests.Integration.Controllers.V4
{
    public class TrustsControllersTests
    {
        [Theory]
        [CustomAutoData(typeof(CustomWebApplicationDbContextFactoryCustomization<Startup>))]
        public async Task GetTrustByUkprn2Async_ShouldReturnException_WhenNoTrustIsFound(
            CustomWebApplicationDbContextFactory<Startup> factory,
            ITrustsV4Client trustsV4Client)
        {
            // Arrange  
            factory.TestClaims = default;
            var ukprn = "32345678";

            // Act & Assert  
            var exception = await Assert.ThrowsAsync<AcademiesApiException>(() => trustsV4Client.GetTrustByUkprn2Async(ukprn, default));
            Assert.Equal(404, exception.StatusCode);
        }
        [Theory]
        [CustomAutoData(typeof(CustomWebApplicationDbContextFactoryCustomization<Startup>))]
        public async Task GetTrustByUkprn2Async_ShouldReturnTrusts_WhenUkprnIsProvided(
           CustomWebApplicationDbContextFactory<Startup> factory,
           ITrustsV4Client trustsV4Client)
        {
            // Arrange  
            factory.TestClaims = default;
            var ukprn = "12345678";

            // Act  
            var result = await trustsV4Client.GetTrustByUkprn2Async(ukprn, default);

            // Assert  
            Assert.NotNull(result);
            Assert.Equal(ukprn, result.Ukprn);
        }
        [Theory]
        [CustomAutoData(typeof(CustomWebApplicationDbContextFactoryCustomization<Startup>))]
        public async Task GetTrustsByEstablishmentUrnsAsync_ShouldReturnTrustsByEstablishmentUrns(
            CustomWebApplicationDbContextFactory<Startup> factory,
            ITrustsV4Client trustsV4Client)
        {
            // Arrange  
            factory.TestClaims = default;
            var requestModel = new UrnRequestModel { Urns = [22, 33] };

            // Act  
            var result = await trustsV4Client.GetTrustsByEstablishmentUrnsAsync(requestModel, default);

            // Assert  
            Assert.NotNull(result);
            Assert.Equal(2, result.Count);

            var trust = result.SingleOrDefault(x => x.Key == requestModel.Urns[0].ToString());
            Assert.Equal(requestModel.Urns[0].ToString(), trust.Key);

            trust = result.SingleOrDefault(x => x.Key == requestModel.Urns[1].ToString());
            Assert.Equal(requestModel.Urns[1].ToString(), trust.Key);
        }

        [Theory]
        [CustomAutoData(typeof(CustomWebApplicationDbContextFactoryCustomization<Startup>))]
        public async Task GetTrustsByEstablishmentUrnsAsync_ShouldReturnBadRequest_WhenNoURN(
           CustomWebApplicationDbContextFactory<Startup> factory,
           ITrustsV4Client trustsV4Client)
        {
            // Arrange  
            factory.TestClaims = default;
            var requestModel = new UrnRequestModel { Urns = [] };

            // Act & Assert  
            var exception = await Assert.ThrowsAsync<AcademiesApiException>(() => trustsV4Client.GetTrustsByEstablishmentUrnsAsync(requestModel, default));
            Assert.Equal(400, exception.StatusCode);
        }
        [Theory]
        [CustomAutoData(typeof(CustomWebApplicationDbContextFactoryCustomization<Startup>))]
        public async Task GetTrustsByEstablishmentUrnsAsync_ShouldReturnNotFound_WhenURNDoesNotMatch(
           CustomWebApplicationDbContextFactory<Startup> factory,
           ITrustsV4Client trustsV4Client)
        {
            // Arrange  
            factory.TestClaims = default;
            var requestModel = new UrnRequestModel { Urns = [111] };

            // Act & Assert  
            var exception = await Assert.ThrowsAsync<AcademiesApiException>(() => trustsV4Client.GetTrustsByEstablishmentUrnsAsync(requestModel, default));
            Assert.Equal(404, exception.StatusCode);
        }
    }
}
