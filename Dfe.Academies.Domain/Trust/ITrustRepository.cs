namespace Dfe.Academies.Domain.Trust
{
    public interface ITrustRepository
    {
        Task<Trust?> GetTrustByUkprn(string ukprn, CancellationToken cancellationToken);
        Task<Trust?> GetTrustByCompaniesHouseNumber(string companiesHouseNumber, CancellationToken cancellationToken);
        Task<Trust?> GetTrustByTrustReferenceNumber(string trustReferenceNumber, CancellationToken cancellationToken);
        Task<List<Trust>> GetTrustsByUkprns(string[] ukprns, CancellationToken cancellationToken);
        Task<List<Trust>> GetTrustsByIdentifier(string identifier, CancellationToken cancellationToken);
        Task<(List<Trust>, int)> Search(int page, int count, string? name, string? ukPrn,
         string? companiesHouseNumber, TrustStatus status, CancellationToken cancellationToken);
    }
}
