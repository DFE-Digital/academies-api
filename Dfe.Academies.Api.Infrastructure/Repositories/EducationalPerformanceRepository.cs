using Dfe.Academies.Domain.EducationalPerformance;
using Microsoft.EntityFrameworkCore;

namespace Dfe.Academies.Infrastructure.Repositories
{
    public class EducationalPerformanceRepository : IEducationalPerformanceRepository
    {
        private EdperfContext _context;

        public EducationalPerformanceRepository(EdperfContext context)
        {
            _context = context;
        }
        public async Task<List<SchoolAbsence>> GetSchoolAbsencesByURN(string urn, CancellationToken cancellationToken)
        {
            var queryResult = await _context.SchoolAbsences.AsNoTracking().Where(r => r.URN == urn).ToListAsync(cancellationToken);

            if (queryResult == null)
            {
                return new ();
            }

            return queryResult;
        }
    }
}
