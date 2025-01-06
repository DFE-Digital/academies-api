using Dfe.Academies.Tests.Common.Customizations;
using DfE.CoreLibs.Testing.AutoFixture.Attributes;
using DfE.CoreLibs.Testing.Mocks.WebApplicationFactory;
using Dfe.TramsDataApi.Client.Contracts;
using TramsDataApi;

namespace Dfe.Academies.TramsDataApi.Tests.Integration.Controllers.V1;

public class EstablishmentsControllerTests
{
    
    [Theory]
    [CustomAutoData(typeof(CustomWebApplicationDbContextFactoryCustomization<Startup>))]
    public async Task GetEstablishmentByUkprnAsync_ShouldReturnEstablishments_WhenUkprnExists(
        IEstablishmentsClient establishmentsClient)
    {
        // Arrange

        // Act
        var result = await establishmentsClient.GetByUkprnAsync("100", "1");

        // Assert
        Assert.NotNull(result);
        Assert.Equal("100", result.Ukprn);
        Assert.NotNull(result.MisEstablishment);
        Assert.NotNull(result.MisFurtherEducationEstablishment);
    }
}