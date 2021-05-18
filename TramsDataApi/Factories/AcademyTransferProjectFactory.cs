using System;
using System.Globalization;
using System.Linq;
using TramsDataApi.DatabaseModels;
using TramsDataApi.RequestModels;

namespace TramsDataApi.Factories
{
    public class AcademyTransferProjectFactory
    {
        public static AcademyTransferProjects Create(CreateOrUpdateAcademyTransferProjectRequest request)
        {
            return new AcademyTransferProjects
            {
                OutgoingTrustUkprn = request.OutgoingTrustUkprn,
                WhoInitiatedTheTransfer = request.Features.WhoInitiatedTheTransfer,
                RddOrEsfaIntervention = request.Features.RddOrEsfaIntervention,
                RddOrEsfaInterventionDetail = request.Features.RddOrEsfaInterventionDetail,
                TypeOfTransfer = request.Features.TypeOfTransfer,
                OtherTransferTypeDescription = request.Features.OtherTransferTypeDescription,
                TransferFirstDiscussed = DateTime.ParseExact(request.Dates.TransferFirstDiscussed, "dd/MM/yyyy", CultureInfo.InvariantCulture),
                TargetDateForTransfer = DateTime.ParseExact(request.Dates.TargetDateForTransfer, "dd/MM/yyyy", CultureInfo.InvariantCulture),
                HtbDate = DateTime.ParseExact(request.Dates.HtbDate, "dd/MM/yyyy", CultureInfo.InvariantCulture),
                ProjectRationale = request.Rationale.ProjectRationale,
                TrustSponsorRationale = request.Rationale.TrustSponsorRationale,
                State = request.State,
                Status = request.Status,
                HighProfileShouldBeConsidered = request.Benefits.OtherFactorsToConsider.HighProfile.ShouldBeConsidered,
                HighProfileFurtherSpecification = request.Benefits.OtherFactorsToConsider.HighProfile.FurtherSpecification,
                ComplexLandAndBuildingShouldBeConsidered = request.Benefits.OtherFactorsToConsider.ComplexLandAndBuilding.ShouldBeConsidered,
                ComplexLandAndBuildingFurtherSpecification = request.Benefits.OtherFactorsToConsider.ComplexLandAndBuilding.FurtherSpecification,
                FinanceAndDebtShouldBeConsidered = request.Benefits.OtherFactorsToConsider.FinanceAndDebt.ShouldBeConsidered,
                FinanceAndDebtFurtherSpecification = request.Benefits.OtherFactorsToConsider.FinanceAndDebt.FurtherSpecification,
                OtherBenefitValue = request.Benefits.IntendedTransferBenefits.OtherBenefitValue,
                AcademyTransferProjectIntendedTransferBenefits = request.Benefits.IntendedTransferBenefits.SelectedBenefits
                    .Select(b => new AcademyTransferProjectIntendedTransferBenefits { SelectedBenefit = b }).ToList(),
                TransferringAcademies = request.TransferringAcademies
                    .Select(t => new TransferringAcademies { OutgoingAcademyUkprn = t.OutgoingAcademyUkprn, IncomingTrustUkprn = t.IncomingTrustUkprn })
                    .ToList()
            };
        }
    }
}