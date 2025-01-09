using Dfe.Academies.Tests.Common.Customizations;
using DfE.CoreLibs.Testing.AutoFixture.Attributes;
using DfE.CoreLibs.Testing.Mocks.WebApplicationFactory;
using Dfe.TramsDataApi.Client.Contracts;
using TramsDataApi;

namespace Dfe.Academies.TramsDataApi.Tests.Integration.Controllers.V1;

public class TrustsControllerTests
{
    [Theory]
    [CustomAutoData(typeof(CustomWebApplicationDbContextFactoryCustomization<Startup>))]
    public async Task GetTrustsByUkprnAsync_ShouldReturnTrustsData_WhenUkprnExists(
        CustomWebApplicationDbContextFactory<Startup> factory,
        ITrustsClient trustsClient)
    {
        // Arrange
        factory.TestClaims = default;
        
        // Act
        var result = await trustsClient.GetTrustByUkprnAsync("1", "1");

        // Assert
        Assert.NotNull(result);
        Assert.NotEmpty(result.Establishments);
        Assert.All(result.Establishments, e =>
        {
            Assert.NotNull(e.MisEstablishment);
            Assert.NotNull(e.MisFurtherEducationEstablishment);
        });
    }
}