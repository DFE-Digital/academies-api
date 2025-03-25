using Dfe.Academies.Domain.Census;
using Dfe.Academies.Domain.Establishment;
using Dfe.Academies.Utils.Extensions;
using DfE.CoreLibs.Contracts.Academies.V4;
using DfE.CoreLibs.Contracts.Academies.V4.Establishments;

namespace Dfe.Academies.Application.Establishment
{
    public class EstablishmentDtoBuilder
    {
        private EstablishmentDto _dto = new EstablishmentDto();

        public EstablishmentDtoBuilder WithBasicDetails(Domain.Establishment.Establishment establishment)
        {
            _dto.Ukprn = establishment?.UKPRN;
            _dto.NoOfBoys = establishment?.NumberOfBoys.ToString();
            _dto.NoOfGirls = establishment?.NumberOfGirls.ToString();
            _dto.GiasLastChangedDate = establishment?.GiasLastChangedDate.ToResponseDate();
            _dto.ReligousEthos = establishment?.ReligiousEthos;
            _dto.SenUnitCapacity = establishment?.SenUnitCapacity.ToString();
            _dto.SenUnitOnRoll = establishment?.SenUnitOnRoll.ToString();
            _dto.Name = establishment?.EstablishmentName;
            _dto.Urn = establishment?.URN.ToString() ?? string.Empty;
            _dto.OfstedRating = establishment?.OfstedRating;
            _dto.OfstedLastInspection = establishment?.OfstedLastInspection;
            _dto.StatutoryLowAge = establishment?.StatutoryLowAge;
            _dto.StatutoryHighAge = establishment?.StatutoryHighAge;
            _dto.SchoolCapacity = establishment?.SchoolCapacity;
            _dto.Pfi = establishment?.IfdPipeline?.DeliveryProcessPFI;
            _dto.EstablishmentNumber = establishment?.EstablishmentNumber.ToString() ?? string.Empty;
            _dto.Pan = establishment?.IfdPipeline?.DeliveryProcessPAN;
            _dto.Deficit = establishment?.IfdPipeline?.ProjectTemplateInformationDeficit;
            _dto.ViabilityIssue = establishment?.IfdPipeline?.ProjectTemplateInformationViabilityIssue;

            _dto.HeadteacherTitle = establishment.HeadTitle;
            _dto.HeadteacherFirstName = establishment.HeadFirstName;
            _dto.HeadteacherLastName = establishment.HeadLastName;
            _dto.HeadteacherPreferredJobTitle = establishment.HeadPreferredJobTitle;

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
                Code = establishment?.DioceseCode
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
                Code = establishment?.GORregionCode
            };

            return this;
        }

        public EstablishmentDtoBuilder WithPhaseOfEducation(Domain.Establishment.Establishment establishment)
        {
            _dto.PhaseOfEducation = new NameAndCodeDto
            {
                Name = establishment?.PhaseOfEducation,
                Code = establishment?.PhaseOfEducationCode.ToString()
            };

            return this;
        }

        public EstablishmentDtoBuilder WithReligiousCharacter(Domain.Establishment.Establishment establishment)
        {
            _dto.ReligiousCharacter = new NameAndCodeDto
            {
                Name = establishment.ReligiousCharacter,
                Code = establishment.ReligiousCharacterCode
            };

            return this;
        }
        public EstablishmentDtoBuilder WithParliamentaryConstituency(Domain.Establishment.Establishment establishment)
        {
            _dto.ParliamentaryConstituency = new NameAndCodeDto
            {
                Name = establishment.ParliamentaryConstituency,
                Code = establishment.ParliamentaryConstituencyCode
            };

            return this;
        }
        public EstablishmentDtoBuilder WithCensus(Domain.Establishment.Establishment establishment, CensusData censusData)
        {
            // census field descriptions
            //URN School - Unique Reference Number
            //LA  - LA number
            //ESTAB - ESTAB number
            //SCHOOLTYPE  - Type of school
            //NOR - Total number of pupils on roll
            //NORG - Number of girls on roll
            //NORB - Number of boys on roll
            //PNORG - Percentage of girls on roll
            //PNORB - Percentage of boys on roll
            //TSENELSE - Number of SEN pupils with an EHC plan
            //PSENELSE  -   Percentage of SEN pupils with an EHC plan
            //TSENELK - Number of eligible pupils with SEN support
            //PSENELK - Percentage of eligible pupils with SEN support
            //NUMEAL - No.  pupils where English not first language
            //NUMENGFL - No. pupils with English first language
            //NUMUNCFL -   No.pupils where first language is unclassified
            //PNUMEAL - % pupils where English not first language
            //PNUMENGFL - % pupils with English first language
            //PNUMUNCFL - % pupils where first language is unclassified
            //NUMFSM  - No.pupils eligible for free school meals
            //NUMFSMEVER  - Number of pupils eligible for FSM at any time during the past 6 years
            //PNUMFSMEVER - Percentage of pupils eligible for FSM at any time during the past 6 years

            _dto.Census = new CensusDto
            {
                NumberOfPupils = establishment.NumberOfPupils,
                PercentageFsm = establishment.PercentageFSM,
                PercentageSen = censusData?.PSENELK,
                PercentageEnglishAsSecondLanguage = censusData?.PNUMEAL,
                PercentageFsmLastSixYears = censusData?.PNUMFSMEVER

            };

            return this;
        }

        public EstablishmentDtoBuilder WithMISEstablishment(Domain.Establishment.MisEstablishment establishment)
        {
            _dto.MISEstablishment = new MisEstablishmentDto
            {
                DateOfLatestSection8Inspection = establishment?.DateOfLatestSection8Inspection?.ToString(),
                InspectionEndDate = null!,
                OverallEffectiveness = establishment?.OverallEffectiveness?.ToString(),
                QualityOfEducation = establishment?.QualityOfEducation?.ToString(),
                BehaviourAndAttitudes = establishment?.BehaviourAndAttitudes?.ToString(),
                PersonalDevelopment = establishment?.PersonalDevelopment?.ToString(),
                EffectivenessOfLeadershipAndManagement = establishment?.EffectivenessOfLeadershipAndManagement?.ToString(),
                EarlyYearsProvision = establishment?.EarlyYearsProvisionWhereApplicable?.ToString(),
                SixthFormProvision = establishment?.SixthFormProvisionWhereApplicable.ToString(),
                Weblink = establishment?.WebLink
            };

            return this;
        }

        public EstablishmentDtoBuilder WithAddress(Domain.Establishment.Establishment establishment)
        {
            _dto.Address = new AddressDto()
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
        public EstablishmentDtoBuilder WithPreviousEstablishment(EducationEstablishmentLink? educationEstablishmentLink)
        {
            _dto.PreviousEstablishment = new PreviousEstablishmentDto()
            {
                Urn = educationEstablishmentLink?.LinkURN?.ToString()
            };

            return this;
        }

        public EstablishmentDto Build()
        {
            return _dto;
        }
    }
}

