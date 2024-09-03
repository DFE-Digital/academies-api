using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Identity.Web;

namespace Dfe.Academies.Infrastructure.Security
{
    public static class AuthorizationExtensions
    {
        public static IServiceCollection AddCustomAuthorization(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddMicrosoftIdentityWebApi(configuration.GetSection("AzureAd"));

            services.AddAuthorization(options =>
            {
                options.DefaultPolicy = new AuthorizationPolicyBuilder()
                    .RequireAuthenticatedUser()
                    .Build();

                var roles = configuration.GetSection("Authorization:Roles").Get<string[]>();
                if (roles != null)
                {
                    foreach (var role in roles)
                    {
                        options.AddPolicy(role, policy => policy.RequireRole(role));
                    }
                }

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

            return services;
        }
    }
}
