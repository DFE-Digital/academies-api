using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace PersonsApi.Services
{
    public abstract class ApiClient
    {
        private readonly IHttpClientFactory _clientFactory;
        private readonly ILogger<ApiClient> _logger;
        private string _httpClientName;

        protected ApiClient(IHttpClientFactory clientFactory, ILogger<ApiClient> logger, string httpClientName)
        {
            _clientFactory = clientFactory;
            _logger = logger;
            _httpClientName = httpClientName;
        }

        public async Task<T> Get<T>(string endpoint) where T : class
        {
            try
            {
                var request = new HttpRequestMessage(HttpMethod.Get, endpoint);

                var client = CreateHttpClient();

                var response = await client.SendAsync(request);

                response.EnsureSuccessStatusCode();

                var content = await response.Content.ReadAsStringAsync();

                var result = JsonConvert.DeserializeObject<T>(content);

                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw;
            }
        }

        private HttpClient CreateHttpClient()
        {
            var client = _clientFactory.CreateClient(_httpClientName);

            return client;
        }
    }
}
