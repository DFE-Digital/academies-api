using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TramsDataApi.DatabaseModels
{
    public partial class LegacyTramsDbContext
    {
        public virtual DbSet<ViewAcademyConversions> ViewAcademyConversions { get; set; }

        protected void OnModelCreatingViewAcademyConversions(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ViewAcademyConversions>(entity =>
            {
                entity.HasKey(e => e.Rid);

                entity.ToTable("vw_AC", "ifd");

                entity.Property(e => e.ApprovalProcessAoDecisionMethod)
                    .HasColumnName("Approval Process.AO Decision Method")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ApprovalProcessAoIssuedDate)
                    .HasColumnName("Approval Process.AO Issued Date")
                    .HasColumnType("date");

                entity.Property(e => e.ApprovalProcessApplicationDate)
                    .HasColumnName("Approval Process.Application Date")
                    .HasColumnType("date");

                entity.Property(e => e.ApprovalProcessAppliedOrBrokered)
                    .HasColumnName("Approval Process.Applied or Brokered")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ApprovalProcessDateRscFundingAgreementApprovedInPrinciple)
                    .HasColumnName("Approval Process.Date RSC funding agreement approved in principle")
                    .HasColumnType("date");

                entity.Property(e => e.ApprovalProcessDateRscHtbApprovalGranted)
                    .HasColumnName("Approval Process.Date RSC/HTB approval granted")
                    .HasColumnType("date");

                entity.Property(e => e.ApprovalProcessDateSubmittedForAoDecision)
                    .HasColumnName("Approval Process.Date Submitted for AO decision")
                    .HasColumnType("date");

                entity.Property(e => e.ApprovalProcessFundingAgreementApprovedDate)
                    .HasColumnName("Approval Process.Funding Agreement Approved Date")
                    .HasColumnType("date");

                entity.Property(e => e.ApprovalProcessReStartApplicationDate)
                    .HasColumnName("Approval Process.Re-start application date")
                    .HasColumnType("date");

                entity.Property(e => e.ApprovalProcessRevokedDAoDate)
                    .HasColumnName("Approval Process.Revoked dAO date")
                    .HasColumnType("date");

                entity.Property(e => e.CaseDataAcademyContactNumber)
                    .HasColumnName("Case Data.Academy contact number")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.CaseDataAcademyHeadPrincipal)
                    .HasColumnName("Case Data.Academy head/principal")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.CaseDataChangeOfLeadership)
                    .HasColumnName("Case Data.Change of leadership")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.CaseDataClosing)
                    .HasColumnName("Case Data.Closing")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.CaseDataClosureStatus)
                    .HasColumnName("Case Data.Closure status")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.CaseDataCommentsNextSteps)
                    .HasColumnName("Case Data.Comments/next steps")
                    .IsUnicode(false);

                entity.Property(e => e.CaseDataConcernType)
                    .HasColumnName("Case Data.Concern Type")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.CaseDataCurrentConfidenceTerm)
                    .HasColumnName("Case Data.Current Confidence Term")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.CaseDataCurrentKs2ConfidenceMeasure)
                    .HasColumnName("Case Data.Current KS2 Confidence Measure")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.CaseDataCurrentKs2Rag)
                    .HasColumnName("Case Data.Current KS2 RAG")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.CaseDataCurrentKs4ConfidenceMeasure)
                    .HasColumnName("Case Data.Current KS4 Confidence Measure")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.CaseDataCurrentKs4Rag)
                    .HasColumnName("Case Data.Current KS4 RAG")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.CaseDataCurrentKs5Rag)
                    .HasColumnName("Case Data.Current KS5 RAG")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.CaseDataDateClosureCommenced)
                    .HasColumnName("Case Data.Date closure commenced")
                    .HasColumnType("date");

                entity.Property(e => e.CaseDataDateOfInitialContact)
                    .HasColumnName("Case Data.Date of initial contact")
                    .HasColumnType("date");

                entity.Property(e => e.CaseDataEducationAdviserTimingOfNextVisit)
                    .HasColumnName("Case Data.Education adviser timing of next visit")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.CaseDataEfaRagRating)
                    .HasColumnName("Case Data.EFA RAG rating")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.CaseDataExpectedClosureDate)
                    .HasColumnName("Case Data.Expected Closure date")
                    .HasColumnType("date");

                entity.Property(e => e.CaseDataFntlIssued)
                    .HasColumnName("Case Data.FNtl issued")
                    .HasColumnType("date");

                entity.Property(e => e.CaseDataFntlRemoved)
                    .HasColumnName("Case Data.FNtl removed")
                    .HasColumnType("date");

                entity.Property(e => e.CaseDataIncreasedCapacityInTrustGb)
                    .HasColumnName("Case Data.Increased capacity in Trust/GB")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.CaseDataKs2BelowTheFloor)
                    .HasColumnName("Case Data.KS2 below the floor?")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.CaseDataKs2CoastingAcademy)
                    .HasColumnName("Case Data.KS2 Coasting Academy?")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.CaseDataKs4BelowTheFloor)
                    .HasColumnName("Case Data.KS4 below the floor?")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.CaseDataKs4CoastingAcademy)
                    .HasColumnName("Case Data.KS4 Coasting Academy?")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.CaseDataKs5BelowTheFloorAcademicCase)
                    .HasColumnName("Case Data.KS5 below the floor? - Academic Case")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.CaseDataKs5BelowTheFloorAppliedGeneralCase)
                    .HasColumnName("Case Data.KS5 below the floor? - Applied General Case")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.CaseDataLinkToWorkplaces)
                    .HasColumnName("Case Data.Link to Workplaces")
                    .IsUnicode(false);

                entity.Property(e => e.CaseDataOtherActionTaken)
                    .HasColumnName("Case Data.Other action taken")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.CaseDataPlannedAction)
                    .HasColumnName("Case Data.Planned Action")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.CaseDataProjectProgress)
                    .HasColumnName("Case Data.Project progress")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.CaseDataReBrokeredDateCaseData)
                    .HasColumnName("Case Data.Re-brokered date Case Data")
                    .HasColumnType("date");

                entity.Property(e => e.CaseDataStatus)
                    .HasColumnName("Case Data.Status")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.CaseDataTrustNotice)
                    .HasColumnName("Case Data.Trust notice?")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.CoSponsor1)
                    .HasColumnName("Co-sponsor 1")
                    .HasMaxLength(7)
                    .IsUnicode(false);

                entity.Property(e => e.DeliveryProcessAcknowledgementAndFollowUpSentToSchool)
                    .HasColumnName("Delivery Process.Acknowledgement and follow-up sent to school")
                    .HasColumnType("date");

                entity.Property(e => e.DeliveryProcessActualDateOfGbResolution)
                    .HasColumnName("Delivery Process.Actual Date of GB Resolution")
                    .HasColumnType("date");

                entity.Property(e => e.DeliveryProcessApplicationFormReference)
                    .HasColumnName("Delivery Process.Application form reference")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.DeliveryProcessArticlesOfAssociationRelatedComments)
                    .HasColumnName("Delivery Process.Articles of Association related comments")
                    .IsUnicode(false);

                entity.Property(e => e.DeliveryProcessArticlesOfAssociations)
                    .HasColumnName("Delivery Process.Articles of Associations")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.DeliveryProcessArticlesOfAssociationsReceivedCleared)
                    .HasColumnName("Delivery Process.Articles of Associations received/cleared")
                    .HasColumnType("date");

                entity.Property(e => e.DeliveryProcessBaselineDate)
                    .HasColumnName("Delivery Process.Baseline Date")
                    .HasColumnType("date");

                entity.Property(e => e.DeliveryProcessCommentsForOfstedPreOpeningInspection)
                    .HasColumnName("Delivery Process.Comments for Ofsted Pre–opening Inspection")
                    .IsUnicode(false);

                entity.Property(e => e.DeliveryProcessCommercialTransferAgreement)
                    .HasColumnName("Delivery Process.Commercial Transfer Agreement")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.DeliveryProcessCommercialTransferAgreementReceivedCleared)
                    .HasColumnName("Delivery Process.Commercial Transfer Agreement received/cleared")
                    .HasColumnType("date");

                entity.Property(e => e.DeliveryProcessCommercialTransferAgreementRelatedComments)
                    .HasColumnName("Delivery Process.Commercial Transfer Agreement related comments")
                    .IsUnicode(false);

                entity.Property(e => e.DeliveryProcessConsideringSoSIebStage)
                    .HasColumnName("Delivery Process.Considering SoS IEB stage")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.DeliveryProcessDateChurchFoundationConsultationReceived)
                    .HasColumnName("Delivery Process.Date Church/Foundation Consultation received")
                    .HasColumnType("date");

                entity.Property(e => e.DeliveryProcessDateDAoDueDiligenceAnnexReceived)
                    .HasColumnName("Delivery Process.Date dAO Due Diligence Annex received")
                    .HasColumnType("date");

                entity.Property(e => e.DeliveryProcessDateDirectionToFacilitateConversionIssuedGbOrLa)
                    .HasColumnName("Delivery Process.Date Direction to Facilitate Conversion Issued (GB or LA)")
                    .HasColumnType("date");

                entity.Property(e => e.DeliveryProcessDateForDiscussionByRscHtb)
                    .HasColumnName("Delivery Process.Date for discussion by RSC/HTB")
                    .HasColumnType("date");

                entity.Property(e => e.DeliveryProcessDateForDiscussionByRscHtbForAgreeingPreOpeningGrant)
                    .HasColumnName("Delivery Process.Date for Discussion by RSC/ HTB  for agreeing pre-opening grant")
                    .HasColumnType("date");

                entity.Property(e => e.DeliveryProcessDateLaIebApplicationApproved)
                    .HasColumnName("Delivery Process.Date LA IEB application approved")
                    .HasColumnType("date");

                entity.Property(e => e.DeliveryProcessDateLaIebApplicationReceived)
                    .HasColumnName("Delivery Process.Date LA IEB application received")
                    .HasColumnType("date");

                entity.Property(e => e.DeliveryProcessDateOfInitialMeeting)
                    .HasColumnName("Delivery Process.Date of Initial Meeting")
                    .HasColumnType("date");

                entity.Property(e => e.DeliveryProcessDateParentInformedBySponsor)
                    .HasColumnName("Delivery Process.Date Parent informed by Sponsor")
                    .HasColumnType("date");

                entity.Property(e => e.DeliveryProcessDateSettlementAgreementApproved)
                    .HasColumnName("Delivery Process.Date settlement agreement approved")
                    .HasColumnType("date");

                entity.Property(e => e.DeliveryProcessDateSoSIebIssued)
                    .HasColumnName("Delivery Process.Date SoS IEB issued")
                    .HasColumnType("date");

                entity.Property(e => e.DeliveryProcessDateSponsorMatchAgreed)
                    .HasColumnName("Delivery Process.Date Sponsor Match agreed")
                    .HasColumnType("date");

                entity.Property(e => e.DeliveryProcessDfEEfaContribution)
                    .HasColumnName("Delivery Process.DfE/EFA contribution")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.DeliveryProcessDidSettlementExceedContractualTerms)
                    .HasColumnName("Delivery Process.Did settlement exceed contractual terms?")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.DeliveryProcessDirectionToFacilitateConversion)
                    .HasColumnName("Delivery Process.Direction to Facilitate Conversion")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.DeliveryProcessEqualityImpactAssessmentsComplete)
                    .HasColumnName("Delivery Process.Equality Impact Assessments Complete")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.DeliveryProcessExpectedDateForGb)
                    .HasColumnName("Delivery Process.Expected Date for GB")
                    .HasColumnType("date");

                entity.Property(e => e.DeliveryProcessFundingAgreement)
                    .HasColumnName("Delivery Process.Funding Agreement")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.DeliveryProcessFundingAgreementConditionsMet)
                    .HasColumnName("Delivery Process.Funding Agreement Conditions met")
                    .HasColumnType("date");

                entity.Property(e => e.DeliveryProcessFundingAgreementReceivedCleared)
                    .HasColumnName("Delivery Process.Funding Agreement received/cleared")
                    .HasColumnType("date");

                entity.Property(e => e.DeliveryProcessFundingAgreementRelatedComments)
                    .HasColumnName("Delivery Process.Funding Agreement related comments")
                    .IsUnicode(false);

                entity.Property(e => e.DeliveryProcessGeneralComments)
                    .HasColumnName("Delivery Process.General Comments")
                    .IsUnicode(false);

                entity.Property(e => e.DeliveryProcessGrantPaymentProcessed)
                    .HasColumnName("Delivery Process.Grant Payment processed")
                    .HasColumnType("date");

                entity.Property(e => e.DeliveryProcessGrantPaymentType)
                    .HasColumnName("Delivery Process.Grant Payment Type")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.DeliveryProcessLand)
                    .HasColumnName("Delivery Process.Land")
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.DeliveryProcessLetterSentWithDtFActionsGbLa)
                    .HasColumnName("Delivery Process.Letter sent with DtF Actions (GB & LA)")
                    .HasColumnType("date");

                entity.Property(e => e.DeliveryProcessLinkToWorkplaces)
                    .HasColumnName("Delivery Process.Link to Workplaces")
                    .IsUnicode(false);

                entity.Property(e => e.DeliveryProcessMainContactForConversion)
                    .HasColumnName("Delivery Process.Main contact for conversion")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.DeliveryProcessMainContactForConversionEmail)
                    .HasColumnName("Delivery Process.Main contact for conversion email")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.DeliveryProcessMainContactForConversionName)
                    .HasColumnName("Delivery Process.Main contact for conversion name")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.DeliveryProcessMainContactForConversionPhone)
                    .HasColumnName("Delivery Process.Main contact for conversion phone")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.DeliveryProcessMainIssueForDelay)
                    .HasColumnName("Delivery Process.Main Issue for delay")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.DeliveryProcessNumberOfSettlementAgreements)
                    .HasColumnName("Delivery Process.Number of settlement agreements")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.DeliveryProcessOfDfEEfaContributionToTotalPaidToEmployees)
                    .HasColumnName("Delivery Process.% of DfE/EFA contribution to total paid to employees")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.DeliveryProcessPan)
                    .HasColumnName("Delivery Process.PAN")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.DeliveryProcessPayRun)
                    .HasColumnName("Delivery Process.Pay Run")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.DeliveryProcessPfi)
                    .HasColumnName("Delivery Process.PFI")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.DeliveryProcessRagRating)
                    .HasColumnName("Delivery Process.RAG Rating")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.DeliveryProcessReasonForNoRpa)
                    .HasColumnName("Delivery Process.Reason for no RPA")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.DeliveryProcessRiskProtectionAgreementStartDate)
                    .HasColumnName("Delivery Process.Risk protection agreement start date")
                    .HasColumnType("date");

                entity.Property(e => e.DeliveryProcessRiskProtectionArrangements)
                    .HasColumnName("Delivery Process.Risk protection arrangements")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.DeliveryProcessRisksAssociatedToLand)
                    .HasColumnName("Delivery Process.Risks associated to land")
                    .IsUnicode(false);

                entity.Property(e => e.DeliveryProcessSecondaryIssueForDelay)
                    .HasColumnName("Delivery Process.Secondary Issue for delay")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.DeliveryProcessSoSImposedIeb)
                    .HasColumnName("Delivery Process.SoS imposed IEB")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.DeliveryProcessTotalAmountPaidToSchoolEmployees)
                    .HasColumnName("Delivery Process.Total amount paid to school employees")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.DeliveryProcessViabilityClosureRoute)
                    .HasColumnName("Delivery Process.Viability Closure Route")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.DeliveryProcessViabilityConcernEffectingSponsorMatch)
                    .HasColumnName("Delivery Process.Viability Concern Effecting Sponsor Match")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.DeliveryProcessWhoPaidTheEnhancement)
                    .HasColumnName("Delivery Process.Who paid the enhancement?")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.EfaFundingBankDetailsReceived)
                    .HasColumnName("EFA Funding.Bank details received")
                    .HasColumnType("date");

                entity.Property(e => e.EfaFundingDraftLetterSentDate)
                    .HasColumnName("EFA Funding.Draft letter sent date")
                    .HasColumnType("date");

                entity.Property(e => e.EfaFundingDraftLetterTargetDate)
                    .HasColumnName("EFA Funding.Draft letter target date")
                    .HasColumnType("date");

                entity.Property(e => e.EfaFundingEfaTerritory)
                    .HasColumnName("EFA Funding.EFA territory")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.EfaFundingEfaWelcomeLetterAndFinanceLetterSentDate)
                    .HasColumnName("EFA Funding.EFA welcome letter and finance letter sent date")
                    .HasColumnType("date");

                entity.Property(e => e.EfaFundingExpectedPaymentDate)
                    .HasColumnName("EFA Funding.Expected payment date")
                    .HasColumnType("date");

                entity.Property(e => e.EfaFundingFinalFundingLetterSentDate)
                    .HasColumnName("EFA Funding.Final funding letter sent date")
                    .HasColumnType("date");

                entity.Property(e => e.EfaFundingFinalFundingLetterTargetDate)
                    .HasColumnName("EFA Funding.Final funding letter target date")
                    .HasColumnType("date");

                entity.Property(e => e.EfaFundingNavCode)
                    .HasColumnName("EFA Funding.NAV Code")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.EfaFundingReminderLetterSentDate)
                    .HasColumnName("EFA Funding.Reminder letter sent date")
                    .HasColumnType("date");

                entity.Property(e => e.EfaFundingSugAvailable)
                    .HasColumnName("EFA Funding.SUG available")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.EfaFundingUpin)
                    .HasColumnName("EFA Funding.UPIN")
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.EfaHandoverFundingAgreementCopyToTheTrust)
                    .HasColumnName("EFA Handover.Funding Agreement copy to the trust")
                    .HasColumnType("date");

                entity.Property(e => e.EfaHandoverFundingAgreementDocumentsRedactedAndSavedInWorkplaces)
                    .HasColumnName("EFA Handover.Funding Agreement documents redacted and saved in workplaces")
                    .HasColumnType("date");

                entity.Property(e => e.EfaHandoverFundingAgreementOnGovUk)
                    .HasColumnName("EFA Handover.Funding Agreement on Gov.UK")
                    .HasColumnType("date");

                entity.Property(e => e.EfaHandoverFundingAgreementToRemoteStorage)
                    .HasColumnName("EFA Handover.Funding Agreement to remote storage")
                    .HasColumnType("date");

                entity.Property(e => e.EfaHandoverHandoverCompleteDate)
                    .HasColumnName("EFA Handover.Handover complete date")
                    .HasColumnType("date");

                entity.Property(e => e.EfaHandoverIssue1RequiringEfaAction)
                    .HasColumnName("EFA Handover.Issue 1 (requiring EFA action)")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.EfaHandoverIssue1ToBeAwareOf)
                    .HasColumnName("EFA Handover.Issue 1 (to be aware of)")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.EfaHandoverIssue2RequiringEfaAction)
                    .HasColumnName("EFA Handover.Issue 2 (requiring EFA action)")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.EfaHandoverIssue2ToBeAwareOf)
                    .HasColumnName("EFA Handover.Issue 2 (to be aware of)")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.EfaHandoverLiveIssueSComments)
                    .HasColumnName("EFA Handover.Live issue(s) comments")
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.EfaHandoverOtherIssueSComments)
                    .HasColumnName("EFA Handover.Other issue(s) comments")
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.EfaHandoverPdfFaSavedInWorkplace)
                    .HasColumnName("EFA Handover.PDF FA saved in workplace")
                    .HasColumnType("date");

                entity.Property(e => e.EfaHandoverPreOpeningCertificateReceived)
                    .HasColumnName("EFA Handover.Pre Opening certificate received")
                    .HasColumnType("date");

                entity.Property(e => e.EfaHandoverSacreExemptionExpiryDate)
                    .HasColumnName("EFA Handover.SACRE exemption expiry date")
                    .HasColumnType("date");

                entity.Property(e => e.EfaHandoverSacreExemptionGiven)
                    .HasColumnName("EFA Handover.SACRE exemption given")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.EfaHandoverSacreExemptionIssuedOn)
                    .HasColumnName("EFA Handover.SACRE exemption issued on")
                    .HasColumnType("date");

                entity.Property(e => e.EfaHandoverSacreExemptionRenewalAppliedFor)
                    .HasColumnName("EFA Handover.SACRE exemption renewal applied for")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.EfaHandoverSacreExemptionRenewalApproved)
                    .HasColumnName("EFA Handover.SACRE exemption renewal approved")
                    .HasColumnType("date");

                entity.Property(e => e.EfaHandoverSacreExemptionRenewalRejected)
                    .HasColumnName("EFA Handover.SACRE exemption renewal rejected")
                    .HasColumnType("date");

                entity.Property(e => e.EfaHandoverSacreNewExemptionExpiryDate)
                    .HasColumnName("EFA Handover.SACRE new exemption expiry date")
                    .HasColumnType("date");

                entity.Property(e => e.EfaHandoverSupportGrantCertificateReceived)
                    .HasColumnName("EFA Handover.Support Grant certificate received")
                    .HasColumnType("date");

                entity.Property(e => e.GeneralDetailsAcademyLaestab)
                    .HasColumnName("General Details.Academy LAESTAB")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.GeneralDetailsAcademyName)
                    .HasColumnName("General Details.Academy Name")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.GeneralDetailsAcademyStatus)
                    .HasColumnName("General Details.Academy Status")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.GeneralDetailsAcademyUkprn)
                    .HasColumnName("General Details.Academy UKPRN")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.GeneralDetailsAcademyUrn)
                    .HasColumnName("General Details.Academy URN")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.GeneralDetailsActualDateOpened)
                    .HasColumnName("General Details.Actual date opened")
                    .HasColumnType("date");

                entity.Property(e => e.GeneralDetailsDAoProgress)
                    .HasColumnName("General Details.dAO Progress")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.GeneralDetailsDivisionalLead)
                    .HasColumnName("General Details.Divisional lead")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.GeneralDetailsExpectedOpeningDate)
                    .HasColumnName("General Details.Expected opening date")
                    .HasColumnType("date");

                entity.Property(e => e.GeneralDetailsGrade6)
                    .HasColumnName("General Details.Grade 6")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.GeneralDetailsInterestProjectLead)
                    .HasColumnName("General Details.Interest project lead")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.GeneralDetailsInterestStatus)
                    .HasColumnName("General Details.Interest  Status")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.GeneralDetailsLaestab)
                    .HasColumnName("General Details.LAESTAB")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.GeneralDetailsLocalAuthority)
                    .HasColumnName("General Details.Local Authority")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.GeneralDetailsPhase)
                    .HasColumnName("General Details.Phase")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.GeneralDetailsProjectLead)
                    .HasColumnName("General Details.Project lead")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.GeneralDetailsProjectName)
                    .HasColumnName("General Details.Project Name")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.GeneralDetailsProjectStatus)
                    .HasColumnName("General Details.Project status")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.GeneralDetailsReBrokeredDate)
                    .HasColumnName("General Details.Re-brokered date")
                    .HasColumnType("date");

                entity.Property(e => e.GeneralDetailsRecordStatus)
                    .HasColumnName("General Details.Record Status")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.GeneralDetailsRouteOfProject)
                    .HasColumnName("General Details.Route of Project")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.GeneralDetailsRscRegion)
                    .HasColumnName("General Details.RSC Region")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.GeneralDetailsStage)
                    .HasColumnName("General Details.Stage")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.GeneralDetailsTeamLeader)
                    .HasColumnName("General Details.Team leader")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.GeneralDetailsUrn)
                    .HasColumnName("General Details.URN")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.InterestComments)
                    .HasColumnName("Interest.Comments")
                    .IsUnicode(false);

                entity.Property(e => e.InterestContactEmail)
                    .HasColumnName("Interest.Contact Email")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.InterestContactName)
                    .HasColumnName("Interest.Contact name")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.InterestContactPhone)
                    .HasColumnName("Interest.Contact phone")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.InterestDateOfInterest)
                    .HasColumnName("Interest.Date of Interest")
                    .HasColumnType("date");

                entity.Property(e => e.InterestResponseToInterestContactDate)
                    .HasColumnName("Interest.Response to interest contact date")
                    .HasColumnType("date");

                entity.Property(e => e.OfstedLatestOfstedSection5CategoryOfConcern)
                    .HasColumnName("Ofsted.Latest Ofsted section 5 Category of Concern")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.OfstedLatestOfstedSection5DateInCategory4)
                    .HasColumnName("Ofsted.Latest Ofsted section 5 Date in Category 4")
                    .HasColumnType("date");

                entity.Property(e => e.OfstedLatestOfstedSection5InspectionDate)
                    .HasColumnName("Ofsted.Latest Ofsted section 5 inspection date")
                    .HasColumnType("date");

                entity.Property(e => e.OfstedLatestOfstedSection5OverallEffectiveness)
                    .HasColumnName("Ofsted.Latest Ofsted section 5 Overall Effectiveness")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.OfstedLatestOfstedSection8InspectionDate)
                    .HasColumnName("Ofsted.Latest Ofsted section 8 inspection date")
                    .HasColumnType("date");

                entity.Property(e => e.OfstedLatestOfstedSection8Judgement)
                    .HasColumnName("Ofsted.Latest Ofsted section 8 judgement")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.OfstedNumberOfMonthsInCategory4)
                    .HasColumnName("Ofsted.Number of months in category 4")
                    .HasMaxLength(100)
                    .IsUnicode(false);


                entity.Property(e => e.PRid)
                    .HasColumnName("p_rid")
                    .HasMaxLength(11)
                    .IsUnicode(false);

                entity.Property(e => e.ProjectTemplateInformationAcademicYear)
                    .HasColumnName("Project template information.Academic year")
                    .HasMaxLength(4)
                    .IsUnicode(false);

                entity.Property(e => e.ProjectTemplateInformationAppointmentOfKeyStaffIncludingPrincipleDesignate)
                    .HasColumnName("Project template information.Appointment of key staff, including Principle Designate")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ProjectTemplateInformationAy1CapacityForecast)
                    .HasColumnName("Project template information.<AY>+1 capacity forecast")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ProjectTemplateInformationAy1TotalPupilNumberForecast)
                    .HasColumnName("Project template information.<AY>+1 total pupil number forecast")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ProjectTemplateInformationAy2CapacityForecast)
                    .HasColumnName("Project template information.<AY>+2 capacity forecast")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ProjectTemplateInformationAy2TotalPupilNumberForecast)
                    .HasColumnName("Project template information.<AY>+2 total pupil number forecast")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ProjectTemplateInformationAy3CapacityForecast)
                    .HasColumnName("Project template information.<AY>+3 capacity forecast")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ProjectTemplateInformationAy3TotalPupilNumberForecast)
                    .HasColumnName("Project template information.<AY>+3 total pupil number forecast")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ProjectTemplateInformationCapitalDeficitReasonsAndRemedialAction)
                    .HasColumnName("Project template information.Capital deficit reasons and remedial action")
                    .IsUnicode(false);

                entity.Property(e => e.ProjectTemplateInformationCommunicationsAndMarketingSupport)
                    .HasColumnName("Project template information.Communications and marketing support")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ProjectTemplateInformationConsultationServices)
                    .HasColumnName("Project template information.Consultation services")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ProjectTemplateInformationDeficit)
                    .HasColumnName("Project template information.Deficit?")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ProjectTemplateInformationEducationAdviceDevelopmentOfEducationalPlanCurriculumStaffingStructureAndPolicies)
                    .HasColumnName("Project template information.Education advice & development of educational plan, curriculum, staffing structure and policies")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ProjectTemplateInformationEigRationale)
                    .HasColumnName("Project template information.EIG rationale")
                    .IsUnicode(false);

                entity.Property(e => e.ProjectTemplateInformationFinancialInformationSystems)
                    .HasColumnName("Project template information.Financial information systems")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ProjectTemplateInformationFinancialManagementAndAdvice)
                    .HasColumnName("Project template information.Financial management and advice")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ProjectTemplateInformationFinancialYear)
                    .HasColumnName("Project template information.Financial year")
                    .HasMaxLength(4)
                    .IsUnicode(false);

                entity.Property(e => e.ProjectTemplateInformationFy1RevenueBalanceBroughtForward)
                    .HasColumnName("Project template information.<FY>+1 Revenue balance brought forward")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ProjectTemplateInformationFy1RevenueBalanceCarriedForward)
                    .HasColumnName("Project template information.<FY>+1 Revenue balance carried forward")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ProjectTemplateInformationFy1RevenueBalanceInYear)
                    .HasColumnName("Project template information.<FY>+1 Revenue balance in year")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ProjectTemplateInformationFy1RevenueGrossExpenditure)
                    .HasColumnName("Project template information.<FY>+1 Revenue gross expenditure ")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ProjectTemplateInformationFy1TotalAllocationAndIncome)
                    .HasColumnName("Project template information.<FY>+1 Total allocation and income")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ProjectTemplateInformationFy2RevenueBalanceBroughtForward)
                    .HasColumnName("Project template information.<FY>+2 Revenue balance brought forward")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ProjectTemplateInformationFy2RevenueBalanceCarriedForward)
                    .HasColumnName("Project template information.<FY>+2 Revenue balance carried forward")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ProjectTemplateInformationFy2RevenueBalanceInYear)
                    .HasColumnName("Project template information.<FY>+2 Revenue balance in year")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ProjectTemplateInformationFy2RevenueGrossExpenditure)
                    .HasColumnName("Project template information.<FY>+2 Revenue gross expenditure ")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ProjectTemplateInformationFy2TotalAllocationAndIncome)
                    .HasColumnName("Project template information.<FY>+2 Total allocation and income")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ProjectTemplateInformationFyRevenueBalanceBroughtForward)
                    .HasColumnName("Project template information.<FY> Revenue balance brought forward")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ProjectTemplateInformationFyRevenueBalanceCarriedForward)
                    .HasColumnName("Project template information.<FY> Revenue balance carried forward")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ProjectTemplateInformationFyRevenueBalanceInYear)
                    .HasColumnName("Project template information.<FY> Revenue balance in year")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ProjectTemplateInformationFyRevenueGrossExpenditure)
                    .HasColumnName("Project template information.<FY> Revenue gross expenditure ")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ProjectTemplateInformationFyTotalAllocationAndIncome)
                    .HasColumnName("Project template information.<FY> Total allocation and income")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ProjectTemplateInformationHrAndRecruitmentServicesInclTupe)
                    .HasColumnName("Project template information.HR and recruitment services (incl. TUPE)")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ProjectTemplateInformationLegalServices)
                    .HasColumnName("Project template information.Legal services")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ProjectTemplateInformationOtherEGIctSystemsProjectContingencyAllocation)
                    .HasColumnName("Project template information.Other (e.g. ICT systems, project contingency allocation)")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ProjectTemplateInformationProjectManagementForecast)
                    .HasColumnName("Project template information.Project management forecast (£)")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ProjectTemplateInformationProjectedCapitalBalanceAtYearEnd)
                    .HasColumnName("Project template information.Projected capital balance at year end")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ProjectTemplateInformationProjectedRevenueBalanceAtYearEnd)
                    .HasColumnName("Project template information.Projected revenue balance at year end")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ProjectTemplateInformationRationaleForProject)
                    .HasColumnName("Project template information.Rationale for project")
                    .IsUnicode(false);

                entity.Property(e => e.ProjectTemplateInformationRationaleForSponsor)
                    .HasColumnName("Project template information.Rationale for sponsor")
                    .IsUnicode(false);

                entity.Property(e => e.ProjectTemplateInformationRelevantDistance)
                    .HasColumnName("Project template information.Relevant distance")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ProjectTemplateInformationRevenueDeficitReasonsAndRemedialAction)
                    .HasColumnName("Project template information.Revenue deficit reasons and remedial action")
                    .IsUnicode(false);

                entity.Property(e => e.ProjectTemplateInformationRisksAndIssues)
                    .HasColumnName("Project template information.Risks and issues")
                    .IsUnicode(false);

                entity.Property(e => e.ProjectTemplateInformationViabilityIssue)
                    .HasColumnName("Project template information.Viability issue?")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ProposedAcademyDetailsAcademyLeadFinanceEmail)
                    .HasColumnName("Proposed Academy Details.Academy Lead Finance Email")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ProposedAcademyDetailsAcademyLeadFinanceName)
                    .HasColumnName("Proposed Academy Details.Academy Lead Finance Name")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ProposedAcademyDetailsAcademyLeadFinancePhone)
                    .HasColumnName("Proposed Academy Details.Academy Lead Finance Phone")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ProposedAcademyDetailsAcademyMainContactAddressLine1)
                    .HasColumnName("Proposed Academy Details.Academy Main Contact Address Line 1")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ProposedAcademyDetailsAcademyMainContactAddressLine2)
                    .HasColumnName("Proposed Academy Details.Academy Main Contact Address Line 2")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ProposedAcademyDetailsAcademyMainContactAddressLine3)
                    .HasColumnName("Proposed Academy Details.Academy Main Contact Address Line 3")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ProposedAcademyDetailsAcademyMainContactCounty)
                    .HasColumnName("Proposed Academy Details.Academy Main Contact County")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ProposedAcademyDetailsAcademyMainContactEmail)
                    .HasColumnName("Proposed Academy Details.Academy Main Contact Email")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ProposedAcademyDetailsAcademyMainContactName)
                    .HasColumnName("Proposed Academy Details.Academy main contact name")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ProposedAcademyDetailsAcademyMainContactPhone)
                    .HasColumnName("Proposed Academy Details.Academy Main Contact Phone")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ProposedAcademyDetailsAcademyMainContactPostcode)
                    .HasColumnName("Proposed Academy Details.Academy Main Contact Postcode")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ProposedAcademyDetailsAcademyMainContactRole)
                    .HasColumnName("Proposed Academy Details.Academy Main Contact Role")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ProposedAcademyDetailsAcademyMainContactTown)
                    .HasColumnName("Proposed Academy Details.Academy Main Contact Town")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ProposedAcademyDetailsAcademyPhaseProposed)
                    .HasColumnName("Proposed Academy Details.Academy Phase Proposed")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ProposedAcademyDetailsAcademyProposedCapacityPost16)
                    .HasColumnName("Proposed Academy Details.Academy Proposed Capacity - Post 16")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ProposedAcademyDetailsAcademyProposedCapacityPrimaryRYr6)
                    .HasColumnName("Proposed Academy Details.Academy Proposed Capacity - Primary (R-Yr6)")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ProposedAcademyDetailsAcademyProposedCapacitySecondaryYr7Yr11)
                    .HasColumnName("Proposed Academy Details.Academy Proposed Capacity - Secondary (Yr7 - Yr11)")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ProposedAcademyDetailsAcademySecureAccessContactEmail)
                    .HasColumnName("Proposed Academy Details.Academy Secure Access Contact email")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ProposedAcademyDetailsAcademySecureAccessContactName)
                    .HasColumnName("Proposed Academy Details.Academy Secure Access Contact name")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ProposedAcademyDetailsGagFundingPupilNumbersType)
                    .HasColumnName("Proposed Academy Details.GAG Funding Pupil Numbers Type")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ProposedAcademyDetailsMatFaClauses3A3FOption1ConvSpons)
                    .HasColumnName("Proposed Academy Details.MAT FA Clauses 3.A - 3.F Option 1(Conv & Spons)")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ProposedAcademyDetailsMatFaClauses3A3FOption2FsNewProv)
                    .HasColumnName("Proposed Academy Details.MAT FA Clauses 3.A - 3.F Option 2(FS & New Prov)")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ProposedAcademyDetailsMatFaClauses3HIfApplicableNotConv)
                    .HasColumnName("Proposed Academy Details.MAT FA Clauses 3.H (if applicable & not Conv)")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ProposedAcademyDetailsNewAcademyName)
                    .HasColumnName("Proposed Academy Details.New Academy Name")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ProposedAcademyDetailsNewAcademyUrn)
                    .HasColumnName("Proposed Academy Details.New Academy URN")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ProposedAcademyDetailsPost16)
                    .HasColumnName("Proposed Academy Details.Post 16")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ProposedAcademyDetailsSatFaClause323IfApplicableNotConv)
                    .HasColumnName("Proposed Academy Details.SAT FA Clause 3.23 (if applicable & not Conv)")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ProposedAcademyDetailsSatFaClauses316321Option1ConvSpons)
                    .HasColumnName("Proposed Academy Details.SAT FA Clauses 3.16-3.21 Option 1 (Conv & Spons)")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ProposedAcademyDetailsSatFaClauses316321Option2FsNewProv)
                    .HasColumnName("Proposed Academy Details.SAT FA Clauses 3.16-3.21 Option 2 (FS & New Prov)")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Rid)
                    .HasColumnName("RID")
                    .HasMaxLength(11)
                    .IsUnicode(false);

                entity.Property(e => e.TrustSponsorManagementCoSponsor1)
                    .HasColumnName("Trust & Sponsor Management.Co-sponsor 1")
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.TrustSponsorManagementCoSponsor1SponsorName)
                    .HasColumnName("Trust & Sponsor Management.Co-sponsor 1 Sponsor Name")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.TrustSponsorManagementCoSponsor2)
                    .HasColumnName("Trust & Sponsor Management.Co-sponsor 2")
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.TrustSponsorManagementCoSponsor2SponsorName)
                    .HasColumnName("Trust & Sponsor Management.Co-sponsor 2 Sponsor Name")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.TrustSponsorManagementCoSponsor3)
                    .HasColumnName("Trust & Sponsor Management.Co-sponsor 3")
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.TrustSponsorManagementCoSponsor3SponsorName)
                    .HasColumnName("Trust & Sponsor Management.Co-sponsor 3 Sponsor Name")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.TrustSponsorManagementPreviousSponsorId)
                    .HasColumnName("Trust & Sponsor Management.Previous sponsor id")
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.TrustSponsorManagementPreviousSponsorName)
                    .HasColumnName("Trust & Sponsor Management.Previous sponsor name")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.TrustSponsorManagementPreviousTrust)
                    .HasColumnName("Trust & Sponsor Management.Previous Trust")
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.TrustSponsorManagementPreviousTrustName)
                    .HasColumnName("Trust & Sponsor Management.Previous Trust name")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.TrustSponsorManagementSponsor1NameProvisional)
                    .HasColumnName("Trust & Sponsor Management.Sponsor 1 Name (Provisional)")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.TrustSponsorManagementSponsor1Provisional)
                    .HasColumnName("Trust & Sponsor Management.Sponsor 1 (Provisional)")
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.TrustSponsorManagementSponsor2NameProvisional)
                    .HasColumnName("Trust & Sponsor Management.Sponsor 2 Name (Provisional)")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.TrustSponsorManagementSponsor2Provisional)
                    .HasColumnName("Trust & Sponsor Management.Sponsor 2 (Provisional)")
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.TrustSponsorManagementSponsor3NameProvisional)
                    .HasColumnName("Trust & Sponsor Management.Sponsor 3 Name (Provisional)")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.TrustSponsorManagementSponsor3Provisional)
                    .HasColumnName("Trust & Sponsor Management.Sponsor 3 (Provisional)")
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.TrustSponsorManagementTrust)
                    .HasColumnName("Trust & Sponsor Management.Trust")
                    .HasMaxLength(5)
                    .IsUnicode(false);
            });

            modelBuilder.HasSequence<int>("AcademyTransferProjectUrns")
                .StartsAt(10000000)
                .HasMin(10000000);
        }
    }
}
