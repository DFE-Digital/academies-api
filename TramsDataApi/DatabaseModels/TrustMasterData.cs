using System;

namespace TramsDataApi.DatabaseModels
{
    public partial class TrustMasterData
    {
        public long? SK { get; set; }
        public long? TrustsTrustType { get; set; }
        public long? Region { get; set; }
        public long? TrustBanding { get; set; }
        public long? FK_TrustStatus { get; set; }
        public string GroupUID { get; set; }
        public string GroupID { get; set; }
        public string RID { get; set; }
        public string Name { get; set; }
        public string CompaniesHouseNumber { get; set; }
        public DateTime? ClosedDate { get; set; }
        public string TrustStatus { get; set; }
        public DateTime? JoinedDate { get; set; }
        public string MainPhone { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string AddressLine3 { get; set; }
        public string Town { get; set; }
        public string County { get; set; }
        public string Postcode { get; set; }
        public string PrioritisedForReview { get; set; }
        public string CurrentSingleListGrouping { get; set; }
        public DateTime? DateOfGroupingDecision { get; set; }
        public DateTime? DateEnteredOntoSingleList { get; set; }
        public string TrustReviewWriteUp { get; set; }
        public DateTime? DateOfTrustReviewMeeting { get; set; }
        public string FollowUpLetterSent { get; set; }
        public DateTime? DateActionPlannedFor { get; set; }
        public string WIPSummaryGoesToMinister { get; set; }
        public DateTime? ExternalGovernanceReviewDate { get; set; }
        public string EfficiencyICFPReviewCompleted { get; set; }
        public string EfficiencyICFPReviewOther { get; set; }
        public string LinkToWorkplaceForEfficiencyICFPReview { get; set; }
        public int? NumberInTrust { get; set; }
        public DateTime? Modified { get; set; }
        public string ModifiedBy { get; set; }
        public string AMSDTerritory { get; set; }
        public string LeadAMSDTerritory { get; set; }
        public string UKPRN { get; set; }
        public DateTime? TrustPerformanceAndRiskDateOfMeeting { get; set; }
        public string UPIN { get; set; }
        public DateTime? IncorporatedOnOpenDate { get; set; }
    }
}
