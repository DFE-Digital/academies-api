using Dfe.Academies.Application.Common.Interfaces;
using Dfe.Academies.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace Dfe.Academies.Infrastructure.QueryServices
{
    internal class EstablishmentQueryService(MstrContext context) : IEstablishmentQueryService
    {
        public IQueryable<AcademyGovernanceQueryModel?>? GetPersonsAssociatedWithAcademyByUrn(int urn)
        {
            var establishmentExists = context.Establishments.AsNoTracking().Any(e => e.URN == urn);
            if (!establishmentExists)
            {
                return null;
            }

            var query = from ee in context.Establishments.AsNoTracking()
                join eeg in context.EducationEstablishmentGovernances.AsNoTracking()
                    on ee.SK equals eeg.EducationEstablishmentId
                join grt in context.GovernanceRoleTypes.AsNoTracking()
                    on eeg.GovernanceRoleTypeId equals grt.SK
                where ee.URN == urn
                select new AcademyGovernanceQueryModel(eeg, grt, ee);

            return query;
        }
    }
}
