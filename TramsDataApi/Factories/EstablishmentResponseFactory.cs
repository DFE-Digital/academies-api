using TramsDataApi.DatabaseModels;
using TramsDataApi.ResponseModels;

namespace TramsDataApi.Factories
{
    public class EstablishmentResponseFactory
    {
        public static EstablishmentResponse Create(Establishment establishment, MisEstablishments misEstablishment, SmartData smartData)
        {
            if (establishment == null)
            {
                return null;
            }
            
            var academyResponse = new EstablishmentResponse
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
                MISEstablishment = MISEstablishmentResponseFactory.Create(misEstablishment),
                MISFurtherEducationEstablishment = null,
                SMARTData = SmartDataResponseFactory.Create(smartData),
                Financial = null,
                Concerns = null
            };
            return academyResponse;
        }
    }
}
