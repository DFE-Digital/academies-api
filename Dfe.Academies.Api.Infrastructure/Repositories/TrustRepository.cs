using Dfe.Academies.Academisation.Data;
using Dfe.Academies.Academisation.Data.Repositories;
using Dfe.Academies.Domain.Establishment;
using Dfe.Academies.Domain.Trust;
using Microsoft.EntityFrameworkCore;

namespace Dfe.Academies.Infrastructure.Repositories
{
    public class TrustRepository : GenericRepository<Trust>, ITrustRepository
    {
        public TrustRepository(MstrContext context) : base(context)
        {
        }

        public async Task<Trust?> GetTrustByUkprn(string ukprn, CancellationToken cancellationToken)
        {
            var trust = await DefaultIncludes()
                .SingleOrDefaultAsync(x => x.UKPRN == ukprn, cancellationToken).ConfigureAwait(false);

            return trust;
        }
        public async Task<Trust?> GetTrustByCompaniesHouseNumber(string companiesHouseNumber, CancellationToken cancellationToken)
        {
            var trust = await DefaultIncludes()
                .SingleOrDefaultAsync(x => x.CompaniesHouseNumber == companiesHouseNumber, cancellationToken).ConfigureAwait(false);

            return trust;
        }

        public async Task<Trust?> GetTrustByTrustReferenceNumber(string trustReferenceNumber, CancellationToken cancellationToken)
        {
            var trust = await DefaultIncludes()
                .SingleOrDefaultAsync(x => x.GroupID == trustReferenceNumber, cancellationToken).ConfigureAwait(false);

            return trust;
        }

        public async Task<List<Trust>> GetTrustsByUkprns(string[] ukprns, CancellationToken cancellationToken)
        {
            var trusts = await DefaultIncludes().Where(x => ukprns.Contains(x.UKPRN)).ToListAsync(cancellationToken).ConfigureAwait(false);

            return trusts;
        }

        public async Task<(List<Trust>, int)> Search(int page, int count, string name, string ukPrn, string companiesHouseNumber, CancellationToken cancellationToken)
        {
            if (name == null && ukPrn == null && companiesHouseNumber == null)
            {
                List<Trust> allTrusts =  await DefaultIncludes().OrderBy(trust => trust.GroupUID).Skip((page - 1) * count)
                   .Take(count).ToListAsync(cancellationToken).ConfigureAwait(false);
                return (allTrusts, allTrusts.Count);
            }

            IOrderedQueryable<Trust> filteredGroups = DefaultIncludes().AsNoTracking()
               .Where(trust => (trust.Name.Contains(name) ||
                            trust.UKPRN.Contains(ukPrn) ||
                            trust.CompaniesHouseNumber.Contains(companiesHouseNumber))
                           && (
                              trust.TrustType.Name == "Single-academy trust" ||
                              trust.TrustType.Name == "Multi-academy trust"
                           ) && trust.TrustStatus == "Open")
               .OrderBy(trust => trust.GroupUID);

            return (await filteredGroups.Skip((page - 1) * count).Take(count).ToListAsync(cancellationToken).ConfigureAwait(false), filteredGroups.Count());
        }

        private IQueryable<Trust> DefaultIncludes()
        {
            var x = dbSet
                .Include(x => x.TrustType)
                .AsQueryable();

            return x;
        }
    }
}
