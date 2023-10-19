using Dfe.Academies.Contracts.Establishments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dfe.Academies.Application.Queries.Establishment
{
    public interface IEstablishmentQueries
    {
        Task<EstablishmentDto?> GetByUkprn(string ukprn, CancellationToken cancellationToken);
    }
}
