using Dfe.Academies.Domain.EducationalPerformance;

namespace Dfe.Academies.Application.Common.Interfaces
{
    public interface IEducationalPerformanceRepository
    {
        public Task<List<SchoolAbsence>> GetSchoolAbsencesByURN(string urn,  CancellationToken cancellationToken);
    }
}
