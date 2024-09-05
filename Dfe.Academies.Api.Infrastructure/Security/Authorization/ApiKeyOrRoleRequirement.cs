using Microsoft.AspNetCore.Authorization;
using System.Diagnostics.CodeAnalysis;

namespace Dfe.Academies.Infrastructure.Security.Authorization
{
    [ExcludeFromCodeCoverage]
    public class ApiKeyOrRoleRequirement : IAuthorizationRequirement
    {
        public string RolePolicy { get; }

        public ApiKeyOrRoleRequirement(string rolePolicy)
        {
            RolePolicy = rolePolicy;
        }
    }
}
