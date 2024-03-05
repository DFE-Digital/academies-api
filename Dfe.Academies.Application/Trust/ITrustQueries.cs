using Dfe.Academies.Contracts.V4.Trusts;
using Dfe.Academies.Domain.Trust;

namespace Dfe.Academies.Application.Trust
{
    public interface ITrustQueries
    {
        Task<TrustDto?> GetByUkprn(string ukprn, CancellationToken cancellationToken);
        Task<TrustDto?> GetByCompaniesHouseNumber(string companiesHouseNumber, CancellationToken cancellationToken);
        Task<TrustDto?> GetByTrustReferenceNumber(string trustReferenceNumber, CancellationToken cancellationToken);
        Task<TrustDto?> GetByTrustGroupUID(string groupUID, CancellationToken cancellationToken);
        Task<List<TrustDto>> GetByUkprns(string[] ukprns, CancellationToken cancellationToken);
        Task<List<TrustIdentifiers>?> GetTrustIdentifiers(string identifer, CancellationToken cancellationToken);
        Task<(List<TrustDto>, int)> Search(int page, int count, string name, string ukPrn, string companiesHouseNumber,
            TrustStatus status, CancellationToken cancellationToken);
    }
}
