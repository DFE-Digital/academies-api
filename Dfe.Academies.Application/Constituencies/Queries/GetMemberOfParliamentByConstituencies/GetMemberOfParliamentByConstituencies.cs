using AutoMapper;
using AutoMapper.QueryableExtensions;
using Dfe.Academies.Application.Common.Models;
using Dfe.Academies.Domain.Interfaces.Caching;
using Dfe.Academies.Domain.Interfaces.Repositories;
using Dfe.Academies.Utils.Caching;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Dfe.Academies.Application.Constituencies.Queries.GetMemberOfParliamentByConstituencies
{
    public record GetMembersOfParliamentByConstituenciesQuery(List<string> ConstituencyNames) : IRequest<List<MemberOfParliament>>;

    public class GetMembersOfParliamentByConstituenciesQueryHandler(
        IConstituencyRepository constituencyRepository,
        IMapper mapper,
        ICacheService cacheService)
        : IRequestHandler<GetMembersOfParliamentByConstituenciesQuery, List<MemberOfParliament>>
    {
        public async Task<List<MemberOfParliament>> Handle(GetMembersOfParliamentByConstituenciesQuery request, CancellationToken cancellationToken)
        {
            var cacheKey = $"MemberOfParliament_{CacheKeyHelper.GenerateHashedCacheKey(request.ConstituencyNames)}";

            var methodName = nameof(GetMembersOfParliamentByConstituenciesQueryHandler);

            return await cacheService.GetOrAddAsync(cacheKey, async () =>
            {
                var constituenciesQuery = constituencyRepository
                    .GetMembersOfParliamentByConstituenciesQueryable(request.ConstituencyNames);

                var membersOfParliament = await constituenciesQuery
                    .ProjectTo<MemberOfParliament>(mapper.ConfigurationProvider)
                    .ToListAsync(cancellationToken);

                return membersOfParliament;
            }, methodName);
        }
    }

}
