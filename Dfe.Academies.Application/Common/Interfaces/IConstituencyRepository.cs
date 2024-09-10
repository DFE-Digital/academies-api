using Dfe.Academies.Domain.Constituencies;

namespace Dfe.Academies.Application.Common.Interfaces
{
    public interface IConstituencyRepository
    {
        Task<Constituency?> GetMemberOfParliamentByConstituencyAsync(string constituencyName, CancellationToken cancellationToken);
        IQueryable<Constituency> GetMembersOfParliamentByConstituenciesQueryable(List<string> constituencyNames);

    }
}
