using Dfe.Academies.Domain.Establishment;
using Dfe.Academies.Domain.Trust;

namespace Dfe.Academies.Infrastructure.Models
{
    public record TrustGovernanceQueryModel(
        Trust Trust,
        GovernanceRoleType GovernanceRoleType,
        TrustGovernance TrustGovernance
    );
}
