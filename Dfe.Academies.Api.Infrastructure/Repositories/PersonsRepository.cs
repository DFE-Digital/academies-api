using Dfe.Academies.Academisation.Data;
using Dfe.Academies.Domain.Persons;

namespace Dfe.Academies.Infrastructure.Repositories
{
    public class PersonsRepository : IPersonsRepository
    {
        private MopContext _context;

        public PersonsRepository(MopContext context)
        {
            _context = context;
        }

        public async Task<Person?> GetMemberOfParlimentByConstituency(string constituencyName, CancellationToken cancellationToken)
        {
            var persons = from constituencies in _context.Constituencies
                          join memberContactDetails in _context.MemberContactDetails
                              on constituencies.MemberID equals memberContactDetails.MemberID
                          where constituencies.ConstituencyName.Equals(constituencyName) && memberContactDetails.TypeId.Equals(1)
                          orderby constituencies.LastRefresh descending
                          select MapToPerson(constituencies, memberContactDetails);

            return persons.FirstOrDefault();
        }


        private static Person MapToPerson(Constituency constituency, MemberContactDetails memberContactDetails)
        {
            var nameList = constituency.NameList.Split(",");
            var firstName = nameList[1].Trim();
            var lastName = nameList[0].Trim();

            var person = new Person()
            {
                Id = constituency.MemberID,
                FirstName = firstName,
                LastName = lastName,
                Email = memberContactDetails.Email,
                DisplayName = constituency.NameDisplayAs,
                DisplayNameWithTitle = constituency.NameFullTitle,
                Role = "Member of Parliament",
                ConstituencyName = constituency.ConstituencyName
            };

            return person;
        }
    }
}