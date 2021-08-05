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
            var ukprn = "urn";
            var companiesHouseNumber = "companiesHouseNumber";
            
            var gateway = new Mock<ITrustGateway>();
            gateway.Setup(g => g.SearchGroups(groupName, ukprn, companiesHouseNumber, 1))
                .Returns(new List<Group>());

            var useCase = new SearchTrusts(gateway.Object, new Mock<IEstablishmentGateway>().Object);
            var result = useCase.Execute(groupName, ukprn, companiesHouseNumber, 1);

            result.Should().BeEquivalentTo(new List<TrustSummaryResponse>());
        }

        [Fact]
        public void SearchTrusts_ReturnsListOfTrustSummaryResponses_WhenTrustsFound()
        {
            var groupName = "groupName";

            var expectedTrusts = Builder<Group>.CreateListOfSize(10)
                .TheFirst(5)
                .With(g => g.GroupType = "Trust")
                .TheNext(3)
                .With(g => g.GroupType = "Single-academy trust")
                .TheRest()
                .With(g => g.GroupType = "Multi-academy trust")
                .All()
                .With(g => g.GroupName = groupName)
                .Build();

            var trustsGateway = new Mock<ITrustGateway>();
            var establishmentsGateway = new Mock<IEstablishmentGateway>();
            
            trustsGateway.Setup(g => g.SearchGroups(groupName, null, null, 1))
                .Returns(expectedTrusts);
            
            establishmentsGateway.Setup(g => g.GetByTrustUid(It.IsAny<string>()))
                .Returns(new List<Establishment>());

            var expected = expectedTrusts.
                Select(e => TrustSummaryResponseFactory.Create(e, new List<Establishment>()))
                .ToList();
            
            var searchTrusts = new SearchTrusts(trustsGateway.Object, establishmentsGateway.Object);
            var result = searchTrusts.Execute(groupName, null, null, 1);

            result.Should().BeEquivalentTo(expected);
        }

        [Fact]
        public void SearchTrusts_ShouldGetTrustsWithEstablishments_WhenTrustsAndEstablishmentsAreFound()
        {
            var ukprn = "mockurn";

            var expectedTrust = Builder<Group>
                .CreateNew()
                .With(g => g.Ukprn = ukprn)
                .Build();

            var expectedEstablishments = Builder<Establishment>.CreateListOfSize(5).All()
                .With(e => e.TrustsCode = expectedTrust.GroupUid)
                .Build();

            var trustGateway = new Mock<ITrustGateway>();
            var establishmentGateway = new Mock<IEstablishmentGateway>();

            trustGateway.Setup(g => g.SearchGroups(null, ukprn, null, 1))
                .Returns(new List<Group> {expectedTrust});
            establishmentGateway.Setup(g => g.GetByTrustUid(expectedTrust.GroupUid))
                .Returns(expectedEstablishments);

            var expected = new List<TrustSummaryResponse>
            {
                TrustSummaryResponseFactory.Create(expectedTrust, expectedEstablishments)
            };

            var searchTrusts = new SearchTrusts(trustGateway.Object, establishmentGateway.Object);
            var result = searchTrusts.Execute(null, ukprn, null, 1);
            result.Should().BeEquivalentTo(expected);
        }
    }
}