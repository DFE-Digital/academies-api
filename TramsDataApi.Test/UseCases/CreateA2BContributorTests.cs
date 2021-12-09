using FizzWare.NBuilder;
using FluentAssertions;
using Moq;
using TramsDataApi.DatabaseModels;
using TramsDataApi.Gateways;
using TramsDataApi.RequestModels.ApplyToBecome;
using TramsDataApi.UseCases;
using Xunit;

namespace TramsDataApi.Test.UseCases
{
    
    public class CreateA2BContributorTests
    {
        [Fact]
        public void CreateA2BContributor_ShouldCreateAndReturnA2BContributor_WhenGivenA2BContributor()
        {
            var contributorCreateRequest = Builder<A2BContributorCreateRequest>.CreateNew().Build();

            var expectedStatus = new A2BContributor
            {
                ContributorUserId = contributorCreateRequest.ContributorUserId,
                ApplicationTypeId = contributorCreateRequest.ApplicationTypeId,
                ContributorAppIdTest = contributorCreateRequest.ContributorAppIdTest,
                ContributorUserName = contributorCreateRequest.ContributorUserName
            };
            
            var mockGateway = new Mock<IA2BContributorGateway>();
            
            mockGateway.Setup(g => g.CreateA2BContributor(It.IsAny<A2BContributor>())).Returns(expectedStatus);
            
            var useCase = new CreateA2BContributor(mockGateway.Object);
            
            var result = useCase.Execute(contributorCreateRequest);

            result.Should().NotBeNull();
            result.Should().BeEquivalentTo(expectedStatus);
        }
    }
}