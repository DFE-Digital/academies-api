using Dfe.Academies.Infrastructure;
using Dfe.Academies.Testing.Common.Attributes;
using Dfe.Academies.Testing.Common.Customizations;
using Dfe.Academies.Testing.Common.Mocks;
using Dfe.PersonsApi.Client.Contracts;
using Microsoft.EntityFrameworkCore;
using PersonsApi;
using System.Security.Claims;

namespace Dfe.Academies.PersonsApi.Tests.Integration.Controllers
{
    public class EstablishmentsControllerTests
    {
        [Theory]
        [CustomAutoData(typeof(CustomWebApplicationDbContextFactoryCustomization<Startup, MstrContext>))]
        public async Task GetAllPersonsAssociatedWithAcademyAsync_ShouldReturnPeople_WhenAcademyExists(
            CustomWebApplicationDbContextFactory<Startup, MstrContext> factory,
            IEstablishmentsClient establishmentsClient)
        {
            // Arrange
            factory.TestClaims = [new Claim(ClaimTypes.Role, "API.Read")];

            var dbContext = factory.GetDbContext();

            await dbContext.Establishments.Where(x => x.SK == 1)
            .ExecuteUpdateAsync(x => x.SetProperty(p => p.URN, 22));

            // Act
            var result = await establishmentsClient.GetAllPersonsAssociatedWithAcademyByUrnAsync(22);

            // Assert
            Assert.NotNull(result);
            Assert.NotEmpty(result);
            Assert.Equal(2, result.Count());
            Assert.True(result.All(x => x.Roles.Any()));
            Assert.Contains(result, x => x.FirstName == "Anna");
            Assert.Contains(result, x => x.FirstName == "John");
        }

        [Theory]
        [CustomAutoData(typeof(CustomWebApplicationDbContextFactoryCustomization<Startup, MstrContext>))]
        public async Task GetAllPersonsAssociatedWithAcademyAsync_ShouldReturnEmptyList_WhenAcademyExistWithNoPeople(
            CustomWebApplicationDbContextFactory<Startup, MstrContext> factory,
            IEstablishmentsClient establishmentsClient)
        {   
            // Arrange
            factory.TestClaims = [new Claim(ClaimTypes.Role, "API.Read")];

            var dbContext = factory.GetDbContext();

            await dbContext.Establishments.Where(x => x.SK == 2)
            .ExecuteUpdateAsync(x => x.SetProperty(p => p.URN, 33));

            // Act
            var result = await establishmentsClient.GetAllPersonsAssociatedWithAcademyByUrnAsync(33);

            // Assert
            Assert.NotNull(result);
            Assert.Empty(result);
        }

        [Theory]
        [CustomAutoData(typeof(CustomWebApplicationDbContextFactoryCustomization<Startup, MstrContext>))]
        public async Task GetAllPersonsAssociatedWithAcademyAsync_ShouldThrowAnException_WhenAcademyDoesntExists(
            CustomWebApplicationDbContextFactory<Startup, MstrContext> factory,
            IEstablishmentsClient establishmentsClient)
        {
            // Arrange
            factory.TestClaims = [new Claim(ClaimTypes.Role, "API.Read")];

            // Act & Assert
            var exception = await Assert.ThrowsAsync<PersonsApiException>(() =>
                establishmentsClient.GetAllPersonsAssociatedWithAcademyByUrnAsync(1));

            Assert.Contains("Academy not found.", exception.Message);
        }
    }
}