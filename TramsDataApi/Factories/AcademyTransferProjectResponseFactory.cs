using System.Globalization;
using System.Linq;
using TramsDataApi.DatabaseModels;
using TramsDataApi.ResponseModels;

namespace TramsDataApi.Factories
{
    public class AcademyTransferProjectResponseFactory
    {
        public static AcademyTransferProjectResponse Create(AcademyTransferProjects model)
        {
            if (model == null) 
            {
                return null;
            }
            
            var transferringAcademies = model.TransferringAcademies
                .Select(a => new TransferringAcademiesResponse
                    {IncomingTrustUkprn = a.IncomingTrustUkprn, OutgoingAcademyUkprn = a.OutgoingAcademyUkprn})
                .ToList();

            var features = new AcademyTransferProjectFeaturesResponse
            {
                WhoInitiatedTheTransfer = model.WhoInitiatedTheTransfer,
                RddOrEsfaIntervention = model.RddOrEsfaIntervention,
                RddOrEsfaInterventionDetail = model.RddOrEsfaInterventionDetail,
                TypeOfTransfer = model.TypeOfTransfer,
                OtherTransferTypeDescription = model.OtherTransferTypeDescription
            };

            var dates = new AcademyTransferProjectDatesResponse
            {
                TransferFirstDiscussed = model.TransferFirstDiscussed?.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture),
                TargetDateForTransfer = model.TargetDateForTransfer?.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture),
                HtbDate = model.HtbDate?.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture)
            };

            var intendedTransferBenefits = new IntendedTransferBenefitResponse
            {
                OtherBenefitValue = model.OtherBenefitValue,
                SelectedBenefits = model.AcademyTransferProjectIntendedTransferBenefits?
                    .Select(b => b.SelectedBenefit).ToList()
            };

            var otherFactorsToConsider = new OtherFactorsToConsiderResponse
            {
                HighProfile = new BenefitConsideredFactorResponse
                {
                    ShouldBeConsidered = model.HighProfileShouldBeConsidered,
                    FurtherSpecification = model.HighProfileFurtherSpecification
                },
                ComplexLandAndBuilding = new BenefitConsideredFactorResponse
                {
                    ShouldBeConsidered = model.ComplexLandAndBuildingShouldBeConsidered,
                    FurtherSpecification = model.ComplexLandAndBuildingFurtherSpecification
                },
                FinanceAndDebt = new BenefitConsideredFactorResponse
                {
                    ShouldBeConsidered = model.FinanceAndDebtShouldBeConsidered,
                    FurtherSpecification = model.FinanceAndDebtFurtherSpecification
                }
            };

            return new AcademyTransferProjectResponse
            {
                ProjectUrn = model.Urn.ToString(),
                OutgoingTrustUkprn = model.OutgoingTrustUkprn,
                TransferringAcademies = transferringAcademies,
                Features = features,
                Dates = dates,
                Benefits = new AcademyTransferProjectBenefitsResponse
                {
                    IntendedTransferBenefits = intendedTransferBenefits,
                    OtherFactorsToConsider = otherFactorsToConsider
                },
                Rationale = new AcademyTransferProjectRationaleResponse
                {
                    ProjectRationale = model.ProjectRationale,
                    TrustSponsorRationale = model.TrustSponsorRationale
                },
                State = model.State,
                Status = model.Status
            };
        }
    }
}