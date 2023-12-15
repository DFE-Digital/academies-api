using Dfe.Academies.Academisation.Data;
using Dfe.Academies.Academisation.Data.Repositories;
using Dfe.Academies.Domain.Establishment;
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
            var queryResult = await BaseQuery().SingleOrDefaultAsync(r => r.Establishment.UKPRN == ukprn);

            if (queryResult == null)
            {
                return null;
            }

            var result = ToEstablishment(queryResult);

            return result;
        }

        public async Task<Establishment?> GetEstablishmentByUrn(string urn, CancellationToken cancellationToken)
        {
            var queryResult = await BaseQuery().SingleOrDefaultAsync(r => r.Establishment.URN.ToString() == urn);

            if (queryResult == null)
            {
                return null;
            }

            var result = ToEstablishment(queryResult);

            return result;
        }

        public async Task<List<Establishment>> Search(string name, string ukPrn, string urn, CancellationToken cancellationToken)
        {
            IQueryable<Establishment> query = DefaultIncludes().AsNoTracking();
            if (!string.IsNullOrEmpty(name))
            {
                query = query.Where(e => e.EstablishmentName.Contains(name));
            }
            if (!string.IsNullOrEmpty(ukPrn))
            {
                query = query.Where(e => e.UKPRN == ukPrn);
            }
            if (!string.IsNullOrEmpty(urn))
            {
                if (int.TryParse(urn, out var urnAsNumber))
                {
                    query = query.Where(e => e.URN == urnAsNumber);
                }
            }
            return await query.Take(100).ToListAsync(cancellationToken);
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

        public async Task<List<Establishment>> GetByTrust(long? trustId, CancellationToken cancellationToken)
        {
            var establishmentIds = 
                await context.EducationEstablishmentTrusts
                        .AsNoTracking()             
                        .Where(eet => eet.TrustId == Convert.ToInt32(trustId))
                        .Select(eet => (long)eet.EducationEstablishmentId)
                        .ToListAsync(cancellationToken);

            var establishments = 
                    await BaseQuery()
                        .Where(r => establishmentIds.Contains(r.Establishment.SK.Value))
                        .ToListAsync(cancellationToken);

            var result = establishments.Select(ToEstablishment).ToList();

            return result;
        }

        private IQueryable<EstablishmentQueryResult> BaseQuery()
        {
            var result =
                context.Establishments
                    .Include(x => x.EstablishmentType)
                    .Include(x => x.LocalAuthority)
                    .Join(context.IfdPipelines, e => e.PK_GIAS_URN, i => i.GeneralDetailsUrn, (e, i) => new EstablishmentQueryResult { Establishment = e, IfdPipeline = i })
                    .AsNoTracking();

            return result;
        }

        private IQueryable<Establishment> DefaultIncludes()
        {
            var x = dbSet
                .Include(x => x.EstablishmentType)
                .Include(x => x.LocalAuthority)
                .AsQueryable();

            return x;
        }

        private static Establishment ToEstablishment(EstablishmentQueryResult queryResult)
        {
            var result = queryResult.Establishment;
            result.IfdPipeline = queryResult.IfdPipeline;

            return result;
        }
    }

    internal record EstablishmentQueryResult
    {
        public Establishment Establishment { get; set; }
        public IfdPipeline IfdPipeline { get; set; }
    }
}
