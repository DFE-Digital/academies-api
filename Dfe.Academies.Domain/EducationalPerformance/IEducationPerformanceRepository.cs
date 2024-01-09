using Dfe.Academies.Domain.Census;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Dfe.Academies.Domain.EducationalPerformance
{
    public interface IEducationPerformanceRepository
    {
        public Task<List<SchoolAbsence>> GetSchoolAbsencesByURN(int urn,  CancellationToken cancellationToken);
    }
}
