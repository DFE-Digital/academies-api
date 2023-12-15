using Dfe.Academies.Academisation.Domain.SeedWork;

namespace Dfe.Academies.Domain.Establishment
{
    public interface IEstablishmentRepository
    {
        Task<Establishment?> GetEstablishmentByUkprn(string ukprn, CancellationToken cancellationToken);
        Task<Establishment?> GetEstablishmentByUrn(string urn, CancellationToken cancellationToken);
        Task<List<Establishment>> Search(string name, string ukPrn,
         string urn, CancellationToken cancellationToken);
        Task<IEnumerable<int>> GetURNsByRegion(string[] regions, CancellationToken cancellationToken);        
        Task<List<Establishment>> GetByTrust(long? trustId, CancellationToken cancellationToken);        
        Task<List<Establishment>> GetByUrns(int[] Urns, CancellationToken cancellationToken);
    }
}
