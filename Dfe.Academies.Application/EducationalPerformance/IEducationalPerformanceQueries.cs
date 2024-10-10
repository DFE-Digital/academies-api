using DfE.CoreLibs.Contracts.Academies.V1.EducationalPerformance;

namespace Dfe.Academies.Application.EducationalPerformance
{
    public interface IEducationalPerformanceQueries
    {
        Task<List<SchoolAbsenceDataDto>> GetSchoolAbsenceDataByUrn(string urn, CancellationToken cancellationToken);
    }
}
