namespace Dfe.Academies.Application.Common.Interfaces
{
    public interface IEstablishmentRepository
    {
        Task<Domain.Establishment.Establishment?> GetEstablishmentByUkprn(string ukprn, CancellationToken cancellationToken);
        Task<Domain.Establishment.Establishment?> GetEstablishmentByUrn(string urn, CancellationToken cancellationToken);
        Task<List<Domain.Establishment.Establishment>> Search(string name, string ukPrn,
         string urn, CancellationToken cancellationToken);
        Task<IEnumerable<int>> GetURNsByRegion(string[] regions, CancellationToken cancellationToken);        
        Task<List<Domain.Establishment.Establishment>> GetByTrust(long? trustId, CancellationToken cancellationToken);        
        Task<List<Domain.Establishment.Establishment>> GetByUrns(int[] Urns, CancellationToken cancellationToken);
        Task<List<Domain.Establishment.Establishment>> GetByUkprns(string[] Urns, CancellationToken cancellationToken);
        Task<Domain.Establishment.Establishment?> GetPersonsAssociatedWithAcademyByUrnAsync(int urn, CancellationToken cancellationToken);
    }
}
