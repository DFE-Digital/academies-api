using AutoFixture.Xunit2;
using Dfe.Academies.Domain.Census;
using FluentAssertions;
using TramsDataApi.CensusData;
using TramsDataApi.DatabaseModels;
using TramsDataApi.Factories;
using TramsDataApi.ResponseModels;
using Xunit;

namespace TramsDataApi.Test.Factories
{
    public class EstablishmentResponseFactoryTests
    {
        [Theory]
        [AutoData]
        public void EstablishmentResponseFactory_CreatesEstablishmentResponse_FromAnEstablishment(Establishment establishment)
        {
            var expected = BuildExpected(establishment, null, null, null, null, null);

            var result = EstablishmentResponseFactory.Create(establishment, null, null, null, null, null);

            result.Should().BeEquivalentTo(expected);
        }

        [Theory]
        [AutoData]
        public void EstablishmentResponseFactory_CreatesEstablishmentResponse_WithAMisEstablishment(Establishment establishment, MisEstablishments misEstablishments)
        {
            var expected = BuildExpected(establishment, misEstablishments, null, null, null, null);

            var result = EstablishmentResponseFactory.Create(establishment, misEstablishments, null, null, null, null);

            result.Should().BeEquivalentTo(expected);
        }

        [Theory]
        [AutoData]
        public void EstablishmentResponseFactory_CreatesEstablishmentResponse_WithASmartData(Establishment establishment, SmartData smartData)
        {
            var expected = BuildExpected(establishment, null, smartData, null, null, null);

            var result = EstablishmentResponseFactory.Create(establishment, null, smartData, null, null, null);

            result.Should().BeEquivalentTo(expected);
        }

        [Theory]
        [AutoData]
        public void EstablishmentResponseFactory_CreatesEstablishmentResponse_WithAFurtherEducationEstablishment(Establishment establishment, FurtherEducationEstablishments furtherEducationEstablishments)
        {
            var expected = BuildExpected(establishment, null, null, furtherEducationEstablishments, null, null);

            var result = EstablishmentResponseFactory.Create(establishment, null, null, furtherEducationEstablishments, null, null);

            result.Should().BeEquivalentTo(expected);
        }

        [Theory]
        [AutoData]
        public void EstablishmentResponseFactory_CreatesEstablishmentResponse_WithViewAcademyConversion(Establishment establishment, ViewAcademyConversions viewAcademyConversions)
        {
            var expected = BuildExpected(establishment, null, null, null, viewAcademyConversions, null);
            var result = EstablishmentResponseFactory.Create(establishment, null, null, null, viewAcademyConversions, null);
            result.Should().BeEquivalentTo(expected);
        }

        private EstablishmentResponse BuildExpected(Establishment establishment, 
            MisEstablishments misEstablishments, 
            SmartData smartData, 
            FurtherEducationEstablishments furtherEducationEstablishments,
            ViewAcademyConversions viewAcademyconversions,
            CensusDataModel censusData)
        {
            var expected = new EstablishmentResponse
            {
                Urn = establishment.Urn.ToString(),
                LocalAuthorityCode = establishment.LaCode,
                LocalAuthorityName = establishment.LaName,
                EstablishmentNumber = establishment.EstablishmentNumber,
                EstablishmentName = establishment.EstablishmentName,
                EstablishmentType = new NameAndCodeResponse
                { Name = establishment.TypeOfEstablishmentName, Code = establishment.TypeOfEstablishmentCode },
                EstablishmentTypeGroup =
                    new NameAndCodeResponse
                    {
                        Name = establishment.EstablishmentTypeGroupName,
                        Code = establishment.EstablishmentTypeGroupCode
                    },
                EstablishmentStatus = new NameAndCodeResponse
                { Name = establishment.EstablishmentStatusName, Code = establishment.EstablishmentStatusCode },
                ReasonEstablishmentOpened = new NameAndCodeResponse
                {
                    Name = establishment.ReasonEstablishmentOpenedName,
                    Code = establishment.ReasonEstablishmentOpenedCode
                },
                OpenDate = establishment.OpenDate,
                ReasonEstablishmentClosed = new NameAndCodeResponse
                {
                    Name = establishment.ReasonEstablishmentClosedName,
                    Code = establishment.ReasonEstablishmentClosedCode
                },
                CloseDate = establishment.CloseDate,
                PhaseOfEducation = new NameAndCodeResponse
                { Name = establishment.PhaseOfEducationName, Code = establishment.PhaseOfEducationCode },
                StatutoryLowAge = establishment.StatutoryLowAge,
                StatutoryHighAge = establishment.StatutoryHighAge,
                Boarders = new NameAndCodeResponse
                { Name = establishment.BoardersName, Code = establishment.BoardersCode },
                NurseryProvision = establishment.NurseryProvisionName,
                OfficialSixthForm =
                    new NameAndCodeResponse
                    { Name = establishment.OfficialSixthFormName, Code = establishment.OfficialSixthFormCode },
                Gender = new NameAndCodeResponse { Name = establishment.GenderName, Code = establishment.GenderCode },
                ReligiousCharacter = new NameAndCodeResponse
                { Name = establishment.ReligiousCharacterName, Code = establishment.ReligiousCharacterCode },
                ReligiousEthos = establishment.ReligiousEthosName,
                Diocese = new NameAndCodeResponse { Name = establishment.DioceseName, Code = establishment.DioceseCode },
                AdmissionsPolicy = new NameAndCodeResponse
                { Name = establishment.AdmissionsPolicyName, Code = establishment.AdmissionsPolicyCode },
                SchoolCapacity = establishment.SchoolCapacity,
                SpecialClasses = new NameAndCodeResponse
                { Name = establishment.SpecialClassesName, Code = establishment.SpecialClassesCode },
                Census =
                    new CensusResponse
                    {
                        CensusDate = establishment.CensusDate,
                        NumberOfPupils = establishment.NumberOfPupils,
                        NumberOfBoys = establishment.NumberOfBoys,
                        NumberOfGirls = establishment.NumberOfGirls,
                        PercentageFsm = establishment.PercentageFsm
                    },
                TrustSchoolFlag = new NameAndCodeResponse
                { Name = establishment.TrustSchoolFlagName, Code = establishment.TrustSchoolFlagCode },
                Trusts = new NameAndCodeResponse { Name = establishment.TrustsName, Code = establishment.TrustsCode },
                SchoolSponsorFlag = establishment.SchoolSponsorFlagName,
                SchoolSponsors = establishment.SchoolSponsorsName,
                FederationFlag = establishment.FederationFlagName,
                Federations = new NameAndCodeResponse
                { Name = establishment.FederationsName, Code = establishment.FederationsCode },
                Ukprn = establishment.Ukprn,
                FeheiIdentifier = establishment.Feheidentifier,
                FurtherEducationType = establishment.FurtherEducationTypeName,
                OfstedLastInspection = establishment.OfstedLastInsp,
                OfstedSpecialMeasures = new NameAndCodeResponse
                { Name = establishment.OfstedSpecialMeasuresName, Code = establishment.OfstedSpecialMeasuresCode },
                LastChangedDate = establishment.LastChangedDate,
                Address =
                    new AddressResponse
                    {
                        Street = establishment.Street,
                        Locality = establishment.Locality,
                        AdditionalLine = establishment.Address3,
                        Town = establishment.Town,
                        County = establishment.CountyName,
                        Postcode = establishment.Postcode
                    },
                SchoolWebsite = establishment.SchoolWebsite,
                TelephoneNumber = establishment.TelephoneNum,
                HeadteacherTitle = establishment.HeadTitleName,
                HeadteacherFirstName = establishment.HeadFirstName,
                HeadteacherLastName = establishment.HeadLastName,
                HeadteacherPreferredJobTitle = establishment.HeadPreferredJobTitle,
                InspectorateName = establishment.InspectorateNameName,
                InspectorateReport = establishment.InspectorateReport,
                DateOfLastInspectionVisit = establishment.DateOfLastInspectionVisit,
                DateOfNextInspectionVisit = establishment.NextInspectionVisit,
                TeenMoth = establishment.TeenMothName,
                TeenMothPlaces = establishment.TeenMothPlaces,
                CCF = establishment.CcfName,
                SENPRU = establishment.SenpruName,
                EBD = establishment.EbdName,
                PlacesPRU = establishment.PlacesPru,
                FTProv = establishment.FtprovName,
                EdByOther = establishment.EdByOtherName,
                Section14Approved = establishment.Section41ApprovedName,
                SEN1 = establishment.Sen1Name,
                SEN2 = establishment.Sen2Name,
                SEN3 = establishment.Sen3Name,
                SEN4 = establishment.Sen4Name,
                SEN5 = establishment.Sen5Name,
                SEN6 = establishment.Sen6Name,
                SEN7 = establishment.Sen7Name,
                SEN8 = establishment.Sen8Name,
                SEN9 = establishment.Sen9Name,
                SEN10 = establishment.Sen10Name,
                SEN11 = establishment.Sen11Name,
                SEN12 = establishment.Sen12Name,
                SEN13 = establishment.Sen13Name,
                TypeOfResourcedProvision = establishment.TypeOfResourcedProvisionName,
                ResourcedProvisionOnRoll = establishment.ResourcedProvisionOnRoll,
                ResourcedProvisionOnCapacity = establishment.ResourcedProvisionCapacity,
                SenUnitOnRoll = establishment.SenUnitOnRoll,
                SenUnitCapacity = establishment.SenUnitCapacity,
                GOR = new NameAndCodeResponse { Name = establishment.GorName, Code = establishment.GorCode },
                DistrictAdministrative =
                    new NameAndCodeResponse
                    {
                        Name = establishment.DistrictAdministrativeName,
                        Code = establishment.DistrictAdministrativeCode
                    },
                AdministractiveWard = new NameAndCodeResponse
                { Name = establishment.AdministrativeWardName, Code = establishment.AdministrativeWardCode },
                ParliamentaryConstituency =
                    new NameAndCodeResponse
                    {
                        Name = establishment.ParliamentaryConstituencyName,
                        Code = establishment.ParliamentaryConstituencyCode
                    },
                UrbanRural =
                    new NameAndCodeResponse
                    {
                        Name = establishment.UrbanRuralName,
                        Code = establishment.UrbanRuralCode
                    },
                GSSLACode = establishment.GsslacodeName,
                Easting = establishment.Easting,
                Northing = establishment.Northing,
                MSOA = new NameAndCodeResponse { Name = establishment.MsoaName, Code = establishment.MsoaCode },
                LSOA = new NameAndCodeResponse { Name = establishment.LsoaName, Code = establishment.LsoaCode },
                SENStat = establishment.Senstat,
                SENNoStat = establishment.SennoStat,
                BoardingEstablishment = establishment.BoardingEstablishmentName,
                PropsName = establishment.PropsName,
                PreviousLocalAuthority = new NameAndCodeResponse
                { Name = establishment.PreviousLaName, Code = establishment.PreviousLaCode },
                PreviousEstablishmentNumber = establishment.PreviousEstablishmentNumber,
                OfstedRating = establishment.OfstedRatingName,
                RSCRegion = establishment.RscregionName,
                Country = establishment.CountryName,
                UPRN = establishment.Uprn,
                MISEstablishment = null,
                MISFurtherEducationEstablishment = null,
                SMARTData = null,
                Financial = null,
                Concerns = null,
            };

            if (misEstablishments != null)
            {
                expected.MISEstablishment = new MISEstablishmentResponse
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
                    PreviousSixthFormProvision = misEstablishments.PreviousSixthFormProvisionWhereApplicable
                };
            }

            if (smartData != null)
            {
                expected.SMARTData = new SMARTDataResponse
                {
                    ProbabilityOfDeclining = smartData.ProbabilityOfDeclining.ToString(),
                    ProbabilityOfStayingTheSame = smartData.ProbabilityOfStayingTheSame.ToString(),
                    ProbabilityOfImproving = smartData.ProbabilityOfImproving.ToString(),
                    PredictedChangeInProgress8Score = smartData.PredictedChangeInProgress8Score,
                    PredictedChanceOfChangeOccurring = smartData.PredictedChanceOfChangeOccuring.ToString(),
                    TotalNumberOfRisks = smartData.TotalNumberOfRisks.ToString(),
                    TotalRiskScore = smartData.TotalRiskScore.ToString(),
                    RiskRatingNum = smartData.RiskRatingNum.ToString()
                };
            }

            if(furtherEducationEstablishments != null)
            {
                expected.MISFurtherEducationEstablishment = new MISFEAResponse
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

            if (viewAcademyconversions != null)
            {
                expected.ViewAcademyConversion = new ViewAcademyConversionResponse
                {
                    Deficit = viewAcademyconversions.ProjectTemplateInformationDeficit,
                    ViabilityIssue = viewAcademyconversions.ProjectTemplateInformationViabilityIssue,
                    PAN = viewAcademyconversions.DeliveryProcessPan,
                    PFI = viewAcademyconversions.DeliveryProcessPfi,
                };
            }
            
            if (censusData != null)
            {
                expected.Census.PercentageEnglishNotFirstLanguage = censusData.PNUMEAL;
                expected.Census.PerceantageEnglishFirstLanguage = censusData.PNUMENGFL;
                expected.Census.PercentageFirstLanguageUnclassified = censusData.PNUMUNCFL;
                expected.Census.NumberEligableForFSM = censusData.NUMFSM;
                expected.Census.NumberEligableForFSM6Years = censusData.NUMFSMEVER;
                expected.Census.PercentageEligableForFSM6Years = censusData.PNUMFSMEVER;
                expected.Census.PercentageSen = censusData.PSENELK;
            }

            return expected;
        }
    }
}
