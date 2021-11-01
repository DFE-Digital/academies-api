using System;
using FizzWare.NBuilder;
using FluentAssertions;
using TramsDataApi.DatabaseModels;
using TramsDataApi.Factories;
using TramsDataApi.ResponseModels;
using Xunit;

namespace TramsDataApi.Test.Factories
{
    public class ConcernsCaseResponseFactoryTests
    {
        [Fact]
        public void ReturnsConcernsCaseResponse_WhenGivenAnConcernsCase()
        {
            var concernsCase = new ConcernsCase
            {
                Id = 123,
                CreatedAt = new DateTime(2021, 10,07),
                UpdatedAt = new DateTime(2021, 10,07),
                ReviewAt = new DateTime(2021, 10,07),
                ClosedAt = new DateTime(2021, 10,07),
                CreatedBy = "12345",
                Description = "Test description",
                CrmEnquiry = "9876",
                TrustUkprn = "7654893",
                ReasonAtReview = "34567",
                DeEscalation = new DateTime(2021, 10,07),
                Issue = "564378",
                CurrentStatus = "87960",
                CaseAim = "0129",
                DeEscalationPoint = "20394",
                NextSteps = "next steps",
                DirectionOfTravel = "Direction",
                Urn = "10988",
                ConcernsStatusUrn = "564329"
            };

            var expected = new ConcernsCaseResponse
            {
                CreatedAt = concernsCase.CreatedAt,
                UpdatedAt = concernsCase.UpdatedAt,
                ReviewedAt = concernsCase.ReviewAt,
                ClosedAt = concernsCase.ClosedAt,
                CreatedBy = concernsCase.CreatedBy,
                Description = concernsCase.Description,
                CrmEnquiry = concernsCase.CrmEnquiry,
                TrustUkprn = concernsCase.TrustUkprn,
                ReasonForReview = concernsCase.ReasonAtReview,
                DeEscalation = concernsCase.DeEscalation,
                Issue = concernsCase.Issue,
                CurrentStatus = concernsCase.CurrentStatus,
                CaseAim = concernsCase.CaseAim,
                DeEscalationPoint = concernsCase.DeEscalationPoint,
                NextSteps = concernsCase.NextSteps,
                DirectionOfTravel = concernsCase.DirectionOfTravel,
                Urn = concernsCase.Urn,
                Status = concernsCase.ConcernsStatusUrn
            };

            var result = ConcernsCaseResponseFactory.Create(concernsCase);
            result.Should().BeEquivalentTo(expected);

        }
    }
}