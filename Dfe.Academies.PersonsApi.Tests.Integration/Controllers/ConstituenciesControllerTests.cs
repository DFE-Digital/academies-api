using Dfe.Academies.PersonsApi.Tests.Integration.Mocks;
using Microsoft.EntityFrameworkCore;
using PersonsApi;
using System.Net;

namespace Dfe.Academies.PersonsApi.Tests.Integration.Controllers
{
    public class When_Fetching_Mp_By_Constituency : IClassFixture<CustomWebApplicationFactory<Startup>>
    {
        private readonly CustomWebApplicationFactory<Startup> _factory;

        public When_Fetching_Mp_By_Constituency(CustomWebApplicationFactory<Startup> factory)
        {
            _factory = factory;
        }

        [Fact]
        public async Task it_should_return_mp_when_constituency_exist()
        {
            var client = _factory.CreateClient();

            var dbcontext = _factory.GetDbContext();

            await dbcontext.Constituencies.Where(x => x.ConstituencyName == "Test Constituency 1")
                .ExecuteUpdateAsync(x => x.SetProperty(p => p.ConstituencyName, "NewConstituencyName"));

            var constituencyName = Uri.EscapeDataString("NewConstituencyName");

            var response = await client.GetAsync($"v1/Constituencies/{constituencyName}/mp");

            var content = await response.Content.ReadAsStringAsync();

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public async Task it_should_return_notfound_when_constituency_doesnt_exist()
        {
            var client = _factory.CreateClient();

            var response = await client.GetAsync($"v1/Constituencies/test/mp");

            var content = await response.Content.ReadAsStringAsync();

            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
        }
    }
}
