using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using FizzWare.NBuilder;
using FluentAssertions;
using TramsDataApi.DatabaseModels;
using TramsDataApi.Factories;
using TramsDataApi.ResponseModels;
using Xunit;

namespace TramsDataApi.Test.Factories
{
    public class AcademyTransferProjectResponseFactoryTests
    {

        [Fact]
        public void ReturnsAnAcademyTransferProjectResponse_WhenGivenAnInitialAcademyTransferProject()
        {
            
      
            var academyTransferProjectModel = new AcademyTransferProjects
            {
                Urn = 0,
                OutgoingTrustUkprn = "00000001",
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
                TransferringAcademies = Builder<TransferringAcademies>
                    .CreateListOfSize(1).All()
                    .With(ta => ta.IncomingTrustUkprn = null)
                    .Build()
            };
            
            var expected = new AcademyTransferProjectResponse
            {
                ProjectUrn = academyTransferProjectModel.Urn.ToString(),
                OutgoingTrustUkprn = academyTransferProjectModel.OutgoingTrustUkprn,
                TransferringAcademies = academyTransferProjectModel.TransferringAcademies.Select(ta =>
                    new TransferringAcademiesResponse
                        {IncomingTrustUkprn = null, OutgoingAcademyUkprn = ta.OutgoingAcademyUkprn}).ToList(),
                Features = new AcademyTransferProjectFeaturesResponse(),
                Dates = new AcademyTransferProjectDatesResponse(),
                Benefits = new AcademyTransferProjectBenefitsResponse
                {
                    IntendedTransferBenefits = new IntendedTransferBenefitResponse(),
                    OtherFactorsToConsider = new OtherFactorsToConsiderResponse
                    {
                        HighProfile = new BenefitConsideredFactorResponse(),
                        ComplexLandAndBuilding = new BenefitConsideredFactorResponse(),
                        FinanceAndDebt = new BenefitConsideredFactorResponse()
                    }
                },
                Rationale = new AcademyTransferProjectRationaleResponse(),
                State = null,
                Status = null
            };

            var result = AcademyTransferProjectResponseFactory.Create(academyTransferProjectModel);
            
            result.Should().BeEquivalentTo(expected);
        }

        [Fact]
        public void ReturnsAnAcademyTransferProjectResponse_WhenGivenACompleteAcademyTransferProject()
        {
            var academyTransferProjectModel = Builder<AcademyTransferProjects>.CreateNew().Build();

            var expectedTransferringAcademies = academyTransferProjectModel.TransferringAcademies
                .Select(a => new TransferringAcademiesResponse
                    {IncomingTrustUkprn = a.IncomingTrustUkprn, OutgoingAcademyUkprn = a.OutgoingAcademyUkprn})
                .ToList();

            var expectedFeatures = new AcademyTransferProjectFeaturesResponse
            {
                WhoInitiatedTheTransfer = academyTransferProjectModel.WhoInitiatedTheTransfer,
                RddOrEsfaIntervention = academyTransferProjectModel.RddOrEsfaIntervention,
                RddOrEsfaInterventionDetail = academyTransferProjectModel.RddOrEsfaInterventionDetail,
                TypeOfTransfer = academyTransferProjectModel.TypeOfTransfer,
                OtherTransferTypeDescription = academyTransferProjectModel.OtherTransferTypeDescription
            };

            var expectedDates = new AcademyTransferProjectDatesResponse
            {
                TransferFirstDiscussed = academyTransferProjectModel.TransferFirstDiscussed?.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture),
                TargetDateForTransfer = academyTransferProjectModel.TargetDateForTransfer?.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture),
                HtbDate = academyTransferProjectModel.HtbDate?.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture)
            };

            var expectedIntendedTransferBenefits = new IntendedTransferBenefitResponse
            {
                OtherBenefitValue = academyTransferProjectModel.OtherBenefitValue,
                SelectedBenefits = academyTransferProjectModel.AcademyTransferProjectIntendedTransferBenefits
                    .Select(b => b.SelectedBenefit).ToList()
            };

            var expectedOtherFactorsToConsider = new OtherFactorsToConsiderResponse
            {
                HighProfile = new BenefitConsideredFactorResponse
                {
                    ShouldBeConsidered = academyTransferProjectModel.HighProfileShouldBeConsidered,
                    FurtherSpecification = academyTransferProjectModel.HighProfileFurtherSpecification
                },
                ComplexLandAndBuilding = new BenefitConsideredFactorResponse
                {
                    ShouldBeConsidered = academyTransferProjectModel.ComplexLandAndBuildingShouldBeConsidered,
                    FurtherSpecification = academyTransferProjectModel.ComplexLandAndBuildingFurtherSpecification
                },
                FinanceAndDebt = new BenefitConsideredFactorResponse
                {
                    ShouldBeConsidered = academyTransferProjectModel.FinanceAndDebtShouldBeConsidered,
                    FurtherSpecification = academyTransferProjectModel.FinanceAndDebtFurtherSpecification
                }
            };

            var expected = new AcademyTransferProjectResponse
            {
                ProjectUrn = academyTransferProjectModel.Urn.ToString(),
                OutgoingTrustUkprn = academyTransferProjectModel.OutgoingTrustUkprn,
                TransferringAcademies = expectedTransferringAcademies,
                Features = expectedFeatures,
                Dates = expectedDates,
                Benefits = new AcademyTransferProjectBenefitsResponse
                {
                IntendedTransferBenefits = expectedIntendedTransferBenefits,
                OtherFactorsToConsider = expectedOtherFactorsToConsider
                },
                Rationale = new AcademyTransferProjectRationaleResponse
                {
                    ProjectRationale = academyTransferProjectModel.ProjectRationale,
                    TrustSponsorRationale = academyTransferProjectModel.TrustSponsorRationale
                },
                State = academyTransferProjectModel.State,
                Status = academyTransferProjectModel.Status
            };

            var result = AcademyTransferProjectResponseFactory.Create(academyTransferProjectModel);
            
            result.Should().BeEquivalentTo(expected);
        }
    }
}