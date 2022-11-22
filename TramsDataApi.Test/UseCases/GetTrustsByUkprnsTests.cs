using FizzWare.NBuilder;
using Moq;
using FluentAssertions;
using TramsDataApi.DatabaseModels;
using TramsDataApi.Factories;
using TramsDataApi.Gateways;
using TramsDataApi.UseCases;
using Xunit;
using System.Collections.Generic;
using TramsDataApi.RequestModels;
using System.Linq;
using TramsDataApi.ResponseModels;

namespace TramsDataApi.Test.UseCases
{
    public class GetTrustsByUkprnTests
    {
        private readonly GetTrustsByUkprns _useCase;
        private readonly Mock<ITrustGateway> _mockTrustGateway;
        private readonly Mock<IGetEstablishments> _mockGetEstablishmentsUseCase;

        public GetTrustsByUkprnTests()
        {
            _mockTrustGateway = new Mock<ITrustGateway>();
            _mockGetEstablishmentsUseCase = new Mock<IGetEstablishments>();
            _useCase = new GetTrustsByUkprns(_mockTrustGateway.Object, _mockGetEstablishmentsUseCase.Object);
        }

        [Fact]
        public void GetTrustsByUkprns_WhenNoGroupsFound_ReturnsNull()
        {
            var requestUkprns = new string[] { "12345678" };
            var request = new GetTrustsByUkprnsRequest { Ukprns = requestUkprns };
            _mockTrustGateway.Setup(gateway => gateway.GetMultipleGroupsByUkprn(requestUkprns)).Returns(() => new List<Group>());

            var result = _useCase.Execute(request);

            result.Should().BeNull();
        }

        [Fact]
        public void GetTrustsByUkprns_WhenGroupsAndTrustsAreFound_ReturnsListOfTrustResponses()
        {
            var requestUkprns = new string[] { "12345678", "23456789" };
            var request = new GetTrustsByUkprnsRequest { Ukprns = requestUkprns };

            var groups = Builder<Group>.CreateListOfSize(requestUkprns.Length)
                .All()
                .With((g, i) => g.Ukprn = requestUkprns[i])
                .Build();

            var trustRefs = groups.Select(g => g.GroupId).ToArray();

            var trusts = Builder<Trust>.CreateListOfSize(requestUkprns.Length)
                .All()
                .With((t, i) => t.TrustRef = trustRefs[i])
                .Build();

            var trustResponses = groups.Select((g, i) => TrustResponseFactory
                .Create(g, trusts[i], null)).ToList();

            _mockTrustGateway.Setup(gateway => gateway.GetMultipleGroupsByUkprn(requestUkprns)).Returns(() => groups);
            _mockTrustGateway.Setup(gateway => gateway.GetMultipleTrustsByGroupId(trustRefs)).Returns(() => trusts);
            _mockGetEstablishmentsUseCase.Setup(useCase => useCase.Execute(It.IsAny<string[]>())).Returns(() => null);

            var result = _useCase.Execute(request);

            result.Should().BeEquivalentTo(trustResponses);
        }

        [Fact]
        public void GetTrustsByUkprns_WhenThereAreMultipleGroupsWithTheSameUkprn_OnlyReturnsTheFirstGroupFound()
        {
            var requestUkprns = new string[] { "12345678" };
            var request = new GetTrustsByUkprnsRequest { Ukprns = requestUkprns };

            var groups = Builder<Group>.CreateListOfSize(2)
                .All()
                .With(g => g.Ukprn = requestUkprns[0])
                .Build();

            var trustRefs = groups.Select(g => g.GroupId).ToArray();

            var trusts = Builder<Trust>.CreateListOfSize(requestUkprns.Length)
                .All()
                .With((t, i) => t.TrustRef = trustRefs[i])
                .Build();

            var trustResponses = groups.Select((g, i) => TrustResponseFactory
                .Create(g, trusts[0], null)).ToList();

            _mockTrustGateway.Setup(gateway => gateway.GetMultipleGroupsByUkprn(requestUkprns)).Returns(() => groups);
            _mockTrustGateway.Setup(gateway => gateway.GetMultipleTrustsByGroupId(trustRefs)).Returns(() => trusts);
            _mockGetEstablishmentsUseCase.Setup(useCase => useCase.Execute(It.IsAny<string[]>())).Returns(() => null);

            var result = _useCase.Execute(request);

            result.Should().BeEquivalentTo(trustResponses.First());
        }

        [Fact]
        public void GetTrustsByUkprns_WhenEstablishmentsAreFound_ReturnsListOfTrustResponses()
        {
            var requestUkprns = new string[] { "12345678", "23456789" };
            var request = new GetTrustsByUkprnsRequest { Ukprns = requestUkprns };

            var groups = Builder<Group>.CreateListOfSize(requestUkprns.Length)
                .All()
                .With((g, i) => g.Ukprn = requestUkprns[i])
                .Build();

            var trustRefs = groups.Select(g => g.GroupId).ToArray();
            var groupUids = groups.Select(g => g.GroupUid).ToArray();

            var trusts = Builder<Trust>.CreateListOfSize(requestUkprns.Length)
                .All()
                .With((t, i) => t.TrustRef = trustRefs[i])
                .Build();

            _mockTrustGateway.Setup(gateway => gateway.GetMultipleGroupsByUkprn(requestUkprns)).Returns(() => groups);
            _mockTrustGateway.Setup(gateway => gateway.GetMultipleTrustsByGroupId(trustRefs)).Returns(() => trusts);

            var establishments = Builder<Establishment>.CreateListOfSize(requestUkprns.Length)
                .All()
                .With((e, i) => e.TrustsCode = groupUids[i])
                .Build();
            var establishmentResponses = establishments.Select(e => EstablishmentResponseFactory.Create(e, null, null, null, null, null)).ToList();

            var trustResponses = groups.Select((g, i) => TrustResponseFactory.Create(g, trusts[i], new List<EstablishmentResponse> { establishmentResponses[i] })).ToList();

            _mockGetEstablishmentsUseCase.Setup(useCase => useCase.Execute(groupUids)).Returns(() => establishmentResponses);

            var result = _useCase.Execute(request);

            result.Should().BeEquivalentTo(trustResponses);
        }
    }
}