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
            var trust = await this.dbSet.SingleOrDefaultAsync(x => x.UKPRN == ukprn).ConfigureAwait(false);

            return trust;
        }
    }
}
