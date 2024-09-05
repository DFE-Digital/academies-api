using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Identity.Web;

namespace Dfe.Academies.Infrastructure.Security.Authorization
{
    public static class AuthorizationExtensions
    {
        public static IServiceCollection AddCustomAuthorization(this IServiceCollection services, IConfiguration configuration)
        {
            // Add both Azure AD (JWT) and API Key authentication mechanisms
            services.AddAuthentication(options =>
            {
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddMicrosoftIdentityWebApi(configuration.GetSection("AzureAd"));

            services.AddAuthorization(options =>
            {
                var roles = configuration.GetSection("Authorization:Roles").Get<string[]>();
                if (roles != null)
                {
                    foreach (var role in roles)
                    {
                        options.AddPolicy(role, policy =>
                        {
                            policy.Requirements.Add(new ApiKeyOrRoleRequirement(role));
                        });
                    }
                }

                // Add claim-based policies
                var claims = configuration.GetSection("Authorization:Claims").Get<Dictionary<string, string>>();
                if (claims != null)
                {
                    foreach (var claim in claims)
                    {
                        options.AddPolicy($"{claim.Key}", policy =>
                            policy.RequireClaim(claim.Key, claim.Value));
                    }
                }
            });

            services.AddSingleton<IAuthorizationHandler, ApiKeyOrRoleHandler>();

            return services;
        }
    }
}
