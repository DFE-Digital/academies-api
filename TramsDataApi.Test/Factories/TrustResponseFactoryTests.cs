using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using FizzWare.NBuilder;
using FizzWare.NBuilder.PropertyNaming;
using FluentAssertions;
using TramsDataApi.DatabaseModels;
using TramsDataApi.Factories;
using TramsDataApi.ResponseModels;
using Xunit;

namespace TramsDataApi.Test.Factories
{
    public class TrustResponseFactoryTests
    {
        public TrustResponseFactoryTests()
        {
            BuilderSetup.SetDefaultPropertyName(new RandomValuePropertyNamer(new BuilderSettings()));
        }

        [Fact]
        public void TrustResponseFactory_CreatesTrustResponse_FromAGroup()
        {
            var group = Builder<Group>.CreateNew().Build();
            var ifdTrustData =  Builder<Trust>.CreateNew().Build();

            var ifdDataResponse = new IFDDataResponse
            {
                TrustOpenDate = ifdTrustData.TrustsTrustOpenDate?.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture),
                LeadRSCRegion = ifdTrustData.LeadRscRegion,
                TrustContactPhoneNumber = ifdTrustData.TrustContactDetailsTrustContactPhoneNumber,
                PerformanceAndRiskDateOfMeeting = ifdTrustData.TrustPerformanceAndRiskDateOfMeeting?.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture),
                PrioritisedAreaOfReview = ifdTrustData.TrustPerformanceAndRiskPrioritisedForAReview,
                CurrentSingleListGrouping = ifdTrustData.TrustPerformanceAndRiskSingleListGrouping,
                DateOfGroupingDecision = ifdTrustData.TrustPerformanceAndRiskDateOfGroupingDecision?.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture),
                DateEnteredOntoSingleList = ifdTrustData.TrustPerformanceAndRiskDateEnteredOntoSingleList?.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture),
                TrustReviewWriteup = ifdTrustData.TrustPerformanceAndRiskTrustReviewWriteUp,
                DateOfTrustReviewMeeting = ifdTrustData.TrustPerformanceAndRiskDateOfMeeting?.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture),
                FollowupLetterSent = ifdTrustData.TrustPerformanceAndRiskFollowUpLetterSent,
                DateActionPlannedFor = ifdTrustData.TrustPerformanceAndRiskDateActionPlannedFor?.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture),
                WIPSummaryGoesToMinister = ifdTrustData.TrustPerformanceAndRiskWipSummaryGoesToMinister,
                ExternalGovernanceReviewDate =
                    ifdTrustData.TrustPerformanceAndRiskExternalGovernanceReviewDate?.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture),
                EfficiencyICFPreviewCompleted = ifdTrustData.TrustPerformanceAndRiskEfficiencyIcfpReviewCompleted,
                EfficiencyICFPreviewOther = ifdTrustData.TrustPerformanceAndRiskEfficiencyIcfpReviewOther,
                LinkToWorkplaceForEfficiencyICFReview =
                    ifdTrustData.TrustPerformanceAndRiskLinkToWorkplaceForEfficiencyIcfpReview,
                NumberInTrust = ifdTrustData.NumberInTrust.ToString()
            };
            
            var giasDataResponse = new GIASDataResponse
            {
                GroupId = group.GroupId,
                GroupName = group.GroupName,
                CompaniesHouseNumber = group.CompaniesHouseNumber,
                GroupContactAddress = new AddressResponse
                {
                    Street = group.GroupContactStreet,
                    AdditionalLine = group.GroupContactAddress3,
                    Locality = group.GroupContactLocality,
                    Town = group.GroupContactTown,
                    County = group.GroupContactCounty,
                    Postcode = group.GroupContactPostcode
                },
                Ukprn = group.Ukprn
            };
            var academyResponses = new List<EstablishmentResponse>();
            var expected = new TrustResponse
                {IfdData = ifdDataResponse, GiasData = giasDataResponse, Academies = academyResponses};

            var result = TrustResponseFactory.Create(group, ifdTrustData, new List<Establishment>());
            result.Should().BeEquivalentTo(expected);
        }
        
        [Fact]
         public void TrustResponseFactory_CreatesTrustResponse_FromAGroup_WhenIfdTrustDataIsNull()
         {
            var group = Builder<Group>.CreateNew().Build();
            var giasDataResponse = new GIASDataResponse
            {
                GroupId = group.GroupId,
                GroupName = group.GroupName,
                CompaniesHouseNumber = group.CompaniesHouseNumber,
                GroupContactAddress = new AddressResponse
                {
                    Street = group.GroupContactStreet,
                    AdditionalLine = group.GroupContactAddress3,
                    Locality = group.GroupContactLocality,
                    Town = group.GroupContactTown,
                    County = group.GroupContactCounty,
                    Postcode = group.GroupContactPostcode
                },
                Ukprn = group.Ukprn
            };
            var academyResponses = new List<EstablishmentResponse>();
            var expected = new TrustResponse
                {IfdData = null, GiasData = giasDataResponse, Academies = academyResponses};

            var result = TrustResponseFactory.Create(group, null, new List<Establishment>());
            result.Should().BeEquivalentTo(expected);
        }
         
         [Fact]
         public void TrustResponseFactory_CreatesTrustResponseWithAcademies_FromAGroup_WhenGroupHasAnAcademy()
         {
             var group = Builder<Group>.CreateNew().Build();
             var testEstablishment =  Builder<Establishment>.CreateNew().With(e => e.TrustsCode = group.GroupId).Build();
             var giasDataResponse = new GIASDataResponse
             {
                 GroupId = group.GroupId,
                 GroupName = group.GroupName,
                 CompaniesHouseNumber = group.CompaniesHouseNumber,
                 GroupContactAddress = new AddressResponse
                 {
                     Street = group.GroupContactStreet,
                     AdditionalLine = group.GroupContactAddress3,
                     Locality = group.GroupContactLocality,
                     Town = group.GroupContactTown,
                     County = group.GroupContactCounty,
                     Postcode = group.GroupContactPostcode
                 },
                 Ukprn = group.Ukprn
             };
             var academyResponses = new List<EstablishmentResponse>
             {
                 new EstablishmentResponse
                 {
                     Urn = testEstablishment.Urn.ToString(),
                     LocalAuthorityCode = testEstablishment.LaCode,
                     LocalAuthorityName = testEstablishment.LaName,
                     EstablishmentNumber = testEstablishment.EstablishmentNumber,
                     EstablishmentName = testEstablishment.EstablishmentName,
                     EstablishmentType = new NameAndCodeResponse {Name = testEstablishment.TypeOfEstablishmentName, Code = testEstablishment.TypeOfEstablishmentCode},
                     EstablishmentTypeGroup =
                         new NameAndCodeResponse {Name = testEstablishment.EstablishmentTypeGroupName, Code = testEstablishment.EstablishmentTypeGroupCode},
                     EstablishmentStatus = new NameAndCodeResponse {Name = testEstablishment.EstablishmentStatusName, Code = testEstablishment.EstablishmentStatusCode},
                     ReasonEstablishmentOpened = new NameAndCodeResponse {Name = testEstablishment.ReasonEstablishmentOpenedName, Code = testEstablishment.ReasonEstablishmentOpenedCode},
                     OpenDate = testEstablishment.OpenDate,
                     ReasonEstablishmentClosed = new NameAndCodeResponse {Name = testEstablishment.ReasonEstablishmentClosedName, Code = testEstablishment.ReasonEstablishmentClosedCode},
                     CloseDate = testEstablishment.CloseDate,
                     PhaseOfEducation = new NameAndCodeResponse {Name = testEstablishment.PhaseOfEducationName, Code = testEstablishment.PhaseOfEducationCode},
                     StatutoryLowAge = testEstablishment.StatutoryLowAge,
                     StatutoryHighAge = testEstablishment.StatutoryHighAge,
                     Boarders = new NameAndCodeResponse {Name = testEstablishment.BoardersName, Code = testEstablishment.BoardersCode},
                     NurseryProvision = testEstablishment.NurseryProvisionName,
                     OfficialSixthForm =
                         new NameAndCodeResponse {Name = testEstablishment.OfficialSixthFormName, Code = testEstablishment.OfficialSixthFormCode},
                     Gender = new NameAndCodeResponse {Name = testEstablishment.GenderName, Code = testEstablishment.GenderCode},
                     ReligiousCharacter = new NameAndCodeResponse {Name = testEstablishment.ReligiousCharacterName, Code = testEstablishment.ReligiousCharacterCode},
                     ReligiousEthos = testEstablishment.ReligiousEthosName,
                     Diocese = new NameAndCodeResponse {Name = testEstablishment.DioceseName, Code = testEstablishment.DioceseCode},
                     AdmissionsPolicy = new NameAndCodeResponse {Name = testEstablishment.AdmissionsPolicyName, Code = testEstablishment.AdmissionsPolicyCode},
                     SchoolCapacity = testEstablishment.SchoolCapacity,
                     SpecialClasses = new NameAndCodeResponse {Name = testEstablishment.SpecialClassesName, Code = testEstablishment.SpecialClassesCode},
                     Census =
                         new CensusResponse
                         {
                             CensusDate = testEstablishment.CensusDate,
                             NumberOfPupils = testEstablishment.NumberOfPupils,
                             NumberOfBoys = testEstablishment.NumberOfBoys,
                             NumberOfGirls = testEstablishment.NumberOfGirls,
                             PercentageFsm = testEstablishment.PercentageFsm
                         },
                     TrustSchoolFlag = new NameAndCodeResponse {Name = testEstablishment.TrustSchoolFlagName, Code = testEstablishment.TrustSchoolFlagCode},
                     Trusts = new NameAndCodeResponse {Name = testEstablishment.TrustsName, Code = testEstablishment.TrustsCode},
                     SchoolSponsorFlag = testEstablishment.SchoolSponsorFlagName,
                     SchoolSponsors = testEstablishment.SchoolSponsorsName,
                     FederationFlag = testEstablishment.FederationFlagName,
                     Federations = new NameAndCodeResponse {Name = testEstablishment.FederationsName, Code = testEstablishment.FederationsCode},
                     Ukprn = testEstablishment.Ukprn,
                     FeheiIdentifier = testEstablishment.Feheidentifier,
                     FurtherEducationType = testEstablishment.FurtherEducationTypeName,
                     OfstedLastInspection = testEstablishment.OfstedLastInsp,
                     OfstedSpecialMeasures = new NameAndCodeResponse {Name = testEstablishment.OfstedSpecialMeasuresName, Code = testEstablishment.OfstedSpecialMeasuresCode},
                     LastChangedDate = testEstablishment.LastChangedDate,
                     Address =
                         new AddressResponse
                         {
                             Street = testEstablishment.Street,
                             Locality = testEstablishment.Locality,
                             AdditionalLine = testEstablishment.Address3,
                             Town = testEstablishment.Town,
                             County = testEstablishment.CountyName,
                             Postcode = testEstablishment.Postcode
                         },
                     SchoolWebsite = testEstablishment.SchoolWebsite,
                     TelephoneNumber = testEstablishment.TelephoneNum,
                     HeadteacherTitle = testEstablishment.HeadTitleName,
                     HeadteacherFirstName = testEstablishment.HeadFirstName,
                     HeadteacherLastName = testEstablishment.HeadLastName,
                     HeadteacherPreferredJobTitle = testEstablishment.HeadPreferredJobTitle,
                     InspectorateName = testEstablishment.InspectorateNameName,
                     InspectorateReport = testEstablishment.InspectorateReport,
                     DateOfLastInspectionVisit = testEstablishment.DateOfLastInspectionVisit,
                     DateOfNextInspectionVisit = testEstablishment.NextInspectionVisit,
                     TeenMoth = testEstablishment.TeenMothName,
                     TeenMothPlaces = testEstablishment.TeenMothPlaces,
                     CCF = testEstablishment.CcfName,
                     SENPRU = testEstablishment.SenpruName,
                     EBD = testEstablishment.EbdName,
                     PlacesPRU = testEstablishment.PlacesPru,
                     FTProv = testEstablishment.FtprovName,
                     EdByOther = testEstablishment.EdByOtherName,
                     Section14Approved = testEstablishment.Section41ApprovedName,
                     SEN1 = testEstablishment.Sen1Name,
                     SEN2 = testEstablishment.Sen2Name,
                     SEN3 = testEstablishment.Sen3Name,
                     SEN4 = testEstablishment.Sen4Name,
                     SEN5 = testEstablishment.Sen5Name,
                     SEN6 = testEstablishment.Sen6Name,
                     SEN7 = testEstablishment.Sen7Name,
                     SEN8 = testEstablishment.Sen8Name,
                     SEN9 = testEstablishment.Sen9Name,
                     SEN10 = testEstablishment.Sen10Name,
                     SEN11 = testEstablishment.Sen11Name,
                     SEN12 = testEstablishment.Sen12Name,
                     SEN13 = testEstablishment.Sen13Name,
                     TypeOfResourcedProvision = testEstablishment.TypeOfResourcedProvisionName,
                     ResourcedProvisionOnRoll = testEstablishment.ResourcedProvisionOnRoll,
                     ResourcedProvisionOnCapacity = testEstablishment.ResourcedProvisionCapacity,
                     SenUnitOnRoll = testEstablishment.SenUnitOnRoll,
                     SenUnitCapacity = testEstablishment.SenUnitCapacity,
                     GOR = new NameAndCodeResponse {Name = testEstablishment.GorName, Code = testEstablishment.GorCode},
                     DistrictAdministrative =
                         new NameAndCodeResponse {Name = testEstablishment.DistrictAdministrativeName, Code = testEstablishment.DistrictAdministrativeCode},
                     AdministractiveWard = new NameAndCodeResponse {Name = testEstablishment.AdministrativeWardName, Code = testEstablishment.AdministrativeWardCode},
                     ParliamentaryConstituency =
                         new NameAndCodeResponse
                         {
                             Name = testEstablishment.ParliamentaryConstituencyName, Code = testEstablishment.ParliamentaryConstituencyCode
                         },
                     UrbanRural =
                         new NameAndCodeResponse
                         {
                             Name = testEstablishment.UrbanRuralName, Code = testEstablishment.UrbanRuralCode
                         },
                     GSSLACode = testEstablishment.GsslacodeName,
                     Easting = testEstablishment.Easting,
                     Northing = testEstablishment.Northing,
                     CensusAreaStatisticWard = testEstablishment.CensusAreaStatisticWardName,
                     MSOA = new NameAndCodeResponse {Name = testEstablishment.MsoaName, Code = testEstablishment.MsoaCode},
                     LSOA = new NameAndCodeResponse {Name = testEstablishment.LsoaName, Code = testEstablishment.LsoaCode},
                     SENStat = testEstablishment.Senstat,
                     SENNoStat = testEstablishment.SennoStat,
                     BoardingEstablishment = testEstablishment.BoardingEstablishmentName,
                     PropsName = testEstablishment.PropsName,
                     PreviousLocalAuthority = new NameAndCodeResponse {Name = testEstablishment.PreviousLaName, Code = testEstablishment.PreviousLaCode},
                     PreviousEstablishmentNumber = testEstablishment.PreviousEstablishmentNumber,
                     OfstedRating = testEstablishment.OfstedRatingName,
                     RSCRegion = testEstablishment.RscregionName,
                     Country = testEstablishment.CountryName,
                     UPRN = testEstablishment.Uprn,
                     MISEstablishment = null,
                     MISFurtherEducationEstablishment = null,
                     SMARTData = null,
                     Financial = null,
                     Concerns = null
                 }
             };
             var expected = new TrustResponse
                 {IfdData = null, GiasData = giasDataResponse, Academies = academyResponses};

             var result = TrustResponseFactory.Create(group, null, new List<Establishment>(){testEstablishment});
             result.Should().BeEquivalentTo(expected);
         }
                  [Fact]
         public void TrustResponseFactory_CreatesTrustResponseWithAcademies_FromAGroup_WhenGroupHasMultipleAcademies()
         {
             var group = Builder<Group>.CreateNew().Build();
             var testEstablishments =  Builder<Establishment>.CreateListOfSize(5).All().With(e => e.TrustsCode = group.GroupId).Build().ToList();
             var giasDataResponse = new GIASDataResponse
             {
                 GroupId = group.GroupId,
                 GroupName = group.GroupName,
                 CompaniesHouseNumber = group.CompaniesHouseNumber,
                 GroupContactAddress = new AddressResponse
                 {
                     Street = group.GroupContactStreet,
                     AdditionalLine = group.GroupContactAddress3,
                     Locality = group.GroupContactLocality,
                     Town = group.GroupContactTown,
                     County = group.GroupContactCounty,
                     Postcode = group.GroupContactPostcode
                 },
                 Ukprn = group.Ukprn
             };
             var academyResponses = testEstablishments.Select(testEstablishment => new EstablishmentResponse
                 {
                     Urn = testEstablishment.Urn.ToString(),
                     LocalAuthorityCode = testEstablishment.LaCode,
                     LocalAuthorityName = testEstablishment.LaName,
                     EstablishmentNumber = testEstablishment.EstablishmentNumber,
                     EstablishmentName = testEstablishment.EstablishmentName,
                     EstablishmentType = new NameAndCodeResponse {Name = testEstablishment.TypeOfEstablishmentName, Code = testEstablishment.TypeOfEstablishmentCode},
                     EstablishmentTypeGroup =
                         new NameAndCodeResponse {Name = testEstablishment.EstablishmentTypeGroupName, Code = testEstablishment.EstablishmentTypeGroupCode},
                     EstablishmentStatus = new NameAndCodeResponse {Name = testEstablishment.EstablishmentStatusName, Code = testEstablishment.EstablishmentStatusCode},
                     ReasonEstablishmentOpened = new NameAndCodeResponse {Name = testEstablishment.ReasonEstablishmentOpenedName, Code = testEstablishment.ReasonEstablishmentOpenedCode},
                     OpenDate = testEstablishment.OpenDate,
                     ReasonEstablishmentClosed = new NameAndCodeResponse {Name = testEstablishment.ReasonEstablishmentClosedName, Code = testEstablishment.ReasonEstablishmentClosedCode},
                     CloseDate = testEstablishment.CloseDate,
                     PhaseOfEducation = new NameAndCodeResponse {Name = testEstablishment.PhaseOfEducationName, Code = testEstablishment.PhaseOfEducationCode},
                     StatutoryLowAge = testEstablishment.StatutoryLowAge,
                     StatutoryHighAge = testEstablishment.StatutoryHighAge,
                     Boarders = new NameAndCodeResponse {Name = testEstablishment.BoardersName, Code = testEstablishment.BoardersCode},
                     NurseryProvision = testEstablishment.NurseryProvisionName,
                     OfficialSixthForm =
                         new NameAndCodeResponse {Name = testEstablishment.OfficialSixthFormName, Code = testEstablishment.OfficialSixthFormCode},
                     Gender = new NameAndCodeResponse {Name = testEstablishment.GenderName, Code = testEstablishment.GenderCode},
                     ReligiousCharacter = new NameAndCodeResponse {Name = testEstablishment.ReligiousCharacterName, Code = testEstablishment.ReligiousCharacterCode},
                     ReligiousEthos = testEstablishment.ReligiousEthosName,
                     Diocese = new NameAndCodeResponse {Name = testEstablishment.DioceseName, Code = testEstablishment.DioceseCode},
                     AdmissionsPolicy = new NameAndCodeResponse {Name = testEstablishment.AdmissionsPolicyName, Code = testEstablishment.AdmissionsPolicyCode},
                     SchoolCapacity = testEstablishment.SchoolCapacity,
                     SpecialClasses = new NameAndCodeResponse {Name = testEstablishment.SpecialClassesName, Code = testEstablishment.SpecialClassesCode},
                     Census =
                         new CensusResponse
                         {
                             CensusDate = testEstablishment.CensusDate,
                             NumberOfPupils = testEstablishment.NumberOfPupils,
                             NumberOfBoys = testEstablishment.NumberOfBoys,
                             NumberOfGirls = testEstablishment.NumberOfGirls,
                             PercentageFsm = testEstablishment.PercentageFsm
                         },
                     TrustSchoolFlag = new NameAndCodeResponse {Name = testEstablishment.TrustSchoolFlagName, Code = testEstablishment.TrustSchoolFlagCode},
                     Trusts = new NameAndCodeResponse {Name = testEstablishment.TrustsName, Code = testEstablishment.TrustsCode},
                     SchoolSponsorFlag = testEstablishment.SchoolSponsorFlagName,
                     SchoolSponsors = testEstablishment.SchoolSponsorsName,
                     FederationFlag = testEstablishment.FederationFlagName,
                     Federations = new NameAndCodeResponse {Name = testEstablishment.FederationsName, Code = testEstablishment.FederationsCode},
                     Ukprn = testEstablishment.Ukprn,
                     FeheiIdentifier = testEstablishment.Feheidentifier,
                     FurtherEducationType = testEstablishment.FurtherEducationTypeName,
                     OfstedLastInspection = testEstablishment.OfstedLastInsp,
                     OfstedSpecialMeasures = new NameAndCodeResponse {Name = testEstablishment.OfstedSpecialMeasuresName, Code = testEstablishment.OfstedSpecialMeasuresCode},
                     LastChangedDate = testEstablishment.LastChangedDate,
                     Address =
                         new AddressResponse
                         {
                             Street = testEstablishment.Street,
                             Locality = testEstablishment.Locality,
                             AdditionalLine = testEstablishment.Address3,
                             Town = testEstablishment.Town,
                             County = testEstablishment.CountyName,
                             Postcode = testEstablishment.Postcode
                         },
                     SchoolWebsite = testEstablishment.SchoolWebsite,
                     TelephoneNumber = testEstablishment.TelephoneNum,
                     HeadteacherTitle = testEstablishment.HeadTitleName,
                     HeadteacherFirstName = testEstablishment.HeadFirstName,
                     HeadteacherLastName = testEstablishment.HeadLastName,
                     HeadteacherPreferredJobTitle = testEstablishment.HeadPreferredJobTitle,
                     InspectorateName = testEstablishment.InspectorateNameName,
                     InspectorateReport = testEstablishment.InspectorateReport,
                     DateOfLastInspectionVisit = testEstablishment.DateOfLastInspectionVisit,
                     DateOfNextInspectionVisit = testEstablishment.NextInspectionVisit,
                     TeenMoth = testEstablishment.TeenMothName,
                     TeenMothPlaces = testEstablishment.TeenMothPlaces,
                     CCF = testEstablishment.CcfName,
                     SENPRU = testEstablishment.SenpruName,
                     EBD = testEstablishment.EbdName,
                     PlacesPRU = testEstablishment.PlacesPru,
                     FTProv = testEstablishment.FtprovName,
                     EdByOther = testEstablishment.EdByOtherName,
                     Section14Approved = testEstablishment.Section41ApprovedName,
                     SEN1 = testEstablishment.Sen1Name,
                     SEN2 = testEstablishment.Sen2Name,
                     SEN3 = testEstablishment.Sen3Name,
                     SEN4 = testEstablishment.Sen4Name,
                     SEN5 = testEstablishment.Sen5Name,
                     SEN6 = testEstablishment.Sen6Name,
                     SEN7 = testEstablishment.Sen7Name,
                     SEN8 = testEstablishment.Sen8Name,
                     SEN9 = testEstablishment.Sen9Name,
                     SEN10 = testEstablishment.Sen10Name,
                     SEN11 = testEstablishment.Sen11Name,
                     SEN12 = testEstablishment.Sen12Name,
                     SEN13 = testEstablishment.Sen13Name,
                     TypeOfResourcedProvision = testEstablishment.TypeOfResourcedProvisionName,
                     ResourcedProvisionOnRoll = testEstablishment.ResourcedProvisionOnRoll,
                     ResourcedProvisionOnCapacity = testEstablishment.ResourcedProvisionCapacity,
                     SenUnitOnRoll = testEstablishment.SenUnitOnRoll,
                     SenUnitCapacity = testEstablishment.SenUnitCapacity,
                     GOR = new NameAndCodeResponse {Name = testEstablishment.GorName, Code = testEstablishment.GorCode},
                     DistrictAdministrative =
                         new NameAndCodeResponse {Name = testEstablishment.DistrictAdministrativeName, Code = testEstablishment.DistrictAdministrativeCode},
                     AdministractiveWard = new NameAndCodeResponse {Name = testEstablishment.AdministrativeWardName, Code = testEstablishment.AdministrativeWardCode},
                     ParliamentaryConstituency =
                         new NameAndCodeResponse
                         {
                             Name = testEstablishment.ParliamentaryConstituencyName, Code = testEstablishment.ParliamentaryConstituencyCode
                         },
                     UrbanRural =
                         new NameAndCodeResponse
                         {
                             Name = testEstablishment.UrbanRuralName, Code = testEstablishment.UrbanRuralCode
                         },
                     GSSLACode = testEstablishment.GsslacodeName,
                     Easting = testEstablishment.Easting,
                     Northing = testEstablishment.Northing,
                     CensusAreaStatisticWard = testEstablishment.CensusAreaStatisticWardName,
                     MSOA = new NameAndCodeResponse {Name = testEstablishment.MsoaName, Code = testEstablishment.MsoaCode},
                     LSOA = new NameAndCodeResponse {Name = testEstablishment.LsoaName, Code = testEstablishment.LsoaCode},
                     SENStat = testEstablishment.Senstat,
                     SENNoStat = testEstablishment.SennoStat,
                     BoardingEstablishment = testEstablishment.BoardingEstablishmentName,
                     PropsName = testEstablishment.PropsName,
                     PreviousLocalAuthority = new NameAndCodeResponse {Name = testEstablishment.PreviousLaName, Code = testEstablishment.PreviousLaCode},
                     PreviousEstablishmentNumber = testEstablishment.PreviousEstablishmentNumber,
                     OfstedRating = testEstablishment.OfstedRatingName,
                     RSCRegion = testEstablishment.RscregionName,
                     Country = testEstablishment.CountryName,
                     UPRN = testEstablishment.Uprn,
                     MISEstablishment = null,
                     MISFurtherEducationEstablishment = null,
                     SMARTData = null,
                     Financial = null,
                     Concerns = null
                 }).ToList();
                 var expected = new TrustResponse
                 {IfdData = null, GiasData = giasDataResponse, Academies = academyResponses};

             var result = TrustResponseFactory.Create(group, null, testEstablishments);
             result.Should().BeEquivalentTo(expected);
         }
    }
}
    