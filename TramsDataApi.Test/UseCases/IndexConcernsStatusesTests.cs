using System.Collections.Generic;
using FizzWare.NBuilder;
using FluentAssertions;
using Moq;
using TramsDataApi.DatabaseModels;
using TramsDataApi.Gateways;
using TramsDataApi.ResponseModels;
using TramsDataApi.UseCases;
using Xunit;

namespace TramsDataApi.Test.UseCases
{
    public class IndexConcernsStatusesTests
    {
        [Fact]
        public void Execute_WhenConcernsStatusesAreNotFound_ReturnsEmptyList()
        {
            var mockGateway = new Mock<IConcernsStatusGateway>();
            var useCase = new IndexConcernsStatuses(mockGateway.Object);

            mockGateway
                .Setup(g => g.GetStatuses())
                .Returns(new List<ConcernsStatus>());
            
            var result = useCase.Execute();

            result.Should().BeOfType<List<ConcernsStatusResponse>>();
            result.Should().BeEmpty();
        }

        [Fact]
        public void Execute_WhenConcernsStatusesAreFound_ReturnsListOfConcernsStatusResponses()
        {
            
            var mockGateway = new Mock<IConcernsStatusGateway>();
            var useCase = new IndexConcernsStatuses(mockGateway.Object);

            var concernsStatuses = Builder<ConcernsStatus>.CreateListOfSize(20).Build();

            mockGateway
                .Setup(g => g.GetStatuses())
                .Returns(concernsStatuses);
            
            var result = useCase.Execute();
            
            result.Should().BeOfType<List<ConcernsStatusResponse>>();
            result.Count.Should().Be(concernsStatuses.Count);
        }
    }
}