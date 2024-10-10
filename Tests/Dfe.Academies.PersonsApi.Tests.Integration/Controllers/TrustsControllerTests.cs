using Dfe.Academies.Infrastructure;
using Dfe.Academies.Tests.Common.Customizations;
using Dfe.PersonsApi.Client.Contracts;
using PersonsApi;
using System.Security.Claims;
using DfE.CoreLibs.Testing.AutoFixture.Attributes;
using DfE.CoreLibs.Testing.Mocks.WebApplicationFactory;

namespace Dfe.Academies.PersonsApi.Tests.Integration.Controllers
{
    public class TrustsControllerTests
    {
        [Theory]
        [CustomAutoData(typeof(CustomWebApplicationDbContextFactoryCustomization<Startup, MstrContext>))]
        public async Task GetAllPersonsAssociatedWithTrustAsync_ShouldReturnPeople_WhenTrustExists(
            CustomWebApplicationDbContextFactory<Startup, MstrContext> factory,
            ITrustsClient trustsClient)
        {
            // Arrange
            factory.TestClaims = [new Claim(ClaimTypes.Role, "API.Read")];

            // Act
            var result = await trustsClient.GetAllPersonsAssociatedWithTrustByTrnOrUkPrnAsync("87654321");

            // Assert
            Assert.NotNull(result);
            Assert.NotEmpty(result);
            Assert.Equal(2, result.Count);
            Assert.True(result.All(x => x.Roles.Count > 0));
            Assert.Contains(result, x => x.FirstName == "John");
            Assert.Contains(result, x => x.FirstName == "Joe");
        }

        [Theory]
        [CustomAutoData(typeof(CustomWebApplicationDbContextFactoryCustomization<Startup, MstrContext>))]
        public async Task GetAllPersonsAssociatedWithTrustAsync_ShouldReturnEmptyList_WhenTrustExistWithNoPeople(
            CustomWebApplicationDbContextFactory<Startup, MstrContext> factory,
            ITrustsClient trustsClient)
        {
            // Arrange
            factory.TestClaims = [new Claim(ClaimTypes.Role, "API.Read")];

            // Act
            var result = await trustsClient.GetAllPersonsAssociatedWithTrustByTrnOrUkPrnAsync("TR00024");

            // Assert
            Assert.NotNull(result);
            Assert.Empty(result);
        }

        [Theory]
        [CustomAutoData(typeof(CustomWebApplicationDbContextFactoryCustomization<Startup, MstrContext>))]
        public async Task GetAllPersonsAssociatedWithTrustAsync_ShouldThrowAnException_WhenTrustDoesntExists(
            CustomWebApplicationDbContextFactory<Startup, MstrContext> factory,
            ITrustsClient trustsClient)
        {
            // Arrange
            factory.TestClaims = [new Claim(ClaimTypes.Role, "API.Read")];

            // Act & Assert
            var exception = await Assert.ThrowsAsync<PersonsApiException>(() =>
                trustsClient.GetAllPersonsAssociatedWithTrustByTrnOrUkPrnAsync("65432567"));

            Assert.Contains("Trust not found.", exception.Message);
        }

        [Theory]
        [CustomAutoData(typeof(CustomWebApplicationDbContextFactoryCustomization<Startup, MstrContext>))]
        public async Task GetAllPersonsAssociatedWithTrustAsync_ShouldThrowAnException_WhenInvalidIdProvided(
            CustomWebApplicationDbContextFactory<Startup, MstrContext> factory,
            ITrustsClient trustsClient)
        {
            // Arrange
            factory.TestClaims = [new Claim(ClaimTypes.Role, "API.Read")];

            // Act & Assert
            var exception = await Assert.ThrowsAsync<PersonsApiException>(() =>
                trustsClient.GetAllPersonsAssociatedWithTrustByTrnOrUkPrnAsync("invalidId"));

            Assert.Contains("The identifier must be either a valid TRN (TR{5 digits}) or a valid UKPRN (8 digits).", exception.Message);
        }
    }
}