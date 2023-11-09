﻿using Dfe.Academies.Contracts.V4.Establishments;

namespace Dfe.Academies.Application.Queries.Establishment
{
    public interface IEstablishmentQueries
    {
        Task<EstablishmentDto?> GetByUkprn(string ukprn, CancellationToken cancellationToken);
        Task<EstablishmentDto?> GetByUrn(string urn, CancellationToken cancellationToken);
        Task<(List<EstablishmentDto>, int)> Search(string name, string ukPrn, string urn, CancellationToken cancellationToken);
        Task<IEnumerable<int>> GetURNsByRegion(string[] regions, CancellationToken cancellationToken);
        Task<List<EstablishmentDto>> GetByUrns(int[] Urns, CancellationToken cancellationToken);       
        Task<List<EstablishmentDto>> GetByTrust(string trustUkprn, CancellationToken cancellationToken);
    }
}
