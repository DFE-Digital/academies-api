using AutoMapper;
using Dfe.Academies.Application.Common.Models;
using Dfe.Academies.Domain.Interfaces.Repositories;
using DfE.CoreLibs.Caching.Helpers;
using DfE.CoreLibs.Caching.Interfaces;
using MediatR;

namespace Dfe.Academies.Application.Constituencies.Queries.GetMemberOfParliamentByConstituency
{
    public record GetMemberOfParliamentByConstituencyQuery(string ConstituencyName) : IRequest<MemberOfParliament>;

    public class GetMemberOfParliamentByConstituencyQueryHandler(
        IConstituencyRepository constituencyRepository,
        IMapper mapper,
        ICacheService<IMemoryCacheType> cacheService)
        : IRequestHandler<GetMemberOfParliamentByConstituencyQuery, MemberOfParliament?>
    {
        public async Task<MemberOfParliament?> Handle(GetMemberOfParliamentByConstituencyQuery request, CancellationToken cancellationToken)
        {
            var cacheKey = $"MemberOfParliament_{CacheKeyHelper.GenerateHashedCacheKey(request.ConstituencyName)}";

            return await cacheService.GetOrAddAsync(cacheKey, async () =>
            {
                var constituencyWithMember = await constituencyRepository
                    .GetMemberOfParliamentByConstituencyAsync(request.ConstituencyName, cancellationToken);

                var result = mapper.Map<MemberOfParliament?>(constituencyWithMember);

                return result;
            }, nameof(GetMemberOfParliamentByConstituencyQueryHandler));
        }
    }
}
