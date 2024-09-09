using Dfe.Academies.Academisation.Data;
using Dfe.Academies.Application.Common.Interfaces;
using Dfe.Academies.Application.Common.Models;
using Dfe.Academies.Domain.Constituencies;
using Microsoft.EntityFrameworkCore;

namespace Dfe.Academies.Infrastructure.Repositories
{
    public class ConstituencyRepository : IConstituencyRepository
    {
        private readonly MopContext _context;

        public ConstituencyRepository(MopContext context)
        {
            _context = context;
        }

        public async Task<Constituency?> GetMemberOfParliamentByConstituencyAsync(string constituencyName, CancellationToken cancellationToken)
        {
            return await _context.Constituencies
                .AsNoTracking()
                .Include(c => c.MemberContactDetails)
                .Where(c => c.ConstituencyName == constituencyName
                            && c.MemberContactDetails.TypeId == 1
                            && !c.EndDate.HasValue)
                .FirstOrDefaultAsync(cancellationToken);
        }

        public IQueryable<Constituency> GetMembersOfParliamentByConstituenciesQueryable(List<string> constituencyNames)
        {
            return _context.Constituencies
                .AsNoTracking()
                .Include(c => c.MemberContactDetails) 
                .Where(c => constituencyNames.Contains(c.ConstituencyName)
                            && c.MemberContactDetails.TypeId == 1
                            && !c.EndDate.HasValue);
        }
    }
}
