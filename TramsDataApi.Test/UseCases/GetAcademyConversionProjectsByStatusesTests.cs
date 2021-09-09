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
    public class GetAcademyConversionProjectsByStatusesTests
    {
        private readonly Fixture _fixture;

        public GetAcademyConversionProjectsByStatusesTests()
        {
            _fixture = new Fixture();
        }
        
        [Fact]
        public void GetAcademyConversionProjectProjectByStatuses_ReturnsEmptyList_WhenAcademyTransferProjectIsNotFound()
        {
            var statuses = new List<string> {"Status_One", "Status_Two"};
            var request = new GetAcademyConversionProjectsByStatusesRequest
            {
                Count = 50,
                Statuses = statuses
            };
            
            var mockProjectsGateway = new Mock<IAcademyConversionProjectGateway>();
            var mockTrustGateway = new Mock<ITrustGateway>();

            mockProjectsGateway
                .Setup(acg => acg.GetByStatuses(50, statuses))
                .Returns(() => new List<AcademyConversionProject>());

            var useCase = new GetAcademyConversionProjectsByStatuses(mockProjectsGateway.Object, mockTrustGateway.Object);
            
            var result = useCase.Execute(request).ToList();

            result.Should().BeEquivalentTo(new List<AcademyConversionProjectResponse>());
        }
        
        [Fact]
        public void GetAcademyConversionProjectProjectByStatuses_ReturnsListOfProjectResponses_WhenAcademyTransferProjectsAreFound()
        {
            var statuses = new List<string> {"Status_One", "Status_Two"};
            var request = new GetAcademyConversionProjectsByStatusesRequest
            {
                Count = 50,
                Statuses = statuses
            };
            
            var project = _fixture.Build<AcademyConversionProject>().With(f => f.SchoolName, "school").Create();
            var expected = AcademyConversionProjectResponseFactory.Create(project);
            
            var mockProjectsGateway = new Mock<IAcademyConversionProjectGateway>();
            var mockTrustGateway = new Mock<ITrustGateway>();

            mockProjectsGateway
                .Setup(acg => acg.GetByStatuses(50, statuses))
                .Returns(() => new List<AcademyConversionProject> { project });
            
            var useCase = new GetAcademyConversionProjectsByStatuses(mockProjectsGateway.Object, mockTrustGateway.Object);
            
            var result = useCase.Execute(request).ToList();
            
            result.Should().BeEquivalentTo(new List<AcademyConversionProjectResponse> { expected });
        }
    }
}