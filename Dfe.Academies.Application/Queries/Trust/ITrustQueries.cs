using Dfe.Academies.Contracts.Trusts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dfe.Academies.Application.Queries.Trust
{
    public interface ITrustQueries
    {
        Task<TrustDto?> GetByUkprn(string ukprn, CancellationToken cancellationToken);
    }
}
