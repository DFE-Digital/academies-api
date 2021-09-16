using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
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
            var mockEstablishmentsGateway = new Mock<IEstablishmentGateway>();

            mockProjectsGateway
                .Setup(acg => acg.GetByStatuses(50, statuses))
                .Returns(() => new List<AcademyConversionJoinModel>());

            var useCase = new GetAcademyConversionProjectsByStatuses(
                mockProjectsGateway.Object, 
                mockTrustGateway.Object,
                mockEstablishmentsGateway.Object);
            
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
            
            var project = _fixture.Build<AcademyConversionJoinModel>().With(f => f.SchoolName, "school").Create();
            var expected = AcademyConversionProjectResponseFactory.Create(project);
            
            var mockProjectsGateway = new Mock<IAcademyConversionProjectGateway>();
            var mockTrustGateway = new Mock<ITrustGateway>();
            var mockEstablishmentsGateway = new Mock<IEstablishmentGateway>();

            mockProjectsGateway
                .Setup(acg => acg.GetByStatuses(50, statuses))
                .Returns(() => new List<AcademyConversionJoinModel> { project });

            mockEstablishmentsGateway
                .Setup(acg => acg.GetMisEstablishmentByUrn(It.IsAny<int>()))
                .Returns(() => new MisEstablishments());
            
            var useCase = new GetAcademyConversionProjectsByStatuses(
                mockProjectsGateway.Object, 
                mockTrustGateway.Object, 
                mockEstablishmentsGateway.Object);
            
            var result = useCase.Execute(request).ToList();
            
            result.Should().BeEquivalentTo(new List<AcademyConversionProjectResponse> { expected });
        }
        
        [Fact]
        public void GetAcademyConversionProjectByStatuses_ReturnsListOfProjectResponses_WhenAcademyTransferProjectsAreFound()
        {
            var statuses = new List<string> {"Status_One", "Status_Two"};
            var request = new GetAcademyConversionProjectsByStatusesRequest
            {
                Count = 50,
                Statuses = statuses
            };
            
            var project = _fixture.Build<AcademyConversionJoinModel>().With(f => f.SchoolName, "school").Create();
            var expected = AcademyConversionProjectResponseFactory.Create(project);
            
            var mockProjectsGateway = new Mock<IAcademyConversionProjectGateway>();
            var mockTrustGateway = new Mock<ITrustGateway>();
            var mockEstablishmentsGateway = new Mock<IEstablishmentGateway>();

            mockProjectsGateway
                .Setup(acg => acg.GetByStatuses(50, statuses))
                .Returns(() => new List<AcademyConversionJoinModel> { project });

            mockEstablishmentsGateway
                .Setup(acg => acg.GetMisEstablishmentByUrn(It.IsAny<int>()))
                .Returns(() => new MisEstablishments());
            
            var useCase = new GetAcademyConversionProjectsByStatuses(
                mockProjectsGateway.Object, 
                mockTrustGateway.Object, 
                mockEstablishmentsGateway.Object);
            
            var result = useCase.Execute(request).ToList();
            
            result.Should().BeEquivalentTo(new List<AcademyConversionProjectResponse> { expected });
        }
        
        [Fact]
        public void GetAcademyConversionProjectByStatuses_ReturnsListOfProjectResponsesWithUkPrnAndLaestab_WhenAcademyTransferProjectsAndEstablishmentsAreFound()
        {
            var urn = 1000;
            var ukPrn = "12345";
            var laestab = 67890;
            var statuses = new List<string> {"Status_One", "Status_Two"};
            var request = new GetAcademyConversionProjectsByStatusesRequest
            {
                Count = 50,
                Statuses = statuses
            };
            
            var project = _fixture.Build<AcademyConversionJoinModel>()
                .With(f => f.SchoolName, "school")
                .With(f => f.Urn, urn)
                .Create();
            
            var expected = AcademyConversionProjectResponseFactory.Create(project);
            expected.UkPrn = ukPrn;
            expected.Laestab = laestab;
            
            var mockProjectsGateway = new Mock<IAcademyConversionProjectGateway>();
            var mockTrustGateway = new Mock<ITrustGateway>();
            var mockEstablishmentsGateway = new Mock<IEstablishmentGateway>();

            mockProjectsGateway
                .Setup(acg => acg.GetByStatuses(50, statuses))
                .Returns(() => new List<AcademyConversionJoinModel> { project });

            mockEstablishmentsGateway
                .Setup(acg => acg.GetMisEstablishmentByUrn(urn))
                .Returns(() => new MisEstablishments { Urn = urn, Laestab = laestab });

            mockEstablishmentsGateway
                .Setup(acg => acg.GetByUrn(urn))
                .Returns(() => new Establishment {Urn = urn, Ukprn = ukPrn});

            var useCase = new GetAcademyConversionProjectsByStatuses(
                mockProjectsGateway.Object, 
                mockTrustGateway.Object, 
                mockEstablishmentsGateway.Object);
            
            var result = useCase.Execute(request).ToList();

            result.Should().BeEquivalentTo(new List<AcademyConversionProjectResponse> { expected });
        }
    }
}