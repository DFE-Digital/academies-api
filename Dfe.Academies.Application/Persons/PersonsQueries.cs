using AutoMapper;
using AutoMapper.QueryableExtensions;
using Dfe.Academies.Application.Models;
using Dfe.Academies.Domain.Persons;
using Dfe.Academies.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Dfe.Academies.Application.Persons
{
    public class PersonsQueries : IPersonsQueries
    {
        private readonly IRepository<Constituency> _constituencyRepository;
        private readonly IRepository<MemberContactDetails> _MemberContactDetailsRepository;
        private readonly IMapper _mapper;

        public PersonsQueries(
            IRepository<Constituency> constituencyRepository,
            IRepository<MemberContactDetails> memberContactDetailsRepository,
            IMapper mapper)
        {
            _constituencyRepository = constituencyRepository;
            _MemberContactDetailsRepository = memberContactDetailsRepository;
            _mapper = mapper;
        }

        public async Task<Person?> GetMemberOfParliamentByConstituencyAsync(string constituencyName, CancellationToken cancellationToken)
        {
            var query = from constituencies in _constituencyRepository.Query()
                        join memberContactDetails in _MemberContactDetailsRepository.Query()
                            on constituencies.MemberID equals memberContactDetails.MemberID
                        where constituencies.ConstituencyName == constituencyName
                        && memberContactDetails.TypeId == 1
                        && !constituencies.EndDate.HasValue
                        select new ConstituencyWithMemberContactDetails(constituencies, memberContactDetails);

            var result = await query
                .ProjectTo<Person>(_mapper.ConfigurationProvider)
                .FirstOrDefaultAsync(cancellationToken);

            return result;
        }



    }
}
