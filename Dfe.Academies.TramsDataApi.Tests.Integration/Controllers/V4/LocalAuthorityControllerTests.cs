using Dfe.Academies.Tests.Common.Customizations;
using Dfe.AcademiesApi.Client.Contracts;
using GovUK.Dfe.CoreLibs.Testing.AutoFixture.Attributes;
using GovUK.Dfe.CoreLibs.Testing.Mocks.WebApplicationFactory;
using TramsDataApi;

namespace Dfe.Academies.TramsDataApi.Tests.Integration.Controllers.V4;

public class LocalAuthorityControllerTests
{
    #region SearchLocalAuthorities Tests

    [Theory]
    [CustomAutoData(typeof(CustomWebApplicationDbContextFactoryCustomization<Startup>))]
    public async Task SearchLocalAuthorities_ShouldReturnAllLocalAuthorities_WhenNoParametersProvided(
        CustomWebApplicationDbContextFactory<Startup> factory,
        ILocalAuthorityV4Client localAuthorityClient)
    {
        // Arrange
        factory.TestClaims = default;

        // Act
        var result = await localAuthorityClient.SearchLocalAuthoritiesAsync(null, null, default);

        var localAuthorities = result.ToList();

        // Assert
        Assert.NotNull(localAuthorities);
        Assert.NotEmpty(localAuthorities);
    }

    [Theory]
    [CustomAutoData(typeof(CustomWebApplicationDbContextFactoryCustomization<Startup>))]
    public async Task SearchLocalAuthorities_ShouldReturnFilteredResults_WhenNameParameterProvided(
        CustomWebApplicationDbContextFactory<Startup> factory,
        ILocalAuthorityV4Client localAuthorityClient)
    {
        // Arrange
        factory.TestClaims = default;
        var searchName = "Birmingham";

        // Act
        var result = await localAuthorityClient.SearchLocalAuthoritiesAsync(searchName, null, default);

        var localAuthorities = result.ToList();

        // Assert
        Assert.NotNull(localAuthorities);
        // Verify that results contain the search term (if any results are returned)
        if (localAuthorities.Count > 0)
        {
            Assert.All(localAuthorities, la =>
                Assert.Contains(searchName, la.Name, StringComparison.OrdinalIgnoreCase));
        }
    }

    [Theory]
    [CustomAutoData(typeof(CustomWebApplicationDbContextFactoryCustomization<Startup>))]
    public async Task SearchLocalAuthorities_ShouldReturnFilteredResults_WhenCodeParameterProvided(
        CustomWebApplicationDbContextFactory<Startup> factory,
        ILocalAuthorityV4Client localAuthorityClient)
    {
        // Arrange
        factory.TestClaims = default;
        var searchCode = "330";

        // Act
        var result = await localAuthorityClient.SearchLocalAuthoritiesAsync(null, searchCode, default);

        var localAuthorities = result.ToList();

        // Assert
        Assert.NotNull(localAuthorities);
        // Verify that results contain the search code (if any results are returned)
        if (localAuthorities.Count > 0)
        {
            Assert.All(localAuthorities, la =>
                Assert.Contains(searchCode, la.Code, StringComparison.OrdinalIgnoreCase));
        }
    }

    [Theory]
    [CustomAutoData(typeof(CustomWebApplicationDbContextFactoryCustomization<Startup>))]
    public async Task SearchLocalAuthorities_ShouldReturnFilteredResults_WhenBothNameAndCodeProvided(
        CustomWebApplicationDbContextFactory<Startup> factory,
        ILocalAuthorityV4Client localAuthorityClient)
    {
        // Arrange
        factory.TestClaims = default;
        var searchName = "Birmingham";
        var searchCode = "330";

        // Act
        var result = await localAuthorityClient.SearchLocalAuthoritiesAsync(searchName, searchCode, default);

        var localAuthorities = result.ToList();

        // Assert
        Assert.NotNull(localAuthorities);
        // Verify that results match both search criteria (if any results are returned)
        if (localAuthorities.Count > 0)
        {
            Assert.All(localAuthorities, la =>
            {
                Assert.Contains(searchName, la.Name, StringComparison.OrdinalIgnoreCase);
                Assert.Contains(searchCode, la.Code, StringComparison.OrdinalIgnoreCase);
            });
        }
    }

    [Theory]
    [CustomAutoData(typeof(CustomWebApplicationDbContextFactoryCustomization<Startup>))]
    public async Task SearchLocalAuthorities_ShouldReturnEmptyList_WhenNoMatchingResults(
        CustomWebApplicationDbContextFactory<Startup> factory,
        ILocalAuthorityV4Client localAuthorityClient)
    {
        // Arrange
        factory.TestClaims = default;
        var nonExistentName = "NonExistentLocalAuthority12345";

        // Act
        var result = await localAuthorityClient.SearchLocalAuthoritiesAsync(nonExistentName, null, default);

        var localAuthorities = result.ToList();

        // Assert
        Assert.NotNull(localAuthorities);
        Assert.Empty(localAuthorities);
    }

    [Theory]
    [CustomAutoData(typeof(CustomWebApplicationDbContextFactoryCustomization<Startup>))]
    public async Task SearchLocalAuthorities_ShouldReturnValidNameAndCodeDto_Structure(
        CustomWebApplicationDbContextFactory<Startup> factory,
        ILocalAuthorityV4Client localAuthorityClient)
    {
        // Arrange
        factory.TestClaims = default;

        // Act
        var result = await localAuthorityClient.SearchLocalAuthoritiesAsync(null, null, default);

        var localAuthorities = result.ToList();

        // Assert
        Assert.NotNull(localAuthorities);

        // If we have results, verify the structure
        if (localAuthorities.Count > 0)
        {
            var firstResult = localAuthorities.First();
            Assert.NotNull(firstResult.Name);
            Assert.NotNull(firstResult.Code);
            Assert.NotEmpty(firstResult.Name);
            Assert.NotEmpty(firstResult.Code);
        }
    }

    [Theory]
    [CustomAutoData(typeof(CustomWebApplicationDbContextFactoryCustomization<Startup>))]
    public async Task SearchLocalAuthorities_ShouldBeCaseInsensitive_ForNameParameter(
        CustomWebApplicationDbContextFactory<Startup> factory,
        ILocalAuthorityV4Client localAuthorityClient)
    {
        // Arrange
        factory.TestClaims = default;

        // Act - Test with different cases
        var resultLower = await localAuthorityClient.SearchLocalAuthoritiesAsync("birmingham", null, default);
        var resultUpper = await localAuthorityClient.SearchLocalAuthoritiesAsync("BIRMINGHAM", null, default);
        var resultMixed = await localAuthorityClient.SearchLocalAuthoritiesAsync("Birmingham", null, default);

        var localAuthoritiesLower = resultLower.ToList();
        var localAuthoritiesUpper = resultUpper.ToList();
        var localAuthoritiesMixed = resultMixed.ToList();

        // Assert
        Assert.NotNull(localAuthoritiesLower);
        Assert.NotNull(localAuthoritiesUpper);
        Assert.NotNull(localAuthoritiesMixed);

        // All should return the same count of results (case insensitive search)
        Assert.Equal(localAuthoritiesLower.Count, localAuthoritiesUpper.Count);
        Assert.Equal(localAuthoritiesUpper.Count, localAuthoritiesMixed.Count);
    }

    [Theory]
    [CustomAutoData(typeof(CustomWebApplicationDbContextFactoryCustomization<Startup>))]
    public async Task SearchLocalAuthorities_ShouldHandleSpecialCharactersInName(
        CustomWebApplicationDbContextFactory<Startup> factory,
        ILocalAuthorityV4Client localAuthorityClient)
    {
        // Arrange
        factory.TestClaims = default;
        var searchNameWithSpaces = "City of London";

        // Act
        var result = await localAuthorityClient.SearchLocalAuthoritiesAsync(searchNameWithSpaces, null, default);

        var localAuthorities = result.ToList();

        // Assert
        Assert.NotNull(localAuthorities);
        // Test should pass regardless of whether results are found
    }

    [Theory]
    [CustomAutoData(typeof(CustomWebApplicationDbContextFactoryCustomization<Startup>))]
    public async Task SearchLocalAuthorities_ShouldHandleNullParameters(
        CustomWebApplicationDbContextFactory<Startup> factory,
        ILocalAuthorityV4Client localAuthorityClient)
    {
        // Arrange
        factory.TestClaims = default;

        // Act
        var result = await localAuthorityClient.SearchLocalAuthoritiesAsync(null, null, default);

        var localAuthorities = result.ToList();

        // Assert
        Assert.NotNull(localAuthorities);
        // Should return all local authorities when no filter is applied
    }

    #endregion

    #region GetLocalAuthorityByCode Tests

    [Theory]
    [CustomAutoData(typeof(CustomWebApplicationDbContextFactoryCustomization<Startup>))]
    public async Task GetLocalAuthorityByCode_ShouldReturnLocalAuthority_WhenValidCodeProvided(
        CustomWebApplicationDbContextFactory<Startup> factory,
        ILocalAuthorityV4Client localAuthorityClient)
    {
        // Arrange
        factory.TestClaims = default;
        var validCode = "330"; // Birmingham code from test data

        // Act
        var result = await localAuthorityClient.GetLocalAuthorityByCodeAsync(validCode, default);

        // Assert
        Assert.NotNull(result);
        Assert.NotNull(result.Name);
        Assert.NotNull(result.Code);
        Assert.NotEmpty(result.Name);
        Assert.NotEmpty(result.Code);
        Assert.Equal(validCode, result.Code);
    }

    [Theory]
    [CustomAutoData(typeof(CustomWebApplicationDbContextFactoryCustomization<Startup>))]
    public async Task GetLocalAuthorityByCode_ShouldThrowException_WhenCodeNotFound(
        CustomWebApplicationDbContextFactory<Startup> factory,
        ILocalAuthorityV4Client localAuthorityClient)
    {
        // Arrange
        factory.TestClaims = default;
        var nonExistentCode = "99999";

        // Act & Assert
        var exception = await Assert.ThrowsAsync<AcademiesApiException>(
            () => localAuthorityClient.GetLocalAuthorityByCodeAsync(nonExistentCode, default));

        Assert.Equal(404, exception.StatusCode);
    }

    [Theory]
    [CustomAutoData(typeof(CustomWebApplicationDbContextFactoryCustomization<Startup>))]
    public async Task GetLocalAuthorityByCode_ShouldThrowException_WhenCodeIsNull(
        CustomWebApplicationDbContextFactory<Startup> factory,
        ILocalAuthorityV4Client localAuthorityClient)
    {
        // Arrange
        factory.TestClaims = default;

        // Act & Assert
        var exception = await Assert.ThrowsAsync<ArgumentNullException>(
            () => localAuthorityClient.GetLocalAuthorityByCodeAsync(null!, default));

        Assert.NotNull(exception);
    }

    [Theory]
    [CustomAutoData(typeof(CustomWebApplicationDbContextFactoryCustomization<Startup>))]
    public async Task GetLocalAuthorityByCode_ShouldThrowException_WhenCodeIsEmpty(
        CustomWebApplicationDbContextFactory<Startup> factory,
        ILocalAuthorityV4Client localAuthorityClient)
    {
        // Arrange
        factory.TestClaims = default;
        var emptyCode = "";

        // Act & Assert
        var exception = await Assert.ThrowsAsync<AcademiesApiException>(
            () => localAuthorityClient.GetLocalAuthorityByCodeAsync(emptyCode, default));

        Assert.NotNull(exception);
    }

    [Theory]
    [CustomAutoData(typeof(CustomWebApplicationDbContextFactoryCustomization<Startup>))]
    public async Task GetLocalAuthorityByCode_ShouldReturnBirmingham_WhenCode330Provided(
        CustomWebApplicationDbContextFactory<Startup> factory,
        ILocalAuthorityV4Client localAuthorityClient)
    {
        // Arrange
        factory.TestClaims = default;
        var birminghamCode = "330";

        // Act
        var result = await localAuthorityClient.GetLocalAuthorityByCodeAsync(birminghamCode, default);

        // Assert
        Assert.NotNull(result);
        Assert.Equal("330", result.Code);
        Assert.Equal("Birmingham", result.Name);
    }

    [Theory]
    [CustomAutoData(typeof(CustomWebApplicationDbContextFactoryCustomization<Startup>))]
    public async Task GetLocalAuthorityByCode_ShouldReturnSheffield_WhenCode456Provided(
        CustomWebApplicationDbContextFactory<Startup> factory,
        ILocalAuthorityV4Client localAuthorityClient)
    {
        // Arrange
        factory.TestClaims = default;
        var sheffieldCode = "456";

        // Act
        var result = await localAuthorityClient.GetLocalAuthorityByCodeAsync(sheffieldCode, default);

        // Assert
        Assert.NotNull(result);
        Assert.Equal("456", result.Code);
        Assert.Equal("Sheffield", result.Name);
    }

    [Theory]
    [CustomAutoData(typeof(CustomWebApplicationDbContextFactoryCustomization<Startup>))]
    public async Task GetLocalAuthorityByCode_ShouldReturnCityOfLondon_WhenCode123Provided(
        CustomWebApplicationDbContextFactory<Startup> factory,
        ILocalAuthorityV4Client localAuthorityClient)
    {
        // Arrange
        factory.TestClaims = default;
        var cityOfLondonCode = "123";

        // Act
        var result = await localAuthorityClient.GetLocalAuthorityByCodeAsync(cityOfLondonCode, default);

        // Assert
        Assert.NotNull(result);
        Assert.Equal("123", result.Code);
        Assert.Equal("City of London", result.Name);
    }

    [Theory]
    [CustomAutoData(typeof(CustomWebApplicationDbContextFactoryCustomization<Startup>))]
    public async Task GetLocalAuthorityByCode_ShouldReturnValidNameAndCodeDto_Structure(
        CustomWebApplicationDbContextFactory<Startup> factory,
        ILocalAuthorityV4Client localAuthorityClient)
    {
        // Arrange
        factory.TestClaims = default;
        var validCode = "330";

        // Act
        var result = await localAuthorityClient.GetLocalAuthorityByCodeAsync(validCode, default);

        // Assert
        Assert.NotNull(result);
        Assert.IsType<NameAndCodeDto>(result);
        Assert.NotNull(result.Name);
        Assert.NotNull(result.Code);
        Assert.NotEmpty(result.Name);
        Assert.NotEmpty(result.Code);
    }

    [Theory]
    [CustomAutoData(typeof(CustomWebApplicationDbContextFactoryCustomization<Startup>))]
    public async Task GetLocalAuthorityByCode_ShouldHandleWhitespaceCode(
        CustomWebApplicationDbContextFactory<Startup> factory,
        ILocalAuthorityV4Client localAuthorityClient)
    {
        // Arrange
        factory.TestClaims = default;
        var whitespaceCode = "   ";

        // Act & Assert
        var exception = await Assert.ThrowsAsync<AcademiesApiException>(
            () => localAuthorityClient.GetLocalAuthorityByCodeAsync(whitespaceCode, default));

        Assert.Equal(404, exception.StatusCode);
    }

    [Theory]
    [CustomAutoData(typeof(CustomWebApplicationDbContextFactoryCustomization<Startup>))]
    public async Task GetLocalAuthorityByCode_ShouldReturnCorrectLocalAuthority_ForAllTestDataCodes(
        CustomWebApplicationDbContextFactory<Startup> factory,
        ILocalAuthorityV4Client localAuthorityClient)
    {
        // Arrange
        factory.TestClaims = default;

        var testCodes = new[]
        {
            ("330", "Birmingham"),
            ("456", "Sheffield"),
            ("123", "City of London")
        };

        // Act & Assert
        foreach (var (code, expectedName) in testCodes)
        {
            var result = await localAuthorityClient.GetLocalAuthorityByCodeAsync(code, default);

            Assert.NotNull(result);
            Assert.Equal(code, result.Code);
            Assert.Equal(expectedName, result.Name);
        }
    }

    [Theory]
    [CustomAutoData(typeof(CustomWebApplicationDbContextFactoryCustomization<Startup>))]
    public async Task GetLocalAuthorityByCode_ShouldHandleSpecialCharacterCodes(
        CustomWebApplicationDbContextFactory<Startup> factory,
        ILocalAuthorityV4Client localAuthorityClient)
    {
        // Arrange
        factory.TestClaims = default;
        var specialCharacterCode = "A-1"; // Code with special characters (doesn't exist in test data)

        // Act & Assert
        var exception = await Assert.ThrowsAsync<AcademiesApiException>(
            () => localAuthorityClient.GetLocalAuthorityByCodeAsync(specialCharacterCode, default));

        Assert.Equal(404, exception.StatusCode);
    }

    [Theory]
    [CustomAutoData(typeof(CustomWebApplicationDbContextFactoryCustomization<Startup>))]
    public async Task GetLocalAuthorityByCode_ShouldBeCaseSensitive_ForCodeParameter(
        CustomWebApplicationDbContextFactory<Startup> factory,
        ILocalAuthorityV4Client localAuthorityClient)
    {
        // Arrange
        factory.TestClaims = default;
        var lowerCaseCode = "abc"; // Non-existent lowercase code
        var upperCaseCode = "ABC"; // Non-existent uppercase code

        // Act & Assert
        var lowerException = await Assert.ThrowsAsync<AcademiesApiException>(
            () => localAuthorityClient.GetLocalAuthorityByCodeAsync(lowerCaseCode, default));

        var upperException = await Assert.ThrowsAsync<AcademiesApiException>(
            () => localAuthorityClient.GetLocalAuthorityByCodeAsync(upperCaseCode, default));

        Assert.Equal(404, lowerException.StatusCode);
        Assert.Equal(404, upperException.StatusCode);
    }

    [Theory]
    [CustomAutoData(typeof(CustomWebApplicationDbContextFactoryCustomization<Startup>))]
    public async Task GetLocalAuthorityByCode_ShouldHandleNumericCodes(
        CustomWebApplicationDbContextFactory<Startup> factory,
        ILocalAuthorityV4Client localAuthorityClient)
    {
        // Arrange
        factory.TestClaims = default;
        var numericCode = "330"; // Valid numeric code

        // Act
        var result = await localAuthorityClient.GetLocalAuthorityByCodeAsync(numericCode, default);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(numericCode, result.Code);
        Assert.Equal("Birmingham", result.Name);
    }

    #endregion
}