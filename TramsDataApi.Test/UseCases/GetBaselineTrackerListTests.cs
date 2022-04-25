using AutoFixture;
using FluentAssertions;
using Moq;
using System.Collections.Generic;
using System.Linq;
using TramsDataApi.DatabaseModels;
using TramsDataApi.Factories;
using TramsDataApi.Gateways;
using TramsDataApi.RequestModels;
using TramsDataApi.ResponseModels;
using TramsDataApi.UseCases;
using Xunit;

namespace TramsDataApi.Test.UseCases
{
    public class GetBaselineTrackerListTests
    {
        private readonly Fixture _fixture;

        public GetBaselineTrackerListTests()
        {
            _fixture = new Fixture();
        }

        [Fact]
        public void GetBaselineTrackerProjects_ReturnsEmptyList_WhenBaselineTrackerIsNotFound()
        {
            var request = new GetAllBaselineTrackerRequest { Count = 50 };

            var useCase = new GetBaselineTrackerList(
                new Mock<ITrustGateway>().Object,
                new Mock<IEstablishmentGateway>().Object,
                new Mock<IIfdPipelineGateway>().Object);

            var result = useCase.Execute(request).ToList();

            result.Should().BeEquivalentTo(new List<BaselineTrackerResponse>());
        }

        [Fact]
        public void GetBaselineTrackerProjects_ReturnsListOfProjectResponses_WhenBaselineTrackerProjectsAreFound()
        {
            var request = new GetAllBaselineTrackerRequest { Page = 1, Count = 50 };

            var project = _fixture.Build<IfdPipeline>().Create();
            project.GeneralDetailsUrn = "12";

            var expectedProject = BaselineTrackerResponseFactory.Create(project);

            var mockGateway = new Mock<IIfdPipelineGateway>();
            mockGateway.Setup(x => x.GetPipelineProjects(1, 50)).Returns(new List<IfdPipeline> { project });

            var useCase = new GetBaselineTrackerList(
                new Mock<ITrustGateway>().Object,
                new Mock<IEstablishmentGateway>().Object,
                mockGateway.Object);

            var result = useCase.Execute(request).ToList();

            result.Should().BeEquivalentTo(new List<BaselineTrackerResponse> { expectedProject });
        }
    }
}
