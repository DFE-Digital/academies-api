using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using FluentAssertions;
using Newtonsoft.Json;
using TramsDataApi.DatabaseModels;
using Xunit;
using Xunit.Abstractions;

namespace TramsDataApi.Test
{
    public class TrustsControllerTests : IClassFixture<TramsDataApiFactory>
    {
        private readonly ITestOutputHelper _testOutputHelper;
        private readonly HttpClient _client;

        public TrustsControllerTests(TramsDataApiFactory fixture, ITestOutputHelper testOutputHelper)
        {
            _testOutputHelper = testOutputHelper;
            _client = fixture.CreateClient();
            _client.BaseAddress = new Uri("https://trams-api.com/");
        }

        [Fact]
        public async Task Should_Get_All_Trusts()
        {
            var httpRequestMessage = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://trams-api.com/Trusts"),
                Headers =
                {
                    {"ApiKey", "testing-api-key"}
                }
            };
            var response = await _client.SendAsync(httpRequestMessage);
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            var responseMessage = response.Content.ReadAsStringAsync().Result;
            var trusts = JsonConvert.DeserializeObject<List<Group>>(responseMessage);
            trusts.Count.Should().Be(0);
        }
    }
}