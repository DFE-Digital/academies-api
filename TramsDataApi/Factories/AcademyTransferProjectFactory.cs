using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using TramsDataApi.DatabaseModels;
using TramsDataApi.RequestModels;
using TramsDataApi.UseCases;

namespace TramsDataApi.Factories
{
    public class AcademyTransferProjectFactory
    {
        public static AcademyTransferProjects Create(AcademyTransferProjectRequest request)
        {
            var transferFirstDiscussed = ParseDate(request?.Dates?.TransferFirstDiscussed);
            var targetDateForTransfer = ParseDate(request?.Dates?.TargetDateForTransfer);
            var htbDate = ParseDate(request?.Dates?.HtbDate);

            return new AcademyTransferProjects
            {
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
                HighProfileShouldBeConsidered = request.Benefits?.OtherFactorsToConsider?.HighProfile?.ShouldBeConsidered,
                HighProfileFurtherSpecification = request.Benefits?.OtherFactorsToConsider?.HighProfile?.FurtherSpecification,
                ComplexLandAndBuildingShouldBeConsidered = request.Benefits?.OtherFactorsToConsider?.ComplexLandAndBuilding?.ShouldBeConsidered,
                ComplexLandAndBuildingFurtherSpecification = request.Benefits?.OtherFactorsToConsider?.ComplexLandAndBuilding?.FurtherSpecification,
                FinanceAndDebtShouldBeConsidered = request.Benefits?.OtherFactorsToConsider?.FinanceAndDebt?.ShouldBeConsidered,
                FinanceAndDebtFurtherSpecification = request.Benefits?.OtherFactorsToConsider?.FinanceAndDebt?.FurtherSpecification,
                OtherBenefitValue = request.Benefits?.IntendedTransferBenefits.OtherBenefitValue,
                AcademyTransferProjectIntendedTransferBenefits = ConvertAcademyTransferProjectIntendedTransferBenefits(request.Benefits?.IntendedTransferBenefits?.SelectedBenefits),
                TransferringAcademies = ConvertTransferringAcademiesList(request.TransferringAcademies),
            };
        }

        private static IList<TransferringAcademies> ConvertTransferringAcademiesList(IList<TransferringAcademiesRequest> transferringAcademiesRequests)
        {
            if (transferringAcademiesRequests == null)
            {
                return null;
            }

            return transferringAcademiesRequests
                    .Select(t => new TransferringAcademies {OutgoingAcademyUkprn = t.OutgoingAcademyUkprn, IncomingTrustUkprn = t.IncomingTrustUkprn})
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

            return new AcademyTransferProjects
            {
                Id = original.Id,
                Urn = original.Urn,
                OutgoingTrustUkprn = toMerge.OutgoingTrustUkprn ?? original.OutgoingTrustUkprn,
                WhoInitiatedTheTransfer = toMerge?.WhoInitiatedTheTransfer ?? original.WhoInitiatedTheTransfer,
                RddOrEsfaIntervention = toMerge?.RddOrEsfaIntervention == null
                    ? original.RddOrEsfaIntervention
                    : toMerge.RddOrEsfaIntervention,
                RddOrEsfaInterventionDetail = toMerge?.RddOrEsfaInterventionDetail ?? original.RddOrEsfaInterventionDetail,
                TypeOfTransfer = toMerge?.TypeOfTransfer ?? original.TypeOfTransfer,
                OtherTransferTypeDescription = toMerge?.OtherTransferTypeDescription ?? original.OtherTransferTypeDescription,
                TransferFirstDiscussed = toMerge.TransferFirstDiscussed ?? original.TransferFirstDiscussed,
                TargetDateForTransfer = toMerge.TargetDateForTransfer ?? original.TargetDateForTransfer,
                HtbDate = toMerge.HtbDate ?? original.HtbDate,
                ProjectRationale = toMerge.ProjectRationale ?? original.ProjectRationale,
                TrustSponsorRationale = toMerge.TrustSponsorRationale ?? original.TrustSponsorRationale,
                State = toMerge.State ?? original.State,
                Status = toMerge.Status ?? original.Status,
                HighProfileShouldBeConsidered = toMerge.HighProfileShouldBeConsidered == null
                    ? original.HighProfileShouldBeConsidered
                    : toMerge.HighProfileShouldBeConsidered,
                HighProfileFurtherSpecification = toMerge.HighProfileFurtherSpecification ?? original.HighProfileFurtherSpecification,
                ComplexLandAndBuildingFurtherSpecification = toMerge.ComplexLandAndBuildingFurtherSpecification ?? original.ComplexLandAndBuildingFurtherSpecification,
                ComplexLandAndBuildingShouldBeConsidered = toMerge.ComplexLandAndBuildingShouldBeConsidered == null
                    ? original.ComplexLandAndBuildingShouldBeConsidered
                    : toMerge.ComplexLandAndBuildingShouldBeConsidered,
                FinanceAndDebtShouldBeConsidered = toMerge.FinanceAndDebtShouldBeConsidered == null
                    ? original.FinanceAndDebtShouldBeConsidered
                    : toMerge.FinanceAndDebtShouldBeConsidered,
                FinanceAndDebtFurtherSpecification = toMerge.FinanceAndDebtFurtherSpecification ?? original.FinanceAndDebtFurtherSpecification,
                OtherBenefitValue = toMerge.OtherBenefitValue ?? original.OtherBenefitValue,
                AcademyTransferProjectIntendedTransferBenefits = toMerge.AcademyTransferProjectIntendedTransferBenefits ?? original.AcademyTransferProjectIntendedTransferBenefits,
                TransferringAcademies = toMerge.TransferringAcademies ?? original.TransferringAcademies
            };
        }
    }
}