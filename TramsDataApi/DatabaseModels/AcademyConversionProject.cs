using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace TramsDataApi.DatabaseModels
{
    public class AcademyConversionProject
    {
        // project list
        public int Id { get; set; }
        public int IfdPipelineId { get; set; }
        public string SchoolName { get; set; }
        public string LocalAuthority { get; set; }
        public string ApplicationReferenceNumber { get; set; }
        public string ProjectStatus { get; set; }
        public DateTime? ApplicationReceivedDate { get; set; }
        public DateTime? AssignedDate { get; set; }
        public DateTime? HtbDate { get; set; }
        public DateTime? OpeningDate { get; set; }
        public DateTime? BaselineDate { get; set; }

        //la summary page
        public DateTime? SentDate { get; set; }
        public DateTime? ReturnedDate { get; set; }
        public string Comments { get; set; }
        public string AdditionalInfo { get; set; }

        //school/trust info
        public string RecommendationForProject { get; set; }
        public string Author { get; set; }
        public string Version { get; set; }
        public string ClearedBy { get; set; }
        public bool? IsAoRequired { get; set; }
        public DateTime? DateOfHtb { get; set; }
        public DateTime? PreviousHTBDate { get; set; }
        public int Urn { get; set; }
        public string TrustReferenceNumber { get; set; }
        public string NameOfTrust { get; set; }
        public string SponsorReferenceNumber { get; set; }
        public string SponsorName { get; set; }
        public string AcademyTypeAndRoute { get; set; }
        public DateTime? ProposedAcademyOpeningDate { get; set; }

        //general info
        public string SchoolPhase { get; set; }
        public string AgeRange { get; set; }
        public string SchoolType { get; set; }
        public int ActualPupilNumbers { get; set; }
        public int Capacity { get; set; }
        public string PublishedAdmissionNumber { get; set; }
        public decimal? PercentageFreeSchoolMeals { get; set; }
        public string PartOfPfiScheme { get; set; }
        public string ViabilityIssues { get; set; }
        public string FinancialSurplusOrDeficit { get; set; }
        public bool? IsThisADiocesanTrust { get; set; }
        public decimal? PercentageOfGoodOrOutstandingSchoolsInTheDiocesanTrust { get; set; }
        public decimal? DistanceFromSchoolToTrustHq { get; set; }
        public string MpParty { get; set; }

        // rationale
        public string RationaleForProject { get; set; }
        public string RationaleForTrust { get; set; }
        public bool? RationaleMarkAsComplete { get; set; }

        // risk and issues
        public string RiskAndIssues { get; set; }
        public bool? EqualitiesImpactAssessmentConsidered { get; set; }

        // school budget info
        public decimal? RevenueCarryForwardAtEndMarchCurrentYear { get; set; }
        public decimal? ProjectedRevenueBalanceAtEndMarchNextYear { get; set; }
        public decimal? CapitalCarryForwardAtEndMarchCurrentYear { get; set; }
        public decimal? CapitalCarryForwardAtEndMarchNextYear { get; set; }
        public string AdditionalInformation { get; set; }

        // pupil schools forecast
        public int? YearOneProjectedCapacity { get; set; }
        public int? YearOneProjectedPupilNumbers { get; set; }
        public int? YearTwoProjectedCapacity { get; set; }
        public int? YearTwoProjectedPupilNumbers { get; set; }
        public int? YearThreeProjectedCapacity { get; set; }
        public int? YearThreeProjectedPupilNumbers { get; set; }
    }
}
