namespace TramsDataApi.Middleware
{
    using System;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Http;
    using Microsoft.Extensions.Logging;
    using ResponseModels;
    using UseCases;

    public class ApiKeyMiddleware
    {
        private readonly RequestDelegate _next;
        private const string APIKEYNAME = "ApiKey";
        private readonly ILogger<ApiKeyMiddleware> _logger;

        public ApiKeyMiddleware(RequestDelegate next, ILogger<ApiKeyMiddleware> logger)
        {
            _next = next;
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }
        public async Task InvokeAsync(HttpContext context, IUseCase<string, ApiUser> apiKeyService)
        {
            // Bypass API Key requirement for health check route
            if (context.Request.Path == "/HealthCheck") {
                await _next(context);
                return;
            }

            if (!context.Request.Headers.TryGetValue(APIKEYNAME, out var extractedApiKey))
            {
                context.Response.StatusCode = 401;
                await context.Response.WriteAsync("Api Key was not provided.");
                return;
            }

            var user = apiKeyService.Execute(extractedApiKey);

            if (user == null)
            {
                context.Response.StatusCode = 401;
                await context.Response.WriteAsync("Unauthorized client.");
            }
            else
            {
                using (_logger.BeginScope("requester: {requester}", user.UserName))
                {
                    await _next(context);
                }
            }
        }
    }
}
