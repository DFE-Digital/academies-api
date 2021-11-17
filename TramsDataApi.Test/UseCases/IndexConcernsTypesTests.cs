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
    public class IndexConcernsTypesTests
    {
        [Fact]
        public void Execute_WhenConcernsTypesAreNotFound_ReturnsEmptyList()
        {
            var mockGateway = new Mock<IConcernsTypeGateway>();
            var useCase = new IndexConcernsTypes(mockGateway.Object);

            mockGateway
                .Setup(g => g.GetTypes())
                .Returns(new List<ConcernsType>());
            
            var result = useCase.Execute();

            result.Should().BeOfType<List<ConcernsTypeResponse>>();
            result.Should().BeEmpty();
        }

        [Fact]
        public void Execute_WhenConcernsTypesAreFound_ReturnsListOfConcernsTypeResponses()
        {
            
            var mockGateway = new Mock<IConcernsTypeGateway>();
            var useCase = new IndexConcernsTypes(mockGateway.Object);

            var concernsTypes = Builder<ConcernsType>.CreateListOfSize(20).Build();

            mockGateway
                .Setup(g => g.GetTypes())
                .Returns(concernsTypes);
            
            var result = useCase.Execute();
            
            result.Should().BeOfType<List<ConcernsTypeResponse>>();
            result.Count.Should().Be(concernsTypes.Count);
        }
    }
}