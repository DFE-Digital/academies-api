using System.Linq;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using TramsDataApi.ResponseModels;

namespace TramsDataApi.UseCases
{
    public class ApiKeyService : IUseCase<string, ApiUser>
    {
        private readonly IConfiguration _configuration;

        public ApiKeyService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public ApiUser Execute(string request)
        {
 
            var key = _configuration
                .GetSection("ApiKeys")
                .AsEnumerable()
                .Where(k => k.Value != null)
                .Select(k => JsonConvert.DeserializeObject<ApiUser>(k.Value))
                .FirstOrDefault(user => user.ApiKey.Equals(request));

            return key;
        }
    }
}