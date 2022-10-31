using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using TramsDataApi.DatabaseModels;
using TramsDataApi.RequestModels;
using TramsDataApi.RequestModels.AcademyTransferProject;
using TramsDataApi.ResponseModels.AcademyTransferProject;
using TramsDataApi.ResponseModels;
using TramsDataApi.UseCases;
using TramsDataApi.Gateways;

namespace TramsDataApi.Factories
{
    public class AcademyTransferProjectFactory
    {
        private static ITrustGateway _trustGateway;

        public AcademyTransferProjectFactory(ITrustGateway trustGateway)
        {
            _trustGateway = trustGateway;
        }
    
        public static AcademyTransferProjects Create(AcademyTransferProjectRequest request)
        {
            var transferFirstDiscussed = ParseDate(request?.Dates?.TransferFirstDiscussed);
            var targetDateForTransfer = ParseDate(request?.Dates?.TargetDateForTransfer);
            var htbDate = ParseDate(request?.Dates?.HtbDate);

            return new AcademyTransferProjects
            {
                ProjectReference = request?.ProjectReference,
                OutgoingTrustUkprn = request.OutgoingTrustUkprn,
                WhoInitiatedTheTransfer = request.Features?.WhoInitiatedTheTransfer,
                RddOrEsfaIntervention = request.Features?.RddOrEsfaIntervention,
                RddOrEsfaInterventionDetail = request.Features?.RddOrEsfaInterventionDetail,
                TypeOfTransfer = request.Features?.TypeOfTransfer,
                OtherTransferTypeDescription = request.Features?.OtherTransferTypeDescription,
                TransferFirstDiscussed = transferFirstDiscussed,
                TargetDateForTransfer = targetDateForTransfer,
                HtbDate = htbDate,
                ProjectRationale = request.Rationale?.ProjectRationale,
                TrustSponsorRationale = request.Rationale?.TrustSponsorRationale,
                State = request.State,
                Status = request.Status,
                Author = request.GeneralInformation?.Author,
                Recommendation = request.GeneralInformation?.Recommendation,
                AnyRisks = request.Benefits?.AnyRisks,
                HighProfileShouldBeConsidered = request.Benefits?.OtherFactorsToConsider?.HighProfile?.ShouldBeConsidered,
                HighProfileFurtherSpecification = request.Benefits?.OtherFactorsToConsider?.HighProfile?.FurtherSpecification,
                ComplexLandAndBuildingShouldBeConsidered = request.Benefits?.OtherFactorsToConsider?.ComplexLandAndBuilding?.ShouldBeConsidered,
                ComplexLandAndBuildingFurtherSpecification = request.Benefits?.OtherFactorsToConsider?.ComplexLandAndBuilding?.FurtherSpecification,
                FinanceAndDebtShouldBeConsidered = request.Benefits?.OtherFactorsToConsider?.FinanceAndDebt?.ShouldBeConsidered,
                FinanceAndDebtFurtherSpecification = request.Benefits?.OtherFactorsToConsider?.FinanceAndDebt?.FurtherSpecification,
                OtherRisksShouldBeConsidered = request.Benefits?.OtherFactorsToConsider?.OtherRisks?.ShouldBeConsidered,
                OtherRisksFurtherSpecification = request.Benefits?.OtherFactorsToConsider?.OtherRisks?.FurtherSpecification,
                OtherBenefitValue = request.Benefits?.IntendedTransferBenefits.OtherBenefitValue,
                EqualitiesImpactAssessmentConsidered = request.Benefits?.EqualitiesImpactAssessmentConsidered,
                TrustAgreement = request.LegalRequirements?.TrustAgreement,
                DiocesanConsent = request.LegalRequirements?.DiocesanConsent,
                FoundationConsent = request.LegalRequirements?.FoundationConsent,
                AcademyTransferProjectIntendedTransferBenefits = ConvertAcademyTransferProjectIntendedTransferBenefits(request.Benefits?.IntendedTransferBenefits?.SelectedBenefits),
                TransferringAcademies = ConvertTransferringAcademiesList(request.TransferringAcademies),
                FeatureSectionIsCompleted = request.Features?.IsCompleted,
                BenefitsSectionIsCompleted = request.Benefits?.IsCompleted,
                LegalRequirementsSectionIsCompleted = request.LegalRequirements?.IsCompleted,
                RationaleSectionIsCompleted = request.Rationale?.IsCompleted,
                HasHtbDate = request.Dates?.HasHtbDate,
                HasTransferFirstDiscussedDate = request.Dates?.HasTransferFirstDiscussedDate,
                HasTargetDateForTransfer = request.Dates?.HasTargetDateForTransfer
            };
        }

        private static IList<TransferringAcademies> ConvertTransferringAcademiesList(IList<TransferringAcademiesRequest> transferringAcademiesRequests)
        {
            if (transferringAcademiesRequests == null)
            {
                return null;
            }

            return transferringAcademiesRequests
                    .Select(t => new TransferringAcademies
                    {
                        OutgoingAcademyUkprn = t.OutgoingAcademyUkprn, 
                        IncomingTrustUkprn = t.IncomingTrustUkprn,
                        PupilNumbersAdditionalInformation = t.PupilNumbersAdditionalInformation,
                        LatestOfstedReportAdditionalInformation = t.LatestOfstedReportAdditionalInformation,
                        KeyStage2PerformanceAdditionalInformation = t.KeyStage2PerformanceAdditionalInformation,
                        KeyStage4PerformanceAdditionalInformation = t.KeyStage4PerformanceAdditionalInformation,
                        KeyStage5PerformanceAdditionalInformation = t.KeyStage5PerformanceAdditionalInformation
                    })
                    .ToList();
        }

        private static IList<AcademyTransferProjectIntendedTransferBenefits> ConvertAcademyTransferProjectIntendedTransferBenefits(IList<string> selectedBenefits)
        {
            if (selectedBenefits == null) {
                return null;
            }

            return selectedBenefits.Select(b => new AcademyTransferProjectIntendedTransferBenefits { SelectedBenefit = b }).ToList();
        }

        private static DateTime? ParseDate(string date)
        {
            return date == null
                ? (DateTime?) null
                : DateTime.ParseExact(date, "dd/MM/yyyy", CultureInfo.InvariantCulture);
        }
        
        public static AcademyTransferProjects Update(AcademyTransferProjects original, AcademyTransferProjectRequest updateRequest)
        {
            if (updateRequest == null)
            {
                return original;
            }

            var toMerge = Create(updateRequest);

            original.ProjectReference = toMerge.ProjectReference ?? original.ProjectReference;
            original.OutgoingTrustUkprn = toMerge.OutgoingTrustUkprn ?? original.OutgoingTrustUkprn;
            original.WhoInitiatedTheTransfer = toMerge?.WhoInitiatedTheTransfer ?? original.WhoInitiatedTheTransfer;
            original.RddOrEsfaIntervention = toMerge?.RddOrEsfaIntervention == null
                ? original.RddOrEsfaIntervention
                : toMerge.RddOrEsfaIntervention;
            original.RddOrEsfaInterventionDetail =
                toMerge?.RddOrEsfaInterventionDetail ?? original.RddOrEsfaInterventionDetail;
            original.TypeOfTransfer = toMerge?.TypeOfTransfer ?? original.TypeOfTransfer;
            original.OtherTransferTypeDescription =
                toMerge?.OtherTransferTypeDescription ?? original.OtherTransferTypeDescription;
            original.TransferFirstDiscussed = (updateRequest.Dates?.HasTransferFirstDiscussedDate ?? true) ? (toMerge.TransferFirstDiscussed ?? original.TransferFirstDiscussed) : null;
            original.TargetDateForTransfer = (updateRequest.Dates?.HasTargetDateForTransfer ?? true) ? (toMerge.TargetDateForTransfer ?? original.TargetDateForTransfer) : null;
            original.HtbDate = (updateRequest.Dates?.HasHtbDate ?? true) ? (toMerge.HtbDate ?? original.HtbDate) : null;
            original.HasHtbDate = toMerge.HasHtbDate ?? original.HasHtbDate;
            original.HasTargetDateForTransfer = toMerge.HasTargetDateForTransfer ?? original.HasTargetDateForTransfer;
            original.HasTransferFirstDiscussedDate =
                toMerge.HasTransferFirstDiscussedDate ?? original.HasTransferFirstDiscussedDate;
            original.ProjectRationale = toMerge.ProjectRationale ?? original.ProjectRationale;
            original.TrustSponsorRationale = toMerge.TrustSponsorRationale ?? original.TrustSponsorRationale;
            original.State = toMerge.State ?? original.State;
            original.Status = toMerge.Status ?? original.Status;
            original.Author = toMerge.Author ?? original.Author;
            original.Recommendation = toMerge.Recommendation ?? original.Recommendation;
            original.AnyRisks = toMerge.AnyRisks ?? original.AnyRisks;
            original.HighProfileShouldBeConsidered = toMerge.HighProfileShouldBeConsidered == null
                ? original.HighProfileShouldBeConsidered
                : toMerge.HighProfileShouldBeConsidered;
            original.HighProfileFurtherSpecification =
                toMerge.HighProfileFurtherSpecification ?? original.HighProfileFurtherSpecification;
            original.ComplexLandAndBuildingFurtherSpecification = toMerge.ComplexLandAndBuildingFurtherSpecification ??
                                                                  original.ComplexLandAndBuildingFurtherSpecification;
            original.ComplexLandAndBuildingShouldBeConsidered = toMerge.ComplexLandAndBuildingShouldBeConsidered == null
                ? original.ComplexLandAndBuildingShouldBeConsidered
                : toMerge.ComplexLandAndBuildingShouldBeConsidered;
            original.FinanceAndDebtShouldBeConsidered = toMerge.FinanceAndDebtShouldBeConsidered == null
                ? original.FinanceAndDebtShouldBeConsidered
                : toMerge.FinanceAndDebtShouldBeConsidered;
            original.FinanceAndDebtFurtherSpecification = toMerge.FinanceAndDebtFurtherSpecification ?? 
                                                          original.FinanceAndDebtFurtherSpecification;
            original.OtherRisksShouldBeConsidered = toMerge.OtherRisksShouldBeConsidered == null
                ? original.OtherRisksShouldBeConsidered
                : toMerge.OtherRisksShouldBeConsidered;
            original.OtherRisksFurtherSpecification = toMerge.OtherRisksFurtherSpecification ?? 
                                                          original.OtherRisksFurtherSpecification;
            original.OtherBenefitValue = toMerge.OtherBenefitValue ?? original.OtherBenefitValue;
            original.EqualitiesImpactAssessmentConsidered = toMerge.EqualitiesImpactAssessmentConsidered ??
                                                            original.EqualitiesImpactAssessmentConsidered;
            original.DiocesanConsent = toMerge.DiocesanConsent ?? original.DiocesanConsent;
            original.FoundationConsent = toMerge.FoundationConsent ?? original.FoundationConsent;
            original.TrustAgreement = toMerge.TrustAgreement ?? original.TrustAgreement;
            original.TransferringAcademies = toMerge.TransferringAcademies ?? original.TransferringAcademies;

            original.FeatureSectionIsCompleted = toMerge.FeatureSectionIsCompleted ?? original.FeatureSectionIsCompleted;
            original.BenefitsSectionIsCompleted = toMerge.BenefitsSectionIsCompleted ?? original.BenefitsSectionIsCompleted;
            original.LegalRequirementsSectionIsCompleted = toMerge.LegalRequirementsSectionIsCompleted ?? original.LegalRequirementsSectionIsCompleted;
            original.RationaleSectionIsCompleted = toMerge.RationaleSectionIsCompleted ?? original.RationaleSectionIsCompleted;

            original.AcademyTransferProjectIntendedTransferBenefits =
                toMerge.AcademyTransferProjectIntendedTransferBenefits ??
                original.AcademyTransferProjectIntendedTransferBenefits;
            
            return original;
        }

        public static List<AcademyTransferProjectSummaryResponse> AcademyTransferProjectSummaryResponseFactory(IList<AcademyTransferProjects> academyTransferProjects)
        {
            var projects = academyTransferProjects.ToList().Select(atp =>
            {
                atp.TransferringAcademies.Add(new TransferringAcademies());
                var outgoingGroup = _trustGateway.GetGroupByUkPrn(atp.OutgoingTrustUkprn);
                return new AcademyTransferProjectSummaryResponse()
                {
                    ProjectUrn = atp.Urn.ToString(),
                    ProjectReference = atp.ProjectReference,
                    OutgoingTrustUkprn = atp.OutgoingTrustUkprn,
                    OutgoingTrustName = outgoingGroup.GroupName,
                    OutgoingTrustLeadRscRegion =
                        _trustGateway.GetIfdTrustByGroupId(outgoingGroup.GroupId).LeadRscRegion,
                    TransferringAcademies = atp.TransferringAcademies.Select(ta =>
                    {
                        var group = _trustGateway.GetGroupByUkPrn(ta.IncomingTrustUkprn);
                        return new TransferringAcademiesResponse
                        {
                            OutgoingAcademyUkprn = ta.OutgoingAcademyUkprn,
                            IncomingTrustUkprn = ta.IncomingTrustUkprn,
                            IncomingTrustName = group.GroupName,
                            IncomingTrustLeadRscRegion = _trustGateway.GetIfdTrustByGroupId(group.GroupId).LeadRscRegion,
                            PupilNumbersAdditionalInformation = ta.PupilNumbersAdditionalInformation,
                            LatestOfstedReportAdditionalInformation = ta.LatestOfstedReportAdditionalInformation,
                            KeyStage2PerformanceAdditionalInformation = ta.KeyStage2PerformanceAdditionalInformation,
                            KeyStage4PerformanceAdditionalInformation = ta.KeyStage4PerformanceAdditionalInformation,
                            KeyStage5PerformanceAdditionalInformation = ta.KeyStage5PerformanceAdditionalInformation
                        };
                    }).ToList()
                };
            }).ToList();
            return projects;
        }
    }
}
