using Dfe.Academies.Domain.Census;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Dfe.Academies.Domain.EducationalPerformance
{
    public interface IEducationalPerformanceRepository
    {
        public Task<List<SchoolAbsence>> GetSchoolAbsencesByURN(string urn,  CancellationToken cancellationToken);
    }
}
