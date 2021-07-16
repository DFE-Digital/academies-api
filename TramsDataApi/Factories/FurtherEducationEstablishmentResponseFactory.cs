using TramsDataApi.DatabaseModels;
using TramsDataApi.ResponseModels;

namespace TramsDataApi.Factories
{
    public class FurtherEducationEstablishmentResponseFactory
    {
        public static MISFEAResponse Create(FurtherEducationEstablishments furtherEducationEstablishments)
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
                NumberOfShortInspectionsSinceLastFullInspectionRAW = furtherEducationEstablishments.NumberOfShortInspectionsSinceLastFullInspectionRaw,
                InspectionNumber = furtherEducationEstablishments.InspectionNumber,
                FirstDayOfInspection = furtherEducationEstablishments.FirstDayOfInspection,
                LastDayOfInspection = furtherEducationEstablishments.LastDayOfInspection,
                InspectionType = furtherEducationEstablishments.InspectionType,
                DatePublished = furtherEducationEstablishments.DatePublished,
                OverallEffectiveness = furtherEducationEstablishments.OverallEffectiveness.ToString(),
                OverallEffectivenessRAW = furtherEducationEstablishments.OverallEffectivenessRaw,
                QualityOfEducation = furtherEducationEstablishments.QualityOfEducation.ToString(),
                QualityOfEducationRAW = furtherEducationEstablishments.QualityOfEducationRaw,
                BehaviourAndAttitudes = furtherEducationEstablishments.BehaviourAndAttitudes.ToString(),
                BehaviourAndAttitudesRAW = furtherEducationEstablishments.BehaviourAndAttitudesRaw,
                PersonalDevelopment = furtherEducationEstablishments.PersonalDevelopment.ToString(),
                PersonalDevelopmentRAW = furtherEducationEstablishments.PersonalDevelopmentRaw,
                EffectivenessOfLeadershipAndManagement = furtherEducationEstablishments.EffectivenessOfLeadershipAndManagement.ToString(),
                EffectivenessOfLeadershipAndManagementRAW = furtherEducationEstablishments.EffectivenessOfLeadershipAndManagementRaw,
                IsSafeguardingEffective = furtherEducationEstablishments.IsSafeguardingEffective,
                PreviousInspectionNumber = furtherEducationEstablishments.PreviousInspectionNumber,
                PreviousLastDayOfInspection = furtherEducationEstablishments.PreviousLastDayOfInspection,
                PreviousOverallEffectiveness = furtherEducationEstablishments.PreviousOverallEffectiveness.ToString(),
                PreviousOverallEffectivenessRAW = furtherEducationEstablishments.PreviousOverallEffectivenessRaw,
            };
        }
    }
}
