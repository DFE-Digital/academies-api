using Microsoft.Extensions.Logging;
using System.Net.Http;

namespace TramsDataApi.Services
{
    public class MfspApiClient : ApiClient
    {
        public MfspApiClient(IHttpClientFactory clientFactory, ILogger<ApiClient> logger, string httpClientName = "MfspApiClient") : base(clientFactory, logger, httpClientName)
        {

        }
    }
}
