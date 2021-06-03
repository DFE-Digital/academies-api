using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using TramsDataApi.DatabaseModels;
using TramsDataApi.RequestModels;

namespace TramsDataApi.Factories
{
    public class AcademyTransferProjectFactory
    {
        public static AcademyTransferProjects Create(AcademyTransferProjectRequest request)
        {
            var transferFirstDiscussed = request.Dates?.TransferFirstDiscussed == null
                ? (DateTime?) null
                : DateTime.ParseExact(request.Dates.TransferFirstDiscussed, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            var targetDateForTransfer = request.Dates?.TargetDateForTransfer == null
                ? (DateTime?) null
                : DateTime.ParseExact(request.Dates.TargetDateForTransfer, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            var htbDate = request.Dates?.HtbDate == null
                ? (DateTime?) null
                : DateTime.ParseExact(request.Dates.HtbDate, "dd/MM/yyyy", CultureInfo.InvariantCulture);

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
                HighProfileShouldBeConsidered = request.Benefits?.OtherFactorsToConsider.HighProfile.ShouldBeConsidered,
                HighProfileFurtherSpecification = request.Benefits?.OtherFactorsToConsider.HighProfile.FurtherSpecification,
                ComplexLandAndBuildingShouldBeConsidered = request.Benefits?.OtherFactorsToConsider.ComplexLandAndBuilding.ShouldBeConsidered,
                ComplexLandAndBuildingFurtherSpecification = request.Benefits?.OtherFactorsToConsider.ComplexLandAndBuilding.FurtherSpecification,
                FinanceAndDebtShouldBeConsidered = request.Benefits?.OtherFactorsToConsider.FinanceAndDebt.ShouldBeConsidered,
                FinanceAndDebtFurtherSpecification = request.Benefits?.OtherFactorsToConsider.FinanceAndDebt.FurtherSpecification,
                OtherBenefitValue = request.Benefits?.IntendedTransferBenefits.OtherBenefitValue,
                AcademyTransferProjectIntendedTransferBenefits = ConvertAcademyTransferProjectIntendedTransferBenefits(request.Benefits?.IntendedTransferBenefits?.SelectedBenefits),
                TransferringAcademies = ConvertTransferringAcademiesList(request.TransferringAcademies),
            };
        }

        private static IList<TransferringAcademies> ConvertTransferringAcademiesList(IList<TransferringAcademiesRequest> transferringAcademiesRequests)
        {
            return transferringAcademiesRequests
                    .Select(t => new TransferringAcademies {OutgoingAcademyUkprn = t.OutgoingAcademyUkprn, IncomingTrustUkprn = t.IncomingTrustUkprn})
                    .ToList();
        }

        private static IList<AcademyTransferProjectIntendedTransferBenefits> ConvertAcademyTransferProjectIntendedTransferBenefits(IList<string> selectedBenefits)
        {
            if (selectedBenefits == null) {
                return new List<AcademyTransferProjectIntendedTransferBenefits>();
            }
            
            return selectedBenefits.Select(b => new AcademyTransferProjectIntendedTransferBenefits { SelectedBenefit = b }).ToList();
        }

        public static AcademyTransferProjects Update(AcademyTransferProjects original, AcademyTransferProjectRequest updateRequest)
        {
            if (updateRequest == null)
            {
                return original;
            }

            return new AcademyTransferProjects
            {
                Id = original.Id,
                Urn = original.Urn,
                OutgoingTrustUkprn = updateRequest.OutgoingTrustUkprn ?? original.OutgoingTrustUkprn,
                WhoInitiatedTheTransfer = updateRequest?.Features?.WhoInitiatedTheTransfer ?? original.WhoInitiatedTheTransfer,
                RddOrEsfaIntervention = updateRequest?.Features?.RddOrEsfaIntervention == null ? original.RddOrEsfaIntervention : updateRequest.Features.RddOrEsfaIntervention,
                RddOrEsfaInterventionDetail = updateRequest?.Features?.RddOrEsfaInterventionDetail ?? original.RddOrEsfaInterventionDetail,
                TypeOfTransfer = updateRequest?.Features?.TypeOfTransfer ?? original.TypeOfTransfer,
                OtherTransferTypeDescription = updateRequest?.Features?.OtherTransferTypeDescription ?? original.OtherTransferTypeDescription,
                TransferFirstDiscussed = updateRequest?.Dates?.TransferFirstDiscussed == null ?
                    original.TransferFirstDiscussed : DateTime.ParseExact(updateRequest.Dates.TransferFirstDiscussed, "dd/MM/yyyy", CultureInfo.InvariantCulture),
                TargetDateForTransfer = updateRequest?.Dates?.TargetDateForTransfer == null ?
                    original.TargetDateForTransfer : DateTime.ParseExact(updateRequest.Dates.TargetDateForTransfer, "dd/MM/yyyy", CultureInfo.InvariantCulture),
                HtbDate = updateRequest?.Dates?.HtbDate == null ?
                    original.HtbDate : DateTime.ParseExact(updateRequest.Dates.HtbDate, "dd/MM/yyyy", CultureInfo.InvariantCulture),
                ProjectRationale = updateRequest?.Rationale?.ProjectRationale ?? original.ProjectRationale,
                TrustSponsorRationale = updateRequest?.Rationale?.TrustSponsorRationale ?? original.TrustSponsorRationale,
                State = updateRequest?.State ?? original.State,
                Status = updateRequest?.Status ?? original.Status,
                HighProfileShouldBeConsidered = updateRequest?.Benefits?.OtherFactorsToConsider?.HighProfile?.ShouldBeConsidered == null ?
                    original.HighProfileShouldBeConsidered : updateRequest.Benefits.OtherFactorsToConsider.HighProfile.ShouldBeConsidered,
                HighProfileFurtherSpecification = updateRequest?.Benefits?.OtherFactorsToConsider?.HighProfile?.FurtherSpecification ?? original.HighProfileFurtherSpecification,
                ComplexLandAndBuildingFurtherSpecification = updateRequest?.Benefits?.OtherFactorsToConsider?.ComplexLandAndBuilding?.FurtherSpecification ?? original.ComplexLandAndBuildingFurtherSpecification,
                ComplexLandAndBuildingShouldBeConsidered = updateRequest?.Benefits?.OtherFactorsToConsider?.ComplexLandAndBuilding?.ShouldBeConsidered == null ?
                    original.ComplexLandAndBuildingShouldBeConsidered : updateRequest.Benefits.OtherFactorsToConsider.ComplexLandAndBuilding.ShouldBeConsidered,
                FinanceAndDebtShouldBeConsidered = updateRequest?.Benefits?.OtherFactorsToConsider?.FinanceAndDebt?.ShouldBeConsidered == null ?
                    original.FinanceAndDebtShouldBeConsidered : updateRequest.Benefits.OtherFactorsToConsider.FinanceAndDebt.ShouldBeConsidered,
                FinanceAndDebtFurtherSpecification = updateRequest?.Benefits?.OtherFactorsToConsider?.FinanceAndDebt?.FurtherSpecification ?? original.FinanceAndDebtFurtherSpecification,
                OtherBenefitValue = updateRequest?.Benefits?.IntendedTransferBenefits?.OtherBenefitValue ?? original.OtherBenefitValue,
                AcademyTransferProjectIntendedTransferBenefits = updateRequest?.Benefits?.IntendedTransferBenefits?.SelectedBenefits == null
                    ? original.AcademyTransferProjectIntendedTransferBenefits
                    : ConvertAcademyTransferProjectIntendedTransferBenefits(updateRequest.Benefits.IntendedTransferBenefits.SelectedBenefits),
                TransferringAcademies = updateRequest.TransferringAcademies == null
                    ? original.TransferringAcademies
                    : ConvertTransferringAcademiesList(updateRequest.TransferringAcademies),
            };
        }
    }
}