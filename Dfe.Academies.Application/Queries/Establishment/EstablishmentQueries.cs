using Dfe.Academies.Contracts.V4.Establishments;
using Dfe.Academies.Domain.Establishment;

using Dfe.Academies.Application.Builders;
using Dfe.Academies.Domain.Trust;
using Dfe.Academies.Domain.Census;

namespace Dfe.Academies.Application.Queries.Establishment
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
            var establishment = await _establishmentRepository.GetEstablishmentByUkprn(ukprn, cancellationToken).ConfigureAwait(false);
            var censusData = this._censusDataRepository.GetCensusDataByURN(establishment.URN.Value);

            return establishment == null ? null : MapToEstablishmentDto(establishment, censusData);
        }
        public async Task<EstablishmentDto?> GetByUrn(string urn, CancellationToken cancellationToken)
        {
            var establishment = await _establishmentRepository.GetEstablishmentByUrn(urn, cancellationToken).ConfigureAwait(false);
            var censusData = this._censusDataRepository.GetCensusDataByURN(establishment.URN.Value);

            return establishment == null ? null : MapToEstablishmentDto(establishment, censusData);
        }
        public async Task<(List<EstablishmentDto>, int)> Search(string name, string ukPrn, string urn, CancellationToken cancellationToken)
        {
            var establishments = await _establishmentRepository.Search(name, ukPrn, urn, cancellationToken).ConfigureAwait(false);

            return (establishments.Select(x => MapToEstablishmentDto(x, _censusDataRepository.GetCensusDataByURN(x.URN.Value))).ToList(), establishments.Count);
        }
        public async Task<IEnumerable<int>> GetURNsByRegion(string[] regions, CancellationToken cancellationToken)
        {
            var URNs = await _establishmentRepository.GetURNsByRegion(regions, cancellationToken).ConfigureAwait(false);

            return URNs;
        }
        public async Task<List<EstablishmentDto>> GetByTrust(string trustUkprn, CancellationToken cancellationToken)
        {
            var trust = await _trustRepository.GetTrustByUkprn(trustUkprn, cancellationToken);
            var establishments = await _establishmentRepository.GetByTrust(trust.SK, cancellationToken).ConfigureAwait(false);
            return establishments.Select(x => MapToEstablishmentDto(x, _censusDataRepository.GetCensusDataByURN(x.URN.Value))).ToList();
        }
        public async Task<List<EstablishmentDto>> GetByUrns(int[] Urns, CancellationToken cancellationToken)
        {
            var establishments = await _establishmentRepository.GetByUrns(Urns, cancellationToken).ConfigureAwait(false);

            return (establishments.Select(x => MapToEstablishmentDto(x, _censusDataRepository.GetCensusDataByURN(x.URN.Value))).ToList());
        }

        private static EstablishmentDto MapToEstablishmentDto(Domain.Establishment.Establishment? establishment, CensusData censusData)
        {
            return new EstablishmentDtoBuilder()
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
        }
    }
}
