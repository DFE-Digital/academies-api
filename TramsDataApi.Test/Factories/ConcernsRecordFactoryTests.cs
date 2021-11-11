using System;
using FizzWare.NBuilder;
using FluentAssertions;
using TramsDataApi.DatabaseModels;
using TramsDataApi.Factories;
using TramsDataApi.RequestModels;
using Xunit;

namespace TramsDataApi.Test.Factories
{
    public class ConcernsRecordFactoryTests
    {
        [Fact]
        public void ReturnsConcernsRecord_WhenGivenAnConcernsRecordRequest()
        {
            var recordRequest = new ConcernsRecordRequest
            {
                CreatedAt = new DateTime(2021, 05, 14),
                UpdatedAt = new DateTime(2021, 05, 14),
                ReviewAt = new DateTime(2021, 07, 05),
                ClosedAt = new DateTime(2021, 07, 05),
                Name = "Test concerns record",
                Description = "Test concerns record desc",
                Reason = "Test concern",
                CaseId = 1,
                TypeId = 2,
                RatingId = 3,
                Primary = true,
                StatusUrn = 1
            };
            
            var status = Builder<ConcernsStatus>.CreateNew().Build();

            var expected = new ConcernsRecord
            {
                CreatedAt = recordRequest.CreatedAt,
                UpdatedAt = recordRequest.UpdatedAt,
                ReviewAt = recordRequest.ReviewAt,
                ClosedAt = recordRequest.ClosedAt,
                Name = recordRequest.Name,
                Description = recordRequest.Description,
                Reason = recordRequest.Reason,
                CaseId = recordRequest.CaseId,
                TypeId = recordRequest.TypeId,
                RatingId = recordRequest.RatingId,
                Primary = recordRequest.Primary,
                Status = status
            };

            var result = ConcernsRecordFactory.Create(recordRequest, status);
            result.Should().BeEquivalentTo(expected);
        }
    }
}