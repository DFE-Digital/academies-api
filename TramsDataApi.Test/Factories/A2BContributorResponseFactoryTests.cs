using FluentAssertions;
using FizzWare.NBuilder;
using TramsDataApi.DatabaseModels;
using TramsDataApi.Factories;
using TramsDataApi.ResponseModels.ApplyToBecome;
using Xunit;

namespace TramsDataApi.Test.Factories
{
    public class A2BContributorResponseFactoryTests
    {
        [Fact]
        public void Create_ReturnsNull_WhenA2BContributorIsNull()
        {
            var response = A2BContributorResponseFactory.Create(null);

            response.Should().BeNull();
        }

        [Fact]
        public void Create_ReturnsExpectedA2BContributorResponse_WhenA2BContributorIsProvided()
        {
            var contributor = Builder<A2BContributor>
                .CreateNew()
                .Build();

            var expectedResponse = new A2BContributorResponse
            {
                ContributorUserId = contributor.ContributorUserId,
                ApplicationTypeId = contributor.ApplicationTypeId,
                ContributorAppIdTest = contributor.ContributorAppIdTest,
                ContributorUserName = contributor.ContributorUserName
            };
                
            var response = A2BContributorResponseFactory.Create(contributor);

            response.Should().BeEquivalentTo(expectedResponse);
        }
    }
}