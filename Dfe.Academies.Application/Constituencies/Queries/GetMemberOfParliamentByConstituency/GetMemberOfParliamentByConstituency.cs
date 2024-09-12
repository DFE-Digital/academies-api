using AutoMapper;
using Dfe.Academies.Application.Common.Models;
using MediatR;
using Dfe.Academies.Utils.Caching;
using Dfe.Academies.Domain.Interfaces.Caching;
using Dfe.Academies.Domain.Interfaces.Repositories;

namespace Dfe.Academies.Application.Constituencies.Queries.GetMemberOfParliamentByConstituency
{
    public record GetMemberOfParliamentByConstituencyQuery(string ConstituencyName) : IRequest<MemberOfParliament>;

    public class GetMemberOfParliamentByConstituencyQueryHandler(
        IConstituencyRepository constituencyRepository,
        IMapper mapper,
        ICacheService cacheService)
        : IRequestHandler<GetMemberOfParliamentByConstituencyQuery, MemberOfParliament?>
    {
        public async Task<MemberOfParliament?> Handle(GetMemberOfParliamentByConstituencyQuery request, CancellationToken cancellationToken)
        {
            var cacheKey = $"MemberOfParliament_{CacheKeyHelper.GenerateHashedCacheKey(request.ConstituencyName)}";

            var methodName = nameof(GetMemberOfParliamentByConstituencyQueryHandler);

            return await cacheService.GetOrAddAsync(cacheKey, async () =>
            {
                var constituencyWithMember = await constituencyRepository
                    .GetMemberOfParliamentByConstituencyAsync(request.ConstituencyName, cancellationToken);

                var result = mapper.Map<MemberOfParliament?>(constituencyWithMember);

                return result;
            }, methodName);
        }
    }
}
