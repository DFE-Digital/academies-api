using System.Collections.Generic;
using FluentAssertions;
using TramsDataApi.DatabaseModels;
using TramsDataApi.Factories;
using TramsDataApi.ResponseModels;
using Xunit;

namespace TramsDataApi.Test.Factories
{
    public class TrustResponseFactoryTests
    {
        [Fact]
        public void TrustResponseFactory_CreatesTrustResponse_FromAGroup()
        {
            var group = new Group();
            
            var ifdDataResponse = new IFDDataResponse();
            var giasDataResponse = new GIASDataResponse();
            var academyResponses = new List<AcademyResponse>();
            var expected = new TrustResponse
                {IfdData = ifdDataResponse, GiasData = giasDataResponse, Academies = academyResponses};

            var result = TrustResponseFactory.Create(group);
            expected.Should().BeEquivalentTo(result);
        }
    }
}

namespace TramsDataApi.Factories
{
    public static class TrustResponseFactory
    {
        public static TrustResponse Create(Group group)
        {
            var ifdDataResponse = new IFDDataResponse();
            var giasDataResponse = new GIASDataResponse();
            var academyResponses = new List<AcademyResponse>();
            return new TrustResponse
                {IfdData = ifdDataResponse, GiasData = giasDataResponse, Academies = academyResponses};
        }
    }
}

namespace TramsDataApi.ResponseModels
{
    public class TrustResponse
    {
        public IFDDataResponse IfdData { get; set; }
        public GIASDataResponse GiasData { get; set; }
        public List<AcademyResponse> Academies { get; set; }
    }
    
    public class IFDDataResponse
    {
        public string TrustOpenDate { get; set; }
        public string LeadRSCRegion { get; set; }
        public string TrustContactPhoneNumber { get; set; }
        public string PerformanceAndRiskDateOfMeeting { get; set; }
        public string PrioritisedAreaOfReview { get; set; }
        public string CurrentSingleListGrouping { get; set; }
        public string DateOfGroupingDecision { get; set; }
        public string DateEnteredOntoSingleList { get; set; }
        public string TrustReviewWriteup { get; set; }
        public string DateOfTrustReviewMeeting { get; set; }
        public string FollowupLetterSent { get; set; }
        public string DateActionPlannedFor { get; set; }
        public string WIPSummaryGoesToMinister { get; set; }
        public string ExternalGovernancyReviewDate { get; set; }
        public string EfficiencyICFPreviewCompleted { get; set; }
        public string LinkToWorkplaceForEfficiencyICFReview { get; set; }
        public string NumberInTrust { get; set; }
    }

    public class GIASDataResponse
    {
        public string GroupId { get; set; }
        public string GroupName { get; set; }
        public string CompaniesHouseNumber { get; set; }
        public AddressResponse GroupContactAddress { get; set; }
        public string Ukprn { get; set; }
    }

    public class AddressResponse
    {
        public string Street { get; set; }
        public string Locality { get; set; }
        public string AdditionalLine { get; set; }
        public string Town { get; set; }
        public string County { get; set; }
        public string Postcode { get; set; }
    }
    
    public class AcademyResponse
    {
        public string Urn { get; set; }
        public string LocalAuthorityCode { get; set; }
        public string LocalAuthorityName { get; set; }
        public string EstablishmentNumber { get; set; }
        public string EstablishmentName { get; set; }
        public string EstablishmentType { get; set; }
        public string EstablishmentTypeGroupCode { get; set; }
        public NameAndCodeResponse EstablishmentStatus { get; set; }
        public NameAndCodeResponse ReasonEstablishmentOpened { get; set; }
        public string OpenDate { get; set; }
        public NameAndCodeResponse ReasonEstablishmentClosed { get; set; }
        public string CloseDate { get; set; }
        public NameAndCodeResponse PhaseOfEducation { get; set; }
        public string StatutoryLowAge { get; set; }
        public string StatutoryHighAge { get; set; }
        public NameAndCodeResponse Boarders { get; set; }
        public string NurseryProvision { get; set; }
        public NameAndCodeResponse OfficialSixthForm { get; set; }
        public NameAndCodeResponse Gender { get; set; }
        public NameAndCodeResponse ReligiousCharacter { get; set; }
        public string ReligiousEthos { get; set; }
        public NameAndCodeResponse Diocese { get; set; }
        public NameAndCodeResponse AdmissionsPolicy { get; set; }
        public string SchoolCapacity { get; set; }
        public NameAndCodeResponse SpecialClasses { get; set; }
        public CensusResponse Census { get; set; }
        public NameAndCodeResponse TrustSchoolFlag { get; set; }
        public NameAndCodeResponse Trusts { get; set; }
        public string SchoolSponsorFlag { get; set; }
        public string SchoolSponsors { get; set; }
        public string FederationFlag { get; set; }
        public NameAndCodeResponse Federations { get; set; }
        public string Ukprn { get; set; }
        public string FeheiIdentifier { get; set; }
        public string FurtherEducationType { get; set; }
        public string OfstedLastInspection { get; set; }
        public NameAndCodeResponse OfstedSpecialMeasures { get; set; }
        public string LastChangedDate { get; set; }
        public AddressResponse Address { get; set; }
        public string SchoolWebsite { get; set; }
        public string TelephoneNumber { get; set; }
        public string HeadteacherTitle { get; set; }
        public string HeadteacherFirstName { get; set; }
        public string HeadteacherLastName { get; set; }
        public string HeadteacherPreferredJobTitle { get; set; }
        public string Inspectorate { get; set; }
        public string InspectorateName { get; set; }
        public string InspectorateReport { get; set; }
        public string DateOfLastInspectionVisit { get; set; }
        public string DateOfNextInspectionVisit { get; set; }
        public string TeenMoth { get; set; }
        public string TeenMothPlaces { get; set; }
        public string CCF { get; set; }
        public string SENPRU { get; set; }
        public string EBD { get; set; }
        public string PlacesPRU { get; set; }
        public string FTProv { get; set; }
        public string EdByOther { get; set; }
        public string Section14Approved { get; set; }
        public string SEN1 { get; set; }
        public string SEN2 { get; set; }
        public string SEN3 { get; set; }
        public string SEN4 { get; set; }
        public string SEN5 { get; set; }
        public string SEN7 { get; set; }
        public string SEN8 { get; set; }
        public string SEN9 { get; set; }
        public string SEN10 { get; set; }
        public string SEN11 { get; set; }
        public string SEN12 { get; set; }
        public string SEN13 { get; set; }
        public string TypeOfResourcedProvision { get; set; }
        public string ResourcedProvisionOnRoll { get; set; }
        public string ResourcedProvisionOnCapacity { get; set; }
        public string SenUnitOnRoll { get; set; }
        public string SenUnitCapacity { get; set; }
        public NameAndCodeResponse GOR { get; set; }
        public NameAndCodeResponse DistrictAdministrative { get; set; }
        public NameAndCodeResponse AdministractiveWard { get; set; }
        public NameAndCodeResponse ParliamentaryConstituency { get; set; }
        public NameAndCodeResponse UrbanRural { get; set; }
        public string GSSLACode { get; set; }
        public string Easting { get; set; }
        public string Northing { get; set; }
        public string CensusAreaStatisticWard { get; set; }
        public NameAndCodeResponse MSOA { get; set; }
        public NameAndCodeResponse LSOA { get; set; }
        public string SENStat { get; set; }
        public string SENNoStat { get; set; }
        public string BoardingEstablishment { get; set; }
        public string PropsName { get; set; }
        public NameAndCodeResponse PreviousLocalAuthority { get; set; }
        public string PreviousEstablishmentNumber { get; set; }
        public string OfstedRating { get; set; }
        public string RSCRegion { get; set; }
        public string Country { get; set; }
        public string UPRN { get; set; }
        public MISEstablishmentResponse MISEstablishment { get; set; }
        public MISFEAResponse MISFurtherEducationEstablishment { get; set; }
        public SMARTDataResponse SMARTData { get; set; }
        public PlaceholderResponse Financial { get; set; }
        public PlaceholderResponse  Concerns { get; set; }
    }

    public class CensusResponse
    {
        public string CensusDate { get; set; }
        public string NumberOfPupils { get; set; }
        public string NumberOfBoys { get; set; }
        public string NumberOfGirls { get; set; }
        public string PercentageFsm { get; set; }
    }

    public class MISEstablishmentResponse
    {
        public string SiteName { get; set; }
        public string WebLink { get; set; }
        public string LAESTAB { get; set; }
        public string SchoolName { get; set; }
        public string OfstedPhase { get; set; }
        public string TypeOfEducation { get; set; }
        public string SchoolOpenDate { get; set; }
        public string SixthForm { get; set; }
        public string DesignatedReligiousCharacter { get; set; }
        public string ReligiousEthos { get; set; }
        public string FaithGrouping { get; set; }
        public string OfstedRegion { get; set; }
        public string Region { get; set; }
        public string LocalAuthority { get; set; }
        public string ParliamentaryConstituency { get; set; }
        public string Postcode { get; set; }
        public string IncomeDeprivationAffectingChildrenIndexQuintile { get; set; }
        public string TotalNumberOfPupils { get; set; }
        public string LatestSection8InspectionNumberSinceLastFullInspection { get; set; }
        public string Section8InspectionRelatedToCurrentSchoolUrn { get; set; }
        public string UrnAtTimeOfSection8Inspection { get; set; }
        public string SchoolNameAtTimeOfSection8Inspection { get; set; }
        public string SchoolTypeAtTimeOfSection8Inspection { get; set; }
        public string NumberOfSection8InspectionsSinceLastFullInspection { get; set; }
        public string DateOfLatestSection8Inspection { get; set; }
        public string Section8InspectionPublicationDate { get; set; }
        public string LatestSection8InspectionConvertedToFullInspection { get; set; }
        public string Section8InspectionOverallOutcome { get; set; }
        public string InspectionNumberOfLatestFullInspection { get; set; }
        public string InspectionType { get; set; }
        public string InspectionTypeGrouping { get; set; }
        public string InspectionStartDate { get; set; }
        public string InspectionEndDate { get; set; }
        public string PublicationDate { get; set; }
        public string LatestFullInspectionRelatesToCurrentSchoolUrn { get; set; }
        public string SchoolUrnAtTimeOfLastFullInspection { get; set; }
        public string LAESTABAtTimeOfLastFullInspection { get; set; }
        public string SchoolNameAtTimeOfLastFullInspection { get; set; }
        public string SchoolTypeAtTimeOfLastFullInspection { get; set; }
        public string OverallEffectiveness { get; set; }
        public string CategoryOfConcern { get; set; }
        public string QualityOfEducation { get; set; }
        public string BehaviourAndAttitudes { get; set; }
        public string PersonalDevelopment { get; set; }
        public string EffectivenessOfLeadershipAndManagement { get; set; }
        public string SafeguardingIsEffective { get; set; }
        public string EarlyYearsProvision { get; set; }
        public string SixthFormProvision { get; set; }
        public string PreviousFullInspectionNumber { get; set; }
        public string PreviousInspectionStartDate { get; set; }
        public string PreviousInspectionEndDate { get; set; }
        public string PreviousPublicationDate { get; set; }
        public string PreviousFullInspectionRelatesToUrnOfCurrentSchool { get; set; }
        public string UrnAtTheTimeOfPreviousFullInspection { get; set; }
        public string LAESTABAtTheTimeOfPreviousFullInspection { get; set; }
        public string SchoolNameAtTheTimeOfPreviousFullInspection { get; set; }
        public string SchoolTypeAtTheTimeOfPreviousFullInspection { get; set; }
        public string PreviousFullInspectionOverallEffectiveness { get; set; }
        public string PreviousCategoryOfConcern { get; set; }
        public string PreviousQualityOfEducation { get; set; }
        public string PreviousBehaviourAndAttitudes { get; set; }
        public string PreviousPersonalDevelopment { get; set; }
        public string PreviousEffectivenessOfLeadershipAndManagement { get; set; }
        public string PreviousIsSafeguardingEffective { get; set; }
        public string PreviousEarlyYearsProvision { get; set; }
        public string PreviousSixthFormProvision { get; set; }
    }

    public class MISFEAResponse
    {
        public ProviderResponse Provider { get; set; }
        public string LocalAuthority { get; set; }
        public string Region { get; set; }
        public string OfstedRegion { get; set; }
        public string DateOfLatestShortInspection { get; set; }
        public string NumberOfShortInspectionsSinceLastFullInspectionRAW { get; set; }
        public string NumberOfShortInspectionsSinceLastFullInspection { get; set; }
        public string InspectionNumber { get; set; }
        public string InspectionType { get; set; }
        public string FirstDayOfInspection { get; set; }
        public string LastDayOfInspection { get; set; }
        public string DatePublished { get; set; }
        public string OverallEffectivenessRAW { get; set; }
        public string OverallEffectiveness { get; set; }
        public string QualityOfEducationRAW { get; set; }
        public string QualityOfEducation { get; set; }
        public string BehaviourAndAttitudesRAW { get; set; }
        public string BehaviourAndAttitudes { get; set; }
        public string PersonalDevelopmentRAW { get; set; }
        public string PersonalDevelopment { get; set; }
        public string EffectivenessOfLeadershipAndManagementRAW { get; set; }
        public string EffectivenessOfLeadershipAndManagement { get; set; }
        public string IsSafeguardingEffective { get; set; }
        public string PreviousInspectionNumber { get; set; }
        public string PreviousLastDayOfInspection { get; set; }
        public string PreviousOverallEffectivenessRAW { get; set; }
        public string PreviousOverallEffectiveness { get; set; }
    }

    public class SMARTDataResponse
    {
        public string ProbabilityOfDeclining { get; set; }
        public string ProbabilityOfStayingTheSame { get; set; }
        public string ProbabilityOfImproving { get; set; }
        public string PredictedChangeInProgress8Score { get; set; }
        public string PredictedChanceOfChangeOccurring { get; set; }
        public string TotalNumberOfRisks { get; set; }
        public string TotalRiskScore { get; set; }
        public string RiskRatingNum { get; set; }
    }

    public class PlaceholderResponse
    {
        public string URN { get; set; }
        public string UKPRN { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string Group { get; set; }
    }

    public class ProviderResponse
    {}
    public class NameAndCodeResponse
    {
        public string Name { get; set; }
        public string Code { get; set; }
    }
}