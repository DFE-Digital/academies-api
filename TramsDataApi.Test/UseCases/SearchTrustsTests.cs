using System;
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
            gateway.Setup(g => g.SearchGroups(1, 10, groupName, ukprn, companiesHouseNumber))
                .Returns((new List<Group>(), 0));

            var useCase = new SearchTrusts(gateway.Object, new Mock<IEstablishmentGateway>().Object);
            var (result, _) = useCase.Execute(1, 10, groupName, ukprn, companiesHouseNumber);

            result.Should().BeEquivalentTo(new List<TrustSummaryResponse>());
        }

        private IList<Group> Test(string groupName)
        {

            return Builder<Group>.CreateListOfSize(10)
                .TheFirst(5)
                .With(g => g.GroupType = "Trust")
                .TheNext(3)
                .With(g => g.GroupType = "Single-academy trust")
                .TheRest()
                .With(g => g.GroupType = "Multi-academy trust")
                .All()
                .With(g => g.GroupName = groupName)
                .Build();
        }

        [Fact]
        public void SearchTrusts_ReturnsListOfTrustSummaryResponses_WhenTrustsFound()
        {
            var groupName = "groupName";

            var expectedTrusts = Test(groupName);

            var trustsGateway = new Mock<ITrustGateway>();
            var establishmentsGateway = new Mock<IEstablishmentGateway>();

            trustsGateway.Setup(g => g.SearchGroups(1, 10, groupName, string.Empty, string.Empty))
                .Returns((expectedTrusts, expectedTrusts.Count));

            trustsGateway.Setup(m => m.GetIfdTrustsByTrustRef(It.IsAny<string[]>()))
                .Returns(new List<Trust>());
            
            establishmentsGateway.Setup(g => g.GetByTrustUids(It.IsAny<string[]>()))
                .Returns(new List<Establishment>());

            var expected = expectedTrusts.
                Select(e => TrustSummaryResponseFactory.Create(e, new List<Establishment>(), null))
                .ToList();
            
            var searchTrusts = new SearchTrusts(trustsGateway.Object, establishmentsGateway.Object);
            var (result, _) = searchTrusts.Execute(1, 10, groupName);

            result.Should().BeEquivalentTo(expected);
        }
        [Fact]
        public void SearchTrusts_ReturnsListOfTrustSummaryResponsesWithAddresses_WhenTrustsFound()
        {
            var groupName = "groupName";

            var expectedGroups = Test(groupName);

            IDictionary<String, Trust> trusts = new Dictionary<String, Trust>();

            foreach (var expectedGroup in expectedGroups)
            {
                var expectedTrust = Builder<Trust>
                    .CreateNew()
                    .With(g => g.TrustRef = expectedGroup.GroupId)
                    .Build();
                trusts.Add(expectedGroup.GroupId, expectedTrust);
            }

            var trustsGateway = new Mock<ITrustGateway>();
            var establishmentsGateway = new Mock<IEstablishmentGateway>();

            trustsGateway.Setup(g => g.SearchGroups(1, 10, groupName, string.Empty, string.Empty))
                .Returns((expectedGroups, expectedGroups.Count));

            trustsGateway.Setup(m => m.GetIfdTrustsByTrustRef(It.IsAny<string[]>()))
                .Returns(trusts.Values.ToList());

            establishmentsGateway.Setup(g => g.GetByTrustUids(It.IsAny<string[]>()))
                .Returns(new List<Establishment>());

            var expected = expectedGroups.
                Select(e => TrustSummaryResponseFactory.Create(e, new List<Establishment>(), trusts[e.GroupId]))
                .ToList();

            var searchTrusts = new SearchTrusts(trustsGateway.Object, establishmentsGateway.Object);
            var (result, _) = searchTrusts.Execute(1, 10, groupName);

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

            var trusts = Builder<Trust>.CreateListOfSize(3).Build();
            
            var trustGateway = new Mock<ITrustGateway>();
            var establishmentGateway = new Mock<IEstablishmentGateway>();

            trustGateway.Setup(g => g.SearchGroups(1, 10, string.Empty, ukprn, string.Empty))
                .Returns((new List<Group> {expectedTrust}, 1));
            trustGateway.Setup(m => m.GetIfdTrustsByTrustRef(It.IsAny<string[]>()))
                .Returns(trusts);
            establishmentGateway.Setup(g => g.GetByTrustUids(It.IsAny<string[]>()))
                .Returns(expectedEstablishments);

            var expected = new List<TrustSummaryResponse>
            {
                TrustSummaryResponseFactory.Create(expectedTrust, expectedEstablishments, null)
            };

            var searchTrusts = new SearchTrusts(trustGateway.Object, establishmentGateway.Object);
            var (result, _) = searchTrusts.Execute(1, 10, ukPrn: ukprn);
            result.Should().BeEquivalentTo(expected);
        }
        
        [Fact]
        public void SearchTrusts_WithoutEstablishments()
        {
            var ukprn = "mockurn";
            var expectedTrust = Builder<Group>
                .CreateNew()
                .With(g => g.Ukprn = ukprn)
                .Build();

            var trusts = Builder<Trust>.CreateListOfSize(3).Build();
            var trustGateway = new Mock<ITrustGateway>();

            trustGateway.Setup(g => g.SearchGroups(1, 10, string.Empty, ukprn, string.Empty))
                .Returns((new List<Group> {expectedTrust}, 1));
            trustGateway.Setup(m => m.GetIfdTrustsByTrustRef(It.IsAny<string[]>()))
                .Returns(trusts);

            var expected = new List<TrustSummaryResponse>
            {
                TrustSummaryResponseFactory.Create(expectedTrust, Enumerable.Empty<Establishment>(), null)
            };

            var searchTrusts = new SearchTrusts(trustGateway.Object, null);
            var (result, _) = searchTrusts.Execute(1, 10, ukPrn: ukprn, includeEstablishments: false);
            result.Should().BeEquivalentTo(expected);
        }

    }
}