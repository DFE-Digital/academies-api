using Dfe.Academies.Infrastructure.Models;

namespace Dfe.Academies.Application.Common.Interfaces
{
    public interface IEstablishmentQueryService
    {
        IQueryable<AcademyGovernanceQueryModel?>? GetPersonsAssociatedWithAcademyByUrn(int urn);
    }
}
