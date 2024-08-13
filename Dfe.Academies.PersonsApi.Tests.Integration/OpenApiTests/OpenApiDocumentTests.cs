using Dfe.Academies.PersonsApi.Tests.Integration.Mocks;
using PersonsApi;
using System.Net;

namespace Dfe.Academies.PersonsApi.Tests.Integration.OpenApiTests;

public class OpenApiDocumentTests : IClassFixture<CustomWebApplicationFactory<Startup>>
{
    private readonly HttpClient _client;

    public OpenApiDocumentTests(CustomWebApplicationFactory<Startup> factory)
    {
        _client = factory.CreateClient();
    }

    [Fact]
    public async Task SwaggerEndpoint_ReturnsSuccessAndCorrectContentType()
    {
        var response = await _client.GetAsync("/swagger/v1/swagger.json");

        response.EnsureSuccessStatusCode();

        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }
}