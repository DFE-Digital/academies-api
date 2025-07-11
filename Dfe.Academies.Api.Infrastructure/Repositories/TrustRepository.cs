using Dfe.Academies.Domain.Trust;
using Microsoft.EntityFrameworkCore;
using Dfe.Academies.Domain.Interfaces.Repositories;

namespace Dfe.Academies.Infrastructure.Repositories
{
    public class TrustRepository : ITrustRepository
    {
        private MstrContext _context;

        public TrustRepository(MstrContext context)
        {
            _context = context;
        }

        public async Task<Trust?> GetTrustByUkprn(string ukprn, CancellationToken cancellationToken)
        {
            var trust = await DefaultIncludes().AsNoTracking()
                .SingleOrDefaultAsync(x => x.UKPRN == ukprn, cancellationToken).ConfigureAwait(false);

            return trust;
        }

        public async Task<Trust?> GetTrustByCompaniesHouseNumber(string companiesHouseNumber,
            CancellationToken cancellationToken)
        {
            var trust = await DefaultIncludes().AsNoTracking()
                .SingleOrDefaultAsync(x => x.CompaniesHouseNumber == companiesHouseNumber, cancellationToken)
                .ConfigureAwait(false);

            return trust;
        }

        public async Task<Trust?> GetTrustByTrustReferenceNumber(string trustReferenceNumber,
            CancellationToken cancellationToken)
        {
            var trust = await DefaultIncludes().AsNoTracking()
                .SingleOrDefaultAsync(x => x.GroupID == trustReferenceNumber, cancellationToken).ConfigureAwait(false);

            return trust;
        }

        public async Task<List<Trust>> GetTrustsByUkprns(string[] ukprns, CancellationToken cancellationToken)
        {
            var trusts = await DefaultIncludes().AsNoTracking().Where(x => ukprns.Contains(x.UKPRN))
                .ToListAsync(cancellationToken).ConfigureAwait(false);

            return trusts;
        }

        public async Task<Dictionary<int, Trust>> GetTrustsByUrns(List<int> urns, CancellationToken cancellationToken)
        {
            var trustData = await (
                from e in _context.Establishments.AsNoTracking()
                join eet in _context.EducationEstablishmentTrusts.AsNoTracking() on e.SK equals eet.EducationEstablishmentId
                join t in _context.Trusts.AsNoTracking() on eet.TrustId equals t.SK
                join tt in _context.TrustTypes.AsNoTracking() on t.TrustTypeId equals tt.SK
                where e.URN != null && urns.Contains(e.URN.Value)
                select new
                {
                    URN = e.URN!.Value,
                    Trust = new Trust
                    {
                        Name = t.Name!,
                        CompaniesHouseNumber = t.CompaniesHouseNumber,
                        GroupID = t.GroupID,
                        UKPRN = t.UKPRN,
                        TrustType = t.TrustType,
                        AddressLine1 = t.AddressLine1,
                        Town = t.Town,
                        Postcode = t.Postcode,
                        County = t.County,
                        AddressLine2 = t.AddressLine2,
                        AddressLine3 = t.AddressLine3
                    }
                }
            ).ToListAsync(cancellationToken);

            var grouped = trustData
                .GroupBy(x => x.URN)
                .ToDictionary(
                    g => g.Key,
                    g => g.Select(x => x.Trust).First()
                );

            return grouped;
        }



        public async Task<(List<Trust>, int)> Search(int page, int count, string? name, string? ukPrn,
            string? companiesHouseNumber, TrustStatus status, CancellationToken cancellationToken)
        {
            if (name == null && ukPrn == null && companiesHouseNumber == null)
            {
                IOrderedQueryable<Trust> allTrusts = DefaultIncludes().AsNoTracking().OrderBy(trust => trust.GroupUID);

                return (await allTrusts.Skip((page - 1) * count)
                    .Take(count).ToListAsync(cancellationToken).ConfigureAwait(false), allTrusts.Count());
            }

            IQueryable<Trust> filteredGroups = DefaultIncludes().AsNoTracking()
                .Where(trust => trust.CompaniesHouseNumber != null
                                && (
                                    (name != null && trust.Name != null && trust.Name.Contains(name)) ||
                                    (ukPrn != null && trust.UKPRN != null && trust.UKPRN.Contains(ukPrn)) ||
                                    (companiesHouseNumber != null
                                     && trust.CompaniesHouseNumber != null
                                     && trust.CompaniesHouseNumber.Contains(companiesHouseNumber))
                                )
                                && trust.TrustType != null &&
                                (trust.TrustType.Name == "Single-academy trust" ||
                                 trust.TrustType.Name == "Multi-academy trust"));

            if (status == TrustStatus.Open)
            {
                filteredGroups = filteredGroups.Where(trust => trust.TrustStatus == "Open");
            }

            return (
                await filteredGroups.OrderBy(trust => trust.GroupUID).Skip((page - 1) * count).Take(count)
                    .ToListAsync(cancellationToken).ConfigureAwait(false), filteredGroups.Count());
        }

        private IQueryable<Trust> DefaultIncludes()
        {
            var x = _context.Trusts
                .Include(x => x.TrustType)
                .AsQueryable();

            return x;
        }
    }
}