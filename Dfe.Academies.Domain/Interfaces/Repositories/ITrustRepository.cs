using Dfe.Academies.Domain.Trust;

namespace Dfe.Academies.Domain.Interfaces.Repositories
{
    public interface ITrustRepository
    {
        Task<Domain.Trust.Trust?> GetTrustByUkprn(string ukprn, CancellationToken cancellationToken);
        Task<Domain.Trust.Trust?> GetTrustByCompaniesHouseNumber(string companiesHouseNumber, CancellationToken cancellationToken);
        Task<Domain.Trust.Trust?> GetTrustByTrustReferenceNumber(string trustReferenceNumber, CancellationToken cancellationToken);
        Task<List<Domain.Trust.Trust>> GetTrustsByUkprns(string[] ukprns, CancellationToken cancellationToken);
        Task<(List<Domain.Trust.Trust>, int)> Search(int page, int count, string? name, string? ukPrn,
         string? companiesHouseNumber, TrustStatus status, CancellationToken cancellationToken);
    }
}
