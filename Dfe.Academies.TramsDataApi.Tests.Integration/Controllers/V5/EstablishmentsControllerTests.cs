using Dfe.Academies.Tests.Common.Customizations;
using Dfe.AcademiesApi.Client.Contracts;
using GovUK.Dfe.CoreLibs.Testing.AutoFixture.Attributes;
using GovUK.Dfe.CoreLibs.Testing.Mocks.WebApplicationFactory;
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
        var result = await establishmentsClient.SearchEstablishmentsWithOfstedReportCardsAsync(null, null, null, null, null, default);

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
        var result = await establishmentsClient.SearchEstablishmentsWithOfstedReportCardsAsync(null, null, null, false, null, default);

        var establishmentDtos = result.ToList();

        // Assert
        Assert.NotNull(establishmentDtos);
        Assert.Equal(5, establishmentDtos.Count);
        foreach (var establishmentDto in establishmentDtos)
        {
            Assert.NotNull(establishmentDto.ReportCardFullInspection);
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
        var result = await establishmentsClient.SearchEstablishmentsWithOfstedReportCardsAsync(null, null, null, true, null, default);

        var establishmentDtos = result.ToList();

        // Assert
        Assert.NotNull(establishmentDtos);
        Assert.Equal(2, establishmentDtos.Count);
        foreach (var establishmentDto in establishmentDtos)
        {
            Assert.NotNull(establishmentDto.ReportCardFullInspection);
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
        var result = await establishmentsClient.SearchEstablishmentsWithOfstedReportCardsAsync("Scho", null, null, null, null, default);

        var establishmentDtos = result.ToList();

        // Assert
        Assert.NotNull(establishmentDtos);
        Assert.Equal(3, establishmentDtos.Count);
        foreach (var establishmentDto in establishmentDtos)
        {
            Assert.NotNull(establishmentDto.ReportCardFullInspection);
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
        var result = await establishmentsClient.SearchEstablishmentsWithOfstedReportCardsAsync("Scho", null, null, null, false, default);

        var establishmentDtos = result.ToList();

        // Assert
        Assert.NotNull(establishmentDtos);
        Assert.Equal(3, establishmentDtos.Count);
        foreach (var establishmentDto in establishmentDtos)
        {
            Assert.NotNull(establishmentDto.ReportCardFullInspection);
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
        var result = await establishmentsClient.SearchEstablishmentsWithOfstedReportCardsAsync("Scho", "Scho", "Scho", null, null, default);

        var establishmentDtos = result.ToList();

        // Assert
        Assert.NotNull(establishmentDtos);
        Assert.Empty(establishmentDtos);
        foreach (var establishmentDto in establishmentDtos)
        {
            Assert.NotNull(establishmentDto.ReportCardFullInspection);
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
        var result = await establishmentsClient.SearchEstablishmentsWithOfstedReportCardsAsync("Scho", "Scho", "Scho", null, false, default);

        var establishmentDtos = result.ToList();

        // Assert
        Assert.NotNull(establishmentDtos);
        Assert.Empty(establishmentDtos);
        foreach (var establishmentDto in establishmentDtos)
        {
            Assert.NotNull(establishmentDto.ReportCardFullInspection);
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
        var result = await establishmentsClient.SearchEstablishmentsWithOfstedReportCardsAsync("Scho", "Scho", "Scho", null, true, default);

        var establishmentDtos = result.ToList();

        // Assert
        Assert.NotNull(establishmentDtos);
        Assert.Equal(3, establishmentDtos.Count);
        foreach (var establishmentDto in establishmentDtos)
        {
            Assert.NotNull(establishmentDto.ReportCardFullInspection);
        }
    }

    [Theory]
    [CustomAutoData(typeof(CustomWebApplicationDbContextFactoryCustomization<Startup>))]
    public async Task GetEstablishmentsWithOfstedReportCardsByUrnsAsync_ShouldReturnMatchingEstablishments_WhenURNsAreMatched(
        CustomWebApplicationDbContextFactory<Startup> factory,
        IEstablishmentsV5Client establishmentsClient)
    {
        // Arrange
        factory.TestClaims = default;
        var request = new UrnRequestModel
        {
            Urns = [22, 33]
        };

        // Act
        var result = await establishmentsClient.GetEstablishmentsWithOfstedReportCardsByUrnsAsync(request, default);
        Assert.NotNull(result);
        Assert.Equal(2, result.Count);

        var establishment = result.SingleOrDefault(x => x.Urn == request.Urns[0].ToString());
        Assert.NotNull(establishment);

        establishment = result.SingleOrDefault(x => x.Urn == request.Urns[1].ToString());
        Assert.NotNull(establishment);
    }

    [Theory]
    [CustomAutoData(typeof(CustomWebApplicationDbContextFactoryCustomization<Startup>))]
    public async Task GetEstablishmentsWithOfstedReportCardsByUrnsAsync_ShouldReturnNotFound(
       CustomWebApplicationDbContextFactory<Startup> factory,
       IEstablishmentsV5Client establishmentsClient)
    {
        // Arrange
        factory.TestClaims = default;

        var request = new UrnRequestModel
        {
            Urns = [10001, 10002] // those URNs do not exist
        };

        AcademiesApiException exception = await Assert.ThrowsAsync<AcademiesApiException>(async () => await establishmentsClient.GetEstablishmentsWithOfstedReportCardsByUrnsAsync(request, default));

        Assert.Equal(404, exception.StatusCode);
    }
}