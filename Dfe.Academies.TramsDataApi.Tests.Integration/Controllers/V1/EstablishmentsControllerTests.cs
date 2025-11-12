using GovUK.Dfe.CoreLibs.Testing.AutoFixture.Attributes;
using GovUK.Dfe.CoreLibs.Testing.Mocks.WebApplicationFactory;
using TramsDataApi;
using Dfe.Academies.Tests.Common.Customizations;
using Dfe.AcademiesApi.Client.Contracts;

namespace Dfe.Academies.TramsDataApi.Tests.Integration.Controllers.V1;

public class EstablishmentsControllerTests
{
    
    [Theory]
    [CustomAutoData(typeof(CustomWebApplicationDbContextFactoryCustomization<Startup>))]
    public async Task GetEstablishmentByUkprnAsync_ShouldReturnEstablishments_WhenUkprnExists(
        CustomWebApplicationDbContextFactory<Startup> factory,
        IEstablishmentsV1Client establishmentsClient)
    {
        // Arrange
        factory.TestClaims = default;

        // Act
        var result = await establishmentsClient.GetByUkprnAsync("100");

        // Assert
        Assert.NotNull(result);
        Assert.Equal("100", result.Ukprn);
        Assert.NotNull(result.MisEstablishment);
        Assert.NotNull(result.MisFurtherEducationEstablishment);
    }
}