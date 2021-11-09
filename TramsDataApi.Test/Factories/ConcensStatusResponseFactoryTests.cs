using System;
using FluentAssertions;
using TramsDataApi.DatabaseModels;
using TramsDataApi.Factories;
using TramsDataApi.ResponseModels;
using Xunit;

namespace TramsDataApi.Test.Factories
{
    public class ConcernsStatusResponseFactoryTests
    {
        [Fact]
        public void ReturnsConcernsStatusResponse_WhenGivenAnConcernsStatus()
        {

            var concernsStatus = new ConcernsStatus
            {
                Id = 456,
                Name = "Test concerns status",
                CreatedAt = new DateTime(2021, 10,07),
                UpdatedAt = new DateTime(2021, 10,07),
                Urn = 789
            };

            var expected = new ConcernsStatusResponse
            {
                Name = concernsStatus.Name,
                CreatedAt = concernsStatus.CreatedAt,
                UpdatedAt = concernsStatus.UpdatedAt,
                Urn = concernsStatus.Urn
            };

            var result = ConcernsStatusResponseFactory.Create(concernsStatus);
            result.Should().BeEquivalentTo(expected);
        }
    }
}