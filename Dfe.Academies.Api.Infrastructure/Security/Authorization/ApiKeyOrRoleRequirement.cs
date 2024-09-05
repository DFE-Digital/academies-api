using Microsoft.AspNetCore.Authorization;

namespace Dfe.Academies.Infrastructure.Security.Authorization
{
    public class ApiKeyOrRoleRequirement : IAuthorizationRequirement
    {
        public string RolePolicy { get; }

        public ApiKeyOrRoleRequirement(string rolePolicy)
        {
            RolePolicy = rolePolicy;
        }
    }
}
