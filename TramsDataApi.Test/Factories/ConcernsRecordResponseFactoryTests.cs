using System;
using FluentAssertions;
using TramsDataApi.DatabaseModels;
using TramsDataApi.Factories;
using TramsDataApi.ResponseModels;
using Xunit;

namespace TramsDataApi.Test.Factories
{
    public class ConcernsRecordResponseFactoryTests
    {
        [Fact]
        public void ReturnsConcernsRecordResponse_WhenGivenAnConcernsRecord()
        {
            var concernsRecord = new ConcernsRecord
            {
                Id = 1,
                CreatedAt = new DateTime(2021, 05, 14),
                UpdatedAt = new DateTime(2021, 07, 20),
                ReviewAt = new DateTime(2021, 06, 19),
                ClosedAt = new DateTime(2021, 12, 03),
                Name = "Test record",
                Description = "Test record desc",
                Reason = "Test reason",
                CaseId = 2,
                TypeId = 3,
                RatingId = 5,
                Primary = false,
                Urn = "4",
                StatusUrn = 3
            };

            var expected = new ConcernsRecordResponse
            {
                CreatedAt = concernsRecord.CreatedAt,
                UpdatedAt = concernsRecord.UpdatedAt,
                ReviewAt = concernsRecord.ReviewAt,
                ClosedAt = concernsRecord.ClosedAt,
                Name = concernsRecord.Name,
                Description = concernsRecord.Description,
                Reason = concernsRecord.Reason,
                CaseId = concernsRecord.CaseId,
                TypeId = concernsRecord.TypeId,
                RatingId = concernsRecord.RatingId,
                Primary = concernsRecord.Primary,
                Urn = concernsRecord.Urn,
                StatusUrn = concernsRecord.StatusUrn
            };

            var result = ConcernsRecordResponseFactory.Create(concernsRecord);
            result.Should().BeEquivalentTo(expected);
        }
    }
}