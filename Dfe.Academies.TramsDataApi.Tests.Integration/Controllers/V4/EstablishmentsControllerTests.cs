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
        Assert.Equal(5, establishmentDtos.Count);
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
        Assert.Equal(5, establishmentDtos.Count);
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

    [Theory]
    [CustomAutoData(typeof(CustomWebApplicationDbContextFactoryCustomization<Startup>))]
    public async Task EstablishmentsByUrnsAsync_ShouldReturnAllEstablishments_By_UKPRN(
    CustomWebApplicationDbContextFactory<Startup> factory,
    IEstablishmentsV4Client establishmentsClient)
    {
        // Arrange
        factory.TestClaims = default;

        var request = new UrnRequestModel
        {
            Urns = [22, 33]
        };

        // Act
        var result = await establishmentsClient.GetEstablishmentsByUrnsAsync(request);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(2, result.Count);

        var establishment = result.SingleOrDefault(x => x.Urn == request.Urns[0].ToString());
        Assert.NotNull(establishment);

        establishment = result.SingleOrDefault(x => x.Urn == request.Urns[1].ToString());
        Assert.NotNull(establishment);
    }

    [Theory]
    [CustomAutoData(typeof(CustomWebApplicationDbContextFactoryCustomization<Startup>))]
    public async Task EstablishmentsByUrnsAsync_ShouldReturnNotFound(
    CustomWebApplicationDbContextFactory<Startup> factory,
    IEstablishmentsV4Client establishmentsClient)
    {
        // Arrange
        factory.TestClaims = default;

        var request = new UrnRequestModel
        {
            Urns = [10001, 10002] // those URNs do not exist
        };

        AcademiesApiException exception = await Assert.ThrowsAsync<AcademiesApiException>(() => establishmentsClient.GetEstablishmentsByUrnsAsync(request));

        Assert.Equal(404, exception.StatusCode);
    }

    [Theory]
    [CustomAutoData(typeof(CustomWebApplicationDbContextFactoryCustomization<Startup>))]
    public async Task EstablishmentsByUkprnsAsync_ShouldReturnAllEstablishments_By_UKPRNs(
    CustomWebApplicationDbContextFactory<Startup> factory,
    IEstablishmentsV4Client establishmentsClient)
    {
        // Arrange
        factory.TestClaims = default;

        var request = new UkprnRequestModel
        {
            Ukprns = ["10060367", "10067112"]
        };

        // Act
        var result = await establishmentsClient.GetEstablishmentsByUkprnsAsync(request);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(2, result.Count);

        var establishment = result.SingleOrDefault(x => x.Ukprn == request.Ukprns[0]);
        Assert.NotNull(establishment);

        establishment = result.SingleOrDefault(x => x.Ukprn == request.Ukprns[1]);
        Assert.NotNull(establishment);
    }

    [Theory]
    [CustomAutoData(typeof(CustomWebApplicationDbContextFactoryCustomization<Startup>))]
    public async Task EstablishmentsByUkprnsAsync_ShouldReturnNotFound(
    CustomWebApplicationDbContextFactory<Startup> factory,
    IEstablishmentsV4Client establishmentsClient)
    {
        // Arrange
        factory.TestClaims = default;
        string[] ukprns = ["10000000", "4634523"]; // those UKPRN do not exist

        var request = new UkprnRequestModel
        {
            Ukprns = ["10000000", "4634523"] // those UKPRN do not exist
        };

        AcademiesApiException exception = await Assert.ThrowsAsync<AcademiesApiException>(() => establishmentsClient.GetEstablishmentsByUkprnsAsync(request));

        Assert.Equal(404, exception.StatusCode);
    }
}