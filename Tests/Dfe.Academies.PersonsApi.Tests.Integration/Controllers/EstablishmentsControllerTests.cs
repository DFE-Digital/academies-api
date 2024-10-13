using Dfe.Academies.Infrastructure;
using Dfe.Academies.Tests.Common.Customizations;
using Dfe.PersonsApi.Client.Contracts;
using DfE.CoreLibs.Testing.AutoFixture.Attributes;
using DfE.CoreLibs.Testing.Mocks.WebApplicationFactory;
using Microsoft.EntityFrameworkCore;
using PersonsApi;
using System.Net;
using System.Security.Claims;

namespace Dfe.Academies.PersonsApi.Tests.Integration.Controllers
{
    public class EstablishmentsControllerTests
    {
        [Theory]
        [CustomAutoData(typeof(CustomWebApplicationDbContextFactoryCustomization<Startup>))]
        public async Task GetAllPersonsAssociatedWithAcademyAsync_ShouldReturnPeople_WhenAcademyExists(
            CustomWebApplicationDbContextFactory<Startup> factory,
            IEstablishmentsClient establishmentsClient)
        {
            // Arrange
            factory.TestClaims = [new Claim(ClaimTypes.Role, "API.Read")];

            var dbContext = factory.GetDbContext<MstrContext>();

            await dbContext.Establishments.Where(x => x.SK == 1)
            .ExecuteUpdateAsync(x => x.SetProperty(p => p.URN, 22));

            // Act
            var result = await establishmentsClient.GetAllPersonsAssociatedWithAcademyByUrnAsync(22);

            // Assert
            Assert.NotNull(result);
            Assert.NotEmpty(result);
            Assert.Equal(2, result.Count);
            Assert.True(result.All(x => x.Roles.Count > 0));
            Assert.Contains(result, x => x.FirstName == "Anna");
            Assert.Contains(result, x => x.FirstName == "John");
        }

        [Theory]
        [CustomAutoData(typeof(CustomWebApplicationDbContextFactoryCustomization<Startup>))]
        public async Task GetAllPersonsAssociatedWithAcademyAsync_ShouldReturnEmptyList_WhenAcademyExistWithNoPeople(
            CustomWebApplicationDbContextFactory<Startup> factory,
            IEstablishmentsClient establishmentsClient)
        {   
            // Arrange
            factory.TestClaims = [new Claim(ClaimTypes.Role, "API.Read")];

            var dbContext = factory.GetDbContext<MstrContext>();

            await dbContext.Establishments.Where(x => x.SK == 2)
            .ExecuteUpdateAsync(x => x.SetProperty(p => p.URN, 33));

            // Act
            var result = await establishmentsClient.GetAllPersonsAssociatedWithAcademyByUrnAsync(33);

            // Assert
            Assert.NotNull(result);
            Assert.Empty(result);
        }

        [Theory]
        [CustomAutoData(typeof(CustomWebApplicationDbContextFactoryCustomization<Startup>))]
        public async Task GetAllPersonsAssociatedWithAcademyAsync_ShouldThrowAnException_WhenAcademyDoesntExists(
            CustomWebApplicationDbContextFactory<Startup> factory,
            IEstablishmentsClient establishmentsClient)
        {
            // Arrange
            factory.TestClaims = [new Claim(ClaimTypes.Role, "API.Read")];

            // Act & Assert
            var exception = await Assert.ThrowsAsync<PersonsApiException>(() =>
                establishmentsClient.GetAllPersonsAssociatedWithAcademyByUrnAsync(1));

            Assert.Contains("Academy not found.", exception.Message);
        }

        [Theory]
        [CustomAutoData(typeof(CustomWebApplicationDbContextFactoryCustomization<Startup>))]
        public async Task GetGetMemberOfParliamentBySchoolUrnAsync_ShouldReturnMP_WhenSchoolExists(
            CustomWebApplicationDbContextFactory<Startup> factory,
            IEstablishmentsClient establishmentsClient)
        {
            // Arrange
            factory.TestClaims = [new Claim(ClaimTypes.Role, "API.Read")];

            // Test access to both dbContexts/ Schemas
            var dbContext = factory.GetDbContext<MstrContext>();
            var mopDbContext = factory.GetDbContext<MopContext>();

            await dbContext.Establishments.Where(x => x.SK == 1)
                .ExecuteUpdateAsync(x => x.SetProperty(p => p.URN, 44)
                     .SetProperty(p => p.ParliamentaryConstituency, "Test Constituency 44"));

            await mopDbContext.Constituencies.Where(x => x.ConstituencyName == "Test Constituency 1")
                .ExecuteUpdateAsync(x => x.SetProperty(p => p.ConstituencyName, "Test Constituency 44"));

            // Act
            var result = await establishmentsClient.GetMemberOfParliamentBySchoolUrnAsync(44);

            // Assert
            Assert.NotNull(result);
            Assert.Equal("Test Constituency 44", result.ConstituencyName);

        }

        [Theory]
        [CustomAutoData(typeof(CustomWebApplicationDbContextFactoryCustomization<Startup>))]
        public async Task GetGetMemberOfParliamentBySchoolUrnAsync_ShouldReturnNull_WhenSchoolDoesntExists(
            CustomWebApplicationDbContextFactory<Startup> factory,
            IEstablishmentsClient establishmentsClient)
        {
            // Arrange
            factory.TestClaims = [new Claim(ClaimTypes.Role, "API.Read")];

            // Act & Assert
            var exception = await Assert.ThrowsAsync<PersonsApiException>(async () =>
                await establishmentsClient.GetMemberOfParliamentBySchoolUrnAsync(111));

            Assert.Equal(HttpStatusCode.NotFound, (HttpStatusCode)exception.StatusCode);
        }
    }
}