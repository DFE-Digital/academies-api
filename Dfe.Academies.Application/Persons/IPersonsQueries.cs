using Dfe.Academies.Application.Models;

namespace Dfe.Academies.Application.Persons
{
    public interface IPersonsQueries
    {
        Task<Person?> GetMemberOfParliamentByConstituencyAsync(string constituencyName, CancellationToken cancellationToken);
    }
}