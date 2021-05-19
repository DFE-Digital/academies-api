using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using FizzWare.NBuilder;
using FluentAssertions;
using TramsDataApi.DatabaseModels;
using TramsDataApi.Factories;
using TramsDataApi.RequestModels;
using TramsDataApi.ResponseModels;
using Xunit;

namespace TramsDataApi.Test.Factories
{
    public class AcademyTransferProjectFactoryTests
    {

        [Fact]
        public void ReturnsAnAcademyTransferProject_WhenGivenAnInitialAcademyTransferProjectRequest()
        {
            var randomGenerator = new RandomGenerator();
            var createRequest = Builder<AcademyTransferProjectRequest>.CreateNew()
                .With(c => c.OutgoingTrustUkprn = randomGenerator.NextString(8,8))
                .With(c => c.Status = null)
                .With(c => c.State = null)
                .With(c => c.Benefits = null)
                .With(c => c.Dates = null)
                .With(c => c.Rationale = null)
                .With(c => c.Features = null)
                .With(c => c.TransferringAcademies = (List<TransferringAcademiesRequest>) Builder<TransferringAcademiesRequest>
                    .CreateListOfSize(5)
                    .All()
                    .With(t => t.OutgoingAcademyUkprn = randomGenerator.NextString(8,8))
                    .With(t => t.IncomingTrustUkprn = null).Build())
                .Build();
            
            var expected = new AcademyTransferProjects
            {
                OutgoingTrustUkprn = createRequest.OutgoingTrustUkprn,
                WhoInitiatedTheTransfer = null,
                RddOrEsfaIntervention = null,
                RddOrEsfaInterventionDetail = null,
                TypeOfTransfer = null,
                OtherTransferTypeDescription = null,
                TransferFirstDiscussed = null,
                TargetDateForTransfer = null,
                HtbDate = null,
                ProjectRationale = null,
                TrustSponsorRationale = null,
                State = null,
                Status = null,
                HighProfileShouldBeConsidered = null,
                HighProfileFurtherSpecification = null,
                ComplexLandAndBuildingShouldBeConsidered = null,
                ComplexLandAndBuildingFurtherSpecification = null,
                FinanceAndDebtShouldBeConsidered = null,
                FinanceAndDebtFurtherSpecification = null,
                OtherBenefitValue = null,
                AcademyTransferProjectIntendedTransferBenefits = null,
                TransferringAcademies = createRequest.TransferringAcademies
                    .Select(t => new TransferringAcademies { OutgoingAcademyUkprn = t.OutgoingAcademyUkprn, IncomingTrustUkprn = null })
                    .ToList()
            };
            
            var result = AcademyTransferProjectFactory.Create(createRequest);

            result.Should().BeEquivalentTo(expected);
        }

        [Fact]
        public void ReturnsAnAcademyTransferProject_WhenGivenACompleteAcademyTransferProjectRequest()
        {
            var randomGenerator = new RandomGenerator();

            var benefitsRequest = Builder<AcademyTransferProjectBenefitsRequest>.CreateNew()
                .With(b => b.IntendedTransferBenefits = Builder<IntendedTransferBenefitRequest>.CreateNew()
                    .With(i => i.SelectedBenefits =  new List<string>()).Build())
                .With(b => b.OtherFactorsToConsider = Builder<OtherFactorsToConsiderRequest>.CreateNew()
                    .With(o => o.ComplexLandAndBuilding = Builder<BenefitConsideredFactorRequest>.CreateNew().Build())
                    .With(o => o.FinanceAndDebt = Builder<BenefitConsideredFactorRequest>.CreateNew().Build())
                    .With(o => o.HighProfile = Builder<BenefitConsideredFactorRequest>.CreateNew().Build()).Build())
                .Build();
            
            var datesRequest = Builder<AcademyTransferProjectDatesRequest>.CreateNew()
                .With(d => d.TransferFirstDiscussed =
                    randomGenerator.DateTime().ToString("dd/MM/yyyy", CultureInfo.InvariantCulture))
                .With(d => d.TargetDateForTransfer =
                    randomGenerator.DateTime().ToString("dd/MM/yyyy", CultureInfo.InvariantCulture))
                .With(d => d.HtbDate = randomGenerator.DateTime().ToString("dd/MM/yyyy", CultureInfo.InvariantCulture))
                .Build();
            
            var createRequest = Builder<AcademyTransferProjectRequest>.CreateNew()
                .With(c => c.OutgoingTrustUkprn = randomGenerator.NextString(8,8))
                .With(c => c.Benefits = benefitsRequest)
                .With(c => c.Dates = datesRequest)
                .With(c => c.Rationale = Builder<AcademyTransferProjectRationaleRequest>.CreateNew().Build())
                .With(c => c.Features = Builder<AcademyTransferProjectFeaturesRequest>.CreateNew().Build())
                .With(c => c.TransferringAcademies = (List<TransferringAcademiesRequest>) Builder<TransferringAcademiesRequest>
                    .CreateListOfSize(5).Build())
                .Build();

            var expected = new AcademyTransferProjects
            {
                OutgoingTrustUkprn = createRequest.OutgoingTrustUkprn,
                WhoInitiatedTheTransfer = createRequest.Features.WhoInitiatedTheTransfer,
                RddOrEsfaIntervention = createRequest.Features.RddOrEsfaIntervention,
                RddOrEsfaInterventionDetail = createRequest.Features.RddOrEsfaInterventionDetail,
                TypeOfTransfer = createRequest.Features.TypeOfTransfer,
                OtherTransferTypeDescription = createRequest.Features.OtherTransferTypeDescription,
                TransferFirstDiscussed = DateTime.ParseExact(createRequest.Dates.TransferFirstDiscussed, "dd/MM/yyyy", CultureInfo.InvariantCulture),
                TargetDateForTransfer = DateTime.ParseExact(createRequest.Dates.TargetDateForTransfer, "dd/MM/yyyy", CultureInfo.InvariantCulture),
                HtbDate = DateTime.ParseExact(createRequest.Dates.HtbDate, "dd/MM/yyyy", CultureInfo.InvariantCulture),
                ProjectRationale = createRequest.Rationale.ProjectRationale,
                TrustSponsorRationale = createRequest.Rationale.TrustSponsorRationale,
                State = createRequest.State,
                Status = createRequest.Status,
                HighProfileShouldBeConsidered = createRequest.Benefits.OtherFactorsToConsider.HighProfile.ShouldBeConsidered,
                HighProfileFurtherSpecification = createRequest.Benefits.OtherFactorsToConsider.HighProfile.FurtherSpecification,
                ComplexLandAndBuildingShouldBeConsidered = createRequest.Benefits.OtherFactorsToConsider.ComplexLandAndBuilding.ShouldBeConsidered,
                ComplexLandAndBuildingFurtherSpecification = createRequest.Benefits.OtherFactorsToConsider.ComplexLandAndBuilding.FurtherSpecification,
                FinanceAndDebtShouldBeConsidered = createRequest.Benefits.OtherFactorsToConsider.FinanceAndDebt.ShouldBeConsidered,
                FinanceAndDebtFurtherSpecification = createRequest.Benefits.OtherFactorsToConsider.FinanceAndDebt.FurtherSpecification,
                OtherBenefitValue = createRequest.Benefits.IntendedTransferBenefits.OtherBenefitValue,
                AcademyTransferProjectIntendedTransferBenefits = createRequest.Benefits.IntendedTransferBenefits.SelectedBenefits
                    .Select(b => new AcademyTransferProjectIntendedTransferBenefits { SelectedBenefit = b }).ToList(),
                TransferringAcademies = createRequest.TransferringAcademies
                    .Select(t => new TransferringAcademies { OutgoingAcademyUkprn = t.OutgoingAcademyUkprn, IncomingTrustUkprn = t.IncomingTrustUkprn })
                    .ToList()
            };

            var result = AcademyTransferProjectFactory.Create(createRequest);

            result.Should().BeEquivalentTo(expected);
        }
    }
}