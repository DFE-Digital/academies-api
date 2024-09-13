using Dfe.Academies.Infrastructure;
using Dfe.Academies.Testing.Common.Attributes;
using Dfe.Academies.Testing.Common.Mocks;
using Dfe.PersonsApi.Client.Contracts;
using Microsoft.EntityFrameworkCore;
using PersonsApi;
using System.Net;

namespace Dfe.Academies.PersonsApi.Tests.Integration.Controllers
{
    public class ConstituenciesControllerTests
    {
        [Theory]
        [CustomWebAppFactoryAutoData<MopContext>("Role:API.Read")]
        public async Task GetMemberOfParliamentByConstituencyAsync_ShouldReturnMp_WhenConstituencyExists(
            CustomWebApplicationFactory<Startup, MopContext> factory,
            IConstituenciesClient constituenciesClient)
        {
            // Arrange
            var dbContext = factory.GetDbContext();

            await dbContext.Constituencies
                .Where(x => x.ConstituencyName == "Test Constituency 1")
                .ExecuteUpdateAsync(x => x.SetProperty(p => p.ConstituencyName, "NewConstituencyName"));

            var constituencyName = Uri.EscapeDataString("NewConstituencyName");

            // Act
            var result = await constituenciesClient.GetMemberOfParliamentByConstituencyAsync(constituencyName);

            // Assert
            Assert.NotNull(result);
            Assert.Equal("NewConstituencyName", result.ConstituencyName);
        }

        [Theory]
        [CustomWebAppFactoryAutoData<MopContext>("Role:API.Read")]
        public async Task GetMemberOfParliamentByConstituencyAsync_ShouldReturnNotFound_WhenConstituencyDoesNotExist(
        CustomWebApplicationFactory<Startup, MopContext> factory,
            IConstituenciesClient constituenciesClient)
        {
            // Arrange
            var constituencyName = Uri.EscapeDataString("NonExistentConstituency");

            // Act & Assert
            var exception = await Assert.ThrowsAsync<PersonsApiException>(async () =>
                await constituenciesClient.GetMemberOfParliamentByConstituencyAsync(constituencyName));

            Assert.Equal(HttpStatusCode.NotFound, (HttpStatusCode)exception.StatusCode);
        }

        [Theory]
        [CustomWebAppFactoryAutoData<MopContext>("Role:API.Read")]
        public async Task GetMemberOfParliamentByConstituenciesAsync_ShouldReturnMps_WhenConstituenciesExists(
        CustomWebApplicationFactory<Startup, MopContext> factory,
            IConstituenciesClient constituenciesClient)
        {

            var dbcontext = factory.GetDbContext();

            await dbcontext.Constituencies.Where(x => x.ConstituencyName == "Test Constituency 1")
                .ExecuteUpdateAsync(x => x.SetProperty(p => p.ConstituencyName, "NewConstituencyName"));

            var constituencyName = Uri.EscapeDataString("NewConstituencyName");

            // Act
            var result = await constituenciesClient.GetMembersOfParliamentByConstituenciesAsync(
                new GetMembersOfParliamentByConstituenciesQuery() { ConstituencyNames = [constituencyName] });

            // Assert
            Assert.NotNull(result);
            Assert.NotEmpty(result);
            Assert.Single(result);
        }

        [Theory]
        [CustomWebAppFactoryAutoData<MopContext>("Role:API.Read")]
        public async Task GetMemberOfParliamentByConstituenciesAsync_ShouldReturnEmpty_WhenConstituenciesDontExists(
        CustomWebApplicationFactory<Startup, MopContext> factory,
            IConstituenciesClient constituenciesClient)
        {
            // Act
            var result = await constituenciesClient.GetMembersOfParliamentByConstituenciesAsync(
                new GetMembersOfParliamentByConstituenciesQuery() { ConstituencyNames = ["constituencyName"] });

            // Assert
            Assert.NotNull(result);
            Assert.Empty(result);
        }

        [Theory]
        [CustomWebAppFactoryAutoData<MopContext>("Role:API.Read")]
        public async Task GetMemberOfParliamentByConstituenciesAsync_ShouldThrowAnException_WhenConstituenciesNotProvided(
        CustomWebApplicationFactory<Startup, MopContext> factory,
            IConstituenciesClient constituenciesClient)
        {
            // Act & Assert
            var exception = await Assert.ThrowsAsync<PersonsApiException>(async () =>
                await constituenciesClient.GetMembersOfParliamentByConstituenciesAsync(
                    new GetMembersOfParliamentByConstituenciesQuery() { ConstituencyNames = [] }));

            Assert.Equal(HttpStatusCode.BadRequest, (HttpStatusCode)exception.StatusCode);
        }
    }
}
