using System.Collections.Generic;
using System.Linq;
using AutoFixture;
using FluentAssertions;
using Moq;
using TramsDataApi.DatabaseModels;
using TramsDataApi.Factories;
using TramsDataApi.Gateways;
using TramsDataApi.RequestModels.AcademyConversionProject;
using TramsDataApi.ResponseModels.AcademyConversionProject;
using TramsDataApi.UseCases;
using Xunit;

namespace TramsDataApi.Test.UseCases
{
    public class GetAcademyConversionProjectsTests
    {
        private readonly Fixture _fixture;

        public GetAcademyConversionProjectsTests()
        {
            _fixture = new Fixture();
        }
        
        [Fact]
        public void GetAllAcademyConversionProjects_ReturnsEmptyList_WhenAcademyTransferProjectIsNotFound()
        {
            var request = new GetAllAcademyConversionProjectsRequest { Count = 50 };
            
            var mockProjectsGateway = new Mock<IAcademyConversionProjectGateway>();
            
            mockProjectsGateway
                .Setup(acg => acg.GetProjects(50))
                .Returns(() => new List<AcademyConversionProject>());

            var useCase = new GetAcademyConversionProjects(
                mockProjectsGateway.Object, 
                new Mock<ITrustGateway>().Object,
                new Mock<IEstablishmentGateway>().Object);
            
            var result = useCase.Execute(request).ToList();

            result.Should().BeEquivalentTo(new List<AcademyConversionProjectResponse>());
        }
        
        [Fact]
        public void GetAllAcademyConversionProjects_ReturnsListOfProjectResponses_WhenAcademyTransferProjectsAreFound()
        {
            var request = new GetAllAcademyConversionProjectsRequest { Count = 50 };

            var mockProjectsGateway = new Mock<IAcademyConversionProjectGateway>();

            var project = _fixture.Build<AcademyConversionProject>()
                .With(f => f.SchoolName, "school")
                .Create();

            var expectedProject = AcademyConversionProjectResponseFactory.Create(project);

            mockProjectsGateway
                .Setup(acg => acg.GetProjects(50))
                .Returns(() => new List<AcademyConversionProject> { project });
            
            var useCase = new GetAcademyConversionProjects(
                mockProjectsGateway.Object,
                new Mock<ITrustGateway>().Object,
                new Mock<IEstablishmentGateway>().Object);

            var result = useCase.Execute(request).ToList();
            
            result.Should().BeEquivalentTo(new List<AcademyConversionProjectResponse> { expectedProject });
        }
    }
}