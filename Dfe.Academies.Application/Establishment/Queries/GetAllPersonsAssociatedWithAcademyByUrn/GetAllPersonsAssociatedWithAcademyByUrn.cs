using AutoMapper;
using AutoMapper.QueryableExtensions;
using Dfe.Academies.Application.Models;
using Dfe.Academies.Domain.Caching;
using Dfe.Academies.Domain.Establishment;
using Dfe.Academies.Domain.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Dfe.Academies.Application.Establishment.Queries.GetAllPersonsAssociatedWithAcademyByUrn
{
    public record GetAllPersonsAssociatedWithAcademyByUrnQuery(int Urn) : IRequest<List<AcademyGovernance>>;

    public class GetAllPersonsAssociatedWithAcademyByUrnQueryHandler : IRequestHandler<GetAllPersonsAssociatedWithAcademyByUrnQuery, List<AcademyGovernance>>
    {
        private readonly IMopRepository<Domain.Establishment.Establishment> _establishmentRepository;
        private readonly IMopRepository<EducationEstablishmentGovernance> _governanceRepository;
        private readonly IMopRepository<GovernanceRoleType> _governanceRoleTypeRepository;
        private readonly IMapper _mapper;
        private readonly ICacheService _cacheService;

        public GetAllPersonsAssociatedWithAcademyByUrnQueryHandler(
            IMopRepository<Domain.Establishment.Establishment> establishmentRepository,
            IMopRepository<EducationEstablishmentGovernance> governanceRepository,
            IMopRepository<GovernanceRoleType> governanceRoleTypeRepository,
            IMapper mapper,
            ICacheService cacheService)
        {
            _establishmentRepository = establishmentRepository;
            _governanceRepository = governanceRepository;
            _governanceRoleTypeRepository = governanceRoleTypeRepository;
            _mapper = mapper;
            _cacheService = cacheService;
        }

        public async Task<List<AcademyGovernance>> Handle(GetAllPersonsAssociatedWithAcademyByUrnQuery request, CancellationToken cancellationToken)
        {
            string cacheKey = $"PersonsAssociatedWithAcademy_{request.Urn}";
            string methodName = nameof(GetAllPersonsAssociatedWithAcademyByUrnQuery);

            return await _cacheService.GetOrAddAsync(cacheKey, async () =>
            {
                var query = from ee in _establishmentRepository.Query()
                            join eeg in _governanceRepository.Query()
                                on ee.SK equals eeg.EducationEstablishmentId
                            join grt in _governanceRoleTypeRepository.Query()
                                on eeg.GovernanceRoleTypeId equals grt.SK
                            where ee.URN == request.Urn
                            select new AcademyWithGovernanceDetails(eeg, grt, ee);

                var result = await query
                    .ProjectTo<AcademyGovernance>(_mapper.ConfigurationProvider)
                    .ToListAsync(cancellationToken);

                return result;
            }, methodName);
        }
    }
}
