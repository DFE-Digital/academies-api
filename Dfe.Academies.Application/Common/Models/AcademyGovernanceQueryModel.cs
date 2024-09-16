using Dfe.Academies.Domain.Establishment;

namespace Dfe.Academies.Infrastructure.Models
{
    public record AcademyGovernanceQueryModel(
        EducationEstablishmentGovernance EducationEstablishmentGovernance,
        GovernanceRoleType GovernanceRoleType,
        Establishment Establishment
    );
}
