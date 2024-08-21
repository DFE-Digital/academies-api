using AutoMapper;
using AutoMapper.QueryableExtensions;
using Dfe.Academies.Application.Models;
using Dfe.Academies.Domain.Caching;
using Dfe.Academies.Domain.Constituencies;
using Dfe.Academies.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Dfe.Academies.Application.Constituencies
{
    public class ConstituencyQueries : IConstituencyQueries
    {
        private readonly IMopRepository<Constituency> _constituencyRepository;
        private readonly IMopRepository<MemberContactDetails> _MemberContactDetailsRepository;
        private readonly IMapper _mapper;
        private readonly ICacheService _cacheService;

        public ConstituencyQueries(
            IMopRepository<Constituency> constituencyRepository,
            IMopRepository<MemberContactDetails> memberContactDetailsRepository,
            IMapper mapper,
            ICacheService cacheService)
        {
            _constituencyRepository = constituencyRepository;
            _MemberContactDetailsRepository = memberContactDetailsRepository;
            _mapper = mapper;
            _cacheService = cacheService;
        }

        public async Task<MemberOfParliament?> GetMemberOfParliamentByConstituencyAsync(string constituencyName, CancellationToken cancellationToken)
        {
            string cacheKey = $"MemberOfParliament_{constituencyName}";
            string methodName = nameof(GetMemberOfParliamentByConstituencyAsync);

            return await _cacheService.GetOrAddAsync(cacheKey, async () =>
            {
                var query = from constituencies in _constituencyRepository.Query()
                            join memberContactDetails in _MemberContactDetailsRepository.Query()
                                on constituencies.MemberID equals memberContactDetails.MemberID
                            where constituencies.ConstituencyName == constituencyName
                            && memberContactDetails.TypeId == 1
                            && !constituencies.EndDate.HasValue
                            select new ConstituencyWithMemberContactDetails(constituencies, memberContactDetails);

                var result = await query
                    .ProjectTo<MemberOfParliament>(_mapper.ConfigurationProvider)
                    .FirstOrDefaultAsync(cancellationToken);

                return result;
            }, methodName);
        }
    }
}
