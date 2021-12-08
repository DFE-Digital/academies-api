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

            var concernsCase = Builder<ConcernsCase>.CreateNew().Build();
            var concernsType = Builder<ConcernsType>.CreateNew().Build();
            var concernsRating = Builder<ConcernsRating>.CreateNew().Build();
            
            var recordRequest = new ConcernsRecordRequest
            {
                CreatedAt = new DateTime(2021, 05, 14),
                UpdatedAt = new DateTime(2021, 05, 14),
                ReviewAt = new DateTime(2021, 07, 05),
                ClosedAt = new DateTime(2021, 07, 05),
                Name = "Test concerns record",
                Description = "Test concerns record desc",
                Reason = "Test concern",
                CaseUrn = 1,
                TypeUrn = 2,
                RatingUrn = 3,
                Primary = true,
                StatusUrn = 1
            };

            var expected = new ConcernsRecord
            {
                CreatedAt = recordRequest.CreatedAt,
                UpdatedAt = recordRequest.UpdatedAt,
                ReviewAt = recordRequest.ReviewAt,
                ClosedAt = recordRequest.ClosedAt,
                Name = recordRequest.Name,
                Description = recordRequest.Description,
                Reason = recordRequest.Reason,
                ConcernsCase = concernsCase,
                ConcernsType = concernsType,
                ConcernsRating = concernsRating,
                StatusUrn = recordRequest.StatusUrn
            };

            var result = ConcernsRecordFactory.Create(recordRequest, concernsCase, concernsType, concernsRating);
            result.Should().BeEquivalentTo(expected);
        }
    }
}