using Dfe.Academies.Application.Common.Interfaces;
using Dfe.Academies.Application.Common.Models;
using Dfe.Academies.Domain.Constituencies;
using Microsoft.EntityFrameworkCore;

namespace Dfe.Academies.Infrastructure.Repositories
{
    public class ConstituencyRepository(MopContext context) : IConstituencyRepository
    {
        public async Task<Constituency?> GetMemberOfParliamentByConstituencyAsync(string constituencyName, CancellationToken cancellationToken)
        {
            return await context.Constituencies
                .AsNoTracking()
                .Include(c => c.MemberContactDetails)
                .Where(c => c.ConstituencyName == constituencyName
                            && c.MemberContactDetails.TypeId == 1
                            && !c.EndDate.HasValue)
                .FirstOrDefaultAsync(cancellationToken);
        }

        public IQueryable<Constituency> GetMembersOfParliamentByConstituenciesQueryable(List<string> constituencyNames)
        {
            return context.Constituencies
                .AsNoTracking()
                .Include(c => c.MemberContactDetails) 
                .Where(c => constituencyNames.Contains(c.ConstituencyName)
                            && c.MemberContactDetails.TypeId == 1
                            && !c.EndDate.HasValue);
        }
    }
}
