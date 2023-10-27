using Dfe.Academies.Contracts.Establishments;

namespace Dfe.Academies.Application.Builders
{
    public class EstablishmentDtoBuilder
    {
        private EstablishmentDto _dto = new EstablishmentDto();

        public EstablishmentDtoBuilder WithBasicDetails(Domain.Establishment.Establishment establishment)
        {
            _dto.Name = establishment?.EstablishmentName;
            _dto.Urn = establishment?.URN.ToString() ?? string.Empty;
            _dto.OfstedRating = establishment?.OfstedRating;
            _dto.OfstedLastInspection = establishment?.OfstedLastInspection;
            _dto.StatutoryLowAge = establishment?.StatutoryLowAge;
            _dto.StatutoryHighAge = establishment?.StatutoryHighAge;
            _dto.SchoolCapacity = establishment?.SchoolCapacity;
            _dto.Pfi = establishment?.IfdPipeline?.DeliveryProcessPFI;
            _dto.EstablishmentNumber = establishment?.EstablishmentNumber.ToString() ?? string.Empty;

            return this;
        }

        public EstablishmentDtoBuilder WithLocalAuthority(Domain.Establishment.Establishment establishment)
        {
            _dto.LocalAuthorityCode = establishment?.LocalAuthority?.Code ?? string.Empty;
            _dto.LocalAuthorityName = establishment?.LocalAuthority?.Name ?? string.Empty;

            return this;
        }

        public EstablishmentDtoBuilder WithDiocese(Domain.Establishment.Establishment establishment)
        {
            _dto.Diocese = new NameAndCodeDto
            {
                Name = establishment?.Diocese,
                Code = establishment?.Diocese // No Code
            };

            return this;
        }

        public EstablishmentDtoBuilder WithEstablishmentType(Domain.Establishment.Establishment establishment)
        {
            _dto.EstablishmentType = new NameAndCodeDto
            {
                Name = establishment?.EstablishmentType?.Name,
                Code = establishment?.EstablishmentType?.Code
            };

            return this;
        }

        public EstablishmentDtoBuilder WithGor(Domain.Establishment.Establishment establishment)
        {
            _dto.Gor = new NameAndCodeDto
            {
                Name = establishment?.GORregion,
                Code = establishment?.GORregion // No Code
            };

            return this;
        }

        public EstablishmentDtoBuilder WithPhaseOfEducation(Domain.Establishment.Establishment establishment)
        {
            _dto.PhaseOfEducation = new NameAndCodeDto
            {
                Name = establishment?.PhaseOfEducation,
                Code = establishment?.PhaseOfEducation // No Code
            };

            return this;
        }

        public EstablishmentDtoBuilder WithReligiousCharacter(Domain.Establishment.Establishment establishment)
        {
            _dto.ReligiousCharacter = new NameAndCodeDto
            {
                Name = establishment.ReligiousCharacter,
                Code = establishment.ReligiousCharacter // No Code
            };

            return this;
        }
        public EstablishmentDtoBuilder WithParliamentaryConstituency(Domain.Establishment.Establishment establishment)
        {
            _dto.ParliamentaryConstituency = new NameAndCodeDto
            {
                Name = establishment.ParliamentaryConstituency,
                Code = establishment.ParliamentaryConstituency // No Code
            };

            return this;
        }
        public EstablishmentDtoBuilder WithCensus(Domain.Establishment.Establishment establishment)
        {
            _dto.Census = new CensusDto
            {
                NumberOfPupils = establishment.NumberOfPupils,
                PercentageFsm = establishment.PercentageFSM
            };

            return this;
        }

        public EstablishmentDtoBuilder WithMISEstablishment(Domain.Establishment.Establishment establishment)
        {
            _dto.MISEstablishment = new MisEstablishmentDto
            {
                DateOfLatestSection8Inspection = establishment?.DateOfLatestShortInspection?.ToString(),
                InspectionEndDate = establishment?.InspectionEndDate?.ToString(),
                OverallEffectiveness = establishment?.OverallEffectiveness?.ToString(),
                QualityOfEducation = establishment?.QualityOfEducation?.ToString(),
                BehaviourAndAttitudes = establishment?.BehaviourAndAttitudes?.ToString(),
                PersonalDevelopment = establishment?.PersonalDevelopment?.ToString(),
                EffectivenessOfLeadershipAndManagement = establishment?.EffectivenessOfLeadershipAndManagement?.ToString(),
                EarlyYearsProvision = establishment?.EarlyYearsProvisionWhereApplicable?.ToString(),
                SixthFormProvision = establishment?.SixthFormProvisionWhereApplicable?.ToString(),
                Weblink = establishment?.Website
            };

            return this;
        }

        public EstablishmentDtoBuilder WithAddress(Domain.Establishment.Establishment establishment)
        {
            _dto.Address = new Contracts.Trusts.AddressDto()
            {
                Street = establishment?.AddressLine1,
                Town = establishment?.Town,
                Postcode = establishment?.Postcode,
                County = establishment?.County,
                Additional = establishment?.AddressLine2,
                Locality = establishment?.AddressLine3
            };

            return this;
        }

        public EstablishmentDto Build()
        {
            return _dto;
        }
    }
}

