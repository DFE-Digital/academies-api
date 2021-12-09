using FluentAssertions;
using FizzWare.NBuilder;
using TramsDataApi.DatabaseModels;
using TramsDataApi.Factories;
using TramsDataApi.RequestModels.ApplyToBecome;
using Xunit;

namespace TramsDataApi.Test.Factories
{
    public class A2BContributorFactoryTests
    {
        [Fact]
        public void Create_ReturnsNull_WhenA2BContributorIsNull()
        {
            var response = A2BContributorFactory.Create(null);

            response.Should().BeNull();
        }

        [Fact]
        public void Create_ReturnsExpectedA2BContributor_WhenA2BContributorResponseIsProvided()
        {
            var contributorCreateRequest = Builder<A2BContributorCreateRequest>
                .CreateNew()
                .Build();

            var expectedStatus = new A2BContributor
            {
                ContributorUserId = contributorCreateRequest.ContributorUserId,
                ApplicationTypeId = contributorCreateRequest.ApplicationTypeId,
                ContributorAppIdTest =contributorCreateRequest.ContributorAppIdTest,
                ContributorUserName = contributorCreateRequest.ContributorUserName
            };
                
            var response = A2BContributorFactory.Create(contributorCreateRequest);

            response.Should().BeEquivalentTo(expectedStatus);
        }
    }
}