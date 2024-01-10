using Dfe.Academies.Contracts.V4.Establishments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dfe.Academies.Application.EducationalPerformance
{
    public interface IEducationalPerformanceQueries
    {
        Task<List<SchoolAbsenceDataDto>> GetAchoolAbsenceDataByUrn(string urn, CancellationToken cancellationToken);
    }
}
