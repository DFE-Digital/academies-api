using System.Collections.Generic;
using System.Threading.Tasks;
using AutoFixture;
using FluentAssertions;
using Moq;
using TramsDataApi.DatabaseModels;
using TramsDataApi.Factories;
using TramsDataApi.Gateways;
using TramsDataApi.ResponseModels.AcademyConversionProject;
using TramsDataApi.UseCases;
using Xunit;

namespace TramsDataApi.Test.UseCases
{
    public class SearchAcademyConversionProjectsTests
    {
        private readonly Fixture _fixture;
        private const string Title = "Title_One";
        string[] DeliveryOfficers = { "DO_One" };
        private const int Page = 1;
        private const int Count = 50;

        public SearchAcademyConversionProjectsTests()
        {
            _fixture = new Fixture();
        }
        
        [Fact]
        public async Task SearchAcademyConversionProjects_ReturnsEmptyList_WhenAcademyConversionProjectIsNotFound()
        {
            var statuses = new List<string> {"Status_One", "Status_Two"};

            var mockProjectsGateway = new Mock<IAcademyConversionProjectGateway>();
            var mockEstablishmentsGateway = new Mock<IEstablishmentGateway>();

            var useCase = new SearchAcademyConversionProjects(
                mockProjectsGateway.Object,
                mockEstablishmentsGateway.Object);

            var result = await useCase.Execute(Page, Count, statuses, 1001, Title, DeliveryOfficers);

            result.Results.Should().BeEquivalentTo(new List<AcademyConversionProjectResponse>());
        }
        
        [Fact]
        public async Task SearchAcademyConversionProjects_ReturnsListOfProjectResponses_WhenAcademyConversionProjectsAreFound()
        {
            var statuses = new List<string> {"ProjectStatus"};

            var project = _fixture.Build<AcademyConversionProject>()
                .With(f => f.SchoolName, "School")
                .With(f => f.ProjectStatus, "ProjectStatus")
                .Create();
            var expected = AcademyConversionProjectResponseFactory.Create(project);
            
            var mockProjectsGateway = new Mock<IAcademyConversionProjectGateway>();
            var mockEstablishmentsGateway = new Mock<IEstablishmentGateway>();
            
            mockProjectsGateway
                .Setup(acg => acg.SearchProjects(It.IsAny<int>(), It.IsAny<int>(), statuses, null, It.IsAny<string>(), It.IsAny<string[]>(), It.IsAny<IEnumerable<int?>>()))
                .Returns(Task.FromResult(new PagedResult<AcademyConversionProject>(new List<AcademyConversionProject> { project })));

            mockEstablishmentsGateway
                .Setup(acg => acg.GetMisEstablishmentByUrn(It.IsAny<int>()))
                .Returns(() => new MisEstablishments());
            
            var useCase = new SearchAcademyConversionProjects(
                mockProjectsGateway.Object,
                mockEstablishmentsGateway.Object);

            var result = await useCase.Execute(Page, Count, statuses, null, Title, DeliveryOfficers);
            
            result.Results.Should().BeEquivalentTo(new List<AcademyConversionProjectResponse> { expected });
        }

        [Fact]
        public async Task SearchAcademyConversionProjects_FilterByRegion_ReturnsListOfProjectResponses_WhenAcademyConversionProjectsAreFound()
        {
            var project = _fixture.Build<AcademyConversionProject>()
                .With(f => f.SchoolName, "School")
                .With(f => f.ProjectStatus, "ProjectStatus")
                .Create();
            var regions = new List<int?> { project.Urn };
            var expected = AcademyConversionProjectResponseFactory.Create(project);

            var mockProjectsGateway = new Mock<IAcademyConversionProjectGateway>();
            var mockEstablishmentsGateway = new Mock<IEstablishmentGateway>();

            mockProjectsGateway
                .Setup(acg => acg.SearchProjects(It.IsAny<int>(), It.IsAny<int>(), null, null, It.IsAny<string>(), It.IsAny<string[]>(), regions))
                .Returns(Task.FromResult(new PagedResult<AcademyConversionProject>(new List<AcademyConversionProject> { project })));

            mockEstablishmentsGateway
                .Setup(acg => acg.GetMisEstablishmentByUrn(It.IsAny<int>()))
                .Returns(() => new MisEstablishments());

            var useCase = new SearchAcademyConversionProjects(
                mockProjectsGateway.Object,
                mockEstablishmentsGateway.Object);

            var result = await useCase.Execute(Page, Count, null, null, Title, DeliveryOfficers, regions);

            result.Results.Should().BeEquivalentTo(new List<AcademyConversionProjectResponse> { expected });
        }

        [Fact]
        public async Task SearchAcademyConversionProjects_ReturnsListOfProjectResponsesWithUkPrnAndLaestab_WhenAcademyConversionProjectsAndEstablishmentsAreFound()
        {
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
                .Setup(acg => acg.SearchProjects(It.IsAny<int>(), It.IsAny<int>(), statuses, urn, It.IsAny<string>(), It.IsAny<string[]>(), It.IsAny<int?[]>()))
                .Returns(Task.FromResult(new PagedResult<AcademyConversionProject>(new List<AcademyConversionProject> { project })));
            
            mockEstablishmentsGateway
                .Setup(acg => acg.GetMisEstablishmentByUrn(urn))
                .Returns(() => new MisEstablishments { Urn = urn, Laestab = laestab });

            mockEstablishmentsGateway
                .Setup(acg => acg.GetByUrn(urn))
                .Returns(() => new Establishment {Urn = urn, Ukprn = ukPrn});

            var useCase = new SearchAcademyConversionProjects(
                mockProjectsGateway.Object,
                mockEstablishmentsGateway.Object);

            var result = await useCase.Execute(Page, Count, statuses, urn, Title, DeliveryOfficers);

            result.Results.Should().BeEquivalentTo(new List<AcademyConversionProjectResponse> { expected });
        }
    }
}