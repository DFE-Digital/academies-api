using Dfe.Academies.Domain.EducationalPerformance;
using Microsoft.EntityFrameworkCore;

namespace Dfe.Academies.Infrastructure.Repositories
{
    public class EducationPerformanceRepository : IEducationPerformanceRepository
    {
        private EdperfContext _context;

        public EducationPerformanceRepository(EdperfContext context)
        {
            _context = context;
        }
        public async Task<List<SchoolAbsence>> GetSchoolAbsencesByURN(int urn, CancellationToken cancellationToken)
        {
            var queryResult = await _context.SchoolAbsences.AsNoTracking().Where(r => r.URN == urn.ToString()).ToListAsync(cancellationToken);

            if (queryResult == null)
            {
                return new ();
            }

            return queryResult;
        }
    }
}
