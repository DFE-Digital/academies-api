﻿using System;

namespace TramsDataApi.DatabaseModels
{
    public partial class Trust
    {
        public string PRid { get; set; }
        public string Rid { get; set; }
        public string TrustRef { get; set; }
        public string ChainId { get; set; }
        public string TrustsTrustRef { get; set; }
        public string TrustsTrustName { get; set; }
        public string TrustsTrustType { get; set; }
        public DateTime? TrustsTrustOpenDate { get; set; }
        public string TrustsCompaniesHouseNumber { get; set; }
        public string TrustsTrustSecureAccessContactName { get; set; }
        public string TrustsTrustSecureAccessContactEmail { get; set; }
        public string TrustsLeadRscRegion { get; set; }
        public string LeadRscRegion { get; set; }
        public string TrustsLeadSponsorId { get; set; }
        public string LeadSponsor { get; set; }
        public string TrustsLeadSponsorName { get; set; }
        public string TrustsChainId { get; set; }
        public string TrustsLinkToWorkplace { get; set; }
        public bool? TrustsLoadOpenAcademiesInThisTrust { get; set; }
        public bool? TrustsLoadPipelineProjectsInThisTrust { get; set; }
        public bool? TrustsLoadOpenAcademiesProvisionallyWithThisTrustReBrokerage { get; set; }
        public string TrustContactDetailsTrustContactName { get; set; }
        public string TrustContactDetailsTrustContactPosition { get; set; }
        public string TrustContactDetailsTrustContactPhoneNumber { get; set; }
        public string TrustContactDetailsTrustContactEmail { get; set; }
        public string TrustContactDetailsTrustAddressLine1 { get; set; }
        public string TrustContactDetailsTrustAddressLine2 { get; set; }
        public string TrustContactDetailsTrustAddressLine3 { get; set; }
        public string TrustContactDetailsTrustTown { get; set; }
        public string TrustContactDetailsTrustCounty { get; set; }
        public string TrustContactDetailsTrustPostcode { get; set; }
        public string TrustContactDetailsTrustContactLa { get; set; }
        public string MatTemplateMatOverview { get; set; }
        public string MatTemplateGovernanceAndTrustBoard { get; set; }
        public string MatTemplateAccountabilityFramework { get; set; }
        public string MatTemplateSchoolImprovementStrategy { get; set; }
        public string MatTemplateFinancialAndResourceManagement { get; set; }
        public string MatTemplateFuturePlans { get; set; }
        public string MatTemplateIssues { get; set; }
        public string TrustPerformanceAndRiskTrustBanding { get; set; }
        public string TrustPerformanceAndRiskPrioritisedForAReview { get; set; }
        public string TrustPerformanceAndRiskSingleListGrouping { get; set; }
        public DateTime? TrustPerformanceAndRiskDateOfGroupingDecision { get; set; }
        public DateTime? TrustPerformanceAndRiskDateEnteredOntoSingleList { get; set; }
        public string TrustPerformanceAndRiskTrustReviewWriteUp { get; set; }
        public DateTime? TrustPerformanceAndRiskDateOfMeeting { get; set; }
        public string TrustPerformanceAndRiskFollowUpLetterSent { get; set; }
        public DateTime? TrustPerformanceAndRiskDateActionPlannedFor { get; set; }
        public string TrustPerformanceAndRiskWipSummaryGoesToMinister { get; set; }
        public DateTime? TrustPerformanceAndRiskExternalGovernanceReviewDate { get; set; }
        public string TrustPerformanceAndRiskEfficiencyIcfpReviewCompleted { get; set; }
        public string TrustPerformanceAndRiskEfficiencyIcfpReviewOther { get; set; }
        public string TrustPerformanceAndRiskLinkToWorkplaceForEfficiencyIcfpReview { get; set; }
        public short? NumberInChain { get; set; }
        public short? NumberInTrust { get; set; }
        public short? NumberInTrustPrePipeline { get; set; }
        public string SchoolsInTrustPrePipeline { get; set; }
        public short? NumberInTrustPipeline { get; set; }
        public string SchoolsInTrustPipeline { get; set; }
        public short? NumberInTrustOpen { get; set; }
        public string AcademiesInTrustOpen { get; set; }
        public short? NumberInTrustRebrokered { get; set; }
        public string AcademiesInTrustRebrokered { get; set; }
    }
}
