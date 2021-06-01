using FizzWare.NBuilder;
using FluentAssertions;
using Moq;
using TramsDataApi.DatabaseModels;
using TramsDataApi.Factories;
using TramsDataApi.Gateways;
using TramsDataApi.UseCases;
using Xunit;

namespace TramsDataApi.Test.UseCases
{
    public class GetAcademyTransferProjectTests
    {
        [Fact]
        public void GetAcademyTransferProjecyByUrn_ReturnsNull_WhenAcademyTransferProjectIsNotFound()
        {
            var urn = 10010010;
            var academyTransferProjectsGateway = new Mock<IAcademyTransferProjectGateway>();

            academyTransferProjectsGateway.Setup(atGateway => atGateway.GetAcademyTransferProjectByUrn(urn))
                .Returns(() => null);

            
            var useCase = new GetAcademyTransferProject(academyTransferProjectsGateway.Object);
            var result = useCase.Execute(urn);

            result.Should().BeNull();
        }

        [Fact]
        public void GetAcademyTransferProjectByUrn_ReturnsAnAcademyTransferProjectResponse_WhenTheProjectIsFound()
        {
            var urn = 10010010;
            var academyTransferProjectsGateway = new Mock<IAcademyTransferProjectGateway>();
            var academyTransferProject = Builder<AcademyTransferProjects>.CreateNew().Build();
            var expected = AcademyTransferProjectResponseFactory.Create(academyTransferProject);

            academyTransferProjectsGateway.Setup(atGateway => atGateway.GetAcademyTransferProjectByUrn(urn))
                .Returns(academyTransferProject);

            
            var useCase = new GetAcademyTransferProject(academyTransferProjectsGateway.Object);
            var result = useCase.Execute(urn);

            result.Should().BeEquivalentTo(expected);
        }
    }
}