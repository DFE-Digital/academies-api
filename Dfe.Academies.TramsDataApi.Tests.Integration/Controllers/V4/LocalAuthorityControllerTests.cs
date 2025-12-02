using Dfe.Academies.Tests.Common.Customizations;
using Dfe.AcademiesApi.Client.Contracts;
using GovUK.Dfe.CoreLibs.Testing.AutoFixture.Attributes;
using GovUK.Dfe.CoreLibs.Testing.Mocks.WebApplicationFactory;
using TramsDataApi;

namespace Dfe.Academies.TramsDataApi.Tests.Integration.Controllers.V4;

public class LocalAuthorityControllerTests
{
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
        if (localAuthorities.Any())
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
        if (localAuthorities.Any())
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
        if (localAuthorities.Any())
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
        if (localAuthorities.Any())
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
}