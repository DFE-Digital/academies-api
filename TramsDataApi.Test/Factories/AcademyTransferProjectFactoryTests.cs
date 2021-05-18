using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using FizzWare.NBuilder;
using TramsDataApi.DatabaseModels;
using TramsDataApi.RequestModels;
using Xunit;

namespace TramsDataApi.Test.Factories
{
    public class AcademyTransferProjectFactoryTests
    {
        [Fact]
        public void ReturnsAnAcademyTransferProject_WhenGivenACreateOrUpdateAcademyTransferProjectRequest()
        {
            var createRequest = Builder<CreateOrUpdateAcademyTransferProjectRequest>.CreateNew()
                .With(c => c.ProjectUrn = null)
                .With(c => c.Benefits = Builder<AcademyTransferProjectBenefitsRequest>.CreateNew().Build())
                .With(c => c.Dates = Builder<AcademyTransferProjectDatesRequest>.CreateNew().Build())
                .With(c => c.Rationale = Builder<AcademyTransferProjectRationaleRequest>.CreateNew().Build())
                .With(c => c.TransferringAcademies = (List<TransferringAcademiesRequest>) Builder<TransferringAcademiesRequest>.CreateListOfSize(5).Build())
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