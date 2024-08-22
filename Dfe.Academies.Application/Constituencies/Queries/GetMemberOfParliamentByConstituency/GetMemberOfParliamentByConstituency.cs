using AutoMapper;
using AutoMapper.QueryableExtensions;
using Dfe.Academies.Application.Models;
using Dfe.Academies.Domain.Caching;
using Dfe.Academies.Domain.Constituencies;
using Dfe.Academies.Domain.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Dfe.Academies.Application.Constituencies.Queries.GetMemberOfParliamentByConstituency
{
    public record GetMemberOfParliamentByConstituencyQuery(string ConstituencyName) : IRequest<MemberOfParliament>;

    public class GetMemberOfParliamentByConstituencyQueryHandler : IRequestHandler<GetMemberOfParliamentByConstituencyQuery, MemberOfParliament?>
    {
        private readonly IMopRepository<Constituency> _constituencyRepository;
        private readonly IMopRepository<MemberContactDetails> _memberContactDetailsRepository;
        private readonly IMapper _mapper;
        private readonly ICacheService _cacheService;

        public GetMemberOfParliamentByConstituencyQueryHandler(
            IMopRepository<Constituency> constituencyRepository,
            IMopRepository<MemberContactDetails> memberContactDetailsRepository,
            IMapper mapper,
            ICacheService cacheService)
        {
            _constituencyRepository = constituencyRepository;
            _memberContactDetailsRepository = memberContactDetailsRepository;
            _mapper = mapper;
            _cacheService = cacheService;
        }

        public async Task<MemberOfParliament?> Handle(GetMemberOfParliamentByConstituencyQuery request, CancellationToken cancellationToken)
        {
            string cacheKey = $"MemberOfParliament_{request.ConstituencyName}";
            string methodName = nameof(GetMemberOfParliamentByConstituencyQuery);

            return await _cacheService.GetOrAddAsync(cacheKey, async () =>
            {
                var query = from constituencies in _constituencyRepository.Query()
                            join memberContactDetails in _memberContactDetailsRepository.Query()
                                on constituencies.MemberID equals memberContactDetails.MemberID
                            where constituencies.ConstituencyName == request.ConstituencyName
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
