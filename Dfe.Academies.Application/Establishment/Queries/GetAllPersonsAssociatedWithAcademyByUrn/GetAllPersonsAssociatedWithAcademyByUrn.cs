using AutoMapper;
using Dfe.Academies.Application.Common.Interfaces;
using Dfe.Academies.Application.Common.Models;
using Dfe.Academies.Domain.Interfaces.Caching;
using Dfe.Academies.Utils.Caching;
using MediatR;

namespace Dfe.Academies.Application.Establishment.Queries.GetAllPersonsAssociatedWithAcademyByUrn
{
    public record GetAllPersonsAssociatedWithAcademyByUrnQuery(int Urn) : IRequest<List<AcademyGovernance>>;

    public class GetAllPersonsAssociatedWithAcademyByUrnQueryHandler(
        IEstablishmentRepository establishmentRepository,
        IMapper mapper,
        ICacheService cacheService)
        : IRequestHandler<GetAllPersonsAssociatedWithAcademyByUrnQuery, List<AcademyGovernance>>
    {
        public async Task<List<AcademyGovernance>?> Handle(GetAllPersonsAssociatedWithAcademyByUrnQuery request, CancellationToken cancellationToken)
        {
            var cacheKey = $"PersonsAssociatedWithAcademy_{CacheKeyHelper.GenerateHashedCacheKey(request.Urn.ToString())}";

            var methodName = nameof(GetAllPersonsAssociatedWithAcademyByUrnQueryHandler);

            return await cacheService.GetOrAddAsync(cacheKey, async () =>
            {
                var establishment = await establishmentRepository.GetPersonsAssociatedWithAcademyByUrnAsync(request.Urn, cancellationToken);

                if (establishment == null)
                {
                    return null;
                }

                var result = mapper.Map<List<AcademyGovernance>>(establishment);


                return result;
            }, methodName);
        }
    }
}
