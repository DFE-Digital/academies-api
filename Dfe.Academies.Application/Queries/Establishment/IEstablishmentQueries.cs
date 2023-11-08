using Dfe.Academies.Contracts.Establishments;
using Dfe.Academies.Contracts.Trusts;
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
        Task<EstablishmentDto?> GetByUrn(string urn, CancellationToken cancellationToken);
        Task<(List<EstablishmentDto>, int)> Search(string name, string ukPrn, string urn, CancellationToken cancellationToken);
        Task<IEnumerable<int>> GetURNsByRegion(string[] regions, CancellationToken cancellationToken);
        Task<List<EstablishmentDto>> GetByUrns(int[] Urns);
        Task<List<EstablishmentDto>> GetByTrust(string trustUkprn, CancellationToken cancellationToken);
    }
}
