using PersonsApi;
using System.Net;
using Dfe.Academies.Tests.Common.Attributes;
using Dfe.Academies.Tests.Common.Customizations;
using Dfe.Academies.Tests.Common.Mocks;

namespace Dfe.Academies.PersonsApi.Tests.Integration.OpenApiTests;

public class OpenApiDocumentTests
{
#pragma warning disable xUnit1026

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
#pragma warning restore xUnit1026
}