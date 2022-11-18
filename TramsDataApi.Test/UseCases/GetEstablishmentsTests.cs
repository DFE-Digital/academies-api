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
    public class GetEstablishmentsTests
    {
        private readonly Mock<IEstablishmentGateway> _mockEstablishmentGateway;
        private readonly GetEstablishments _useCase;

        public GetEstablishmentsTests()
        {
            _mockEstablishmentGateway = new Mock<IEstablishmentGateway>();
            _useCase = new GetEstablishments(_mockEstablishmentGateway.Object);
        }

        public class GetEstablishmentsByUrns : GetEstablishmentsTests
        {
            [Fact]
            public void WhenNoEstablishmentsFound_ReturnsNull()
            {
                var requestUrns = new int[] { 12345 };
                var request = new GetEstablishmentsByUrnsRequest { Urns = requestUrns };
                _mockEstablishmentGateway.Setup(gateway => gateway.GetByUrns(requestUrns)).Returns(() => new List<Establishment>());

                var result = _useCase.Execute(request);

                result.Should().BeNull();
            }

            [Fact]
            public void WhenEstablishmentsAreFound_ReturnsListOfEstablishmentResponses()
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

                var result = _useCase.Execute(request);

                result.Should().BeEquivalentTo(establishmentResponses);
            }

            [Fact]
            public void WhenMisEstablishmentsAreFound_ReturnsListOfEstablishmentResponses()
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

                var result = _useCase.Execute(request);

                result.Should().BeEquivalentTo(establishmentResponses);
            }

            [Fact]
            public void WhenSmartDataIsFound_ReturnsListOfEstablishmentResponses()
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

                var result = _useCase.Execute(request);

                result.Should().BeEquivalentTo(establishmentResponses);
            }

            [Fact]
            public void WhenFurtherEducationEstablishmentsAreFound_ReturnsListOfEstablishmentResponses()
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

                var result = _useCase.Execute(request);

                result.Should().BeEquivalentTo(establishmentResponses);
            }

            [Fact]
            public void WhenViewAcademyConversionsAreFound_ReturnsListOfEstablishmentResponses()
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

                var result = _useCase.Execute(request);

                result.Should().BeEquivalentTo(establishmentResponses);
            }
        }

        public class GetEstablishmentsByTrustUids : GetEstablishmentsTests
        {
            [Fact]
            public void WhenNoEstablishmentsFound_ReturnsNull()
            {
                var trustUids = new string[] { "1234" };
                _mockEstablishmentGateway.Setup(gateway => gateway.GetByTrustUids(trustUids)).Returns(() => new List<Establishment>());

                var result = _useCase.Execute(trustUids);

                result.Should().BeNull();
            }

            [Fact]
            public void WhenEstablishmentsAreFound_ReturnsListOfEstablishmentResponses()
            {
                var trustUids = new string[] { "1234", "2345" };

                var establishments = Builder<Establishment>.CreateListOfSize(trustUids.Length)
                    .All()
                    .Build();
                var establishmentResponses = establishments.Select((e, i) => EstablishmentResponseFactory
                    .Create(e, null, null, null, null, null)).ToList();

                _mockEstablishmentGateway.Setup(gateway => gateway.GetByTrustUids(trustUids)).Returns(() => establishments);

                var result = _useCase.Execute(trustUids);

                result.Should().BeEquivalentTo(establishmentResponses);
            }

            [Fact]
            public void WhenMisEstablishmentsAreFound_ReturnsListOfEstablishmentResponses()
            {
                (string TrustUid, int Urn)[] establishmentAttributes = {
                    (TrustUid: "1234", Urn: 12345),
                    (TrustUid: "2345", Urn: 23456)
                };
                var urns = establishmentAttributes.Select(e => e.Urn).ToArray();
                var trustUids = establishmentAttributes.Select(e => e.TrustUid).ToArray();

                var establishments = Builder<Establishment>.CreateListOfSize(establishmentAttributes.Length)
                    .All()
                    .With((e, i) => e.Urn = establishmentAttributes[i].Urn)
                    .Build();
                var misEstablishments = Builder<MisEstablishments>.CreateListOfSize(establishmentAttributes.Length)
                    .All()
                    .With((e, i) => e.Urn = establishmentAttributes[i].Urn)
                    .Build();
                var establishmentResponses = establishments.Select((e, i) => EstablishmentResponseFactory
                    .Create(e, misEstablishments[i], null, null, null, null)).ToList();

                _mockEstablishmentGateway.Setup(gateway => gateway.GetByTrustUids(trustUids)).Returns(() => establishments);
                _mockEstablishmentGateway.Setup(gateway => gateway.GetMisEstablishmentsByUrns(urns)).Returns(() => misEstablishments);

                var result = _useCase.Execute(trustUids);

                result.Should().BeEquivalentTo(establishmentResponses);
            }

            [Fact]
            public void WhenSmartDataIsFound_ReturnsListOfEstablishmentResponses()
            {
                (string TrustUid, int Urn)[] establishmentAttributes = {
                    (TrustUid: "1234", Urn: 12345),
                    (TrustUid: "2345", Urn: 23456)
                };
                var urns = establishmentAttributes.Select(e => e.Urn).ToArray();
                var trustUids = establishmentAttributes.Select(e => e.TrustUid).ToArray();

                var establishments = Builder<Establishment>.CreateListOfSize(establishmentAttributes.Length)
                    .All()
                    .With((e, i) => e.Urn = establishmentAttributes[i].Urn)
                    .Build();
                var smartData = Builder<SmartData>.CreateListOfSize(establishmentAttributes.Length)
                    .All()
                    .With((e, i) => e.Urn = establishmentAttributes[i].Urn.ToString())
                    .Build();
                var establishmentResponses = establishments.Select((e, i) => EstablishmentResponseFactory
                    .Create(e, null, smartData[i], null, null, null)).ToList();

                _mockEstablishmentGateway.Setup(gateway => gateway.GetByTrustUids(trustUids)).Returns(() => establishments);
                _mockEstablishmentGateway.Setup(gateway => gateway.GetSmartDataByUrns(urns)).Returns(() => smartData);

                var result = _useCase.Execute(trustUids);

                result.Should().BeEquivalentTo(establishmentResponses);
            }

            [Fact]
            public void WhenFurtherEducationEstablishmentsAreFound_ReturnsListOfEstablishmentResponses()
            {
                (string TrustUid, int Urn)[] establishmentAttributes = {
                    (TrustUid: "1234", Urn: 12345),
                    (TrustUid: "2345", Urn: 23456)
                };
                var urns = establishmentAttributes.Select(e => e.Urn).ToArray();
                var trustUids = establishmentAttributes.Select(e => e.TrustUid).ToArray();

                var establishments = Builder<Establishment>.CreateListOfSize(establishmentAttributes.Length)
                    .All()
                    .With((e, i) => e.Urn = establishmentAttributes[i].Urn)
                    .Build();
                var furtherEducationEstablishments = Builder<FurtherEducationEstablishments>.CreateListOfSize(establishmentAttributes.Length)
                    .All()
                    .With((e, i) => e.ProviderUrn = establishmentAttributes[i].Urn)
                    .Build();
                var establishmentResponses = establishments.Select((e, i) => EstablishmentResponseFactory
                    .Create(e, null, null, furtherEducationEstablishments[i], null, null)).ToList();

                _mockEstablishmentGateway.Setup(gateway => gateway.GetByTrustUids(trustUids)).Returns(() => establishments);
                _mockEstablishmentGateway.Setup(gateway => gateway.GetFurtherEducationEstablishmentsByUrns(urns)).Returns(() => furtherEducationEstablishments);

                var result = _useCase.Execute(trustUids);

                result.Should().BeEquivalentTo(establishmentResponses);
            }

            [Fact]
            public void WhenViewAcademyConversionsAreFound_ReturnsListOfEstablishmentResponses()
            {
                (string TrustUid, int Urn)[] establishmentAttributes = {
                    (TrustUid: "1234", Urn: 12345),
                    (TrustUid: "2345", Urn: 23456)
                };
                var urns = establishmentAttributes.Select(e => e.Urn).ToArray();
                var trustUids = establishmentAttributes.Select(e => e.TrustUid).ToArray();

                var establishments = Builder<Establishment>.CreateListOfSize(establishmentAttributes.Length)
                    .All()
                    .With((e, i) => e.Urn = establishmentAttributes[i].Urn)
                    .Build(); ;
                var viewAcademyConversions = Builder<ViewAcademyConversions>.CreateListOfSize(establishmentAttributes.Length)
                    .All()
                    .With((e, i) => e.GeneralDetailsAcademyUrn = establishmentAttributes[i].Urn.ToString())
                    .Build();
                var establishmentResponses = establishments.Select((e, i) => EstablishmentResponseFactory
                    .Create(e, null, null, null, viewAcademyConversions[i], null)).ToList();

                _mockEstablishmentGateway.Setup(gateway => gateway.GetByTrustUids(trustUids)).Returns(() => establishments);
                _mockEstablishmentGateway.Setup(gateway => gateway.GetViewAcademyConversionInfoByUrns(urns)).Returns(() => viewAcademyConversions);

                var result = _useCase.Execute(trustUids);

                result.Should().BeEquivalentTo(establishmentResponses);
            }
        }
    }
}
