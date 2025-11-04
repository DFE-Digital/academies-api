using Dfe.Academies.Tests.Common.Customizations;
using Dfe.AcademiesApi.Client.Contracts;
using DfE.CoreLibs.Testing.AutoFixture.Attributes;
using DfE.CoreLibs.Testing.Mocks.WebApplicationFactory;
using TramsDataApi;

namespace Dfe.Academies.TramsDataApi.Tests.Integration.Controllers.V5;

public class EstablishmentsControllerTests
{

    [Theory]
    [CustomAutoData(typeof(CustomWebApplicationDbContextFactoryCustomization<Startup>))]
    public async Task SearchEstablishmentsAsync_ShouldReturnAllEstablishments_WhenClosedDateIsNull(
        CustomWebApplicationDbContextFactory<Startup> factory,
        IEstablishmentsV5Client establishmentsClient)
    {
        // Arrange
        factory.TestClaims = default;

        // Act
        var result = await establishmentsClient.SearchEstablishmentsWithMockReportCardsAsync(null, null, null, null, null, default);

        var establishmentDtos = result.ToList();

        // Assert
        Assert.NotNull(establishmentDtos);
        Assert.Equal(5, establishmentDtos.Count);
    }

    [Theory]
    [CustomAutoData(typeof(CustomWebApplicationDbContextFactoryCustomization<Startup>))]
    public async Task SearchEstablishmentsAsync_ShouldReturnAllEstablishments_WhenClosedDateIsFalse(
    CustomWebApplicationDbContextFactory<Startup> factory,
    IEstablishmentsV5Client establishmentsClient)
    {
        // Arrange
        factory.TestClaims = default;

        // Act
        var result = await establishmentsClient.SearchEstablishmentsWithMockReportCardsAsync(null, null, null, false, null, default);

        var establishmentDtos = result.ToList();

        // Assert
        Assert.NotNull(establishmentDtos);
        Assert.Equal(5, establishmentDtos.Count);
        foreach (var establishmentDto in establishmentDtos)
        {
            Assert.NotNull(establishmentDto.ReportCard); 
        }
    }

    [Theory]
    [CustomAutoData(typeof(CustomWebApplicationDbContextFactoryCustomization<Startup>))]
    public async Task SearchEstablishmentsAsync_ShouldReturnAllEstablishments_WhenClosedDateIsTrue(
    CustomWebApplicationDbContextFactory<Startup> factory,
    IEstablishmentsV5Client establishmentsClient)
    {
        // Arrange
        factory.TestClaims = default;

        // Act
        var result = await establishmentsClient.SearchEstablishmentsWithMockReportCardsAsync(null, null, null, true, null, default);

        var establishmentDtos = result.ToList();

        // Assert
        Assert.NotNull(establishmentDtos);
        Assert.Equal(2, establishmentDtos.Count);
        foreach (var establishmentDto in establishmentDtos)
        {
            Assert.NotNull(establishmentDto.ReportCard);
        }
    }

    [Theory]
    [CustomAutoData(typeof(CustomWebApplicationDbContextFactoryCustomization<Startup>))]
    public async Task SearchEstablishmentsAsync_ShouldReturnMatchingEstablishments_WhenMatchAnyIsNullAndOnlyNameProvided(
        CustomWebApplicationDbContextFactory<Startup> factory,
        IEstablishmentsV5Client establishmentsClient)
    {
        // Arrange
        factory.TestClaims = default;

        // Act
        var result = await establishmentsClient.SearchEstablishmentsWithMockReportCardsAsync("Scho", null, null, null, null, default);

        var establishmentDtos = result.ToList();

        // Assert
        Assert.NotNull(establishmentDtos);
        Assert.Equal(3, establishmentDtos.Count);
        foreach (var establishmentDto in establishmentDtos)
        {
            Assert.NotNull(establishmentDto.ReportCard);
        }
    }

    [Theory]
    [CustomAutoData(typeof(CustomWebApplicationDbContextFactoryCustomization<Startup>))]
    public async Task SearchEstablishmentsAsync_ShouldReturnMatchingEstablishments_WhenMatchAnyIsFalseAndOnlyNameProvided(
    CustomWebApplicationDbContextFactory<Startup> factory,
    IEstablishmentsV5Client establishmentsClient)
    {
        // Arrange
        factory.TestClaims = default;

        // Act
        var result = await establishmentsClient.SearchEstablishmentsWithMockReportCardsAsync("Scho",  null, null, null, false, default);

        var establishmentDtos = result.ToList();

        // Assert
        Assert.NotNull(establishmentDtos);
        Assert.Equal(3, establishmentDtos.Count);
        foreach (var establishmentDto in establishmentDtos)
        {
            Assert.NotNull(establishmentDto.ReportCard);
        }
    }

    [Theory]
    [CustomAutoData(typeof(CustomWebApplicationDbContextFactoryCustomization<Startup>))]
    public async Task SearchEstablishmentsAsync_ShouldReturnNoEstablishments_WhenMatchAnyIsNullAndAllParamsProvided(
    CustomWebApplicationDbContextFactory<Startup> factory,
    IEstablishmentsV5Client establishmentsClient)
    {
        // Arrange
        factory.TestClaims = default;

        // Act
        var result = await establishmentsClient.SearchEstablishmentsWithMockReportCardsAsync("Scho", "Scho", "Scho", null, null, default);

        var establishmentDtos = result.ToList();

        // Assert
        Assert.NotNull(establishmentDtos);
        Assert.Empty(establishmentDtos);
        foreach (var establishmentDto in establishmentDtos)
        {
            Assert.NotNull(establishmentDto.ReportCard);
        }
    }

    [Theory]
    [CustomAutoData(typeof(CustomWebApplicationDbContextFactoryCustomization<Startup>))]
    public async Task SearchEstablishmentsAsync_ShouldReturnNoEstablishments_WhenMatchAnyIsFalseAndAllParamsProvided(
    CustomWebApplicationDbContextFactory<Startup> factory,
    IEstablishmentsV5Client establishmentsClient)
    {
        // Arrange
        factory.TestClaims = default;

        // Act
        var result = await establishmentsClient.SearchEstablishmentsWithMockReportCardsAsync("Scho", "Scho", "Scho", null, false, default);

        var establishmentDtos = result.ToList();

        // Assert
        Assert.NotNull(establishmentDtos);
        Assert.Empty(establishmentDtos);
        foreach (var establishmentDto in establishmentDtos)
        {
            Assert.NotNull(establishmentDto.ReportCard);
        }
    }

    [Theory]
    [CustomAutoData(typeof(CustomWebApplicationDbContextFactoryCustomization<Startup>))]
    public async Task SearchEstablishmentsAsync_ShouldReturnMatchingEstablishments_WhenMatchAnyIsTrue(
    CustomWebApplicationDbContextFactory<Startup> factory,
    IEstablishmentsV5Client establishmentsClient)
    {
        // Arrange
        factory.TestClaims = default;

        // Act
        var result = await establishmentsClient.SearchEstablishmentsWithMockReportCardsAsync("Scho", "Scho", "Scho", null, true, default);

        var establishmentDtos = result.ToList();

        // Assert
        Assert.NotNull(establishmentDtos);
        Assert.Equal(3, establishmentDtos.Count);
        foreach (var establishmentDto in establishmentDtos)
        {
            Assert.NotNull(establishmentDto.ReportCard);
        }
    } 
}