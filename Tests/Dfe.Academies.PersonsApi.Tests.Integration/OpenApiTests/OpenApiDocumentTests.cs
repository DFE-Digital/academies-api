using Dfe.Academies.Testing.Common.Attributes;
using Dfe.Academies.Testing.Common.Customizations;
using Dfe.Academies.Testing.Common.Mocks;
using PersonsApi;
using System.Net;

namespace Dfe.Academies.PersonsApi.Tests.Integration.OpenApiTests;

public class OpenApiDocumentTests
{
    [Theory]
    [CustomAutoData(typeof(CustomWebApplicationFactoryCustomization<Startup>))]
    public async Task SwaggerEndpoint_ReturnsSuccessAndCorrectContentType(
        CustomWebApplicationFactory<Startup> factory,
        HttpClient client)
    {
        var response = await client.GetAsync("/swagger/v1/swagger.json");

        response.EnsureSuccessStatusCode();

        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }
}