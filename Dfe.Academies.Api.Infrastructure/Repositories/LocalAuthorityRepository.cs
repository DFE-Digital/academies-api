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

        public async Task<(List<LocalAuthority>, int)> Search(string name, string code, CancellationToken cancellationToken)
        {
            IQueryable<LocalAuthority> query = _mstrContext.LocalAuthorities.AsNoTracking();

            query = query.Where(la =>
                (string.IsNullOrEmpty(name) || (la.Name != null && la.Name.Contains(name, StringComparison.OrdinalIgnoreCase))) &&
                (string.IsNullOrEmpty(code) || (la.Code != null && la.Code.Contains(code, StringComparison.OrdinalIgnoreCase))));

            var queryResult = await query.Take(100).ToListAsync(cancellationToken);

            return (queryResult, queryResult.Count);
        }
    }
}
