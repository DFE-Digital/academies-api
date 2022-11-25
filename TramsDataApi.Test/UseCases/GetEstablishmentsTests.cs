using FizzWare.NBuilder;
using FluentAssertions;
using Moq;
using System.Collections.Generic;
using System.Linq;
using TramsDataApi.CensusData;
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
        private readonly Mock<ICensusDataGateway> _mockCensusGateway;
        private readonly GetEstablishments _useCase;

        public GetEstablishmentsTests()
        {
            _mockEstablishmentGateway = new Mock<IEstablishmentGateway>();
            _mockCensusGateway = new Mock<ICensusDataGateway>();

            _useCase = new GetEstablishments(_mockEstablishmentGateway.Object, _mockCensusGateway.Object);
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
            public void WhenRelatedDataIsFound_ReturnsListOfEstablishmentResponses()
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
                var smartData = Builder<SmartData>.CreateListOfSize(requestUrns.Length)
                    .All()
                    .With((e, i) => e.Urn = requestUrns[i].ToString())
                    .Build();
                var furtherEducationEstablishments = Builder<FurtherEducationEstablishments>.CreateListOfSize(requestUrns.Length)
                    .All()
                    .With((e, i) => e.ProviderUrn = requestUrns[i])
                    .Build();
                var viewAcademyConversions = Builder<ViewAcademyConversions>.CreateListOfSize(requestUrns.Length)
                    .All()
                    .With((e, i) => e.GeneralDetailsAcademyUrn = requestUrns[i].ToString())
                    .Build();
                var censusData = GetMockCensusData(establishments);
                var establishmentResponses = establishments.Select((e, i) => EstablishmentResponseFactory
                    .Create(e, misEstablishments[i], smartData[i], furtherEducationEstablishments[i], viewAcademyConversions[i], censusData[i])).ToList();

                _mockEstablishmentGateway.Setup(gateway => gateway.GetByUrns(requestUrns)).Returns(() => establishments);
                _mockEstablishmentGateway.Setup(gateway => gateway.GetMisEstablishmentsByUrns(requestUrns)).Returns(() => misEstablishments);
                _mockEstablishmentGateway.Setup(gateway => gateway.GetSmartDataByUrns(requestUrns)).Returns(() => smartData);
                _mockEstablishmentGateway.Setup(gateway => gateway.GetFurtherEducationEstablishmentsByUrns(requestUrns)).Returns(() => furtherEducationEstablishments);
                _mockEstablishmentGateway.Setup(gateway => gateway.GetViewAcademyConversionInfoByUrns(requestUrns)).Returns(() => viewAcademyConversions);

                var stringUrns = requestUrns.Select(urn => urn.ToString()).ToArray();
                _mockCensusGateway.Setup(gateway => gateway.GetCensusDataByURNs(stringUrns)).Returns(() => censusData);

                var result = _useCase.Execute(request);

                result.Should().BeEquivalentTo(establishmentResponses);
            }

            [Fact]
            public void WhenThereAreMultipleEstablishmentsWithTheSameUrn_OnlyReturnsTheFirstEstablishmentFound()
            {
                var requestUrns = new int[] { 12345 };
                var request = new GetEstablishmentsByUrnsRequest { Urns = requestUrns };

                var establishments = Builder<Establishment>.CreateListOfSize(2)
                    .All()
                    .With(e => e.Urn = requestUrns[0])
                    .Build();
                var establishmentResponses = establishments.Select((e) => EstablishmentResponseFactory
                    .Create(e, null, null, null, null, null)).ToList();

                _mockEstablishmentGateway.Setup(gateway => gateway.GetByUrns(requestUrns)).Returns(() => establishments);

                var result = _useCase.Execute(request);

                result.Should().BeEquivalentTo(establishmentResponses.First());
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
            public void WhenRelatedDataIsFound_ReturnsListOfEstablishmentResponses()
            {
                var trustUids = new string[] { "1234", "2345" };

                var establishments = Builder<Establishment>.CreateListOfSize(trustUids.Length)
                    .All()
                    .Build();
                var misEstablishments = Builder<MisEstablishments>.CreateListOfSize(trustUids.Length)
                    .All()
                    .With((e, i) => e.Urn = establishments[i].Urn)
                    .Build();
                var smartData = Builder<SmartData>.CreateListOfSize(trustUids.Length)
                    .All()
                    .With((e, i) => e.Urn = establishments[i].Urn.ToString())
                    .Build();
                var furtherEducationEstablishments = Builder<FurtherEducationEstablishments>.CreateListOfSize(trustUids.Length)
                    .All()
                    .With((e, i) => e.ProviderUrn = establishments[i].Urn)
                    .Build();
                var viewAcademyConversions = Builder<ViewAcademyConversions>.CreateListOfSize(trustUids.Length)
                    .All()
                    .With((e, i) => e.GeneralDetailsAcademyUrn = establishments[i].Urn.ToString())
                    .Build();
                var censusData = GetMockCensusData(establishments);
                var establishmentResponses = establishments.Select((e, i) => EstablishmentResponseFactory
                    .Create(e, misEstablishments[i], smartData[i], furtherEducationEstablishments[i], viewAcademyConversions[i], censusData[i])).ToList();

                var urns = establishments.Select(e => e.Urn).ToArray();

                _mockEstablishmentGateway.Setup(gateway => gateway.GetByTrustUids(trustUids)).Returns(() => establishments);
                _mockEstablishmentGateway.Setup(gateway => gateway.GetMisEstablishmentsByUrns(urns)).Returns(() => misEstablishments);
                _mockEstablishmentGateway.Setup(gateway => gateway.GetSmartDataByUrns(urns)).Returns(() => smartData);
                _mockEstablishmentGateway.Setup(gateway => gateway.GetFurtherEducationEstablishmentsByUrns(urns)).Returns(() => furtherEducationEstablishments);
                _mockEstablishmentGateway.Setup(gateway => gateway.GetViewAcademyConversionInfoByUrns(urns)).Returns(() => viewAcademyConversions);

                var stringUrns = urns.Select(urn => urn.ToString()).ToArray();

                _mockCensusGateway.Setup(gateway => gateway.GetCensusDataByURNs(stringUrns)).Returns(() => censusData);

                var result = _useCase.Execute(trustUids);

                result.Should().BeEquivalentTo(establishmentResponses);
            }
        }

        private IList<CensusDataModel> GetMockCencusData(IEnumerable<Establishment> establishments)
        {
            return establishments.Select(
                establishment => new CensusDataModel
                {
                    URN = establishment.Urn.ToString(),
                    LA = "201",
                    ESTAB = "3614",
                    SCHOOLTYPE = "State-funded primary",
                    NOR = "285",
                    NORG = "141",
                    NORB = "144",
                    PNORG = "49.5",
                    PNORB = "50.5",
                    TSENELSE = "5",
                    PSENELSE = "1.8",
                    TSENELK = "50",
                    PSENELK = "17.5",
                    NUMEAL = "141",
                    NUMENGFL = "143",
                    NUMUNCFL = "1",
                    PNUMEAL = "49.5",
                    PNUMENGFL = "50.2",
                    PNUMUNCFL = "0.4",
                    NUMFSM = "32",
                    NUMFSMEVER = "38",
                    PNUMFSMEVER = "16.2"
                }
            ).ToList();
        }
    }
}
