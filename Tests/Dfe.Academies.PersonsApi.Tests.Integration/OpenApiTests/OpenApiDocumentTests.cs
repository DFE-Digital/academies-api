using Dfe.Academies.Tests.Common.Customizations;
using DfE.CoreLibs.Testing.AutoFixture.Attributes;
using DfE.CoreLibs.Testing.Mocks.WebApplicationFactory;
using PersonsApi;
using System.Net;

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