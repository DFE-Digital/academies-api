using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace TramsDataApi.DatabaseModels
{
    public class AcademyConversionProject
    {
        // project list
        public int Id { get; set; }
        public int IfdPipelineId { get; set; }
        public int? Urn { get; set; }
        public string SchoolName { get; set; }
        public string LocalAuthority { get; set; }
        public string ApplicationReferenceNumber { get; set; }
        public string ProjectStatus { get; set; }
        public DateTime? ApplicationReceivedDate { get; set; }
        public DateTime? AssignedDate { get; set; }
        public DateTime? HeadTeacherBoardDate { get; set; }
        public DateTime? OpeningDate { get; set; }
        public DateTime? BaselineDate { get; set; }

        //la summary page
        public DateTime? LocalAuthorityInformationTemplateSentDate { get; set; }
        public DateTime? LocalAuthorityInformationTemplateReturnedDate { get; set; }
        public string LocalAuthorityInformationTemplateComments { get; set; }
        public string LocalAuthorityInformationTemplateLink { get; set; }
        public bool? LocalAuthorityInformationTemplateSectionComplete { get; set; }

        //school/trust info
        public string RecommendationForProject { get; set; }
        public string Author { get; set; }
        public string Version { get; set; }
        public string ClearedBy { get; set; }
        public string AcademyOrderRequired { get; set; }
        public DateTime? PreviousHeadTeacherBoardDate { get; set; }
        public string PreviousHeadTeacherBoardDateQuestion { get; set; }
        public string PreviousHeadTeacherBoardLink { get; set; }
        public string TrustReferenceNumber { get; set; }
        public string NameOfTrust { get; set; }
        public string SponsorReferenceNumber { get; set; }
        public string SponsorName { get; set; }
        public string AcademyTypeAndRoute { get; set; }
        public DateTime? ProposedAcademyOpeningDate { get; set; }
        public bool? SchoolAndTrustInformationSectionComplete { get; set; }

        [Column(TypeName = "decimal(38, 2)")]
        public decimal ConversionSupportGrantAmount { get; set; }
        public string ConversionSupportGrantChangeReason { get; set; }

        //general info
        public string SchoolPhase { get; set; }
        public string AgeRange { get; set; }
        public string SchoolType { get; set; }
        public int? ActualPupilNumbers { get; set; }
        public int? Capacity { get; set; }
        public string PublishedAdmissionNumber { get; set; }
        [Column(TypeName = "decimal(38, 3)")] public decimal? PercentageFreeSchoolMeals { get; set; }
        public string PartOfPfiScheme { get; set; }
        public string ViabilityIssues { get; set; }
        public string FinancialDeficit { get; set; }
        public string DiocesanTrust { get; set; }

        [Column(TypeName = "decimal(38, 3)")]
        public decimal? PercentageOfGoodOrOutstandingSchoolsInTheDiocesanTrust { get; set; }

        [Column(TypeName = "decimal(38, 3)")] public decimal? DistanceFromSchoolToTrustHeadquarters { get; set; }
        public string DistanceFromSchoolToTrustHeadquartersAdditionalInformation { get; set; }
        public string MemberOfParliamentParty { get; set; }
        public bool? GeneralInformationSectionComplete { get; set; }

        //school performance ofsted information
        public string SchoolPerformanceAdditionalInformation { get; set; }

        // rationale
        public string RationaleForProject { get; set; }
        public string RationaleForTrust { get; set; }
        public bool? RationaleSectionComplete { get; set; }

        // risk and issues
        public string RisksAndIssues { get; set; }
        public string EqualitiesImpactAssessmentConsidered { get; set; }
        public bool? RisksAndIssuesSectionComplete { get; set; }

        // school budget info
        [Column(TypeName = "decimal(38, 2)")] public decimal? RevenueCarryForwardAtEndMarchCurrentYear { get; set; }
        [Column(TypeName = "decimal(38, 2)")] public decimal? ProjectedRevenueBalanceAtEndMarchNextYear { get; set; }
        [Column(TypeName = "decimal(38, 2)")] public decimal? CapitalCarryForwardAtEndMarchCurrentYear { get; set; }
        [Column(TypeName = "decimal(38, 2)")] public decimal? CapitalCarryForwardAtEndMarchNextYear { get; set; }
        public string SchoolBudgetInformationAdditionalInformation { get; set; }
        public bool? SchoolBudgetInformationSectionComplete { get; set; }

        // pupil schools forecast
        public int? YearOneProjectedCapacity { get; set; }
        public int? YearOneProjectedPupilNumbers { get; set; }
        public int? YearTwoProjectedCapacity { get; set; }
        public int? YearTwoProjectedPupilNumbers { get; set; }
        public int? YearThreeProjectedCapacity { get; set; }
        public int? YearThreeProjectedPupilNumbers { get; set; }
        public string SchoolPupilForecastsAdditionalInformation { get; set; }

        // key stage performance
        public string KeyStage2PerformanceAdditionalInformation { get; set; }
        public string KeyStage4PerformanceAdditionalInformation { get; set; }
        public string KeyStage5PerformanceAdditionalInformation { get; set; }
    }
}