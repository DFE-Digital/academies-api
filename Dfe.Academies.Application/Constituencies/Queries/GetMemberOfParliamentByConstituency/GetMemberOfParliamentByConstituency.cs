using AutoMapper;
using Dfe.Academies.Application.Common.Interfaces;
using Dfe.Academies.Application.Common.Models;
using MediatR;
using Dfe.Academies.Utils.Caching;

namespace Dfe.Academies.Application.Constituencies.Queries.GetMemberOfParliamentByConstituency
{
    public record GetMemberOfParliamentByConstituencyQuery(string ConstituencyName) : IRequest<MemberOfParliament>;

    public class GetMemberOfParliamentByConstituencyQueryHandler : IRequestHandler<GetMemberOfParliamentByConstituencyQuery, MemberOfParliament?>
    {
        private readonly IConstituencyRepository _constituencyRepository;
        private readonly IMapper _mapper;
        private readonly ICacheService _cacheService;

        public GetMemberOfParliamentByConstituencyQueryHandler(
            IConstituencyRepository constituencyRepository,
            IMapper mapper,
            ICacheService cacheService)
        {
            _constituencyRepository = constituencyRepository;
            _mapper = mapper;
            _cacheService = cacheService;
        }

        public async Task<MemberOfParliament?> Handle(GetMemberOfParliamentByConstituencyQuery request, CancellationToken cancellationToken)
        {
            var cacheKey = $"MemberOfParliament_{CacheKeyHelper.GenerateHashedCacheKey(request.ConstituencyName)}";
            var methodName = nameof(GetMemberOfParliamentByConstituencyQueryHandler);

            return await _cacheService.GetOrAddAsync(cacheKey, async () =>
            {
                var constituencyWithMember = await _constituencyRepository
                    .GetMemberOfParliamentByConstituencyAsync(request.ConstituencyName, cancellationToken);

                var result = _mapper.Map<MemberOfParliament?>(constituencyWithMember);

                return result;
            }, methodName);
        }
    }
}
