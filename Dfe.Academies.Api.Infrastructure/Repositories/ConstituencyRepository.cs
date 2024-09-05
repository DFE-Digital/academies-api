using Dfe.Academies.Academisation.Data;
using Dfe.Academies.Application.Common.Interfaces;
using Dfe.Academies.Application.Common.Models;
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

        public async Task<ConstituencyWithMemberContactDetails?> GetMemberOfParliamentByConstituencyAsync(string constituencyName, CancellationToken cancellationToken)
        {
            var query = from constituencies in _context.Constituencies.AsNoTracking()
                        join memberContactDetails in _context.MemberContactDetails.AsNoTracking()
                            on constituencies.MemberID equals memberContactDetails.MemberID
                        where constituencies.ConstituencyName == constituencyName
                        && memberContactDetails.TypeId == 1
                        && !constituencies.EndDate.HasValue
                        select new ConstituencyWithMemberContactDetails(constituencies, memberContactDetails);

            return await query.FirstOrDefaultAsync(cancellationToken);
        }

        public IQueryable<ConstituencyWithMemberContactDetails> GetMembersOfParliamentByConstituenciesQueryable(List<string> constituencyNames)
        {
            var query = from constituencies in _context.Constituencies.AsNoTracking()
                        join memberContactDetails in _context.MemberContactDetails.AsNoTracking()
                            on constituencies.MemberID equals memberContactDetails.MemberID
                        where constituencyNames.Contains(constituencies.ConstituencyName)
                        && memberContactDetails.TypeId == 1
                        && !constituencies.EndDate.HasValue
                        select new ConstituencyWithMemberContactDetails(constituencies, memberContactDetails);

            return query;
        }
    }
}
