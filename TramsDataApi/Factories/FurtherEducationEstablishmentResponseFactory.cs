using Dfe.Academies.Domain.Establishment;
using TramsDataApi.DatabaseModels;
using TramsDataApi.ResponseModels;

namespace TramsDataApi.Factories
{
    public class FurtherEducationEstablishmentResponseFactory
    {
        public static MISFEAResponse Create(FurtherEducationEstablishment furtherEducationEstablishments)
        {
            if (furtherEducationEstablishments == null)
            {
                return null;
            }

            return new MISFEAResponse
            {
                Provider = new ProviderResponse
                {
                    Urn = furtherEducationEstablishments.ProviderUrn,
                    Name = furtherEducationEstablishments.ProviderName,
                    Type = furtherEducationEstablishments.ProviderType,
                    Group = furtherEducationEstablishments.ProviderGroup,
                    Ukprn = furtherEducationEstablishments.ProviderUkprn
                },
                LocalAuthority = furtherEducationEstablishments.LocalAuthority,
                Region = furtherEducationEstablishments.Region,
                OfstedRegion = furtherEducationEstablishments.OfstedRegion,
                DateOfLatestShortInspection = furtherEducationEstablishments.DateOfLatestShortInspection,
                NumberOfShortInspectionsSinceLastFullInspection = furtherEducationEstablishments.NumberOfShortInspectionsSinceLastFullInspection.ToString(),
                NumberOfShortInspectionsSinceLastFullInspectionRAW = string.Empty,
                InspectionNumber = furtherEducationEstablishments.InspectionNumber,
                FirstDayOfInspection = furtherEducationEstablishments.FirstDayOfInspection,
                LastDayOfInspection = furtherEducationEstablishments.LastDayOfInspection,
                InspectionType = furtherEducationEstablishments.InspectionType,
                DatePublished = furtherEducationEstablishments.DatePublished,
                OverallEffectiveness = furtherEducationEstablishments.OverallEffectiveness,
                OverallEffectivenessRAW = string.Empty,
                QualityOfEducation = furtherEducationEstablishments.QualityOfEducation.ToString(),
                QualityOfEducationRAW = string.Empty,
                BehaviourAndAttitudes = furtherEducationEstablishments.BehaviourAndAttitudes.ToString(),
                BehaviourAndAttitudesRAW = string.Empty,
                PersonalDevelopment = furtherEducationEstablishments.PersonalDevelopment.ToString(),
                PersonalDevelopmentRAW = string.Empty,
                EffectivenessOfLeadershipAndManagement = furtherEducationEstablishments.EffectivenessOfLeadershipAndManagement.ToString(),
                EffectivenessOfLeadershipAndManagementRAW = string.Empty,
                IsSafeguardingEffective = furtherEducationEstablishments.IsSafeguardingEffective,
                PreviousInspectionNumber = furtherEducationEstablishments.PreviousInspectionNumber,
                PreviousLastDayOfInspection = furtherEducationEstablishments.PreviousLastDayOfInspection,
                PreviousOverallEffectiveness = furtherEducationEstablishments.PreviousOverallEffectiveness,
                PreviousOverallEffectivenessRAW = string.Empty,
            };
        }
    }
}
