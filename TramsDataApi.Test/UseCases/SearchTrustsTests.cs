using System.Collections;
using System.Collections.Generic;
using System.Linq;
using FizzWare.NBuilder;
using FluentAssertions;
using Moq;
using TramsDataApi.DatabaseModels;
using TramsDataApi.Factories;
using TramsDataApi.Gateways;
using TramsDataApi.ResponseModels;
using TramsDataApi.UseCases;
using Xunit;

namespace TramsDataApi.Test.UseCases
{
    public class SearchTrustsTests
    {
        [Fact]
        public void SearchTrusts_ReturnsEmptyList_WhenNoTrustsFound()
        {
            var groupName = "groupName";
            var urn = "urn";
            var companiesHouseNumber = "companiesHouseNumber";
            
            var gateway = new Mock<ITrustGateway>();
            gateway.Setup(g => g.SearchGroups(groupName, urn, companiesHouseNumber))
                .Returns(new List<GroupLink>());

            var useCase = new SearchTrusts(gateway.Object, new Mock<IEstablishmentGateway>().Object);
            var result = useCase.Execute(groupName, urn, companiesHouseNumber);

            result.Should().BeEquivalentTo(new List<TrustListItemResponse>());
        }

        [Fact]
        public void SearchTrusts_ReturnsListOfTrustListItemResponses_WhenTrustsFound()
        {
            var groupName = "groupName";

            var expectedTrusts = Builder<GroupLink>.CreateListOfSize(10)
                .All()
                .With(g => g.GroupName = groupName)
                .Build();

            var trustsGateway = new Mock<ITrustGateway>();
            var establishmentsGateway = new Mock<IEstablishmentGateway>();
            
            trustsGateway.Setup(g => g.SearchGroups(groupName, null, null))
                .Returns(expectedTrusts);
            
            establishmentsGateway.Setup(g => g.GetByTrustUid(It.IsAny<string>()))
                .Returns(new List<Establishment>());

            var expected = expectedTrusts.
                Select(e => TrustListItemResponseFactory.Create(e, new List<Establishment>()))
                .ToList();
            
            var searchTrusts = new SearchTrusts(trustsGateway.Object, establishmentsGateway.Object);
            var result = searchTrusts.Execute(groupName, null, null);

            result.Should().BeEquivalentTo(expected);
        }

        [Fact]
        public void SearchTrusts_ShouldGetTrustsWithEstablishments_WhenTrustsAndEstablishmentsAreFound()
        {
            var urn = "mockurn";

            var expectedTrust = Builder<GroupLink>
                .CreateNew()
                .With(g => g.Urn = urn)
                .Build();

            var expectedEstablishments = Builder<Establishment>.CreateListOfSize(5).All()
                .With(e => e.TrustsCode = expectedTrust.GroupUid)
                .Build();

            var trustGateway = new Mock<ITrustGateway>();
            var establishmentGateway = new Mock<IEstablishmentGateway>();

            trustGateway.Setup(g => g.SearchGroups(null, urn, null))
                .Returns(new List<GroupLink> {expectedTrust});
            establishmentGateway.Setup(g => g.GetByTrustUid(expectedTrust.GroupUid))
                .Returns(expectedEstablishments);

            var expected = new List<TrustListItemResponse>
            {
                TrustListItemResponseFactory.Create(expectedTrust, expectedEstablishments)
            };

            var searchTrusts = new SearchTrusts(trustGateway.Object, establishmentGateway.Object);
            var result = searchTrusts.Execute(null, urn, null);
            result.Should().BeEquivalentTo(expected);
        }
    }
}