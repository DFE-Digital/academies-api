using Dfe.Academies.Tests.Common.Customizations;
using GovUK.Dfe.AcademiesApi.Client.Contracts;
using GovUK.Dfe.CoreLibs.Contracts.Academies.V4.Establishments;
using GovUK.Dfe.CoreLibs.Testing.AutoFixture.Attributes;
using GovUK.Dfe.CoreLibs.Testing.Mocks.WebApplicationFactory;
using TramsDataApi;

namespace Dfe.Academies.TramsDataApi.Tests.Integration.Controllers.V4;

public class DioceseControllerTests
{
    #region SearchDioceses Tests

    [Theory]
    [CustomAutoData(typeof(CustomWebApplicationDbContextFactoryCustomization<Startup>))]
    public async Task SearchDioceses_ShouldReturnResults_WhenNoParametersProvided(
        CustomWebApplicationDbContextFactory<Startup> factory,
        IDioceseV4Client dioceseClient)
    {
        // Arrange
        factory.TestClaims = default;

        // Act
        var result = await dioceseClient.SearchDiocesesAsync(null, null, default);
        var dioceses = result.ToList();

        // Assert
        Assert.NotNull(dioceses);
    }

    [Theory]
    [CustomAutoData(typeof(CustomWebApplicationDbContextFactoryCustomization<Startup>))]
    public async Task SearchDioceses_ShouldReturnFilteredResults_WhenNameParameterProvided(
        CustomWebApplicationDbContextFactory<Startup> factory,
        IDioceseV4Client dioceseClient)
    {
        // Arrange
        factory.TestClaims = default;
        var searchName = "test 1";

        // Act
        var result = await dioceseClient.SearchDiocesesAsync(searchName, null, default);
        var dioceses = result.ToList();

        // Assert
        Assert.NotNull(dioceses);
        if (dioceses.Count > 0)
        {
            Assert.All(dioceses, d =>
                Assert.Contains(searchName, d.Name, StringComparison.OrdinalIgnoreCase));
        }
    }

    [Theory]
    [CustomAutoData(typeof(CustomWebApplicationDbContextFactoryCustomization<Startup>))]
    public async Task SearchDioceses_ShouldReturnFilteredResults_WhenCodeParameterProvided(
        CustomWebApplicationDbContextFactory<Startup> factory,
        IDioceseV4Client dioceseClient)
    {
        // Arrange
        factory.TestClaims = default;
        var searchCode = "DR03";

        // Act
        var result = await dioceseClient.SearchDiocesesAsync(null, searchCode, default);
        var dioceses = result.ToList();

        // Assert
        Assert.NotNull(dioceses);
        if (dioceses.Count > 0)
        {
            Assert.All(dioceses, d =>
                Assert.Contains(searchCode, d.Code, StringComparison.OrdinalIgnoreCase));
        }
    }

    [Theory]
    [CustomAutoData(typeof(CustomWebApplicationDbContextFactoryCustomization<Startup>))]
    public async Task SearchDioceses_ShouldReturnEmptyList_WhenNoMatches(
        CustomWebApplicationDbContextFactory<Startup> factory,
        IDioceseV4Client dioceseClient)
    {
        // Arrange
        factory.TestClaims = default;

        // Act
        var result = await dioceseClient.SearchDiocesesAsync("NonExistentDiocese12345", null, default);
        var dioceses = result.ToList();

        // Assert
        Assert.NotNull(dioceses);
        Assert.Empty(dioceses);
    }

    #endregion

    #region GetDioceseByCode Tests

    [Theory]
    [CustomAutoData(typeof(CustomWebApplicationDbContextFactoryCustomization<Startup>))]
    public async Task GetDioceseByCode_ShouldReturnDiocese_WhenValidCodeProvided(
        CustomWebApplicationDbContextFactory<Startup> factory,
        IDioceseV4Client dioceseClient)
    {
        // Arrange
        factory.TestClaims = default;
        var validCode = "DR01";

        // Act
        var result = await dioceseClient.GetDioceseByCodeAsync(validCode, default);

        // Assert
        Assert.NotNull(result);
        Assert.IsType<GovUK.Dfe.AcademiesApi.Client.Contracts.NameAndCodeDto>(result);
        Assert.Equal(validCode, result.Code);
        Assert.NotNull(result.Name);
        Assert.NotEmpty(result.Name);
    }

    [Theory]
    [CustomAutoData(typeof(CustomWebApplicationDbContextFactoryCustomization<Startup>))]
    public async Task GetDioceseByCode_ShouldThrow404_WhenCodeNotFound(
        CustomWebApplicationDbContextFactory<Startup> factory,
        IDioceseV4Client dioceseClient)
    {
        // Arrange
        factory.TestClaims = default;
        var nonExistentCode = "99999";

        // Act & Assert
        var exception = await Assert.ThrowsAsync<AcademiesApiException>(
            () => dioceseClient.GetDioceseByCodeAsync(nonExistentCode, default));

        Assert.Equal(404, exception.StatusCode);
    }

    #endregion
}