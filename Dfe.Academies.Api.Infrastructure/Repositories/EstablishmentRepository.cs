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
            var Establishment = await DefaultIncludes().SingleOrDefaultAsync(x => x.UKPRN == ukprn).ConfigureAwait(false);

            return Establishment;
        }
        public async Task<Establishment?> GetEstablishmentByUrn(string urn, CancellationToken cancellationToken)
        {
            var establishment = await DefaultIncludes().SingleOrDefaultAsync(x => x.URN.ToString() == urn).ConfigureAwait(false);

            return establishment;
        }
        public async Task<List<Establishment>> Search(string name, string ukPrn, string urn, CancellationToken cancellationToken)
        {
            IQueryable<Establishment> query = DefaultIncludes();

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
        public async Task<IEnumerable<int>> GetURNsByRegion(string[] regions, CancellationToken cancellationToken)
        {            
            return await DefaultIncludes() //Adding Explicit cast because the Domain entity has the URN as nullable
                .AsNoTracking()
                .Where(p => regions.Contains(p!.GORregion.ToLower()) && p.URN.HasValue)
                .Select(e => e.URN.Value)
                .ToListAsync(cancellationToken)
                .ConfigureAwait(false);
        }
        public async Task<List<Establishment>> GetByUrns(int[] urns, CancellationToken cancellationToken)
        {
            var urnsList = urns.ToList();
            return await DefaultIncludes()
                .AsNoTracking()
                .Where(e => urnsList.Contains((int)e.URN))
                .ToListAsync(cancellationToken);
        }

        public async Task<List<Establishment>> GetByTrust(int trustId, CancellationToken cancellationToken)
        {       
            var establishmentIds = await context.EducationEstablishmentTrusts
                                                 .Where(eet => eet.FK_Trust == trustId)
                                                 .Select(eet => eet.FK_EducationEstablishment)
                                                 .ToListAsync(cancellationToken)
                                                 .ConfigureAwait(false);
            
            var establishments = await DefaultIncludes()                                            
                                              .Where(e => establishmentIds.Contains((int)e.SK))
                                              .ToListAsync(cancellationToken)
                                              .ConfigureAwait(false);

            return establishments;
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
