using AutoMapper;
using AutoMapper.QueryableExtensions;
using Dfe.Academies.Application.Common.Interfaces;
using Dfe.Academies.Application.Common.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Dfe.Academies.Application.Establishment.Queries.GetAllPersonsAssociatedWithAcademyByUrn
{
    public record GetAllPersonsAssociatedWithAcademyByUrnQuery(int Urn) : IRequest<List<AcademyGovernance>>;

    public class GetAllPersonsAssociatedWithAcademyByUrnQueryHandler : IRequestHandler<GetAllPersonsAssociatedWithAcademyByUrnQuery, List<AcademyGovernance>>
    {
        private readonly IEstablishmentRepository _establishmentRepository;
        private readonly IMapper _mapper;
        private readonly ICacheService _cacheService;

        public GetAllPersonsAssociatedWithAcademyByUrnQueryHandler(
            IEstablishmentRepository establishmentRepository,
            IMapper mapper,
            ICacheService cacheService)
        {
            _establishmentRepository = establishmentRepository;
            _mapper = mapper;
            _cacheService = cacheService;
        }

        public async Task<List<AcademyGovernance>?> Handle(GetAllPersonsAssociatedWithAcademyByUrnQuery request, CancellationToken cancellationToken)
        {
            string cacheKey = $"PersonsAssociatedWithAcademy_{request.Urn}";
            string methodName = nameof(GetAllPersonsAssociatedWithAcademyByUrnQueryHandler);

            return await _cacheService.GetOrAddAsync(cacheKey, async () =>
            {
                var query = _establishmentRepository.GetPersonsAssociatedWithAcademyByUrn(request.Urn);

                if (query == null)
                {
                    return null;
                }

                var result = await query
                    .ProjectTo<AcademyGovernance>(_mapper.ConfigurationProvider)
                    .ToListAsync(cancellationToken);

                return result;
            }, methodName);
        }
    }
}
