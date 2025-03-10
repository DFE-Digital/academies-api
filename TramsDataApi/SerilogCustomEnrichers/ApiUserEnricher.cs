using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Serilog.Core;
using Serilog.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using TramsDataApi.ResponseModels;
using TramsDataApi.UseCases;

namespace TramsDataApi.SerilogCustomEnrichers
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
                User = user?.UserName ?? "Unknown"

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
