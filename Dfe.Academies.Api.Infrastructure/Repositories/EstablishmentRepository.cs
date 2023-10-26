using Dfe.Academies.Academisation.Data;
using Dfe.Academies.Academisation.Data.Repositories;
using Dfe.Academies.Domain.Establishment;
using Microsoft.EntityFrameworkCore;
using static System.Net.Mime.MediaTypeNames;

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
            var establishment = await DefaultIncludes().SingleOrDefaultAsync(x => x.URN.ToString() == urn).ConfigureAwait(false);

            return establishment;
        }
        public async Task<List<Establishment>> Search(string name, string ukPrn, string urn, CancellationToken cancellationToken)
        {
            IQueryable<Establishment> query = dbSet;

            query = !string.IsNullOrEmpty(name)
                ? query.Where(establishment => establishment.EstablishmentName.Contains(name))
                : query;

            query = !string.IsNullOrEmpty(ukPrn)
                ? query.Where(establishment => establishment.UKPRN.Contains(ukPrn))
                : query;

            query = !string.IsNullOrEmpty(urn)
                ? query.Where(establishment => establishment.URN.ToString().Contains(urn))
                : query;

            return await query.OrderBy(establishment => establishment.SK)
                              .ToListAsync(cancellationToken)
                              .ConfigureAwait(false);
        }
        public async Task<IEnumerable<int>> GetURNsByRegion(ICollection<string> regions, CancellationToken cancellationToken)
        {
            return (IEnumerable<int>)await dbSet //Adding Explicit cast because the Domain entity has the URN as nullable
                .AsNoTracking()
                .Where(p => regions.Contains(p!.GORregion.ToLower())) // Assuming GORregion is correct
                .Select(e => e.URN)
                .ToListAsync(cancellationToken)
                .ConfigureAwait(false);
        }
        public async Task<List<Establishment>> GetByUrns(int[] urns)
        {
            var urnsList = urns.ToList();
            return await dbSet
                .AsNoTracking()
                .Where(e => urnsList.Contains((int)e.URN))
                .ToListAsync();
        }

        private IQueryable<Establishment> DefaultIncludes()
        {
            var x = dbSet
                .Include(x => x.EstablishmentType)
                .Include(x => x.LocalAuthority)
                .Include(x => x.IfdPipeline)
                .AsQueryable();

            return x;
        }



    }
}
