using PersonsApi.ResponseModels;

namespace PersonsApi.UseCases
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
 
            var keys = _configuration.GetSection("ApiKeys").Get<List<ApiUser>>();

            var key = keys?.FirstOrDefault(user => user.ApiKey.Equals(request));

            return key;
        }
    }
}