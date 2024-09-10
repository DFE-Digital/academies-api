using Dfe.Academies.PersonsApi.Tests.Integration.Mocks;
using PersonsApi;
using System.Net;
using Dfe.Academies.Infrastructure;

namespace Dfe.Academies.PersonsApi.Tests.Integration.OpenApiTests;

public class OpenApiDocumentTests(CustomWebApplicationFactory<Startup, MopContext> factory)
    : IClassFixture<CustomWebApplicationFactory<Startup, MopContext>>
{
    private readonly HttpClient _client = factory.CreateClient();

    [Fact]
    public async Task SwaggerEndpoint_ReturnsSuccessAndCorrectContentType()
    {
        var response = await _client.GetAsync("/swagger/v1/swagger.json");

        response.EnsureSuccessStatusCode();

        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }
}