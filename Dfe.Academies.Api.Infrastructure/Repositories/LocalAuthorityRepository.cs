using Dfe.Academies.Domain.Establishment;
using Dfe.Academies.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Dfe.Academies.Infrastructure.Repositories
{
    public class LocalAuthorityRepository : ILocalAuthorityRepository
    {
        private readonly MstrContext _mstrContext;

        public LocalAuthorityRepository(MstrContext mstrContext)
        {
            _mstrContext = mstrContext ?? throw new ArgumentNullException(nameof(mstrContext));
        }

        public async Task<LocalAuthority?> GetLocalAuthorityByCode(string code, CancellationToken cancellationToken)
        {
            var localAuthority = await _mstrContext.LocalAuthorities.AsNoTracking()
                    .SingleOrDefaultAsync(x => x.Code == code, cancellationToken).ConfigureAwait(false);

            return localAuthority;
        }

        public async Task<(List<LocalAuthority>, int)> Search(string name, string code, CancellationToken cancellationToken)
        {
            IQueryable<LocalAuthority> query = _mstrContext.LocalAuthorities.AsNoTracking();

#pragma warning disable CA1862 // Use the 'StringComparison' method overloads to perform case-insensitive string comparisons
            var hasName = !string.IsNullOrEmpty(name);
            var hasCode = !string.IsNullOrEmpty(code);

            if (hasName || hasCode)
            {
                query = query.Where(la =>
                    (hasName && la.Name != null && la.Name.ToLower().Contains(name.ToLower())) ||
                    (hasCode && la.Code != null && la.Code.ToLower().Contains(code.ToLower())));
            }
#pragma warning restore CA1862 // Use the 'StringComparison' method overloads to perform case-insensitive string comparisons

            var queryResult = await query.Take(100).ToListAsync(cancellationToken);

            return (queryResult, queryResult.Count);
        }
    }
}
