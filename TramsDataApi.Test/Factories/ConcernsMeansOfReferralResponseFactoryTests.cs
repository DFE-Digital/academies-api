using System;
using FluentAssertions;
using TramsDataApi.DatabaseModels;
using TramsDataApi.Factories;
using TramsDataApi.ResponseModels;
using Xunit;

namespace TramsDataApi.Test.Factories
{
    public class ConcernsMeansOfReferralResponseFactoryTests
    {
        [Fact]
        public void ReturnsConcernsMeansOfReferralResponse_WhenGivenAnConcernsMeansOfReferral()
        {
            var concernMeansOfReferral = new ConcernsMeansOfReferral
            {
                Id = 2,
                Name = "test means of referral",
                Description = "some description of the means of referral",
                CreatedAt = new DateTime(2022, 07,27),
                UpdatedAt = new DateTime(2022, 07,28),
                Urn = 123,
            };

            var expected = new ConcernsMeansOfReferralResponse
            {
                Name = concernMeansOfReferral.Name,
                Description = concernMeansOfReferral.Description,
                CreatedAt = concernMeansOfReferral.CreatedAt,
                UpdatedAt = concernMeansOfReferral.UpdatedAt,
                Urn = concernMeansOfReferral.Urn
            };

            var result = ConcernsMeansOfReferralResponseFactory.Create(concernMeansOfReferral);
            result.Should().BeEquivalentTo(expected);
        }
    }
}