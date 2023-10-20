using Dfe.Academies.Academisation.Domain.SeedWork;

namespace Dfe.Academies.Domain.Trust
{
    public interface ITrustRepository : IGenericRepository<Trust>
    {
        Task<Trust?> GetTrustByUkprn(string ukprn, CancellationToken cancellationToken);
        Task<List<Trust>> GetTrustsByUkprns(string[] ukprns, CancellationToken cancellationToken);
        Task<List<Trust>> Search(int page, int count, string name, string ukPrn,
         string companiesHouseNumber, CancellationToken cancellationToken);
    }
}
