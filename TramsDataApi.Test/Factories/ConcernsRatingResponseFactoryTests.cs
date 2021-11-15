using System;
using FluentAssertions;
using TramsDataApi.DatabaseModels;
using TramsDataApi.Factories;
using TramsDataApi.ResponseModels;
using Xunit;

namespace TramsDataApi.Test.Factories
{
    public class ConcernsRatingResponseFactoryTests
    {
        [Fact]
        public void ReturnsConcernsRatingResponse_WhenGivenAnConcernsRating()
        {

            var concernsRating = new ConcernsRating
            {
                Id = 5,
                Name = "Test concerns rating",
                CreatedAt = new DateTime(2021, 10,07),
                UpdatedAt = new DateTime(2021, 10,07),
                Urn = 789
            };

            var expected = new ConcernsRatingResponse
            {
                Name = concernsRating.Name,
                CreatedAt = concernsRating.CreatedAt,
                UpdatedAt = concernsRating.UpdatedAt,
                Urn = concernsRating.Urn
            };

            var result = ConcernsRatingResponseFactory.Create(concernsRating);
            result.Should().BeEquivalentTo(expected);
        }
    }
}