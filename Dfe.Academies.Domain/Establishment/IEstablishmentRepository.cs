﻿using Dfe.Academies.Academisation.Domain.SeedWork;

namespace Dfe.Academies.Domain.Establishment
{
    public interface IEstablishmentRepository : IGenericRepository<Establishment>
    {
        Task<Establishment?> GetEstablishmentByUkprn(string ukprn, CancellationToken cancellationToken);
        Task<Establishment?> GetEstablishmentByUrn(string urn, CancellationToken cancellationToken);
        Task<List<Establishment>> Search(string name, string ukPrn,
         string urn, CancellationToken cancellationToken);
        Task<IEnumerable<int>> GetURNsByRegion(ICollection<string> regions, CancellationToken cancellationToken);
        Task<List<Establishment>> GetByUrns(int[] Urns);
    }
}