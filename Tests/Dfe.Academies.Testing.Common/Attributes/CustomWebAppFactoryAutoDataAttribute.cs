using AutoFixture;
using AutoFixture.Xunit2;
using Dfe.Academies.Testing.Common.Customizations;
using Microsoft.EntityFrameworkCore;
using PersonsApi;
using System.Reflection;
using System.Security.Claims;

namespace Dfe.Academies.Testing.Common.Attributes
{
    public class CustomWebAppFactoryAutoDataAttribute<TDbContext>(string claimsCsv)
        : AutoDataAttribute(() => new Fixture().Customize(new WebAppFactoryCustomization<Startup, TDbContext>(ParseClaims(claimsCsv))))
        where TDbContext : DbContext
    {
        private static List<Claim> ParseClaims(string claimsCsv)
        {
            var claims = new List<Claim>();
            var claimPairs = claimsCsv.Split(';', StringSplitOptions.RemoveEmptyEntries);

            foreach (var claimPair in claimPairs)
            {
                var parts = claimPair.Split(':');
                if (parts.Length == 2)
                {
                    var claimType = parts[0];
                    var claimValue = parts[1];

                    var matchedClaimType = GetClaimTypeFromClaimTypes(claimType) ?? claimType;

                    claims.Add(new Claim(matchedClaimType, claimValue));
                }
            }

            return claims;
        }

        private static string? GetClaimTypeFromClaimTypes(string claimType)
        {
            var claimTypesFields = typeof(ClaimTypes).GetFields(BindingFlags.Public | BindingFlags.Static | BindingFlags.FlattenHierarchy);

            foreach (var field in claimTypesFields)
            {
                if (field.IsLiteral && !field.IsInitOnly && field.FieldType == typeof(string))
                {
                    var fieldValue = field.GetValue(null)?.ToString();
                    if (fieldValue != null && fieldValue.EndsWith(claimType, StringComparison.OrdinalIgnoreCase))
                    {
                        return fieldValue;
                    }
                }
            }

            return null;
        }
    }
}
