using Dfe.Academies.Application.Common.Models;
using Dfe.Academies.Infrastructure.Security.Authorization;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Primitives;

namespace Dfe.Academies.Infrastructure.Security
{
    /// <summary>
    /// Temporary workaround to allow API Key authentication, will be removed once all clients use Client Credentials
    /// </summary>
    public class ApiKeyOrRoleHandler : AuthorizationHandler<ApiKeyOrRoleRequirement>
    {
        private const string ApiKeyHeaderName = "ApiKey";
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly List<ApiUser>? _configuredApiKeys;

        public ApiKeyOrRoleHandler(IHttpContextAccessor httpContextAccessor, IConfiguration configuration)
        {
            _httpContextAccessor = httpContextAccessor;
            _configuredApiKeys = configuration.GetSection("ApiKeys").Get<List<ApiUser>>();
        }

        protected override async Task HandleRequirementAsync(AuthorizationHandlerContext context, ApiKeyOrRoleRequirement requirement)
        {
            // Check API Key
            if (_httpContextAccessor.HttpContext.Request.Headers.TryGetValue(ApiKeyHeaderName, out StringValues apiKeyHeader))
            {

                var key = _configuredApiKeys?.FirstOrDefault(user => user.ApiKey.Equals(apiKeyHeader));

                if (key != null)
                {
                    context.Succeed(requirement);
                    return;
                }
            }

            // Check Role-based authorization
            if (context.User != null && context.User.IsInRole(requirement.RolePolicy))
            {
                context.Succeed(requirement);
            }
        }
    }
}
