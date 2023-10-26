using Dfe.Academies.Academisation.Data;
using Dfe.Academies.Academisation.Data.Repositories;
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
            var trust = await dbSet
                .Include(x => x.TrustType)
                .SingleOrDefaultAsync(x => x.UKPRN == ukprn).ConfigureAwait(false);

            return trust;
        }

        public async Task<List<Trust>> GetTrustsByUkprns(string[] ukprns, CancellationToken cancellationToken)
        {
            var trusts = await dbSet.Where(x => ukprns.Contains(x.UKPRN)).ToListAsync(cancellationToken).ConfigureAwait(false);

            return trusts;
        }

        public async Task<List<Trust>> Search(int page, int count, string name, string ukPrn, string companiesHouseNumber, CancellationToken cancellationToken)
        {
            if (name == null && ukPrn == null && companiesHouseNumber == null)
            {
                List<Trust> allTrusts =  await dbSet.OrderBy(trust => trust.GroupUID).Skip((page - 1) * count)
                   .Take(count).ToListAsync(cancellationToken).ConfigureAwait(false);
                return allTrusts;
            }

            IOrderedQueryable<Trust> filteredGroups = dbSet
               .Where(trust => (trust.Name.Contains(name) ||
                            trust.UKPRN.Contains(ukPrn) ||
                            trust.CompaniesHouseNumber.Contains(companiesHouseNumber))
                           && (
                              trust.TrustType.Name == "Single-academy trust" ||
                              trust.TrustType.Name == "Multi-academy trust"
                           ))
               .OrderBy(trust => trust.GroupUID);

            return await filteredGroups.Skip((page - 1) * count).Take(count).ToListAsync(cancellationToken).ConfigureAwait(false);
        }
    }
}
