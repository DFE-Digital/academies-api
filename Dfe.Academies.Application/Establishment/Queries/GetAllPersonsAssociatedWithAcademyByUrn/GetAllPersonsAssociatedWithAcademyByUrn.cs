using AutoMapper;
using AutoMapper.QueryableExtensions;
using Dfe.Academies.Application.Common.Interfaces;
using Dfe.Academies.Application.Common.Models;
using Dfe.Academies.Domain.Interfaces.Caching;
using Dfe.Academies.Utils.Caching;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Dfe.Academies.Application.Establishment.Queries.GetAllPersonsAssociatedWithAcademyByUrn
{
    public record GetAllPersonsAssociatedWithAcademyByUrnQuery(int Urn) : IRequest<List<AcademyGovernance>?>;

    public class GetAllPersonsAssociatedWithAcademyByUrnQueryHandler(
        IEstablishmentQueryService establishmentQueryService,
        IMapper mapper,
        ICacheService cacheService)
        : IRequestHandler<GetAllPersonsAssociatedWithAcademyByUrnQuery, List<AcademyGovernance>?>
    {
        public async Task<List<AcademyGovernance>?> Handle(GetAllPersonsAssociatedWithAcademyByUrnQuery request, CancellationToken cancellationToken)
        {
            var cacheKey = $"PersonsAssociatedWithAcademy_{CacheKeyHelper.GenerateHashedCacheKey(request.Urn.ToString())}";

            var methodName = nameof(GetAllPersonsAssociatedWithAcademyByUrnQueryHandler);

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
            }, methodName);
        }
    }
}
