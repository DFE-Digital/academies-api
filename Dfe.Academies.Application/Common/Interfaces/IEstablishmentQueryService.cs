using Dfe.Academies.Application.Common.Models;

namespace Dfe.Academies.Application.Common.Interfaces
{
    public interface IEstablishmentQueryService
    {
        IQueryable<AcademyGovernanceQueryModel?>? GetPersonsAssociatedWithAcademyByUrn(int urn);
    }
}
