using Dfe.Academies.Domain.Establishment;

namespace Dfe.Academies.Domain.Interfaces.Repositories
{
    public interface IEstablishmentRepository
    {
        Task<Establishment.Establishment?> GetEstablishmentByUkprn(string ukprn, CancellationToken cancellationToken);
        Task<Establishment.Establishment?> GetEstablishmentByUrn(string urn, CancellationToken cancellationToken);
        Task<List<Establishment.Establishment>> Search(string name, string ukPrn,
         string urn, bool? excludeClosed, bool? matchAny, CancellationToken cancellationToken);
        Task<IEnumerable<int>> GetURNsByRegion(string[] regions, CancellationToken cancellationToken);
        Task<List<Establishment.Establishment>> GetByTrust(long? trustId, CancellationToken cancellationToken);
        Task<List<Establishment.Establishment>> GetByUrns(int[] Urns, CancellationToken cancellationToken);
        Task<List<Establishment.Establishment>> GetByUkprns(string[] Urns, CancellationToken cancellationToken);
        MisEstablishment? GetMisEstablishmentByURN(int? urn);
        EducationEstablishmentLink? GetEducationEstablishmentLinksByURN(long? urn);
        ReportCardFullInspection? GetOfstedReportCardsByURN(int? urn);
    }
}
