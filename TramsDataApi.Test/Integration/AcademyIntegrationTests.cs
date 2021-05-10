using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using TramsDataApi.DatabaseModels;
using TramsDataApi.ResponseModels;
using Xunit;

namespace TramsDataApi.Test.Integration
{
    [Collection("Database")]
    public class AcademyIntegrationTests : IClassFixture<TramsDataApiFactory>
    {
        private readonly HttpClient _client;
        private readonly TramsDbContext _dbContext;

        public AcademyIntegrationTests(TramsDataApiFactory fixture)
        {
            _client = fixture.CreateClient();
            _client.BaseAddress = new Uri("https://trams-api.com/");
            _dbContext = fixture.Services.GetRequiredService<TramsDbContext>();
        }

        [Fact]
        public async Task CanGetAcademyByUkprn()
        {
            var establishment = GenerateEstablishment();
            await _dbContext.Establishment.AddAsync(establishment);
            await _dbContext.SaveChangesAsync();

            var expected = new AcademyResponse
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
                MISEstablishment = null,
                MISFurtherEducationEstablishment = null,
                SMARTData = null,
                Financial = null,
                Concerns = null
            };

            var httpRequestMessage = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://trams-api.com/academy/mockukprn"),
                Headers = { 
                    { "ApiKey", "testing-api-key" }
                }
            };

            var response = await _client.SendAsync(httpRequestMessage);
            var jsonString = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<AcademyResponse>(jsonString);
            
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            result.Should().BeEquivalentTo(expected);
            
            _dbContext.Establishment.Remove(establishment);
            await _dbContext.SaveChangesAsync();
        }
        
        private Establishment GenerateEstablishment()
        {
            return new Establishment
            {
                Urn = 100001,
                LaCode = "203",
                LaName = "Greenwich",
                EstablishmentNumber = "4100",
                EstablishmentName = "Plum Village School",
                TypeOfEstablishmentCode = "02",
                TypeOfEstablishmentName = "Voluntary added school",
                EstablishmentTypeGroupCode = "4",
                EstablishmentTypeGroupName = "Local authority maintained schools",
                EstablishmentStatusCode = "1",
                EstablishmentStatusName = "Open",
                ReasonEstablishmentOpenedCode = "00",
                ReasonEstablishmentOpenedName = "Not applicable",
                OpenDate = "01-01-1999",
                ReasonEstablishmentClosedCode = "00",
                ReasonEstablishmentClosedName = "Not applicable",
                CloseDate = null,
                PhaseOfEducationCode = "2",
                PhaseOfEducationName = "Primary",
                StatutoryLowAge = "3",
                StatutoryHighAge = "11",
                BoardersCode = "1",
                BoardersName = "No boarders",
                NurseryProvisionName = "Has Nursery Classes",
                OfficialSixthFormCode = "2",
                OfficialSixthFormName = "Doers not have a sixth form",
                GenderCode = "3",
                GenderName = "Mixed",
                ReligiousCharacterCode = "02",
                ReligiousCharacterName = "Church of England",
                ReligiousEthosName = "Does not apply",
                DioceseCode = "CE23",
                DioceseName = "Diocese of London",
                AdmissionsPolicyCode = "0",
                AdmissionsPolicyName = "Not applicable",
                SchoolCapacity = "300",
                SpecialClassesCode = "2",
                SpecialClassesName = "No Special Classes",
                CensusDate = "16-01-2020",
                NumberOfPupils = "276",
                NumberOfBoys = "136",
                NumberOfGirls = "140",
                PercentageFsm = "10.2",
                TrustSchoolFlagCode = "0",
                TrustSchoolFlagName = "Not applicable",
                TrustsCode = "500",
                TrustsName = "Test Group",
                SchoolSponsorFlagName = "Not applicable",
                SchoolSponsorsName = null,
                FederationFlagName = "Not under a federation",
                FederationsCode = null,
                FederationsName = null,
                Ukprn = "mockukprn",
                Feheidentifier = null,
                FurtherEducationTypeName = "Not applicable",
                OfstedLastInsp = "19-04-2013",
                OfstedSpecialMeasuresCode = "0",
                OfstedSpecialMeasuresName = "Not applicable",
                LastChangedDate =  "04-02-2021",
                Street = "St Jame's Passage",
                Locality = "Duke's Place",
                Address3 = null,
                Town = "London",
                CountyName = null,
                Postcode = "EC3A 9DA",
                SchoolWebsite = "www.test-school.com",
                TelephoneNum = "02072342211",
                HeadTitleName = "Miss",
                HeadFirstName = "Jenny",
                HeadLastName = "Bloggs",
                HeadPreferredJobTitle = "Headteacher",
                InspectorateNameName = "ISI",
                InspectorateReport = null,
                DateOfLastInspectionVisit = null,
                NextInspectionVisit = null,
                TeenMothName = "Not applicable",
                TeenMothPlaces = null,
                CcfName = "Not applicable",
                SenpruName = "Not applicable",
                EbdName = "Not applicable",
                PlacesPru = null,
                FtprovName = null,
                EdByOtherName = "Not applicable",
                Section41ApprovedName = "Not applicable",
                Sen1Name = null,
                Sen2Name = null,
                Sen3Name = null,
                Sen4Name = null,
                Sen5Name = null,
                Sen6Name = null,
                Sen7Name = null,
                Sen8Name = null,
                Sen9Name = null,
                Sen10Name = null,
                Sen11Name = null,
                Sen12Name = null,
                Sen13Name = null,
                TypeOfResourcedProvisionName = null,
                ResourcedProvisionOnRoll = null,
                ResourcedProvisionCapacity = null,
                SenUnitOnRoll = null,
                SenUnitCapacity = null,
                GorCode = "H",
                GorName = "London",
                DistrictAdministrativeCode = "E09000001",
                DistrictAdministrativeName = "City of London",
                AdministrativeWardCode = "E05009293",
                AdministrativeWardName = "Cripplegate",
                ParliamentaryConstituencyCode = "E14000639",
                ParliamentaryConstituencyName = "Cities of London and Westminster",
                UrbanRuralCode = "A1",
                UrbanRuralName = "(England/Wales) Urban major conurbation",
                GsslacodeName = "E09000001",
                Easting = "533498",
                Northing = "181201",
                CensusAreaStatisticWardName = null,
                MsoaName = "City of London 001",
                LsoaName = "City of London 001F",
                Senstat = "0",
                SennoStat = "63",
                BoardingEstablishmentName = "Does not have boarders",
                PropsName = "Corporation of London",
                PreviousLaCode = "000",
                PreviousLaName = "Not applicable",
                PreviousEstablishmentNumber = null,
                OfstedRatingName = "Outstanding",
                RscregionName = "North-West London and South-Central England",
                CountryName = "United Kingdom",
                Uprn = "20000007192",
                SiteName = null,
                MsoaCode = null,
                LsoaCode = null,
                BsoinspectorateNameName = null,
                Chnumber = null,
                EstablishmentAccreditedCode = null,
                EstablishmentAccreditedName = null,
                QabnameCode = null,
                QabnameName = null,
                Qabreport = null
            };
        }
    }
}