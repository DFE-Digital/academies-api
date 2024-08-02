using Dfe.Academies.Application.Persons;
using Dfe.Academies.Contracts.V4.Establishments;
using Dfe.Academies.Domain.Persons;

namespace Dfe.Academies.Application.Persons
{
    public class PersonsQueries : IPersonsQueries
    {
        //private readonly IEstablishmentRepository _establishmentRepository;

        public async Task<Person> GetMemberOfParlimentByConstituency(string constituency, CancellationToken cancellationToken)
        {
            var person = new Person()
            {
                Id = "222",
                FirstName = "Elijah",
                LastName = "Aremu"
            };

            return person;
        }

    }
}
