namespace Dfe.Academies.Domain.Persons
{
    public interface IPersonsRepository
    {
        Task<Person> GetMemberOfParlimentByConstituency(string constituency, CancellationToken cancellationToken);
    }
}
