﻿using Dfe.Academies.Academisation.Data;
using Dfe.Academies.Domain.Establishment;
using Microsoft.EntityFrameworkCore;

namespace Dfe.Academies.Infrastructure.Repositories
{
    public class EstablishmentRepository : IEstablishmentRepository
    {
        private MstrContext _context;

        public EstablishmentRepository(MstrContext context)
        {
            _context = context;
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
            IQueryable<EstablishmentQueryResult> query = BaseQuery();

            if (!string.IsNullOrEmpty(name))
            {
                query = query.Where(r => r.Establishment.EstablishmentName.Contains(name));
            }
            if (!string.IsNullOrEmpty(ukPrn))
            {
                query = query.Where(r => r.Establishment.UKPRN == ukPrn);
            }
            if (!string.IsNullOrEmpty(urn))
            {
                if (int.TryParse(urn, out var urnAsNumber))
                {
                    query = query.Where(r => r.Establishment.URN == urnAsNumber);
                }
            }
            var queryResult = await query.Take(100).ToListAsync(cancellationToken);

            var result = queryResult.Select(ToEstablishment).ToList();

            return result;
        }

        public async Task<IEnumerable<int>> GetURNsByRegion(string[] regions, CancellationToken cancellationToken)
        {
            return await _context.Establishments
                .AsNoTracking()
                .Where(p => regions.Contains(p.GORregion) && p.URN.HasValue)
                .Select(e => e.URN.Value)
                .ToListAsync(cancellationToken);
        }

        public async Task<List<Establishment>> GetByUrns(int[] urns, CancellationToken cancellationToken)
        {
            var urnsList = urns.ToList();
            var queryResult = await BaseQuery()
                .Where(r => urnsList.Contains((int)r.Establishment.URN))
                .ToListAsync(cancellationToken);

            var result = queryResult.Select(ToEstablishment).ToList();

            return result;
        }

        public async Task<List<Establishment>> GetByTrust(long? trustId, CancellationToken cancellationToken)
        {
            var establishmentIds = 
                await _context.EducationEstablishmentTrusts
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
                _context.Establishments
                    .Include(x => x.EstablishmentType)
                    .Include(x => x.LocalAuthority)
                    .Join(_context.IfdPipelines, e => e.PK_GIAS_URN, i => i.GeneralDetailsUrn, (e, i) => new EstablishmentQueryResult { Establishment = e, IfdPipeline = i })
                    .AsNoTracking();

            return result;
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
