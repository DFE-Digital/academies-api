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
    public class IndexConcernsMeansOfReferralTests
    {
        [Fact]
        public void Execute_WhenConcernsMeansOfReferralAreNotFound_ReturnsEmptyList()
        {
            // Arrange
            var mockGateway = new Mock<IConcernsMeansOfReferralGateway>();
            var useCase = new IndexConcernsMeansOfReferrals(mockGateway.Object);

            mockGateway
                .Setup(g => g.GetMeansOfReferrals())
                .Returns(new List<ConcernsMeansOfReferral>());
            
            // Act
            var result = useCase.Execute();

            // Assert
            result.Should().BeOfType<List<ConcernsMeansOfReferralResponse>>();
            result.Should().BeEmpty();
        }

        [Fact]
        public void Execute_WhenConcernsMeansOfReferralAreFound_ReturnsListOfConcernsMeansOfReferralResponses()
        {
            // Arrange
            var mockGateway = new Mock<IConcernsMeansOfReferralGateway>();
            var useCase = new IndexConcernsMeansOfReferrals(mockGateway.Object);

            var concernsMeansOfReferral = Builder<ConcernsMeansOfReferral>.CreateListOfSize(20).Build();

            mockGateway
                .Setup(g => g.GetMeansOfReferrals())
                .Returns(concernsMeansOfReferral);
            
            // Act
            var result = useCase.Execute();
            
            // Assert
            result.Should().BeOfType<List<ConcernsMeansOfReferralResponse>>();
            result.Count.Should().Be(concernsMeansOfReferral.Count);
        }
    }
}