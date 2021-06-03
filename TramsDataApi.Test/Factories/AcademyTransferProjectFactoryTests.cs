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
                AcademyTransferProjectIntendedTransferBenefits = new List<AcademyTransferProjectIntendedTransferBenefits>(),
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

        [Fact]
        public void ReturnsOriginalAcademyTransferProject_WhenUpdating_IfAcademyTransferProjectRequestIsNull()
        {
            var academyTransferProject = Builder<AcademyTransferProjects>.CreateNew().Build();

            var result = AcademyTransferProjectFactory.Update(academyTransferProject, null);

            result.Should().BeEquivalentTo(academyTransferProject);
        }

        [Fact]
        public void ReturnsUpdatedAcademyTransferProject_WhenUpdating_IfRequestHasUpdatedFields()
        {
            var academyTransferProject = Builder<AcademyTransferProjects>.CreateNew().Build();
            var updateRequest = new AcademyTransferProjectRequest
            {
                OutgoingTrustUkprn = "12312354",
                Rationale = new AcademyTransferProjectRationaleRequest {
                    ProjectRationale = "A new rationale for the project"
                }
            };

            var expected = new AcademyTransferProjects
            {
                Id = academyTransferProject.Id,
                Urn = academyTransferProject.Urn,   
                OutgoingTrustUkprn = updateRequest.OutgoingTrustUkprn,
                ProjectRationale = updateRequest.Rationale.ProjectRationale,
                TransferringAcademies = academyTransferProject.TransferringAcademies,
                WhoInitiatedTheTransfer = academyTransferProject.WhoInitiatedTheTransfer,
                TargetDateForTransfer = academyTransferProject.TargetDateForTransfer,
                RddOrEsfaIntervention = academyTransferProject.RddOrEsfaIntervention,
                RddOrEsfaInterventionDetail = academyTransferProject.RddOrEsfaInterventionDetail,
                TypeOfTransfer = academyTransferProject.TypeOfTransfer,
                OtherTransferTypeDescription = academyTransferProject.OtherTransferTypeDescription,
                TransferFirstDiscussed = academyTransferProject.TransferFirstDiscussed,
                HtbDate = academyTransferProject.HtbDate,
                TrustSponsorRationale = academyTransferProject.TrustSponsorRationale,
                State = academyTransferProject.State,
                Status = academyTransferProject.Status,
                HighProfileShouldBeConsidered = academyTransferProject.HighProfileShouldBeConsidered,
                HighProfileFurtherSpecification = academyTransferProject.HighProfileFurtherSpecification,
                ComplexLandAndBuildingShouldBeConsidered = academyTransferProject.ComplexLandAndBuildingShouldBeConsidered,
                ComplexLandAndBuildingFurtherSpecification = academyTransferProject.ComplexLandAndBuildingFurtherSpecification,
                FinanceAndDebtShouldBeConsidered = academyTransferProject.FinanceAndDebtShouldBeConsidered,
                FinanceAndDebtFurtherSpecification = academyTransferProject.FinanceAndDebtFurtherSpecification,
                OtherBenefitValue = academyTransferProject.OtherBenefitValue,
                AcademyTransferProjectIntendedTransferBenefits = academyTransferProject.AcademyTransferProjectIntendedTransferBenefits,
            };

            var result = AcademyTransferProjectFactory.Update(academyTransferProject, updateRequest);
            result.Should().BeEquivalentTo(expected);
        }

        [Fact]
        public void ReturnsUpdatedAcademyTransferProject_WhenUpdating_AndUpdatesTheListOfTransferringAcademies()
        {
            var academyTransferProject = Builder<AcademyTransferProjects>
                .CreateNew()
                .With(atp => atp.TransferringAcademies = Builder<TransferringAcademies>.CreateListOfSize(5).Build())
                .Build();

            var transferringAcademiesRequests = academyTransferProject.TransferringAcademies.Select(ta => new TransferringAcademiesRequest
            {
                OutgoingAcademyUkprn = ta.OutgoingAcademyUkprn,
                IncomingTrustUkprn = ta.IncomingTrustUkprn
            }).ToList();
            transferringAcademiesRequests.ElementAt(0).OutgoingAcademyUkprn = "12385731";
            
            var updateRequest = new AcademyTransferProjectRequest
            {
                OutgoingTrustUkprn = "12387123",
                TransferringAcademies = transferringAcademiesRequests,
            };

            var expectedTransferringAcademies = transferringAcademiesRequests.Select(ta => new TransferringAcademies
            {
                OutgoingAcademyUkprn = ta.OutgoingAcademyUkprn,
                IncomingTrustUkprn = ta.IncomingTrustUkprn
            }).ToList();

            var expected = new AcademyTransferProjects
            {
                Id = academyTransferProject.Id,
                Urn = academyTransferProject.Urn,   
                OutgoingTrustUkprn = updateRequest.OutgoingTrustUkprn,
                ProjectRationale = academyTransferProject.ProjectRationale,
                TransferringAcademies = expectedTransferringAcademies,
                WhoInitiatedTheTransfer = academyTransferProject.WhoInitiatedTheTransfer,
                TargetDateForTransfer = academyTransferProject.TargetDateForTransfer,
                RddOrEsfaIntervention = academyTransferProject.RddOrEsfaIntervention,
                RddOrEsfaInterventionDetail = academyTransferProject.RddOrEsfaInterventionDetail,
                TypeOfTransfer = academyTransferProject.TypeOfTransfer,
                OtherTransferTypeDescription = academyTransferProject.OtherTransferTypeDescription,
                TransferFirstDiscussed = academyTransferProject.TransferFirstDiscussed,
                HtbDate = academyTransferProject.HtbDate,
                TrustSponsorRationale = academyTransferProject.TrustSponsorRationale,
                State = academyTransferProject.State,
                Status = academyTransferProject.Status,
                HighProfileShouldBeConsidered = academyTransferProject.HighProfileShouldBeConsidered,
                HighProfileFurtherSpecification = academyTransferProject.HighProfileFurtherSpecification,
                ComplexLandAndBuildingShouldBeConsidered = academyTransferProject.ComplexLandAndBuildingShouldBeConsidered,
                ComplexLandAndBuildingFurtherSpecification = academyTransferProject.ComplexLandAndBuildingFurtherSpecification,
                FinanceAndDebtShouldBeConsidered = academyTransferProject.FinanceAndDebtShouldBeConsidered,
                FinanceAndDebtFurtherSpecification = academyTransferProject.FinanceAndDebtFurtherSpecification,
                OtherBenefitValue = academyTransferProject.OtherBenefitValue,
                AcademyTransferProjectIntendedTransferBenefits = academyTransferProject.AcademyTransferProjectIntendedTransferBenefits,
            };

            var result = AcademyTransferProjectFactory.Update(academyTransferProject, updateRequest);

            result.Should().BeEquivalentTo(expected);
        }

        [Fact]
        public void ReturnsUpdatedAcademyTransferProject_WhenUpdating_IfRequestHasUpdatedSelectedBenefitsRequests()
        {
            var academyTransferProject = Builder<AcademyTransferProjects>
                .CreateNew()
                .With(atp =>
                    atp.AcademyTransferProjectIntendedTransferBenefits = Builder<AcademyTransferProjectIntendedTransferBenefits>.CreateListOfSize(5).Build())
                .Build();

            var updatedBenefits = academyTransferProject.AcademyTransferProjectIntendedTransferBenefits
                            .Select(benefit => benefit.SelectedBenefit)
                            .ToList();
            updatedBenefits.Insert(0, "A completely new benefit");

            var updateRequest = new AcademyTransferProjectRequest
            {
                State = "A New State",
                Benefits = new AcademyTransferProjectBenefitsRequest
                {
                    IntendedTransferBenefits = new IntendedTransferBenefitRequest
                    {
                        SelectedBenefits = updatedBenefits,
                    }
                }
            };

            var expectedBenefits = updateRequest.Benefits.IntendedTransferBenefits.SelectedBenefits
                .Select(selectedBenefit => new AcademyTransferProjectIntendedTransferBenefits { SelectedBenefit = selectedBenefit })
                .ToList();

             var expected = new AcademyTransferProjects
            {
                Id = academyTransferProject.Id,
                Urn = academyTransferProject.Urn,   
                OutgoingTrustUkprn = academyTransferProject.OutgoingTrustUkprn,
                ProjectRationale = academyTransferProject.ProjectRationale,
                TransferringAcademies = academyTransferProject.TransferringAcademies,
                WhoInitiatedTheTransfer = academyTransferProject.WhoInitiatedTheTransfer,
                TargetDateForTransfer = academyTransferProject.TargetDateForTransfer,
                RddOrEsfaIntervention = academyTransferProject.RddOrEsfaIntervention,
                RddOrEsfaInterventionDetail = academyTransferProject.RddOrEsfaInterventionDetail,
                TypeOfTransfer = academyTransferProject.TypeOfTransfer,
                OtherTransferTypeDescription = academyTransferProject.OtherTransferTypeDescription,
                TransferFirstDiscussed = academyTransferProject.TransferFirstDiscussed,
                HtbDate = academyTransferProject.HtbDate,
                TrustSponsorRationale = academyTransferProject.TrustSponsorRationale,
                State = updateRequest.State,
                Status = academyTransferProject.Status,
                HighProfileShouldBeConsidered = academyTransferProject.HighProfileShouldBeConsidered,
                HighProfileFurtherSpecification = academyTransferProject.HighProfileFurtherSpecification,
                ComplexLandAndBuildingShouldBeConsidered = academyTransferProject.ComplexLandAndBuildingShouldBeConsidered,
                ComplexLandAndBuildingFurtherSpecification = academyTransferProject.ComplexLandAndBuildingFurtherSpecification,
                FinanceAndDebtShouldBeConsidered = academyTransferProject.FinanceAndDebtShouldBeConsidered,
                FinanceAndDebtFurtherSpecification = academyTransferProject.FinanceAndDebtFurtherSpecification,
                OtherBenefitValue = academyTransferProject.OtherBenefitValue,
                AcademyTransferProjectIntendedTransferBenefits = expectedBenefits,
            };

            var result = AcademyTransferProjectFactory.Update(academyTransferProject, updateRequest);

            result.Should().BeEquivalentTo(expected);
        }
    }

    
}