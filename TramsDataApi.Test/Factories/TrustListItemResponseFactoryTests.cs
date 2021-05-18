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
    public class TrustListItemResponseFactoryTests
    {
        [Fact]
        public void TrustListItemResponseFactory_CreatesTrustListItemResponse_FromGroupLink()
        {
            var group = Builder<GroupLink>.CreateNew().Build();
            var expected = new TrustListItemResponse
            {
                Urn = group.Urn,
                GroupName = group.GroupName,
                CompaniesHouseNumber = group.CompaniesHouseNumber,
                Establishments = new List<EstablishmentSummaryResponse>()
            };
            var result = TrustListItemResponseFactory.Create(group, new List<Establishment>());
            result.Should().BeEquivalentTo(expected);
        }

        [Fact]
        public void TrustListItemResponseFactory_ReturnsNull_WhenGroupLinkIsNull()
        {
            TrustListItemResponseFactory.Create(null, new List<Establishment>()).Should().BeNull();
        }

        [Fact]
        public void TrustListItemResponseFactory_ReturnsTrustListItemResponse_WithEstablishmentListItemResponses()
        {
            var group = Builder<GroupLink>.CreateNew().Build();
            var establishments = Builder<Establishment>.CreateListOfSize(5).Build();

            var expected = new TrustListItemResponse
            {
                Urn = group.Urn,
                GroupName = group.GroupName,
                CompaniesHouseNumber = group.CompaniesHouseNumber,
                Establishments = establishments
                    .Select(e => new EstablishmentSummaryResponse { Name = e.EstablishmentName, Urn = e.Urn.ToString() })
                    .ToList()
            };

            var result = TrustListItemResponseFactory.Create(group, establishments);
            result.Should().BeEquivalentTo(expected);
        }
    }
}