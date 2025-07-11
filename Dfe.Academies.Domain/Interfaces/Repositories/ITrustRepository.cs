using Dfe.Academies.Domain.Trust;

namespace Dfe.Academies.Domain.Interfaces.Repositories
{
    public interface ITrustRepository
    {
        Task<Trust.Trust?> GetTrustByUkprn(string ukprn, CancellationToken cancellationToken);
        Task<Trust.Trust?> GetTrustByCompaniesHouseNumber(string companiesHouseNumber, CancellationToken cancellationToken);
        Task<Trust.Trust?> GetTrustByTrustReferenceNumber(string trustReferenceNumber, CancellationToken cancellationToken);
        Task<List<Trust.Trust>> GetTrustsByUkprns(string[] ukprns, CancellationToken cancellationToken);
        Task<(List<Trust.Trust>, int)> Search(int page, int count, string? name, string? ukPrn,
         string? companiesHouseNumber, TrustStatus status, CancellationToken cancellationToken);
        Task<Dictionary<int, Trust.Trust>> GetTrustsByEstablishmentUrns(List<int> urns, CancellationToken cancellationToken);
    }
}
