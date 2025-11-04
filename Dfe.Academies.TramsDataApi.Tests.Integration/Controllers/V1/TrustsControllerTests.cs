using Dfe.Academies.Tests.Common.Customizations;
using Dfe.AcademiesApi.Client.Contracts;
using GovUK.Dfe.CoreLibs.Testing.AutoFixture.Attributes;
using GovUK.Dfe.CoreLibs.Testing.Mocks.WebApplicationFactory;
using TramsDataApi;

namespace Dfe.Academies.TramsDataApi.Tests.Integration.Controllers.V1;

public class TrustsControllerTests
{
    [Theory]
    [CustomAutoData(typeof(CustomWebApplicationDbContextFactoryCustomization<Startup>))]
    public async Task GetTrustsByUkprnAsync_ShouldReturnTrustsData_WhenUkprnExists(
        CustomWebApplicationDbContextFactory<Startup> factory,
        ITrustsV1Client trustsClient)
    {
        // Arrange
        factory.TestClaims = default;
        
        // Act
        var result = await trustsClient.GetTrustByUkprnAsync("1");

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