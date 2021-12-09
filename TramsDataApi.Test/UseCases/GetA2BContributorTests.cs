using FizzWare.NBuilder;
using FluentAssertions;
using Moq;
using TramsDataApi.DatabaseModels;
using TramsDataApi.Factories;
using TramsDataApi.Gateways;
using TramsDataApi.UseCases;
using Xunit;

namespace TramsDataApi.Test.UseCases
{
    public class GetA2BContributorTests
    {
        [Fact]
        public void GetA2BContributor_ShouldReturnNull_WhenContributorIdIsNotFound()
        {
            const string contributorId = "10001";
            var mockGateway = new Mock<IA2BContributorGateway>();

            mockGateway.Setup(g => g.GetByContributorId(contributorId));
           
            var useCase = new GetA2BContributor(mockGateway.Object);
            var result = useCase.Execute(contributorId);

            result.Should().BeNull();
        }

        [Fact]
        public void GetA2BContributor_ShouldReturnA2BContributorResponse_WhenContributorIdIsFound()
        {
            const string contributorId = "10001";
            var mockGateway = new Mock<IA2BContributorGateway>();
            var contributor = Builder<A2BContributor>
                .CreateNew()
                .With(a => a.ContributorUserId == contributorId)
                .Build();

           
            var expected = A2BContributorResponseFactory.Create(contributor);

            mockGateway.Setup(g => g.GetByContributorId(contributorId)).Returns(contributor);
            
            var useCase = new GetA2BContributor(mockGateway.Object);
            var result = useCase.Execute(contributorId);
            
            result.Should().BeEquivalentTo(expected);
        }
    }
}