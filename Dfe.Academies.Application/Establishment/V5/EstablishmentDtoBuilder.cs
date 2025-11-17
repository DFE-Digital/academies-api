using Dfe.Academies.Domain.Census;
using Dfe.Academies.Domain.Establishment;
using Dfe.Academies.Utils.Extensions;
using GovUK.Dfe.CoreLibs.Contracts.Academies.Base;
using GovUK.Dfe.CoreLibs.Contracts.Academies.V5.Establishments;

namespace Dfe.Academies.Application.Establishment.V5
{
    public class EstablishmentDtoBuilder
    {
        private readonly EstablishmentDto _dto = new();

        public EstablishmentDtoBuilder WithBasicDetails(Domain.Establishment.Establishment establishment)
        {
            _dto.Ukprn = establishment?.UKPRN ?? string.Empty;
            _dto.NoOfBoys = establishment?.NumberOfBoys.ToString() ?? string.Empty;
            _dto.NoOfGirls = establishment?.NumberOfGirls.ToString() ?? string.Empty;
            _dto.GiasLastChangedDate = establishment?.GiasLastChangedDate.ToResponseDate() ?? string.Empty;
            _dto.ReligousEthos = establishment?.ReligiousEthos ?? string.Empty;
            _dto.SenUnitCapacity = establishment?.SenUnitCapacity.ToString() ?? string.Empty;
            _dto.SenUnitOnRoll = establishment?.SenUnitOnRoll.ToString() ?? string.Empty;
            _dto.Name = establishment?.EstablishmentName ?? string.Empty;
            _dto.Urn = establishment?.URN.ToString() ?? string.Empty;
            _dto.OfstedRating = establishment?.OfstedRating ?? string.Empty;
            _dto.OfstedLastInspection = establishment?.OfstedLastInspection ?? string.Empty;
            _dto.StatutoryLowAge = establishment?.StatutoryLowAge ?? string.Empty;
            _dto.StatutoryHighAge = establishment?.StatutoryHighAge ?? string.Empty;
            _dto.SchoolCapacity = establishment?.SchoolCapacity ?? string.Empty;
            _dto.Pfi = establishment?.IfdPipeline?.DeliveryProcessPFI ?? string.Empty;
            _dto.EstablishmentNumber = establishment?.EstablishmentNumber.ToString() ?? string.Empty;
            _dto.Pan = establishment?.IfdPipeline?.DeliveryProcessPAN ?? string.Empty;
            _dto.Deficit = establishment?.IfdPipeline?.ProjectTemplateInformationDeficit ?? string.Empty;
            _dto.ViabilityIssue = establishment?.IfdPipeline?.ProjectTemplateInformationViabilityIssue ?? string.Empty;

            _dto.HeadteacherTitle = establishment?.HeadTitle ?? string.Empty;
            _dto.HeadteacherFirstName = establishment?.HeadFirstName ?? string.Empty;
            _dto.HeadteacherLastName = establishment?.HeadLastName ?? string.Empty;
            _dto.HeadteacherPreferredJobTitle = establishment?.HeadPreferredJobTitle ?? string.Empty;

            // main phone was made a string to be consistent but the entire dto probably need to make the strings nullable
            // for now empty assignment if it is null
            _dto.MainPhone = establishment?.MainPhone ?? string.Empty;

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
                Name = establishment?.Diocese ?? string.Empty,
                Code = establishment?.DioceseCode ?? string.Empty
            };

            return this;
        }

        public EstablishmentDtoBuilder WithEstablishmentType(Domain.Establishment.Establishment establishment)
        {
            _dto.EstablishmentType = new NameAndCodeDto
            {
                Name = establishment?.EstablishmentType?.Name ?? string.Empty,
                Code = establishment?.EstablishmentType?.Code ?? string.Empty
            };

            return this;
        }

        public EstablishmentDtoBuilder WithGor(Domain.Establishment.Establishment establishment)
        {
            _dto.Gor = new NameAndCodeDto
            {
                Name = establishment?.GORregion ?? string.Empty,
                Code = establishment?.GORregionCode ?? string.Empty
            };

            return this;
        }

        public EstablishmentDtoBuilder WithPhaseOfEducation(Domain.Establishment.Establishment establishment)
        {
            _dto.PhaseOfEducation = new NameAndCodeDto
            {
                Name = establishment?.PhaseOfEducation ?? string.Empty,
                Code = establishment?.PhaseOfEducationCode.ToString() ?? string.Empty
            };

            return this;
        }

        public EstablishmentDtoBuilder WithReligiousCharacter(Domain.Establishment.Establishment establishment)
        {
            _dto.ReligiousCharacter = new NameAndCodeDto
            {
                Name = establishment?.ReligiousCharacter ?? string.Empty,
                Code = establishment?.ReligiousCharacterCode ?? string.Empty
            };

            return this;
        }
        public EstablishmentDtoBuilder WithParliamentaryConstituency(Domain.Establishment.Establishment establishment)
        {
            _dto.ParliamentaryConstituency = new NameAndCodeDto
            {
                Name = establishment?.ParliamentaryConstituency ?? string.Empty,
                Code = establishment?.ParliamentaryConstituencyCode ?? string.Empty
            };

            return this;
        }
        public EstablishmentDtoBuilder WithCensus(Domain.Establishment.Establishment establishment, CensusData censusData)
        {
            _dto.Census = new CensusDto
            {
                NumberOfPupils = establishment?.NumberOfPupils ?? string.Empty,
                PercentageFsm = establishment?.PercentageFSM ?? string.Empty,
                PercentageSen = censusData?.PSENELK ?? string.Empty,
                PercentageEnglishAsSecondLanguage = censusData?.PNUMEAL ?? string.Empty,
                PercentageFsmLastSixYears = censusData?.PNUMFSMEVER ?? string.Empty

            };

            return this;
        }

        public EstablishmentDtoBuilder WithMISEstablishment(MisEstablishment establishment)
        {
            _dto.MISEstablishment = new MisEstablishmentDto
            {
                DateOfLatestSection8Inspection = establishment?.DateOfLatestSection8Inspection?.ToString() ?? string.Empty,
                InspectionEndDate = null!,
                OverallEffectiveness = establishment?.OverallEffectiveness?.ToString() ?? string.Empty,
                QualityOfEducation = establishment?.QualityOfEducation.ToString() ?? string.Empty,
                BehaviourAndAttitudes = establishment?.BehaviourAndAttitudes?.ToString() ?? string.Empty,
                PersonalDevelopment = establishment?.PersonalDevelopment.ToString() ?? string.Empty,
                EffectivenessOfLeadershipAndManagement = establishment?.EffectivenessOfLeadershipAndManagement.ToString() ?? string.Empty,
                EarlyYearsProvision = establishment?.EarlyYearsProvisionWhereApplicable.ToString() ?? string.Empty,
                SixthFormProvision = establishment?.SixthFormProvisionWhereApplicable.ToString() ?? string.Empty,
                Weblink = establishment?.WebLink ?? string.Empty
            };

            return this;
        }

        public EstablishmentDtoBuilder WithAddress(Domain.Establishment.Establishment establishment)
        {
            _dto.Address = new AddressDto()
            {
                Street = establishment?.AddressLine1 ?? string.Empty,
                Town = establishment?.Town ?? string.Empty,
                Postcode = establishment?.Postcode ?? string.Empty,
                County = establishment?.County ?? string.Empty,
                Additional = establishment?.AddressLine2 ?? string.Empty,
                Locality = establishment?.AddressLine3 ?? string.Empty
            };

            return this;
        }
        public EstablishmentDtoBuilder WithPreviousEstablishment(EducationEstablishmentLink? educationEstablishmentLink)
        {
            _dto.PreviousEstablishment = new PreviousEstablishmentDto()
            {
                Urn = educationEstablishmentLink?.LinkURN.ToString()
            };

            return this;
        }
        public EstablishmentDtoBuilder WithMockReportCards(ReportCardMock reportCardMock)
        {
            _dto.ReportCard = new ReportCardDto()
            {
                WebLink = reportCardMock?.WebLink,
                LatestInspectionDate = reportCardMock?.LatestInspectionDate.ToResponseDate(),
                LatestCurriculumAndTeaching = reportCardMock?.LatestCurriculumAndTeaching,
                LatestAttendanceAndBehaviour = reportCardMock?.LatestAttendanceAndBehaviour,
                LatestPersonalDevelopmentAndWellbeing = reportCardMock?.LatestPersonalDevelopmentAndWellbeing,
                LatestLeadershipAndGovernance = reportCardMock?.LatestLeadershipAndGovernance,
                LatestInclusion = reportCardMock?.LatestInclusion,
                LatestAchievement = reportCardMock?.LatestAchievement,
                LatestEarlyYearsProvision = reportCardMock?.LatestEarlyYearsProvision,
                LatestSafeguarding = reportCardMock?.LatestSafeguarding,
                PreviousInspectionDate = reportCardMock?.PreviousInspectionDate.ToResponseDate(),
                PreviousCurriculumAndTeaching = reportCardMock?.PreviousCurriculumAndTeaching,
                PreviousAttendanceAndBehaviour = reportCardMock?.PreviousAttendanceAndBehaviour,
                PreviousPersonalDevelopmentAndWellbeing = reportCardMock?.PreviousPersonalDevelopmentAndWellbeing,
                PreviousLeadershipAndGovernance = reportCardMock?.PreviousLeadershipAndGovernance,
                PreviousInclusion = reportCardMock?.PreviousInclusion,
                PreviousAchievement = reportCardMock?.PreviousAchievement,
                PreviousEarlyYearsProvision = reportCardMock?.PreviousEarlyYearsProvision,
                PreviousSafeguarding = reportCardMock?.PreviousSafeguarding
            };

            return this;
        }

        public EstablishmentDto Build()
        {
            return _dto;
        }
    }
}

