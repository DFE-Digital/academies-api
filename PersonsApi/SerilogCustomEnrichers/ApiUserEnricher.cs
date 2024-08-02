using Serilog.Core;
using Serilog.Events;
using PersonsApi.ResponseModels;
using PersonsApi.UseCases;

namespace PersonsApi.SerilogCustomEnrichers
{
    public class ApiUserEnricher : ILogEventEnricher
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IUseCase<string, ApiUser> _apiKeyService;

        public ApiUserEnricher(IHttpContextAccessor httpContextAccessor, IUseCase<string, ApiUser> apiKeyService)
        {
            _httpContextAccessor = httpContextAccessor;
            _apiKeyService = apiKeyService;
        }

        public void Enrich(LogEvent logEvent, ILogEventPropertyFactory propertyFactory)
        {
            var httpContext = _httpContextAccessor.HttpContext;

            if (httpContext is null)
            {
                return;
            }

            ApiUser user = null;

            if (httpContext.Request.Headers.TryGetValue("ApiKey", out var apiKey))
            {
                user = _apiKeyService.Execute(apiKey);
            }

            var httpContextModel = new HttpContextModel
            {
                Method = httpContext.Request.Method,
                User = user?.UserName ?? "Unknow or not applicable"

            };

            logEvent.AddPropertyIfAbsent(propertyFactory.CreateProperty("ApiUser", httpContextModel.User, true));
        }
    }

    public class HttpContextModel
    {
        public string Method { get; init; }

        public string User { get; init; }
    }
}
