using AutoMapper;
using Dfe.Academies.Application.Common.Interfaces;
using MediatR;
using Dfe.Academies.Application.Common.Models;
using Dfe.Academies.Utils.Caching;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;

namespace Dfe.Academies.Application.Constituencies.Queries.GetMemberOfParliamentByConstituencies
{
    public record GetMembersOfParliamentByConstituenciesQuery(List<string> ConstituencyNames) : IRequest<List<MemberOfParliament>>;

    public class GetMembersOfParliamentByConstituenciesQueryHandler : IRequestHandler<GetMembersOfParliamentByConstituenciesQuery, List<MemberOfParliament>>
    {
        private readonly IConstituencyRepository _constituencyRepository;
        private readonly IMapper _mapper;
        private readonly ICacheService _cacheService;

        public GetMembersOfParliamentByConstituenciesQueryHandler(
            IConstituencyRepository constituencyRepository,
            IMapper mapper,
            ICacheService cacheService)
        {
            _constituencyRepository = constituencyRepository;
            _mapper = mapper;
            _cacheService = cacheService;
        }

        public async Task<List<MemberOfParliament>> Handle(GetMembersOfParliamentByConstituenciesQuery request, CancellationToken cancellationToken)
        {
            var cacheKey = $"MemberOfParliament_{CacheKeyHelper.GenerateHashedCacheKey(request.ConstituencyNames)}";

            var methodName = nameof(GetMembersOfParliamentByConstituenciesQueryHandler);

            return await _cacheService.GetOrAddAsync(cacheKey, async () =>
            {
                var constituenciesQuery = _constituencyRepository
                    .GetMembersOfParliamentByConstituenciesQueryable(request.ConstituencyNames);

                var membersOfParliament = await constituenciesQuery
                    .ProjectTo<MemberOfParliament>(_mapper.ConfigurationProvider)
                    .ToListAsync(cancellationToken);

                return membersOfParliament;
            }, methodName);
        }
    }

}
