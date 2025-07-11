using Dfe.Academies.Tests.Common.Customizations;
using Dfe.AcademiesApi.Client.Contracts;
using DfE.CoreLibs.Testing.AutoFixture.Attributes;
using DfE.CoreLibs.Testing.Mocks.WebApplicationFactory;
using TramsDataApi;

namespace Dfe.Academies.TramsDataApi.Tests.Integration.Controllers.V4
{
    public class TrustsControllersTests
    {

        [Theory]
        [CustomAutoData(typeof(CustomWebApplicationDbContextFactoryCustomization<Startup>))]
        public async Task GetTrustsByEstablishmentUrnsAsync_ShouldReturnTrustsByEstablishmentUrns(
            CustomWebApplicationDbContextFactory<Startup> factory, 
            ITrustsV4Client trustsV4Client)
        {
            // Arrange
            factory.TestClaims = default;
            var requestModel = new UrnRequestModel { Urns = new List<int> { 22, 33 } };

            // Act
            var result = await trustsV4Client.GetTrustsByEstablishmentUrnsAsync(requestModel, default);

            // Flatten all TrustDto results from the dictionary
            var establishmentDtos = result.Values.SelectMany(x => x).ToList();

            // Assert
            Assert.NotNull(establishmentDtos);
            Assert.Equal(2, establishmentDtos.Count);

            var trust = result.SingleOrDefault(x => x.Urn == requestModel.Urns[0].ToString());
            Assert.NotNull(trust);

            trust = result.SingleOrDefault(x => x.Urn == requestModel.Urns[1].ToString());
            Assert.NotNull(trust);


        }

    }
}
