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
using TramsDataApi.Factories;

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

            var expectedUpdatedProject = AcademyTransferProjectFactory.Update(academyTransferProject, updateAcademyTransferProject);

            gateway.Setup(g => g.SaveAcademyTransferProject(
                It.Is<AcademyTransferProjects>(atp => atp.Id == academyTransferProject.Id && atp.OutgoingTrustUkprn == updateAcademyTransferProject.OutgoingTrustUkprn))
            ).Returns(expectedUpdatedProject);

            var expected = AcademyTransferProjectResponseFactory.Create(expectedUpdatedProject);
            var useCase = new UpdateAcademyTransferProject(gateway.Object);
            var result = useCase.Execute(urn, updateAcademyTransferProject);

            result.Should().BeEquivalentTo(expected);
        }
    }
}