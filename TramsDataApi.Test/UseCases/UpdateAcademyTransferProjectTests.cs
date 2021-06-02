using FizzWare.NBuilder;
using FluentAssertions;
using Moq;
using TramsDataApi.DatabaseModels;
using TramsDataApi.Gateways;
using TramsDataApi.RequestModels;
using System.Globalization;
using Xunit;
using System;
using TramsDataApi.UseCases;

namespace TramsDataApi.Test.UseCases
{
    public class UpdateAcademyTransferProjectTests
    {
        [Fact]
        public void ShouldSaveAnUpdateAcademyTransferProject_WhenGivenAPartialModelToUpdate()
        {
            var urn = 10010010;
            var gateway = new Mock<IAcademyTransferProjectGateway>();
            var academyTransferProject = Builder<AcademyTransferProjects>
                .CreateNew().With(atp => atp.Urn = urn).Build();
            var updateAcademyTransferProject = new AcademyTransferProjectRequest
            {
                OutgoingTrustUkprn = "12345123",
                Dates = new AcademyTransferProjectDatesRequest
                {
                    TargetDateForTransfer = "12/12/2022"
                },
                Features = new AcademyTransferProjectFeaturesRequest
                {
                    WhoInitiatedTheTransfer = "Somebody Else"
                }
            };
            
            gateway.Setup(g => g.GetAcademyTransferProjectByUrn(urn)).Returns(academyTransferProject);

            var expected = new AcademyTransferProjects
            {
                Id = academyTransferProject.Id,
                OutgoingTrustUkprn = updateAcademyTransferProject.OutgoingTrustUkprn,
                TransferringAcademies = academyTransferProject.TransferringAcademies,
                WhoInitiatedTheTransfer = updateAcademyTransferProject.Features.WhoInitiatedTheTransfer,
                TargetDateForTransfer = DateTime.ParseExact(updateAcademyTransferProject.Dates.TargetDateForTransfer, "dd/MM/yyyy", CultureInfo.InvariantCulture),
                RddOrEsfaIntervention = updateAcademyTransferProject.Features.RddOrEsfaIntervention,
                RddOrEsfaInterventionDetail = academyTransferProject.RddOrEsfaInterventionDetail,
                TypeOfTransfer = academyTransferProject.TypeOfTransfer,
                OtherTransferTypeDescription = academyTransferProject.OtherTransferTypeDescription,
                TransferFirstDiscussed = academyTransferProject.TransferFirstDiscussed,
                HtbDate = academyTransferProject.HtbDate,
                ProjectRationale = academyTransferProject.ProjectRationale,
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

            gateway.Setup(g => g.SaveAcademyTransferProject(expected)).Returns(expected);

            var useCase = new UpdateAcademyTransferProject(gateway.Object);
            var result = useCase.Execute(urn, updateAcademyTransferProject);
            result.Should().BeEquivalentTo(expected);
        }
    }
}