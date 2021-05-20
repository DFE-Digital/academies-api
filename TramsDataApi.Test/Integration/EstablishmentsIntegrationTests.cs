using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using FizzWare.NBuilder;
using FizzWare.NBuilder.PropertyNaming;
using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using TramsDataApi.DatabaseModels;
using TramsDataApi.ResponseModels;
using TramsDataApi.Test.Utils;
using Xunit;

namespace TramsDataApi.Test.Integration
{
    [Collection("Database")]
    public class EstablishmentsIntegrationTests : IClassFixture<TramsDataApiFactory>
    {
        private readonly HttpClient _client;
        private readonly LegacyTramsDbContext _dbContext;
        private readonly RandomGenerator _randomGenerator;

        public EstablishmentsIntegrationTests(TramsDataApiFactory fixture)
        {
            _client = fixture.CreateClient();
            _client.BaseAddress = new Uri("https://trams-api.com/");
            _dbContext = fixture.Services.GetRequiredService<LegacyTramsDbContext>();
            _randomGenerator = new RandomGenerator();
        }

        [Fact]
        public async Task CanGetEstablishmentByUkprn()
        {
            var establishment = Builder<Establishment>.CreateNew()
                .With(e => e.Ukprn = "mockukprn")
                .With(e => e.Urn = _randomGenerator.Next(100000, 199999))
                .Build();
            var misEstablishment = Builder<MisEstablishments>.CreateNew().With(m => m.Urn = establishment.Urn).Build();
            var smartData = Generators.GenerateSmartData(establishment.Urn);
            _dbContext.Establishment.Add(establishment);
            _dbContext.MisEstablishments.Add(misEstablishment);
            _dbContext.SmartData.Add(smartData);
            _dbContext.SaveChanges();

            var expectedMisEstablishmentResponse = new MISEstablishmentResponse
            {
                SiteName = null,
                WebLink = misEstablishment.WebLink,
                LAESTAB = misEstablishment.Laestab.ToString(),
                SchoolName = misEstablishment.SchoolName,
                OfstedPhase = misEstablishment.OfstedPhase,
                TypeOfEducation = misEstablishment.TypeOfEducation,
                SchoolOpenDate = misEstablishment.SchoolOpenDate,
                SixthForm = misEstablishment.SixthForm,
                DesignatedReligiousCharacter = misEstablishment.DesignatedReligiousCharacter,
                ReligiousEthos = misEstablishment.ReligiousEthos,
                FaithGrouping = misEstablishment.FaithGrouping,
                OfstedRegion = misEstablishment.OfstedRegion,
                Region = misEstablishment.Region,
                LocalAuthority = misEstablishment.LocalAuthority,
                ParliamentaryConstituency = misEstablishment.ParliamentaryConstituency,
                Postcode = misEstablishment.Postcode,
                IncomeDeprivationAffectingChildrenIndexQuintile =
                    misEstablishment.TheIncomeDeprivationAffectingChildrenIndexIdaciQuintile.ToString(),
                TotalNumberOfPupils = misEstablishment.TotalNumberOfPupils.ToString(),
                LatestSection8InspectionNumberSinceLastFullInspection =
                    misEstablishment.LatestSection8InspectionNumberSinceLastFullInspection,
                Section8InspectionRelatedToCurrentSchoolUrn =
                    misEstablishment.DoesTheSection8InspectionRelateToTheUrnOfTheCurrentSchool,
                UrnAtTimeOfSection8Inspection = misEstablishment.UrnAtTimeOfTheSection8Inspection.ToString(),
                SchoolNameAtTimeOfSection8Inspection = misEstablishment.SchoolNameAtTimeOfTheLatestSection8Inspection,
                SchoolTypeAtTimeOfSection8Inspection = misEstablishment.SchoolTypeAtTimeOfTheLatestSection8Inspection,
                NumberOfSection8InspectionsSinceLastFullInspection =
                    misEstablishment.NumberOfSection8InspectionsSinceTheLastFullInspection.ToString(),
                DateOfLatestSection8Inspection = misEstablishment.DateOfLatestSection8Inspection,
                Section8InspectionPublicationDate = misEstablishment.Section8InspectionPublicationDate,
                LatestSection8InspectionConvertedToFullInspection =
                    misEstablishment.DidTheLatestSection8InspectionConvertToAFullInspection,
                Section8InspectionOverallOutcome = misEstablishment.Section8InspectionOverallOutcome,
                InspectionNumberOfLatestFullInspection = misEstablishment.InspectionNumberOfLatestFullInspection,
                InspectionType = misEstablishment.InspectionType,
                InspectionTypeGrouping = misEstablishment.InspectionTypeGrouping,
                InspectionStartDate = misEstablishment.InspectionStartDate,
                InspectionEndDate = misEstablishment.InspectionEndDate,
                PublicationDate = misEstablishment.PublicationDate,
                LatestFullInspectionRelatesToCurrentSchoolUrn =
                    misEstablishment.DoesTheLatestFullInspectionRelateToTheUrnOfTheCurrentSchool,
                SchoolUrnAtTimeOfLastFullInspection = misEstablishment.UrnAtTimeOfLatestFullInspection.ToString(),
                LAESTABAtTimeOfLastFullInspection = misEstablishment.LaestabAtTimeOfLatestFullInspection.ToString(),
                SchoolNameAtTimeOfLastFullInspection = misEstablishment.SchoolNameAtTimeOfLatestFullInspection,
                SchoolTypeAtTimeOfLastFullInspection = misEstablishment.SchoolTypeAtTimeOfLatestFullInspection,
                OverallEffectiveness = misEstablishment.OverallEffectiveness.ToString(),
                CategoryOfConcern = misEstablishment.CategoryOfConcern,
                QualityOfEducation = misEstablishment.QualityOfEducation.ToString(),
                BehaviourAndAttitudes = misEstablishment.BehaviourAndAttitudes.ToString(),
                PersonalDevelopment = misEstablishment.PersonalDevelopment.ToString(),
                EffectivenessOfLeadershipAndManagement =
                    misEstablishment.EffectivenessOfLeadershipAndManagement.ToString(),
                SafeguardingIsEffective = misEstablishment.SafeguardingIsEffective,
                EarlyYearsProvision = misEstablishment.EarlyYearsProvisionWhereApplicable.ToString(),
                SixthFormProvision = misEstablishment.SixthFormProvisionWhereApplicable.ToString(),
                PreviousFullInspectionNumber = misEstablishment.PreviousFullInspectionNumber,
                PreviousInspectionStartDate = misEstablishment.PreviousInspectionStartDate,
                PreviousInspectionEndDate = misEstablishment.PreviousInspectionEndDate,
                PreviousPublicationDate = misEstablishment.PreviousPublicationDate,
                PreviousFullInspectionRelatesToUrnOfCurrentSchool =
                    misEstablishment.DoesThePreviousFullInspectionRelateToTheUrnOfTheCurrentSchool,
                UrnAtTheTimeOfPreviousFullInspection = misEstablishment.UrnAtTimeOfPreviousFullInspection.ToString(),
                LAESTABAtTheTimeOfPreviousFullInspection =
                    misEstablishment.LaestabAtTimeOfPreviousFullInspection.ToString(),
                SchoolNameAtTheTimeOfPreviousFullInspection =
                    misEstablishment.SchoolNameAtTimeOfPreviousFullInspection,
                SchoolTypeAtTheTimeOfPreviousFullInspection =
                    misEstablishment.SchoolTypeAtTimeOfPreviousFullInspection,
                PreviousFullInspectionOverallEffectiveness =
                    misEstablishment.PreviousFullInspectionOverallEffectiveness,
                PreviousCategoryOfConcern = misEstablishment.PreviousCategoryOfConcern,
                PreviousQualityOfEducation = misEstablishment.PreviousQualityOfEducation.ToString(),
                PreviousBehaviourAndAttitudes = misEstablishment.PreviousBehaviourAndAttitudes.ToString(),
                PreviousPersonalDevelopment = misEstablishment.PreviousPersonalDevelopment.ToString(),
                PreviousEffectivenessOfLeadershipAndManagement =
                    misEstablishment.PreviousEffectivenessOfLeadershipAndManagement.ToString(),
                PreviousIsSafeguardingEffective = misEstablishment.PreviousSafeguardingIsEffective,
                PreviousEarlyYearsProvision = misEstablishment.PreviousEarlyYearsProvisionWhereApplicable.ToString(),
                PreviousSixthFormProvision = misEstablishment.PreviousSixthFormProvisionWhereApplicable
            };

            var expectedSmartDataResponse = new SMARTDataResponse
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
            

            var expected = new EstablishmentResponse
            {
                Urn = establishment.Urn.ToString(),
                LocalAuthorityCode = establishment.LaCode,
                LocalAuthorityName = establishment.LaName,
                EstablishmentNumber = establishment.EstablishmentNumber,
                EstablishmentName = establishment.EstablishmentName,
                EstablishmentType = new NameAndCodeResponse
                    {Name = establishment.TypeOfEstablishmentName, Code = establishment.TypeOfEstablishmentCode},
                EstablishmentTypeGroup =
                    new NameAndCodeResponse
                    {
                        Name = establishment.EstablishmentTypeGroupName, Code = establishment.EstablishmentTypeGroupCode
                    },
                EstablishmentStatus = new NameAndCodeResponse
                    {Name = establishment.EstablishmentStatusName, Code = establishment.EstablishmentStatusCode},
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
                    {Name = establishment.PhaseOfEducationName, Code = establishment.PhaseOfEducationCode},
                StatutoryLowAge = establishment.StatutoryLowAge,
                StatutoryHighAge = establishment.StatutoryHighAge,
                Boarders = new NameAndCodeResponse
                    {Name = establishment.BoardersName, Code = establishment.BoardersCode},
                NurseryProvision = establishment.NurseryProvisionName,
                OfficialSixthForm =
                    new NameAndCodeResponse
                        {Name = establishment.OfficialSixthFormName, Code = establishment.OfficialSixthFormCode},
                Gender = new NameAndCodeResponse {Name = establishment.GenderName, Code = establishment.GenderCode},
                ReligiousCharacter = new NameAndCodeResponse
                    {Name = establishment.ReligiousCharacterName, Code = establishment.ReligiousCharacterCode},
                ReligiousEthos = establishment.ReligiousEthosName,
                Diocese = new NameAndCodeResponse {Name = establishment.DioceseName, Code = establishment.DioceseCode},
                AdmissionsPolicy = new NameAndCodeResponse
                    {Name = establishment.AdmissionsPolicyName, Code = establishment.AdmissionsPolicyCode},
                SchoolCapacity = establishment.SchoolCapacity,
                SpecialClasses = new NameAndCodeResponse
                    {Name = establishment.SpecialClassesName, Code = establishment.SpecialClassesCode},
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
                    {Name = establishment.TrustSchoolFlagName, Code = establishment.TrustSchoolFlagCode},
                Trusts = new NameAndCodeResponse {Name = establishment.TrustsName, Code = establishment.TrustsCode},
                SchoolSponsorFlag = establishment.SchoolSponsorFlagName,
                SchoolSponsors = establishment.SchoolSponsorsName,
                FederationFlag = establishment.FederationFlagName,
                Federations = new NameAndCodeResponse
                    {Name = establishment.FederationsName, Code = establishment.FederationsCode},
                Ukprn = establishment.Ukprn,
                FeheiIdentifier = establishment.Feheidentifier,
                FurtherEducationType = establishment.FurtherEducationTypeName,
                OfstedLastInspection = establishment.OfstedLastInsp,
                OfstedSpecialMeasures = new NameAndCodeResponse
                    {Name = establishment.OfstedSpecialMeasuresName, Code = establishment.OfstedSpecialMeasuresCode},
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
                GOR = new NameAndCodeResponse {Name = establishment.GorName, Code = establishment.GorCode},
                DistrictAdministrative =
                    new NameAndCodeResponse
                    {
                        Name = establishment.DistrictAdministrativeName, Code = establishment.DistrictAdministrativeCode
                    },
                AdministractiveWard = new NameAndCodeResponse
                    {Name = establishment.AdministrativeWardName, Code = establishment.AdministrativeWardCode},
                ParliamentaryConstituency =
                    new NameAndCodeResponse
                    {
                        Name = establishment.ParliamentaryConstituencyName,
                        Code = establishment.ParliamentaryConstituencyCode
                    },
                UrbanRural =
                    new NameAndCodeResponse
                    {
                        Name = establishment.UrbanRuralName, Code = establishment.UrbanRuralCode
                    },
                GSSLACode = establishment.GsslacodeName,
                Easting = establishment.Easting,
                Northing = establishment.Northing,
                CensusAreaStatisticWard = establishment.CensusAreaStatisticWardName,
                MSOA = new NameAndCodeResponse {Name = establishment.MsoaName, Code = establishment.MsoaCode},
                LSOA = new NameAndCodeResponse {Name = establishment.LsoaName, Code = establishment.LsoaCode},
                SENStat = establishment.Senstat,
                SENNoStat = establishment.SennoStat,
                BoardingEstablishment = establishment.BoardingEstablishmentName,
                PropsName = establishment.PropsName,
                PreviousLocalAuthority = new NameAndCodeResponse
                    {Name = establishment.PreviousLaName, Code = establishment.PreviousLaCode},
                PreviousEstablishmentNumber = establishment.PreviousEstablishmentNumber,
                OfstedRating = establishment.OfstedRatingName,
                RSCRegion = establishment.RscregionName,
                Country = establishment.CountryName,
                UPRN = establishment.Uprn,
                MISEstablishment = expectedMisEstablishmentResponse,
                MISFurtherEducationEstablishment = null,
                SMARTData = expectedSmartDataResponse,
                Financial = null,
                Concerns = null
            };

            var httpRequestMessage = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://trams-api.com/establishment/mockukprn"),
                Headers = { 
                    { "ApiKey", "testing-api-key" }
                }
            };

            var response = await _client.SendAsync(httpRequestMessage);
            var jsonString = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<EstablishmentResponse>(jsonString);
            
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            result.Should().BeEquivalentTo(expected);
            
            _dbContext.Establishment.Remove(establishment);
            _dbContext.MisEstablishments.Remove(misEstablishment);
            _dbContext.SmartData.Remove(smartData);
            _dbContext.SaveChanges();
        }
    }
}