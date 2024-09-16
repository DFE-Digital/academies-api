using Dfe.Academies.Domain.EducationalPerformance;

namespace Dfe.Academies.Domain.Interfaces.Repositories
{
    public interface IEducationalPerformanceRepository
    {
        public Task<List<SchoolAbsence>> GetSchoolAbsencesByURN(string urn,  CancellationToken cancellationToken);
    }
}
