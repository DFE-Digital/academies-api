using Dfe.Academies.Academisation.Data;
using Dfe.Academies.Domain.Trust;
using Microsoft.EntityFrameworkCore;

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
        
        public async Task<Trust?> GetTrustByGroupUID(string groupUID, CancellationToken cancellationToken)
        {
            var trust = await DefaultIncludes().AsNoTracking()
                .SingleOrDefaultAsync(x => x.GroupUID == groupUID, cancellationToken).ConfigureAwait(false);

            return trust;
        }

        public async Task<List<Trust>> GetTrustsByUkprns(string[] ukprns, CancellationToken cancellationToken)
        {
            var trusts = await DefaultIncludes().AsNoTracking().Where(x => ukprns.Contains(x.UKPRN))
                .ToListAsync(cancellationToken).ConfigureAwait(false);

            return trusts;
        }

        public async Task<List<Trust>> GetTrustsByIdentifier(string identifier, CancellationToken cancellationToken)
        {
            var trusts = await DefaultIncludes().AsNoTracking().Where(x =>
                    identifier.Equals(x.UKPRN) || identifier.Equals(x.GroupID) || identifier.Equals(x.GroupUID))
                .ToListAsync(cancellationToken).ConfigureAwait(false);
            return trusts;
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