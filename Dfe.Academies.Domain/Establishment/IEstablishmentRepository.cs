using Dfe.Academies.Academisation.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dfe.Academies.Domain.Establishment
{
    public interface IEstablishmentRepository : IGenericRepository<Establishment>
    {
        Task<Establishment?> GetEstablishmentByUkprn(string ukprn, CancellationToken cancellationToken);
        Task<Establishment?> GetEstablishmentByUrn(string urn, CancellationToken cancellationToken);
    }
}
