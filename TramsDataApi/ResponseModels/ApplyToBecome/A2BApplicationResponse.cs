using System;

namespace TramsDataApi.ResponseModels.ApplyToBecome
{
    public class A2BApplicationResponse
    {
        public string Name {get; set;}
        public int ApplicationId {get; set;}
        public string ApplicationType {get; set;}
        public string TrustId { get; set; }
        public A2BApplicationAccount Account { get; set; }
        public string FormTrustProposedNameOfTrust {get; set;}
        public bool ApplicationSubmitted {get; set;}
        public string ApplicationLeadAuthorId {get; set;}
        public string ApplicationVersion {get; set;}
        public string ApplicationLeadAuthorName {get; set;}
        public string ApplicationRole {get; set;}
        public string ApplicationRoleOtherDescription {get; set;}
        public int? ChangesToTrust {get; set;}
        public string ChangesToTrustExplained {get; set;}
        public int? ChangesToLaGovernance {get; set;}
        public string ChangesToLaGovernanceExplained {get; set;}
        public DateTime? FormTrustOpeningDate {get; set;}
        public string TrustApproverName {get; set;}
        public string TrustApproverEmail {get; set;}
        public int? FormTrustReasonApprovalToConvertAsSat {get; set;}
        public string FormTrustReasonApprovedPerson {get; set;}
        public string FormTrustReasonForming {get; set;}
        public string FormTrustReasonVision {get; set;}
        public string FormTrustReasonGeoAreas {get; set;}
        public string FormTrustReasonFreedom {get; set;}
        public string FormTrustReasonImproveTeaching {get; set;}
        public string FormTrustPlanForGrowth {get; set;}
        public string FormTrustPlansForNoGrowth {get; set;}
        public int? FormTrustGrowthPlansYesNo {get; set;}
        public string FormTrustImprovementSupport {get; set;}
        public string FormTrustImprovementStrategy {get; set;}
        public string FormTrustImprovementApprovedSponsor {get; set;}
        
        public string ApplicationStatus {get; set;}
    }

    public class A2BApplicationAccount
    {
        public string Name { get; set; }
        public string Urn { get; set; }
        public string AccountId { get; set; }
        public string Address1Composite { get; set; }
        public string TrustCompanyNumber { get; set; }
        public string TrustReferenceNumber { get; set; }
    }
}