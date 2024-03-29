﻿using System;

namespace TramsDataApi.DatabaseModels
{
    public partial class SmartData
    {
        public string Urn { get; set; }
        public string LaCode { get; set; }
        public string LocalAuthority { get; set; }
        public string EstablishmentNumber { get; set; }
        public string EstablishmentName { get; set; }
        public string Status { get; set; }
        public string RscRegion { get; set; }
        public string RscShort { get; set; }
        public string TypeGroup { get; set; }
        public string EstablishmentType { get; set; }
        public string Phase { get; set; }
        public string TrustId { get; set; }
        public string TrustName { get; set; }
        public string TrustType { get; set; }
        public string RatGrade { get; set; }
        public string RatDefinition { get; set; }
        public bool? IsSpecial { get; set; }
        public int IsConsideredOpen { get; set; }
        public string PostCode { get; set; }
        public decimal? Lat { get; set; }
        public decimal? Lon { get; set; }
        public string SponsorId { get; set; }
        public string SponsorName { get; set; }
        public int? ShortInspectionNumber { get; set; }
        public DateTime? ShortInspectionPubDate { get; set; }
        public DateTime? RebrokerageDate { get; set; }
        public int? MostRecentRating { get; set; }
        public DateTime? MostRecentPublicationDate { get; set; }
        public int? HtchangesLastyear { get; set; }
        public int? HtchangesTotal { get; set; }
        public decimal? Ks4Attainment8Score { get; set; }
        public decimal? Ks4Progress8Score { get; set; }
        public decimal? Ks4DisadvProgress8Score { get; set; }
        public decimal? Ks4AvgAchieveBasics3Years { get; set; }
        public bool? Ks4CoastingFlag { get; set; }
        public decimal? Ks2ExpStandardsRwm { get; set; }
        public decimal? Ks2Reading { get; set; }
        public decimal? Ks2Maths { get; set; }
        public decimal? Ks2Writing { get; set; }
        public decimal? Ks2DisadvReading { get; set; }
        public decimal? Ks2DisadvMaths { get; set; }
        public decimal? Ks2DisadvWriting { get; set; }
        public bool? Ks2CoastingFlag { get; set; }
        public decimal? AbsencesOverall { get; set; }
        public decimal? AbsencesPa { get; set; }
        public decimal? AbsencesUnauthorised { get; set; }
        public string PsdFlag { get; set; }
        public string PredecessorUrn { get; set; }
        public string PredecessorName { get; set; }
        public int? OfstedSource { get; set; }
        public int? Ks4Source { get; set; }
        public int? Ks2Source { get; set; }
        public int? AbsSource { get; set; }
        public int? PsdSource { get; set; }
        public int? FlagOfstedEverInadequate { get; set; }
        public int? FlagOfstedLastTwoRi { get; set; }
        public int? FlagHtchangesTotal { get; set; }
        public int? FlagHtchangesLastYear { get; set; }
        public int? FlagKs4Attainment8 { get; set; }
        public int? FlagKs4Progress8Score { get; set; }
        public int? FlagKs4AvgAchieveBasics3Years { get; set; }
        public int? FlagKs4DisadvProgress8Score { get; set; }
        public int? FlagKs4CoastingFlag { get; set; }
        public int? FlagKs2ExpStandardsRwm { get; set; }
        public int? FlagKs2CombinedProgress { get; set; }
        public int? FlagKs2CombinedDisadvantagedProgress { get; set; }
        public int? FlagKs2CoastingFlag { get; set; }
        public int? FlagAbsencesUnauthorised { get; set; }
        public int? FlagAbsencesOverallPa { get; set; }
        public bool? IsNa { get; set; }
        public DateTime? DateOfLastFullOrShortInspection { get; set; }
        public double? ProbabilityOfDeclining { get; set; }
        public double? ProbabilityOfStayingTheSame { get; set; }
        public double? ProbabilityOfImproving { get; set; }
        public string PredictedChangeInProgress8Score { get; set; }
        public double? PredictedChanceOfChangeOccuring { get; set; }
        public int? TotalNumberOfRisks { get; set; }
        public decimal? TotalRiskScore { get; set; }
        public int RiskRatingNum { get; set; }
    }
}
