using Dfe.Academies.Contracts.Establishments;
using Dfe.Academies.Contracts.Trusts;
using Dfe.Academies.Domain.Establishment;
using System.Threading;
using System;

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
        public async Task<IEnumerable<int>> GetURNsByRegion(ICollection<string> regions, CancellationToken cancellationToken)
        {
            var URNs = await _establishmentRepository.GetURNsByRegion(regions, cancellationToken).ConfigureAwait(false);

            return URNs;
        }
        public async Task<List<EstablishmentDto>> GetByUrns(int[] Urns)
        {
            var establishments = await _establishmentRepository.GetByUrns(Urns).ConfigureAwait(false);

            return (establishments.Select(x => MapToEstablishmentDto(x)).ToList());
        }

        private static EstablishmentDto MapToEstablishmentDto(Domain.Establishment.Establishment? establishment)
        {
            return new EstablishmentDto()
            {
                Name = establishment.EstablishmentName,
                Urn = establishment?.URN.ToString() ?? string.Empty,
                LocalAuthorityCode = establishment?.LocalAuthority.Code ?? string.Empty,
                LocalAuthorityName = establishment?.LocalAuthority.Name ?? string.Empty, 
                OfstedRating = establishment.OfstedRating,
                OfstedLastInspection = establishment.OfstedLastInspection,
                StatutoryLowAge = establishment.StatutoryLowAge,
                StatutoryHighAge = establishment.StatutoryHighAge,
                SchoolCapacity = establishment.SchoolCapacity,
                Pfi = establishment.IfdPipeline.DeliveryProcessPFI,
                EstablishmentNumber = establishment?.EstablishmentNumber.ToString() ?? string.Empty,
                Diocese = new NameAndCodeDto
                {
                    Name = establishment.Diocese,
                    Code = establishment.Diocese // No Code
                },
                EstablishmentType = new NameAndCodeDto
                {
                    Name = establishment.EstablishmentType.Name,
                    Code = establishment.EstablishmentType.Code
                },
                Gor = new NameAndCodeDto
                {
                    Name = establishment.GORregion, // This is all we have, may or may not align 
                    Code = establishment.GORregion // No Code
                },
                PhaseOfEducation = new NameAndCodeDto
                {
                    Name = establishment.PhaseOfEducation,
                    Code = establishment.PhaseOfEducation // No Code
                },
                ReligiousCharacter = new NameAndCodeDto
                {
                    Name = establishment.ReligiousCharacter,
                    Code = establishment.ReligiousCharacter // No Code
                },
                ParliamentaryConstituency = new NameAndCodeDto
                {
                    Name = establishment.ParliamentaryConstituency,
                    Code = establishment.ParliamentaryConstituency // No Code
                },
                Census = new CensusDto
                {
                    NumberOfPupils = establishment.NumberOfPupils,
                    PercentageFsm = establishment.PercentageFSM
                },
                MISEstablishment = new MisEstablishmentDto
                {
                    DateOfLatestSection8Inspection = establishment.DateOfLatestShortInspection.ToString(), // May not be correct
                    InspectionEndDate = establishment.InspectionEndDate.ToString(),
                    OverallEffectiveness = establishment.OverallEffectiveness.ToString(),
                    QualityOfEducation = establishment.QualityOfEducation.ToString(),
                    BehaviourAndAttitudes = establishment.BehaviourAndAttitudes.ToString(),
                    PersonalDevelopment = establishment.PersonalDevelopment.ToString(),
                    EffectivenessOfLeadershipAndManagement = establishment.EffectivenessOfLeadershipAndManagement.ToString(),
                    EarlyYearsProvision = establishment.EarlyYearsProvisionWhereApplicable.ToString(),
                    SixthFormProvision = establishment.SixthFormProvisionWhereApplicable.ToString(),
                    Weblink = establishment.Website,
                },
                Address = new Contracts.Establishments.AddressDto()
                {
                    Street = establishment.AddressLine1,
                    Town = establishment.Town,
                    Postcode = establishment.Postcode,
                    County = establishment.County,
                    Additional = establishment.AddressLine2,
                    Locality = establishment.AddressLine3
                }
            };
        }
    }
}
