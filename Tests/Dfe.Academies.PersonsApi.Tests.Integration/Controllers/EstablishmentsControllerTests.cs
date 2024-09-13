using Dfe.Academies.Infrastructure;
using Dfe.Academies.Testing.Common.Attributes;
using Dfe.Academies.Testing.Common.Mocks;
using Dfe.PersonsApi.Client.Contracts;
using Microsoft.EntityFrameworkCore;
using PersonsApi;

namespace Dfe.Academies.PersonsApi.Tests.Integration.Controllers
{
    public class EstablishmentsControllerTests
    {
        [Theory]
        [CustomWebAppFactoryAutoData<MstrContext>("Role:API.Read")]
        public async Task GetAllPersonsAssociatedWithAcademyAsync_ShouldReturnPeople_WhenAcademyExists(
            CustomWebApplicationFactory<Startup, MstrContext> factory,
            IEstablishmentsClient establishmentsClient)
        {
            // Arrange
            var dbcontext = factory.GetDbContext();

            await dbcontext.Establishments.Where(x => x.SK == 1)
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
        [CustomWebAppFactoryAutoData<MstrContext>("Role:API.Read")]
        public async Task GetAllPersonsAssociatedWithAcademyAsync_ShouldReturnEmptyList_WhenAcademyExistWithNoPeople(
        CustomWebApplicationFactory<Startup, MstrContext> factory,
            IEstablishmentsClient establishmentsClient)

        {   // Arrange
            var dbcontext = factory.GetDbContext();

            await dbcontext.Establishments.Where(x => x.SK == 2)
            .ExecuteUpdateAsync(x => x.SetProperty(p => p.URN, 33));

            // Act
            var result = await establishmentsClient.GetAllPersonsAssociatedWithAcademyByUrnAsync(33);

            // Assert
            Assert.NotNull(result);
            Assert.Empty(result);
        }

        [Theory]
        [CustomWebAppFactoryAutoData<MstrContext>("Role:API.Read")]
        public async Task GetAllPersonsAssociatedWithAcademyAsync_ShouldThrowAnException_WhenAcademyDoesntExists(
        CustomWebApplicationFactory<Startup, MstrContext> factory,
            IEstablishmentsClient establishmentsClient)
        {

            // Act & Assert
            var exception = await Assert.ThrowsAsync<PersonsApiException>(() =>
                establishmentsClient.GetAllPersonsAssociatedWithAcademyByUrnAsync(1));

            Assert.Contains("Academy not found.", exception.Message);
        }
    }
}