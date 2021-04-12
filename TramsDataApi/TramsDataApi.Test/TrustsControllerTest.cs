using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using TramsDataApi.DatabaseModels;
using FluentAssertions;
using Newtonsoft.Json;
using Xunit;

namespace TramsDataApi.Test
{
    public class TrustsControllerTest : IClassFixture<TramsDataApiFactory>
    {
        private readonly HttpClient _client;

        public TrustsControllerTest(TramsDataApiFactory fixture)
        {
            _client = fixture.CreateClient();
            _client.BaseAddress = new Uri("https://trams-api.com/");
        }

        [Fact]
        public async Task Should_Return_Empty_List_When_No_Trusts_Exist()
        {
            var httpRequestMessage = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://trams-api.com/Trusts"),
                Headers = { 
                    { "ApiKey", "testing-api-key" }
                }
            };
            
            var response = await _client.SendAsync(httpRequestMessage);
            var jsonString = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<List<Group>>(jsonString);

            response.StatusCode.Should().Be(HttpStatusCode.OK);
            result.Should().Equal(new List<Group>());
        }
    }
}