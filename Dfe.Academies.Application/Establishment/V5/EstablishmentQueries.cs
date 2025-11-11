using Dfe.Academies.Domain.Interfaces.Repositories;
using GovUK.Dfe.CoreLibs.Contracts.Academies.V5.Establishments;

namespace Dfe.Academies.Application.Establishment.V5
{
    public class EstablishmentQueries(IEstablishmentRepository establishmentRepository, ICensusDataRepository censusDataRepository) : IEstablishmentQueries
    {
        public async Task<(List<EstablishmentDto>, int)> Search(string name, string ukPrn, string urn, bool? excludeClosed, bool? matchAny, CancellationToken cancellationToken)
        {
            var establishments = await establishmentRepository.Search(name, ukPrn, urn, excludeClosed, matchAny, cancellationToken);

            return (establishments.Select(MapToEstablishmentDto).ToList(), establishments.Count);
        }  
        private EstablishmentDto MapToEstablishmentDto(Domain.Establishment.Establishment establishment)
        {
            var censusData = censusDataRepository.GetCensusDataByURN(establishment.URN.GetValueOrDefault());
            var reportCard = establishmentRepository.GetMockReportCardsByURN(establishment.URN);
            var misEstablishment = establishmentRepository.GetMisEstablishmentByURN(establishment.URN);
            var previousEstablishment = establishmentRepository.GetEducationEstablishmentLinksByURN(establishment.SK);
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
                .WithMISEstablishment(misEstablishment!)
                .WithAddress(establishment)
                .WithPreviousEstablishment(previousEstablishment)
                .WithMockReportCards(reportCard!)
                .Build();

            return result;
        }
    }
}
