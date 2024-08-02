using Dfe.Academies.Domain.Persons;

namespace Dfe.Academies.Application.Persons
{
    public interface IPersonsQueries
    {
        Task<Person> GetMemberOfParlimentByConstituency(string constituency, CancellationToken cancellationToken);
    }
}
