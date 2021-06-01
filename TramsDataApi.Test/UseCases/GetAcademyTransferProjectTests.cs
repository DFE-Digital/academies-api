using FluentAssertions;
using Moq;
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
    }
}