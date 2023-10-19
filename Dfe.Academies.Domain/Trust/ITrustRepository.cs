using Dfe.Academies.Academisation.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dfe.Academies.Domain.Trust
{
    public interface ITrustRepository : IGenericRepository<Trust>
    {
        Task<Trust?> GetTrustByUkprn(string ukprn, CancellationToken cancellationToken);
    }
}
