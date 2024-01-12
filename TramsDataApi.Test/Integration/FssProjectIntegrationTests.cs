using FluentAssertions;
using Newtonsoft.Json;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using TramsDataApi.ResponseModels;
using TramsDataApi.Test.Fixtures;
using Xunit;

namespace TramsDataApi.Test.Integration
{
    [Collection(ApiTestCollection.ApiTestCollectionName)]
    public class FssProjectIntegrationTests
    {
        private readonly HttpClient _client;

        public FssProjectIntegrationTests(ApiTestFixture fixture)
        {
            _client = fixture.Client;
        }

        [Fact]
        public async Task GetFssProject()
        {
            var response = await _client.GetAsync($"v2/fss/projects");
            response.StatusCode.Should().Be(HttpStatusCode.OK);

            var responseContent = await response.Content.ReadAsStringAsync();

            var fssProjectsResponse = JsonConvert.DeserializeObject<ApiResponseV2<FssProjectResponse>>(responseContent);

            var fssProjects = fssProjectsResponse.Data;

            fssProjects.Should().HaveCount(2);

            var firstProject = fssProjects.ElementAt(0);
            firstProject.CurrentFreeSchoolName.Should().Be("This is my free school");
            firstProject.AgeRange.Should().Be("5-11");
            firstProject.ProjectStatus.Should().Be("Open");

            var secondProject = fssProjects.ElementAt(1);
            secondProject.CurrentFreeSchoolName.Should().Be("This is another free school");
            secondProject.AgeRange.Should().Be("11-16");
            secondProject.ProjectStatus.Should().Be("Open");
        }
    }
}
