using Dfe.Academies.Domain.Persons;

namespace Dfe.Academies.Application.Persons
{
    public class PersonsQueries : IPersonsQueries
    {
        private readonly IPersonsRepository _personsRepository;

        public PersonsQueries(IPersonsRepository personsRepository)
        {
            _personsRepository = personsRepository;
        }

        public async Task<Person> GetMemberOfParlimentByConstituency(string constituency, CancellationToken cancellationToken)
        {
            return await _personsRepository.GetMemberOfParlimentByConstituency(constituency, cancellationToken);
        }

    }
}
