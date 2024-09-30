using Dfe.Academies.Domain.Establishment;

namespace Dfe.Academies.Application.Common.Models
{
    public record TrustGovernanceQueryModel(
        Domain.Trust.Trust Trust,
        GovernanceRoleType GovernanceRoleType,
        Domain.Trust.TrustGovernance TrustGovernance
    );
}
