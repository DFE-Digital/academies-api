using Dfe.Academies.Domain.Trust;
using GovUK.Dfe.CoreLibs.Contracts.Academies.V4.Trusts;

namespace Dfe.Academies.Application.Trust
{
    public interface ITrustQueries
    {
        Task<TrustDto?> GetByUkprn(string ukprn, CancellationToken cancellationToken);
        Task<TrustDto?> GetByCompaniesHouseNumber(string companiesHouseNumber, CancellationToken cancellationToken);
        Task<TrustDto?> GetByTrustReferenceNumber(string trustReferenceNumber, CancellationToken cancellationToken);
        Task<List<TrustDto>> GetByUkprns(string[] ukprns, CancellationToken cancellationToken);
        Task<(List<TrustDto>, int)> Search(int page, int count, string name, string ukPrn, string companiesHouseNumber, TrustStatus status, CancellationToken cancellationToken);
        Task<Dictionary<int, TrustDto>> GetTrustsByEstablishmentUrns(List<int> urns, CancellationToken cancellationToken);
    }
}
