using Dfe.Academies.Application.Models;

namespace Dfe.Academies.Application.Constituencies
{
    public interface IConstituencyQueries
    {
        Task<MemberOfParliament?> GetMemberOfParliamentByConstituencyAsync(string constituencyName, CancellationToken cancellationToken);
    }
}