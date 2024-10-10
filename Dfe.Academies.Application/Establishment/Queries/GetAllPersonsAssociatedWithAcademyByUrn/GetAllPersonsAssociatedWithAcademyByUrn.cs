using AutoMapper;
using AutoMapper.QueryableExtensions;
using Dfe.Academies.Application.Common.Interfaces;
using Dfe.Academies.Application.Common.Models;
using DfE.CoreLibs.Caching.Helpers;
using DfE.CoreLibs.Caching.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Dfe.Academies.Application.Establishment.Queries.GetAllPersonsAssociatedWithAcademyByUrn
{
    public record GetAllPersonsAssociatedWithAcademyByUrnQuery(int Urn) : IRequest<List<AcademyGovernance>?>;

    public class GetAllPersonsAssociatedWithAcademyByUrnQueryHandler(
        IEstablishmentQueryService establishmentQueryService,
        IMapper mapper,
        ICacheService<IMemoryCacheType> cacheService)
        : IRequestHandler<GetAllPersonsAssociatedWithAcademyByUrnQuery, List<AcademyGovernance>?>
    {
        public async Task<List<AcademyGovernance>?> Handle(GetAllPersonsAssociatedWithAcademyByUrnQuery request, CancellationToken cancellationToken)
        {
            var cacheKey = $"PersonsAssociatedWithAcademy_{CacheKeyHelper.GenerateHashedCacheKey(request.Urn.ToString())}";

            return await cacheService.GetOrAddAsync(cacheKey, async () =>
            {
                var query = establishmentQueryService.GetPersonsAssociatedWithAcademyByUrn(request.Urn);

                if (query == null)
                {
                    return null;
                }

                var result = await query
                    .ProjectTo<AcademyGovernance>(mapper.ConfigurationProvider)
                    .ToListAsync(cancellationToken);

                return result;
            }, nameof(GetAllPersonsAssociatedWithAcademyByUrnQueryHandler));
        }
    }
}
