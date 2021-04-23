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
        
    }

    public class NameAndCodeResponse
    {
        public string Name { get; set; }
        public string Code { get; set; }
    }
}