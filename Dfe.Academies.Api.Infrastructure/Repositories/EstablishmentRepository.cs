using Dfe.Academies.Academisation.Data;
using Dfe.Academies.Academisation.Data.Repositories;
using Dfe.Academies.Domain.Establishment;
using Dfe.Academies.Domain.Trust;
using Microsoft.EntityFrameworkCore;

namespace Dfe.Academies.Infrastructure.Repositories
{
    public class EstablishmentRepository : GenericRepository<Establishment>, IEstablishmentRepository
    {
        public EstablishmentRepository(MstrContext context) : base(context)
        {
        }

        public async Task<Establishment?> GetEstablishmentByUkprn(string ukprn, CancellationToken cancellationToken)
        {
            var Establishment = await dbSet.SingleOrDefaultAsync(x => x.UKPRN == ukprn).ConfigureAwait(false);

            return Establishment;
        }
        public async Task<Establishment?> GetEstablishmentByUrn(string urn, CancellationToken cancellationToken)
        {
            var Establishment = await dbSet.SingleOrDefaultAsync(x => x.URN.ToString() == urn).ConfigureAwait(false);

            return Establishment;
        }
    }
}
