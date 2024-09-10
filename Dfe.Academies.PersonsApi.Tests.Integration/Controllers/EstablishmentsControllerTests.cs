using Dfe.Academies.PersonsApi.Tests.Integration.Mocks;
using Dfe.PersonsApi.Client;
using Dfe.PersonsApi.Client.Contracts;
using Dfe.PersonsApi.Client.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PersonsApi;
using System.Security.Claims;
using Dfe.Academies.Infrastructure;

namespace Dfe.Academies.PersonsApi.Tests.Integration.Controllers
{
    public class EstablishmentsControllerTests : IClassFixture<CustomWebApplicationFactory<Startup, MstrContext>>
    {
        private readonly CustomWebApplicationFactory<Startup, MstrContext> _factory;
        private readonly IServiceProvider _serviceProvider;

        public EstablishmentsControllerTests(CustomWebApplicationFactory<Startup, MstrContext> factory)
        {
            _factory = factory;

            _factory.TestClaims = [new Claim(ClaimTypes.Role, "API.Read")];

            var httpClient = _factory.CreateClient();

            var config = new ConfigurationBuilder()
                .AddInMemoryCollection(new Dictionary<string, string?>
                {
                    { "PersonsApiClient:BaseUrl", httpClient.BaseAddress!.ToString() }
                })
                .Build();

            var services = new ServiceCollection();
            services.AddSingleton<IConfiguration>(config);

            services.AddPersonsApiClient<IEstablishmentsClient, EstablishmentsClient>(config, httpClient);

            _serviceProvider = services.BuildServiceProvider();
        }

        [Fact]
        public async Task GetAllPersonsAssociatedWithAcademyAsync_ShouldReturnPeople_WhenAcademyExists()
        {
            // Arrange
            var establishmentClient = _serviceProvider.GetRequiredService<IEstablishmentsClient>();

            var dbcontext = _factory.GetDbContext();

            await dbcontext.Establishments.Where(x => x.SK == 1)
            .ExecuteUpdateAsync(x => x.SetProperty(p => p.URN, 22));

            // Act
            var result = await establishmentClient.GetAllPersonsAssociatedWithAcademyByUrnAsync(22);

            // Assert
            Assert.NotNull(result);
            Assert.NotEmpty(result);
            Assert.Equal(2, result.Count());
            Assert.True(result.All(x => x.Roles.Any()));
            Assert.Contains(result, x => x.FirstName == "Anna");
            Assert.Contains(result, x => x.FirstName == "John");
        }

        [Fact]
        public async Task GetAllPersonsAssociatedWithAcademyAsync_ShouldReturnEmptyList_WhenAcademyExistWithNoPeople()
        {
            // Arrange
            var establishmentClient = _serviceProvider.GetRequiredService<IEstablishmentsClient>();

            var dbcontext = _factory.GetDbContext();

            await dbcontext.Establishments.Where(x => x.SK == 2)
            .ExecuteUpdateAsync(x => x.SetProperty(p => p.URN, 33));

            // Act
            var result = await establishmentClient.GetAllPersonsAssociatedWithAcademyByUrnAsync(33);

            // Assert
            Assert.NotNull(result);
            Assert.Empty(result);
        }

        [Fact]
        public async Task GetAllPersonsAssociatedWithAcademyAsync_ShouldThrowAnException_WhenAcademyDoesntExists()
        {
            // Arrange
            var establishmentClient = _serviceProvider.GetRequiredService<IEstablishmentsClient>();

            // Act & Assert
            var exception = await Assert.ThrowsAsync<PersonsApiException>(() =>
                establishmentClient.GetAllPersonsAssociatedWithAcademyByUrnAsync(1));

            Assert.Contains("Academy not found.", exception.Message);
        }
    }
}
