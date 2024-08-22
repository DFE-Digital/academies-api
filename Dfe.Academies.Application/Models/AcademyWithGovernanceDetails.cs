using Dfe.Academies.Domain.Establishment;

namespace Dfe.Academies.Application.Models
{
    public record AcademyWithGovernanceDetails(
        EducationEstablishmentGovernance EducationEstablishmentGovernance,
        GovernanceRoleType GovernanceRoleType,
        Domain.Establishment.Establishment Establishment
    );
}
