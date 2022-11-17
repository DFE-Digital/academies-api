using FizzWare.NBuilder;
using FluentAssertions;
using Moq;
using System.Collections.Generic;
using System.Linq;
using TramsDataApi.DatabaseModels;
using TramsDataApi.Factories;
using TramsDataApi.Gateways;
using TramsDataApi.RequestModels;
using TramsDataApi.UseCases;
using Xunit;

namespace TramsDataApi.Test.UseCases
{
    public class GetEstablishmentsByUrnsTests
    {
        private readonly Mock<IEstablishmentGateway> _mockEstablishmentGateway;

        public GetEstablishmentsByUrnsTests()
        {
            _mockEstablishmentGateway = new Mock<IEstablishmentGateway>();
        }

        [Fact]
        public void GetEstablishmentsByUrns_WhenNoEstablishmentsFound_ReturnsNull()
        {
            var requestUrns = new int[] { 12345 };
            var request = new GetEstablishmentsByUrnsRequest { Urns = requestUrns };
            _mockEstablishmentGateway .Setup(gateway => gateway.GetByUrns(requestUrns)).Returns(() => new List<Establishment>());
            var useCase = new GetEstablishmentsByUrns(_mockEstablishmentGateway.Object);

            var result = useCase.Execute(request);

            result.Should().BeNull();
        }

        [Fact]
        public void GetEstablishmentsByUrns_WhenEstablishmentsAreFound_ReturnsListOfEstablishmentResponses()
        {
            var requestUrns = new int[] { 12345, 23456 };
            var request = new GetEstablishmentsByUrnsRequest { Urns = requestUrns };

            var establishments = Builder<Establishment>.CreateListOfSize(requestUrns.Length)
                .All()
                .With((e, i) => e.Urn = requestUrns[i])
                .Build();
            var establishmentResponses = establishments.Select((e) => EstablishmentResponseFactory
                .Create(e, null, null, null, null, null)).ToList();

            _mockEstablishmentGateway.Setup(gateway => gateway.GetByUrns(requestUrns)).Returns(() => establishments);

            var useCase = new GetEstablishmentsByUrns(_mockEstablishmentGateway.Object);

            var result = useCase.Execute(request);

            result.Should().BeEquivalentTo(establishmentResponses);
        }

        [Fact]
        public void GetEstablishmentsByUrns_WhenMisEstablishmentsAreFound_ReturnsListOfEstablishmentResponses()
        {
            var requestUrns = new int[] { 12345, 23456 };
            var request = new GetEstablishmentsByUrnsRequest { Urns = requestUrns };

            var establishments = Builder<Establishment>.CreateListOfSize(requestUrns.Length)
                .All()
                .With((e, i) => e.Urn = requestUrns[i])
                .Build();
            var misEstablishments = Builder<MisEstablishments>.CreateListOfSize(requestUrns.Length)
                .All()
                .With((e, i) => e.Urn = requestUrns[i])
                .Build();
            var establishmentResponses = establishments.Select((e, i) => EstablishmentResponseFactory
                .Create(e, misEstablishments[i], null, null, null, null)).ToList();

            _mockEstablishmentGateway.Setup(gateway => gateway.GetByUrns(requestUrns)).Returns(() => establishments);
            _mockEstablishmentGateway.Setup(gateway => gateway.GetMisEstablishmentsByUrns(requestUrns)).Returns(() => misEstablishments);

            var useCase = new GetEstablishmentsByUrns(_mockEstablishmentGateway.Object);

            var result = useCase.Execute(request);

            result.Should().BeEquivalentTo(establishmentResponses);
        }

        [Fact]
        public void GetEstablishmentsByUrns_WhenSmartDataIsFound_ReturnsListOfEstablishmentResponses()
        {
            var requestUrns = new int[] { 12345, 23456 };
            var request = new GetEstablishmentsByUrnsRequest { Urns = requestUrns };

            var establishments = Builder<Establishment>.CreateListOfSize(requestUrns.Length)
                .All()
                .With((e, i) => e.Urn = requestUrns[i])
                .Build();
            var smartData = Builder<SmartData>.CreateListOfSize(requestUrns.Length)
                .All()
                .With((e, i) => e.Urn = requestUrns[i].ToString())
                .Build();
            var establishmentResponses = establishments.Select((e, i) => EstablishmentResponseFactory
                .Create(e, null, smartData[i], null, null, null)).ToList();

            _mockEstablishmentGateway.Setup(gateway => gateway.GetByUrns(requestUrns)).Returns(() => establishments);
            _mockEstablishmentGateway.Setup(gateway => gateway.GetSmartDataByUrns(requestUrns)).Returns(() => smartData);

            var useCase = new GetEstablishmentsByUrns(_mockEstablishmentGateway.Object);

            var result = useCase.Execute(request);

            result.Should().BeEquivalentTo(establishmentResponses);
        }

        [Fact]
        public void GetEstablishmentsByUrns_WhenFurtherEducationEstablishmentsAreFound_ReturnsListOfEstablishmentResponses()
        {
            var requestUrns = new int[] { 12345, 23456 };
            var request = new GetEstablishmentsByUrnsRequest { Urns = requestUrns };

            var establishments = Builder<Establishment>.CreateListOfSize(requestUrns.Length)
                .All()
                .With((e, i) => e.Urn = requestUrns[i])
                .Build();
            var furtherEducationEstablishments = Builder<FurtherEducationEstablishments>.CreateListOfSize(requestUrns.Length)
                .All()
                .With((e, i) => e.ProviderUrn = requestUrns[i])
                .Build();
            var establishmentResponses = establishments.Select((e, i) => EstablishmentResponseFactory
                .Create(e, null, null, furtherEducationEstablishments[i], null, null)).ToList();

            _mockEstablishmentGateway.Setup(gateway => gateway.GetByUrns(requestUrns)).Returns(() => establishments);
            _mockEstablishmentGateway.Setup(gateway => gateway.GetFurtherEducationEstablishmentsByUrns(requestUrns)).Returns(() => furtherEducationEstablishments);

            var useCase = new GetEstablishmentsByUrns(_mockEstablishmentGateway.Object);

            var result = useCase.Execute(request);

            result.Should().BeEquivalentTo(establishmentResponses);
        }

        [Fact]
        public void GetEstablishmentsByUrns_WhenViewAcademyConversionsAreFound_ReturnsListOfEstablishmentResponses()
        {
            var requestUrns = new int[] { 12345, 23456 };
            var request = new GetEstablishmentsByUrnsRequest { Urns = requestUrns };

            var establishments = Builder<Establishment>.CreateListOfSize(requestUrns.Length)
                .All()
                .With((e, i) => e.Urn = requestUrns[i])
                .Build();
            var viewAcademyConversions = Builder<ViewAcademyConversions>.CreateListOfSize(requestUrns.Length)
                .All()
                .With((e, i) => e.GeneralDetailsAcademyUrn = requestUrns[i].ToString())
                .Build();
            var establishmentResponses = establishments.Select((e, i) => EstablishmentResponseFactory
                .Create(e, null, null, null, viewAcademyConversions[i], null)).ToList();

            _mockEstablishmentGateway.Setup(gateway => gateway.GetByUrns(requestUrns)).Returns(() => establishments);
            _mockEstablishmentGateway.Setup(gateway => gateway.GetViewAcademyConversionInfoByUrns(requestUrns)).Returns(() => viewAcademyConversions);

            var useCase = new GetEstablishmentsByUrns(_mockEstablishmentGateway.Object);

            var result = useCase.Execute(request);

            result.Should().BeEquivalentTo(establishmentResponses);
        }
    }
}
