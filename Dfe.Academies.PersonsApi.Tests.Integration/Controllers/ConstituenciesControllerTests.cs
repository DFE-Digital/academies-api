using Dfe.Academies.Academisation.Data;
using Dfe.Academies.PersonsApi.Tests.Integration.Mocks;
using Dfe.PersonsApi.Client;
using Dfe.PersonsApi.Client.Contracts;
using Dfe.PersonsApi.Client.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PersonsApi;
using System.Net;
using System.Security.Claims;

namespace Dfe.Academies.PersonsApi.Tests.Integration.Controllers
{
    public class ConstituenciesControllerTests : IClassFixture<CustomWebApplicationFactory<Startup, MopContext>>
    {
        private readonly CustomWebApplicationFactory<Startup, MopContext> _factory;
        private readonly IServiceProvider _serviceProvider;

        public ConstituenciesControllerTests(CustomWebApplicationFactory<Startup, MopContext> factory)
        {
            _factory = factory;

            _factory.TestClaims = new List<Claim>
            {
                new Claim(ClaimTypes.Role, "API.Read")
            };

            var httpClient = _factory.CreateClient();

            var config = new ConfigurationBuilder()
                .AddInMemoryCollection(new Dictionary<string, string?>
                {
                    { "PersonsApiClient:BaseUrl", httpClient.BaseAddress!.ToString() }
                })
                .Build();

            var services = new ServiceCollection();
            services.AddSingleton<IConfiguration>(config);

            services.AddPersonsApiClient<IConstituenciesClient, ConstituenciesClient>(config, httpClient);

            _serviceProvider = services.BuildServiceProvider();
        }

        [Fact]
        public async Task GetMemberOfParliamentByConstituencyAsync_ShouldReturnMp_WhenConstituencyExists()
        {
            // Arrange
            var constituenciesClient = _serviceProvider.GetRequiredService<IConstituenciesClient>();

            var dbcontext = _factory.GetDbContext();

            await dbcontext.Constituencies.Where(x => x.ConstituencyName == "Test Constituency 1")
                .ExecuteUpdateAsync(x => x.SetProperty(p => p.ConstituencyName, "NewConstituencyName"));

            var constituencyName = Uri.EscapeDataString("NewConstituencyName");

            // Act
            var result = await constituenciesClient.GetMemberOfParliamentByConstituencyAsync(constituencyName);

            // Assert
            Assert.NotNull(result);
            Assert.Equal("NewConstituencyName", result.ConstituencyName);
        }

        [Fact]
        public async Task GetMemberOfParliamentByConstituencyAsync_ShouldReturnNotFound_WhenConstituencyDoesNotExist()
        {
            // Arrange
            var constituenciesClient = _serviceProvider.GetRequiredService<IConstituenciesClient>();

            var constituencyName = Uri.EscapeDataString("NonExistentConstituency");

            // Act & Assert
            var exception = await Assert.ThrowsAsync<PersonsApiException>(async () =>
                await constituenciesClient.GetMemberOfParliamentByConstituencyAsync(constituencyName));

            Assert.Equal(HttpStatusCode.NotFound, (HttpStatusCode)exception.StatusCode);
        }

    }

}
