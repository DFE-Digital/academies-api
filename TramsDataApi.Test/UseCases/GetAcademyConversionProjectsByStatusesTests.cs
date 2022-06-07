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
        public void GetAcademyConversionProjectProjectByStatuses_ReturnsEmptyList_WhenAcademyConversionProjectIsNotFound()
        {
            const int page = 1;
            const int count = 50;
            var statuses = new List<string> {"Status_One", "Status_Two"};
            
            var mockProjectsGateway = new Mock<IAcademyConversionProjectGateway>();
            var mockEstablishmentsGateway = new Mock<IEstablishmentGateway>();

            var useCase = new GetAcademyConversionProjectsByStatuses(
                mockProjectsGateway.Object,
                mockEstablishmentsGateway.Object);
            
            var result = useCase.Execute(page, count, statuses).ToList();

            result.Should().BeEquivalentTo(new List<AcademyConversionProjectResponse>());
        }
        
        [Fact]
        public void GetAcademyConversionProjectProjectByStatuses_ReturnsListOfProjectResponses_WhenAcademyConversionProjectsAreFound()
        {
            const int page = 1;
            const int count = 1;
            var statuses = new List<string> {"ProjectStatus"};
            
            var project = _fixture.Build<AcademyConversionProject>()
                .With(f => f.SchoolName, "school")
                .With(f => f.ProjectStatus, "ProjectStatus")
                .Create();
            var expected = AcademyConversionProjectResponseFactory.Create(project);
            
            var mockProjectsGateway = new Mock<IAcademyConversionProjectGateway>();
            var mockEstablishmentsGateway = new Mock<IEstablishmentGateway>();
            
            mockProjectsGateway
                .Setup(acg => acg.GetByStatuses(It.IsAny<int>(), It.IsAny<int>(), statuses))
                .Returns(() => new List<AcademyConversionProject> { project });
            
            mockEstablishmentsGateway
                .Setup(acg => acg.GetMisEstablishmentByUrn(It.IsAny<int>()))
                .Returns(() => new MisEstablishments());
            
            var useCase = new GetAcademyConversionProjectsByStatuses(
                mockProjectsGateway.Object,
                mockEstablishmentsGateway.Object);
            
            var result = useCase.Execute(page, count, statuses).ToList();
            
            result.Should().BeEquivalentTo(new List<AcademyConversionProjectResponse> { expected });
        }
        
        [Fact]
        public void GetAcademyConversionProjectByStatuses_ReturnsListOfProjectResponses_WhenAcademyConversionProjectsAreFound()
        {
            const int page = 1;
            const int count = 50;
            var statuses = new List<string> {"ProjectStatus"};
            
            var project = _fixture.Build<AcademyConversionProject>()
                .With(f => f.SchoolName, "School")
                .With(f => f.ProjectStatus, "ProjectStatus")
                .Create();
            var expected = AcademyConversionProjectResponseFactory.Create(project);
            
            var mockProjectsGateway = new Mock<IAcademyConversionProjectGateway>();
            var mockEstablishmentsGateway = new Mock<IEstablishmentGateway>();
            
            mockProjectsGateway
                .Setup(acg => acg.GetByStatuses(It.IsAny<int>(), It.IsAny<int>(), statuses))
                .Returns(() => new List<AcademyConversionProject> { project });

            mockEstablishmentsGateway
                .Setup(acg => acg.GetMisEstablishmentByUrn(It.IsAny<int>()))
                .Returns(() => new MisEstablishments());
            
            var useCase = new GetAcademyConversionProjectsByStatuses(
                mockProjectsGateway.Object,
                mockEstablishmentsGateway.Object);
            
            var result = useCase.Execute(page, count, statuses).ToList();
            
            result.Should().BeEquivalentTo(new List<AcademyConversionProjectResponse> { expected });
        }
        
        [Fact]
        public void GetAcademyConversionProjectByStatuses_ReturnsListOfProjectResponsesWithUkPrnAndLaestab_WhenAcademyConversionProjectsAndEstablishmentsAreFound()
        {
            const int page = 1;
            const int count = 50;
            const int urn = 1000;
            const string ukPrn = "12345";
            const int laestab = 67890;
            var statuses = new List<string> {"Status_One"};
            
            var project = _fixture.Build<AcademyConversionProject>()
                .With(acp => acp.SchoolName, "School")
                .With(acp => acp.ProjectStatus, "Status_One")
                .With(f => f.Urn, urn)
                .Create();
            
            var expected = AcademyConversionProjectResponseFactory.Create(project);
            expected.UkPrn = ukPrn;
            expected.Laestab = laestab;
            
            var mockProjectsGateway = new Mock<IAcademyConversionProjectGateway>();
            var mockEstablishmentsGateway = new Mock<IEstablishmentGateway>();

            mockProjectsGateway
                .Setup(acg => acg.GetByStatuses(It.IsAny<int>(), It.IsAny<int>(), statuses))
                .Returns(() => new List<AcademyConversionProject> { project });
            
            mockEstablishmentsGateway
                .Setup(acg => acg.GetMisEstablishmentByUrn(urn))
                .Returns(() => new MisEstablishments { Urn = urn, Laestab = laestab });

            mockEstablishmentsGateway
                .Setup(acg => acg.GetByUrn(urn))
                .Returns(() => new Establishment {Urn = urn, Ukprn = ukPrn});

            var useCase = new GetAcademyConversionProjectsByStatuses(
                mockProjectsGateway.Object,
                mockEstablishmentsGateway.Object);
            
            var result = useCase.Execute(page, count, statuses).ToList();

            result.Should().BeEquivalentTo(new List<AcademyConversionProjectResponse> { expected });
        }
    }
}