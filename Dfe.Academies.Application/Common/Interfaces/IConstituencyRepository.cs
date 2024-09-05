using Dfe.Academies.Application.Common.Models;

namespace Dfe.Academies.Application.Common.Interfaces
{
    public interface IConstituencyRepository
    {
        Task<ConstituencyWithMemberContactDetails?> GetMemberOfParliamentByConstituencyAsync(string constituencyName, CancellationToken cancellationToken);
        IQueryable<ConstituencyWithMemberContactDetails> GetMembersOfParliamentByConstituenciesQueryable(List<string> constituencyNames);

    }
}
