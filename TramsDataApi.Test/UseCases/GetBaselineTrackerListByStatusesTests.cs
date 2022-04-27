using AutoFixture;
using FluentAssertions;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TramsDataApi.DatabaseModels;
using TramsDataApi.Factories;
using TramsDataApi.Gateways;
using TramsDataApi.RequestModels;
using TramsDataApi.ResponseModels;
using TramsDataApi.UseCases;
using Xunit;

namespace TramsDataApi.Test.UseCases
{
    public class GetBaselineTrackerListByStatusesTests
    {
        private readonly Fixture _fixture;

        public GetBaselineTrackerListByStatusesTests()
        {
            _fixture = new Fixture();
        }

        [Fact]
        public void GetByStatuses_ReturnsEmptyList_WhenIsNotFound()
        {
            var statuses = new List<string> { "Status_One", "Status_Two" };
            var request = new GetAllBaselineTrackerRequestByStatusesRequest
            {
                Page = 1,
                Count = 50,
                Statuses = statuses
            };

            var mockTrustGateway = new Mock<ITrustGateway>();
            var mockEstablishmentsGateway = new Mock<IEstablishmentGateway>();
            var mockIfdPipelineGateway = new Mock<IIfdPipelineGateway>();

            mockIfdPipelineGateway
                .Setup(ifd => ifd.GetPipelineProjectsByStatus(1, 50, statuses))
                .Returns(() => new List<IfdPipeline>());

            var useCase = new GetBaselineTrackerListByStatuses(
                mockTrustGateway.Object,
                mockEstablishmentsGateway.Object,
                mockIfdPipelineGateway.Object);

            var result = useCase.Execute(request).ToList();

            result.Should().BeEquivalentTo(new List<BaselineTrackerResponse>());
        }

        [Fact]
        public void GetBaselineTrackerProjects_ReturnsListOfProjectResponses_WhenBaselineTrackerProjectsAreFound()
        {
            var statuses = new List<string> { "Status_One", "Status_Two" };
            var request = new GetAllBaselineTrackerRequestByStatusesRequest
            {
                Page = 1,
                Count = 50,
                Statuses = statuses
            };

            var project = _fixture.Build<IfdPipeline>().Create();
            project.GeneralDetailsUrn = "12";

            var expectedProject = BaselineTrackerResponseFactory.Create(project);

            var mockGateway = new Mock<IIfdPipelineGateway>();
            mockGateway.Setup(x => x.GetPipelineProjectsByStatus(1, 50, statuses)).Returns(new List<IfdPipeline> { project });

            var useCase = new GetBaselineTrackerListByStatuses(
                new Mock<ITrustGateway>().Object,
                new Mock<IEstablishmentGateway>().Object,
                mockGateway.Object);

            var result = useCase.Execute(request).ToList();

            result.Should().BeEquivalentTo(new List<BaselineTrackerResponse> { expectedProject });
        }
    }
}
