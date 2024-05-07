using Dfe.Academies.Contracts.V4.Establishments;
using Dfe.Academies.Domain.Census;
using Dfe.Academies.Domain.Establishment;
using Dfe.Academies.Domain.Trust;

namespace Dfe.Academies.Application.Establishment
{
    public class EstablishmentQueries : IEstablishmentQueries
    {
        private readonly IEstablishmentRepository _establishmentRepository;
        private readonly ITrustRepository _trustRepository;
        private readonly ICensusDataRepository _censusDataRepository;

        public EstablishmentQueries(IEstablishmentRepository establishmentRepository, ITrustRepository trustRepository, ICensusDataRepository censusDataRepository)
        {
            _establishmentRepository = establishmentRepository;
            _trustRepository = trustRepository;
            _censusDataRepository = censusDataRepository;
        }

        public async Task<EstablishmentDto?> GetByUkprn(string ukprn, CancellationToken cancellationToken)
        {
            var establishment = await _establishmentRepository.GetEstablishmentByUkprn(ukprn, cancellationToken);

            if (establishment == null)
            {
                return null;
            }

            return MapToEstablishmentDto(establishment);
        }

        public async Task<EstablishmentDto?> GetByUrn(string urn, CancellationToken cancellationToken)
        {
            var establishment = await _establishmentRepository.GetEstablishmentByUrn(urn, cancellationToken);

            if (establishment == null)
            {
                return null;
            }

            return MapToEstablishmentDto(establishment);
        }

        public async Task<(List<EstablishmentDto>, int)> Search(string name, string ukPrn, string urn, CancellationToken cancellationToken)
        {
            var establishments = await _establishmentRepository.Search(name, ukPrn, urn, cancellationToken);

            return (establishments.Select(x => MapToEstablishmentDto(x)).ToList(), establishments.Count);
        }

        public async Task<IEnumerable<int>> GetURNsByRegion(string[] regions, CancellationToken cancellationToken)
        {
            var urns = await _establishmentRepository.GetURNsByRegion(regions, cancellationToken);

            return urns;
        }

        public async Task<List<EstablishmentDto>> GetByTrust(string trustUkprn, CancellationToken cancellationToken)
        {
            var trust = await _trustRepository.GetTrustByUkprn(trustUkprn, cancellationToken);

            if (trust == null)
            {
                return new List<EstablishmentDto>();
            }

            var establishments = await _establishmentRepository.GetByTrust(trust.SK, cancellationToken).ConfigureAwait(false);
            return establishments.Select(x => MapToEstablishmentDto(x)).ToList();
        }

        public async Task<List<EstablishmentDto>> GetByUrns(int[] Urns, CancellationToken cancellationToken)
        {
            var establishments = await _establishmentRepository.GetByUrns(Urns, cancellationToken).ConfigureAwait(false);

            return establishments.Select(x => MapToEstablishmentDto(x)).ToList();
        }

        public async Task<List<EstablishmentDto>> GetByUkprns(string[] Ukprns, CancellationToken cancellationToken)
        {
            var establishments = await _establishmentRepository.GetByUkprns(Ukprns, cancellationToken).ConfigureAwait(false);

            return establishments.Select(x => MapToEstablishmentDto(x)).ToList();
        }

        private EstablishmentDto MapToEstablishmentDto(Domain.Establishment.Establishment establishment)
        {
            var censusData = _censusDataRepository.GetCensusDataByURN(establishment.URN.Value);

            var result = new EstablishmentDtoBuilder()
                .WithBasicDetails(establishment)
                .WithLocalAuthority(establishment)
                .WithDiocese(establishment)
                .WithEstablishmentType(establishment)
                .WithGor(establishment)
                .WithPhaseOfEducation(establishment)
                .WithReligiousCharacter(establishment)
                .WithParliamentaryConstituency(establishment)
                .WithCensus(establishment, censusData)
                .WithMISEstablishment(establishment)
                .WithAddress(establishment)
                .Build();

            return result;
        }
    }
}
