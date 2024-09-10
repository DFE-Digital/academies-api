using Microsoft.AspNetCore.Authorization;
using System.Diagnostics.CodeAnalysis;

namespace Dfe.Academies.Infrastructure.Security.Authorization
{
    [ExcludeFromCodeCoverage]
    public class ApiKeyOrRoleRequirement(string rolePolicy) : IAuthorizationRequirement
    {
        public string RolePolicy { get; } = rolePolicy;
    }
}
