using System.Collections.Generic;
using System.Linq;
using FizzWare.NBuilder;
using FluentAssertions;
using TramsDataApi.DatabaseModels;
using TramsDataApi.Factories;
using TramsDataApi.ResponseModels;
using Xunit;

namespace TramsDataApi.Test.Factories
{
    public class TrustSummaryResponseFactoryTests
    {
        [Fact]
        public void TrustSummaryResponseFactory_CreatesTrustSummaryResponse_FromGroupLink()
        {
            var group = Builder<Group>.CreateNew().Build();
            var expected = new TrustSummaryResponse
            {
                Ukprn = group.Ukprn,
                GroupName = group.GroupName,
                CompaniesHouseNumber = group.CompaniesHouseNumber,
                Establishments = new List<EstablishmentSummaryResponse>()
            };
            var result = TrustSummaryResponseFactory.Create(group, new List<Establishment>());
            result.Should().BeEquivalentTo(expected);
        }

        [Fact]
        public void TrustSummaryResponseFactory_ReturnsNull_WhenGroupIsNull()
        {
            TrustSummaryResponseFactory.Create((Group) null, new List<Establishment>()).Should().BeNull();
        }

        [Fact]
        public void TrustSummaryResponseFactory_ReturnsTrustSummaryResponse_WithEstablishmentListItemResponses()
        {
            var group = Builder<Group>.CreateNew().Build();
            var establishments = Builder<Establishment>.CreateListOfSize(5).Build();

            var expected = new TrustSummaryResponse
            {
                Ukprn = group.Ukprn,
                GroupName = group.GroupName,
                CompaniesHouseNumber = group.CompaniesHouseNumber,
                Establishments = establishments
                    .Select(e => new EstablishmentSummaryResponse { Name = e.EstablishmentName, Urn = e.Urn.ToString(), Ukprn = e.Ukprn })
                    .ToList()
            };

            var result = TrustSummaryResponseFactory.Create(group, establishments);
            result.Should().BeEquivalentTo(expected);
        }
    }
}