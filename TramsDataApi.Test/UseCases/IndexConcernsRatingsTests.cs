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
    public class IndexConcernsRatingsTests
    {
        [Fact]
        public void Execute_WhenConcernsRatingsAreNotFound_ReturnsEmptyList()
        {
            var mockGateway = new Mock<IConcernsRatingGateway>();
            var useCase = new IndexConcernsRatings(mockGateway.Object);

            mockGateway
                .Setup(g => g.GetRatings())
                .Returns(new List<ConcernsRating>());
            
            var result = useCase.Execute();

            result.Should().BeOfType<List<ConcernsRatingResponse>>();
            result.Should().BeEmpty();
        }

        [Fact]
        public void Execute_WhenConcernsRatingsAreFound_ReturnsListOfConcernsStatusResponses()
        {
            
            var mockGateway = new Mock<IConcernsRatingGateway>();
            var useCase = new IndexConcernsRatings(mockGateway.Object);

            var concernsRatings = Builder<ConcernsRating>.CreateListOfSize(20).Build();

            mockGateway
                .Setup(g => g.GetRatings())
                .Returns(concernsRatings);
            
            var result = useCase.Execute();
            
            result.Should().BeOfType<List<ConcernsRatingResponse>>();
            result.Count.Should().Be(concernsRatings.Count);
        }
    }
}