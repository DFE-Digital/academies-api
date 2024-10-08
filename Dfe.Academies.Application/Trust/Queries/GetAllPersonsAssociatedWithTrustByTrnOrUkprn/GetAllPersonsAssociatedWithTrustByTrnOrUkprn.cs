﻿using AutoMapper;
using AutoMapper.QueryableExtensions;
using Dfe.Academies.Application.Common.Interfaces;
using Dfe.Academies.Application.Common.Models;
using Dfe.Academies.Utils.Enums;
using Dfe.Academies.Utils.Helpers;
using DfE.CoreLibs.Caching.Helpers;
using DfE.CoreLibs.Caching.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Dfe.Academies.Application.Trust.Queries.GetAllPersonsAssociatedWithTrustByTrnOrUkprn
{
    public record GetAllPersonsAssociatedWithTrustByTrnOrUkprnQuery(string Id) : IRequest<List<TrustGovernance>?>;

    public class GetAllPersonsAssociatedWithTrustByTrnOrUkprnQueryHandler(
        ITrustQueryService trustQueryService,
        IMapper mapper,
        ICacheService<IMemoryCacheType> cacheService)
        : IRequestHandler<GetAllPersonsAssociatedWithTrustByTrnOrUkprnQuery, List<TrustGovernance>?>
    {
        public async Task<List<TrustGovernance>?> Handle(GetAllPersonsAssociatedWithTrustByTrnOrUkprnQuery request, CancellationToken cancellationToken)
        {
            var idType = IdentifierHelper<string, TrustIdType>.DetermineIdType(request.Id, TrustIdValidator.GetTrustIdValidators());

            var groupId = idType == TrustIdType.Trn ? request.Id : null;
            var ukPrn = idType == TrustIdType.UkPrn ? request.Id : null;

            var cacheKey = $"PersonsAssociatedWithTrust_{CacheKeyHelper.GenerateHashedCacheKey(request.Id)}";

            return await cacheService.GetOrAddAsync(cacheKey, async () =>
            {
                var query = trustQueryService.GetTrustGovernanceByGroupIdOrUkprn(groupId, ukPrn);

                return query == null
                    ? null
                    : await query
                        .ProjectTo<TrustGovernance>(mapper.ConfigurationProvider)
                        .ToListAsync(cancellationToken);
            }, nameof(GetAllPersonsAssociatedWithTrustByTrnOrUkprnQueryHandler));
        }
    }
}
