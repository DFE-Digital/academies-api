using Dfe.Academies.Contracts.Establishments;
using Dfe.Academies.Domain.Establishment;

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

            return establishment == null ? null : new EstablishmentDto()
            {
                Name = establishment.EstablishmentName,
                Urn = establishment?.URN.ToString() ?? string.Empty, // To question
                LocalAuthorityCode = establishment?.FK_LocalAuthority.ToString() ?? string.Empty, // To question
                LocalAuthorityName = establishment?.FK_LocalAuthority.ToString() ?? string.Empty, // To question/we're missing it's name unless the above is it
                OfstedRating = establishment.OfstedRating,
                OfstedLastInspection = establishment.OfstedLastInspection,
                StatutoryLowAge = establishment.StatutoryLowAge,
                StatutoryHighAge = establishment.StatutoryHighAge,
                SchoolCapacity = establishment.SchoolCapacity,
                Pfi = establishment.SchoolCapacity, // Not available
                EstablishmentNumber = establishment?.EstablishmentNumber.ToString() ?? string.Empty,
                Diocese = new NameAndCodeDto
                {
                    Name = establishment.Diocese,
                    Code = establishment.Diocese // No Code
                },
                // There is no type, just a FK to a type
                //EstablishmentType = new NameAndCodeDto
                //{
                //    Name = establishment.FK_EstablishmentType,
                //    Code = establishment.FK_EstablishmentType // No Code
                //},
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
                Address = new AddressDto()
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
