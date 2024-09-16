using Dfe.Academies.Application.Common.Models;
using Dfe.Academies.Infrastructure.Security.Authorization;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Primitives;
using System.Diagnostics.CodeAnalysis;

namespace Dfe.Academies.Infrastructure.Security
{
    /// <summary>
    /// Temporary workaround to allow API Key authentication, will be removed once all clients use Client Credentials
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class ApiKeyOrRoleHandler(IHttpContextAccessor httpContextAccessor, IConfiguration configuration)
        : AuthorizationHandler<ApiKeyOrRoleRequirement>
    {
        private const string ApiKeyHeaderName = "ApiKey";
        private readonly List<ApiUser>? _configuredApiKeys = configuration.GetSection("ApiKeys").Get<List<ApiUser>>();

        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, ApiKeyOrRoleRequirement requirement)
        {
            // Check API Key
            if (httpContextAccessor.HttpContext!.Request.Headers.TryGetValue(ApiKeyHeaderName, out StringValues apiKeyHeader))
            {

                var key = _configuredApiKeys?.Find(user => user.ApiKey!.Equals(apiKeyHeader));

                if (key != null)
                {
                    context.Succeed(requirement);
                    return Task.CompletedTask;
                }
            }

            // Check Role-based authorization
            if (context?.User != null && context.User.IsInRole(requirement.RolePolicy))
            {
                context.Succeed(requirement);
            }

            return Task.CompletedTask;
        }
    }
}
