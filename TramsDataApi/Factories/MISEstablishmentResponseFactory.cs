using TramsDataApi.DatabaseModels;
using TramsDataApi.ResponseModels;

namespace TramsDataApi.Factories
{
    public class MISEstablishmentResponseFactory
    {
        public static MISEstablishmentResponse Create(MisEstablishments misEstablishments)
        {
            if (misEstablishments == null)
            {
                return null;
            }
            return new MISEstablishmentResponse
            {
                SiteName = null,
                WebLink = misEstablishments.WebLink,
                LAESTAB = misEstablishments.Laestab.ToString(),
                SchoolName = misEstablishments.SchoolName,
                OfstedPhase = misEstablishments.OfstedPhase,
                TypeOfEducation = misEstablishments.TypeOfEducation,
                SchoolOpenDate = misEstablishments.SchoolOpenDate,
                SixthForm = misEstablishments.SixthForm,
                DesignatedReligiousCharacter = misEstablishments.DesignatedReligiousCharacter,
                ReligiousEthos = misEstablishments.ReligiousEthos,
                FaithGrouping = misEstablishments.FaithGrouping,
                OfstedRegion = misEstablishments.OfstedRegion,
                Region = misEstablishments.Region,
                LocalAuthority = misEstablishments.LocalAuthority,
                ParliamentaryConstituency = misEstablishments.ParliamentaryConstituency,
                Postcode = misEstablishments.Postcode,
                IncomeDeprivationAffectingChildrenIndexQuintile =
                    misEstablishments.TheIncomeDeprivationAffectingChildrenIndexIdaciQuintile.ToString(),
                TotalNumberOfPupils = misEstablishments.TotalNumberOfPupils.ToString(),
                LatestSection8InspectionNumberSinceLastFullInspection =
                    misEstablishments.LatestSection8InspectionNumberSinceLastFullInspection,
                Section8InspectionRelatedToCurrentSchoolUrn =
                    misEstablishments.DoesTheSection8InspectionRelateToTheUrnOfTheCurrentSchool,
                UrnAtTimeOfSection8Inspection = misEstablishments.UrnAtTimeOfTheSection8Inspection.ToString(),
                SchoolNameAtTimeOfSection8Inspection = misEstablishments.SchoolNameAtTimeOfTheLatestSection8Inspection,
                SchoolTypeAtTimeOfSection8Inspection = misEstablishments.SchoolTypeAtTimeOfTheLatestSection8Inspection,
                NumberOfSection8InspectionsSinceLastFullInspection =
                    misEstablishments.NumberOfSection8InspectionsSinceTheLastFullInspection.ToString(),
                DateOfLatestSection8Inspection = misEstablishments.DateOfLatestSection8Inspection,
                Section8InspectionPublicationDate = misEstablishments.Section8InspectionPublicationDate,
                LatestSection8InspectionConvertedToFullInspection =
                    misEstablishments.DidTheLatestSection8InspectionConvertToAFullInspection,
                Section8InspectionOverallOutcome = misEstablishments.Section8InspectionOverallOutcome,
                InspectionNumberOfLatestFullInspection = misEstablishments.InspectionNumberOfLatestFullInspection,
                InspectionType = misEstablishments.InspectionType,
                InspectionTypeGrouping = misEstablishments.InspectionTypeGrouping,
                InspectionStartDate = misEstablishments.InspectionStartDate,
                InspectionEndDate = misEstablishments.InspectionEndDate,
                PublicationDate = misEstablishments.PublicationDate,
                LatestFullInspectionRelatesToCurrentSchoolUrn =
                    misEstablishments.DoesTheLatestFullInspectionRelateToTheUrnOfTheCurrentSchool,
                SchoolUrnAtTimeOfLastFullInspection = misEstablishments.UrnAtTimeOfLatestFullInspection.ToString(),
                LAESTABAtTimeOfLastFullInspection = misEstablishments.LaestabAtTimeOfLatestFullInspection.ToString(),
                SchoolNameAtTimeOfLastFullInspection = misEstablishments.SchoolNameAtTimeOfLatestFullInspection,
                SchoolTypeAtTimeOfLastFullInspection = misEstablishments.SchoolTypeAtTimeOfLatestFullInspection,
                OverallEffectiveness = misEstablishments.OverallEffectiveness.ToString(),
                CategoryOfConcern = misEstablishments.CategoryOfConcern,
                QualityOfEducation = misEstablishments.QualityOfEducation.ToString(),
                BehaviourAndAttitudes = misEstablishments.BehaviourAndAttitudes.ToString(),
                PersonalDevelopment = misEstablishments.PersonalDevelopment.ToString(),
                EffectivenessOfLeadershipAndManagement =
                    misEstablishments.EffectivenessOfLeadershipAndManagement.ToString(),
                SafeguardingIsEffective = misEstablishments.SafeguardingIsEffective,
                EarlyYearsProvision = misEstablishments.EarlyYearsProvisionWhereApplicable.ToString(),
                SixthFormProvision = misEstablishments.SixthFormProvisionWhereApplicable.ToString(),
                PreviousFullInspectionNumber = misEstablishments.PreviousFullInspectionNumber,
                PreviousInspectionStartDate = misEstablishments.PreviousInspectionStartDate,
                PreviousInspectionEndDate = misEstablishments.PreviousInspectionEndDate,
                PreviousPublicationDate = misEstablishments.PreviousPublicationDate,
                PreviousFullInspectionRelatesToUrnOfCurrentSchool =
                    misEstablishments.DoesThePreviousFullInspectionRelateToTheUrnOfTheCurrentSchool,
                UrnAtTheTimeOfPreviousFullInspection = misEstablishments.UrnAtTimeOfPreviousFullInspection.ToString(),
                LAESTABAtTheTimeOfPreviousFullInspection =
                    misEstablishments.LaestabAtTimeOfPreviousFullInspection.ToString(),
                SchoolNameAtTheTimeOfPreviousFullInspection =
                    misEstablishments.SchoolNameAtTimeOfPreviousFullInspection,
                SchoolTypeAtTheTimeOfPreviousFullInspection =
                    misEstablishments.SchoolTypeAtTimeOfPreviousFullInspection,
                PreviousFullInspectionOverallEffectiveness =
                    misEstablishments.PreviousFullInspectionOverallEffectiveness,
                PreviousCategoryOfConcern = misEstablishments.PreviousCategoryOfConcern,
                PreviousQualityOfEducation = misEstablishments.PreviousQualityOfEducation.ToString(),
                PreviousBehaviourAndAttitudes = misEstablishments.PreviousBehaviourAndAttitudes.ToString(),
                PreviousPersonalDevelopment = misEstablishments.PreviousPersonalDevelopment.ToString(),
                PreviousEffectivenessOfLeadershipAndManagement =
                    misEstablishments.PreviousEffectivenessOfLeadershipAndManagement.ToString(),
                PreviousIsSafeguardingEffective = misEstablishments.PreviousSafeguardingIsEffective,
                PreviousEarlyYearsProvision = misEstablishments.PreviousEarlyYearsProvisionWhereApplicable.ToString(),
                PreviousSixthFormProvision = misEstablishments.PreviousSixthFormProvisionWhereApplicable,
                UngradedInspectionOverallOutcome = misEstablishments.UngradedInspectionOverallOutcome
            };
        }
    }
}