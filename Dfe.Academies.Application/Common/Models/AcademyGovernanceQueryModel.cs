using Dfe.Academies.Domain.Establishment;

namespace Dfe.Academies.Application.Common.Models
{
    public record AcademyGovernanceQueryModel(
        EducationEstablishmentGovernance EducationEstablishmentGovernance,
        GovernanceRoleType GovernanceRoleType,
        Domain.Establishment.Establishment Establishment
    );
}
