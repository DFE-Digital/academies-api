using Dfe.Academies.Contracts.V4.Establishments;
using Dfe.Academies.Domain.Establishment;

using Dfe.Academies.Application.Builders;

namespace Dfe.Academies.Application.Queries.Establishment
{
    public class EstablishmentQueries : IEstablishmentQueries
    {
        private readonly IEstablishmentRepository _establishmentRepository;

        public EstablishmentQueries(IEstablishmentRepository establishmentRepository)
        {
            _establishmentRepository = establishmentRepository;
        }
        public async Task<EstablishmentDto?> GetByUkprn(string ukprn, CancellationToken cancellationToken)
        {
            var establishment = await _establishmentRepository.GetEstablishmentByUkprn(ukprn, cancellationToken).ConfigureAwait(false);
            return establishment == null ? null : MapToEstablishmentDto(establishment);
        }
        public async Task<EstablishmentDto?> GetByUrn(string urn, CancellationToken cancellationToken)
        {
            var establishment = await _establishmentRepository.GetEstablishmentByUrn(urn, cancellationToken).ConfigureAwait(false);
            return establishment == null ? null : MapToEstablishmentDto(establishment);
        }
        public async Task<(List<EstablishmentDto>, int)> Search(string name, string ukPrn, string urn, CancellationToken cancellationToken)
        {
            var establishments = await _establishmentRepository.Search(name, ukPrn, urn, cancellationToken).ConfigureAwait(false);

            return (establishments.Select(x => MapToEstablishmentDto(x)).ToList(), establishments.Count);
        }
        public async Task<IEnumerable<int>> GetURNsByRegion(string[] regions, CancellationToken cancellationToken)
        {
            var URNs = await _establishmentRepository.GetURNsByRegion(regions, cancellationToken).ConfigureAwait(false);

            return URNs;
        }
        public async Task<List<EstablishmentDto>> GetByUrns(int[] Urns, CancellationToken cancellationToken)
        {
            var establishments = await _establishmentRepository.GetByUrns(Urns, cancellationToken).ConfigureAwait(false);

            return (establishments.Select(x => MapToEstablishmentDto(x)).ToList());
        }

        private static EstablishmentDto MapToEstablishmentDto(Domain.Establishment.Establishment? establishment)
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
                .WithCensus(establishment)
                .WithMISEstablishment(establishment)
                .WithAddress(establishment)
                .Build();
        }
    }
}
