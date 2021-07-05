using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using FluentAssertions;
using Xunit;

namespace TramsDataApi.Test.Integration
{
    [Collection("Database")]
    public class HealthCheckIntegrationTests : IClassFixture<TramsDataApiFactory>
    {
        private readonly HttpClient _client;

        public HealthCheckIntegrationTests(TramsDataApiFactory fixture)
        {
            _client = fixture.CreateClient();
            _client.BaseAddress = new Uri("https://trams-api.com/");
        }
        
        [Fact] public async Task Should_Get_401_Status_When_Not_Using_Correct_Api_Key()
        {
            var httpRequestMessage = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://trams-api.com/HealthCheck"),
                Headers = { 
                    { "ApiKey", "Incorrect Key" }
                }
            };
            
            var response = await _client.SendAsync(httpRequestMessage);
            
            response.StatusCode.Should().Be(HttpStatusCode.Unauthorized);
        }

        [Fact] public async Task Should_Get_200_Status_When_Using_Correct_Api_Key()
        {
            var httpRequestMessage = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://trams-api.com/HealthCheck"),
                Headers = { 
                    { "ApiKey", "testing-api-key" }
                }
            };
            
            var response = await _client.SendAsync(httpRequestMessage);
            
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }
        
        [Fact]
        public async Task Should_Return_True_When_Running_DB_Check()
        {
            var httpRequestMessage = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://trams-api.com/check_db"),
                Headers = { 
                    { "ApiKey", "testing-api-key" }
                }
            };
                
            var response = await _client.SendAsync(httpRequestMessage);
                
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            var content = await response.Content.ReadAsStringAsync();
            content.Should().Be("true");
        }
    }
    

}