using Dfe.Academies.Tests.Common.Customizations;
using Dfe.AcademiesApi.Client.Contracts;
using DfE.CoreLibs.Testing.AutoFixture.Attributes;
using DfE.CoreLibs.Testing.Mocks.WebApplicationFactory;
using TramsDataApi;

namespace Dfe.Academies.TramsDataApi.Tests.Integration.Controllers.V4;

public class EstablishmentsControllerTests
{

    [Theory]
    [CustomAutoData(typeof(CustomWebApplicationDbContextFactoryCustomization<Startup>))]
    public async Task SearchEstablishmentsAsync_ShouldReturnAllEstablishments_WhenClosedDateIsNull(
        CustomWebApplicationDbContextFactory<Startup> factory,
        IEstablishmentsV4Client establishmentsClient)
    {
        // Arrange
        factory.TestClaims = default;

        // Act
        var result = await establishmentsClient.SearchEstablishments2Async(null, null, null, null, default);

        var establishmentDtos = result.ToList();

        // Assert
        Assert.NotNull(establishmentDtos);
        Assert.Equal(3, establishmentDtos.Count);
    }

    [Theory]
    [CustomAutoData(typeof(CustomWebApplicationDbContextFactoryCustomization<Startup>))]
    public async Task SearchEstablishmentsAsync_ShouldReturnAllEstablishments_WhenClosedDateIsFalse(
    CustomWebApplicationDbContextFactory<Startup> factory,
    IEstablishmentsV4Client establishmentsClient)
    {
        // Arrange
        factory.TestClaims = default;

        // Act
        var result = await establishmentsClient.SearchEstablishments2Async(null, null, null, false, default);

        var establishmentDtos = result.ToList();

        // Assert
        Assert.NotNull(establishmentDtos);
        Assert.Equal(3, establishmentDtos.Count);
    }

    [Theory]
    [CustomAutoData(typeof(CustomWebApplicationDbContextFactoryCustomization<Startup>))]
    public async Task SearchEstablishmentsAsync_ShouldReturnAllEstablishments_WhenClosedDateIsTrue(
    CustomWebApplicationDbContextFactory<Startup> factory,
    IEstablishmentsV4Client establishmentsClient)
    {
        // Arrange
        factory.TestClaims = default;

        // Act
        var result = await establishmentsClient.SearchEstablishments2Async(null, null, null, true, default);

        var establishmentDtos = result.ToList();

        // Assert
        Assert.NotNull(establishmentDtos);
        Assert.Equal(2, establishmentDtos.Count);
    }
}