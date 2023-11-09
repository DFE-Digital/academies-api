using Dfe.Academies.Contracts.Trusts;

namespace Dfe.Academies.Application.Queries.Trust
{
    public interface ITrustQueries
    {
        Task<TrustDto?> GetByUkprn(string ukprn, CancellationToken cancellationToken);
        Task<TrustDto?> GetByCompaniesHouseNumber(string companiesHouseNumber, CancellationToken cancellationToken);
        Task<List<TrustDto>> GetByUkprns(string[] ukprns, CancellationToken cancellationToken);
        Task<(List<TrustDto>, int)> Search(int page, int count, string name, string ukPrn, string companiesHouseNumber, CancellationToken cancellationToken);
    }
}
