using System;
using System.Collections.Generic;
using FizzWare.NBuilder;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using TramsDataApi.Controllers;
using TramsDataApi.RequestModels;
using TramsDataApi.ResponseModels;
using TramsDataApi.UseCases;
using Xunit;

namespace TramsDataApi.Test.Controllers
{
    public class EstablishmentsControllerTests
    {
        private readonly EstablishmentsController _controller;
        private readonly Mock<IGetEstablishmentByUkprn> _getEstablishmentByUkprn;
        private readonly Mock<IGetEstablishmentURNsByRegion> _getEstablishmentURNsByRegion;
        private readonly Mock<IUseCase<GetEstablishmentByUrnRequest, EstablishmentResponse>> _getEstablishmentByUrn;
        private readonly Mock<IUseCase<SearchEstablishmentsRequest, IList<EstablishmentSummaryResponse>>> _searchEstablishments;
        private readonly Mock<IGetEstablishmentsByUrns> _getEstablishmentsByUrns;
        private const string UKPRN = "mockukprn";
        private const int URN = 123456789;

        private static readonly string[] Regions = {"East", "West"};

        public EstablishmentsControllerTests()
        {
            _getEstablishmentURNsByRegion = new Mock<IGetEstablishmentURNsByRegion>();
            _getEstablishmentByUkprn = new Mock<IGetEstablishmentByUkprn>();
            _getEstablishmentByUrn = new Mock<IUseCase<GetEstablishmentByUrnRequest, EstablishmentResponse>>();
            _searchEstablishments = new Mock<IUseCase<SearchEstablishmentsRequest, IList<EstablishmentSummaryResponse>>>();
            _getEstablishmentsByUrns = new Mock<IGetEstablishmentsByUrns>();

            _controller = new EstablishmentsController(
                _getEstablishmentByUkprn.Object,
                _getEstablishmentByUrn.Object,
                _searchEstablishments.Object,
                _getEstablishmentURNsByRegion.Object,
                _getEstablishmentsByUrns.Object,
                new Mock<ILogger<EstablishmentsController>>().Object
            );
        }

        [Fact]
        public void GetEstablishmentByUkprn_ReturnsNotFoundResult_WhenNoEstablishmentFound()
        {
            _getEstablishmentByUkprn.Setup(g => g.Execute(UKPRN)).Returns(() => null);

            var result = _controller.GetByUkprn(UKPRN);

            result.Result.Should().BeOfType(typeof(NotFoundResult));
        }

        [Fact]
        public void GetEstablishmentByUkprn_ReturnsEstablishmentResponse_WhenEstablishmentFound()
        {
            var establishmentResponse = Builder<EstablishmentResponse>.CreateNew().With(a => a.Ukprn = UKPRN).Build();
            _getEstablishmentByUkprn.Setup(g => g.Execute(UKPRN)).Returns(() => establishmentResponse);

            var result = _controller.GetByUkprn(UKPRN);
            
            result.Result.Should().BeEquivalentTo(new OkObjectResult(establishmentResponse));
        }
        [Fact]
        public void GetEstablishmentURNsByRegion_ReturnsNotFoundResult_WhenNoEstablishmentFound()
        {
            _getEstablishmentURNsByRegion.Setup(g => g.Execute(Regions)).Returns(() => new List<int>());

            var result = _controller.GetURNsByRegion(Regions);

            result.Result.Should().BeEquivalentTo(new OkObjectResult(new List<int>()));
        }

        [Fact]
        public void GetEstablishmentURNsByRegion_ReturnsEstablishmentResponse_WhenEstablishmentFound()
        {
            var GOR = new NameAndCodeResponse()
            {
                Code = "Code",
                Name = Regions[0]
            };
            var establishmentResponse = Builder<EstablishmentResponse>.CreateNew().With(b => b.Urn = "11").With(a => a.GOR = GOR).Build();
            var listOfURNs = new List<int>
            {
                Convert.ToInt32(establishmentResponse.Urn)
            };
            _getEstablishmentURNsByRegion.Setup(g => g.Execute(Regions)).Returns(() => listOfURNs);

            var result = _controller.GetURNsByRegion(Regions);

            result.Result.Should().BeEquivalentTo(new OkObjectResult(listOfURNs));
        }

        [Fact]
        public void GetEstablishmentByUrn_ReturnsNotFoundResult_WhenNoEstablishmentFound()
        {
            _getEstablishmentByUrn.Setup(g => g.Execute(It.IsAny<GetEstablishmentByUrnRequest>())).Returns(() => null);

            var result = _controller.GetByUrn(URN);

            result.Result.Should().BeOfType(typeof(NotFoundResult));
        }

        [Fact]
        public void GetEstablishmentByUrn_ReturnsEstablishmentResponse_WhenEstablishmentFound()
        {
            var establishmentResponse = Builder<EstablishmentResponse>.CreateNew().With(a => a.Urn = URN.ToString()).Build();
            _getEstablishmentByUrn.Setup(g => g.Execute(It.Is<GetEstablishmentByUrnRequest>(req => req.URN == URN))).Returns(() => establishmentResponse);

            var result = _controller.GetByUrn(URN);

            result.Result.Should().BeEquivalentTo(new OkObjectResult(establishmentResponse));
        }

        [Fact]
        public void SearchEstablishments_ReturnsEstablishmentSummaryResponse_WhenEstablishmentsFound()
        {
            var establishmentResponses = Builder<EstablishmentSummaryResponse>.CreateListOfSize(10).Build();

            var request = new SearchEstablishmentsRequest
            {
                Urn = 10010011,
                Ukprn = "mockukprn",
                Name = "establishmentname"
            };
            _searchEstablishments.Setup(s => s.Execute(request)).Returns(establishmentResponses);

            var result = _controller.SearchEstablishments(request);

            result.Result.Should().BeEquivalentTo(new OkObjectResult(establishmentResponses));
        }

        [Fact]
        public void SearchEstablishments_ReturnsEstablishmentSummaryResponse_WhenEstablishmentsFound_AndNoParametersGiven()
        {
            var establishmentResponses = Builder<EstablishmentSummaryResponse>.CreateListOfSize(10).Build();

            _searchEstablishments.Setup(s => s.Execute(null)).Returns(establishmentResponses);

            var result = _controller.SearchEstablishments(null);

            result.Result.Should().BeEquivalentTo(new OkObjectResult(establishmentResponses));
        }

        [Fact]
        public void GetByUrns_WhenNoEstablishmentsAreFound_ReturnsNotFoundResult()
        {
            const int missingEstablishmentUrn = 12345;
            _getEstablishmentsByUrns.Setup(g => g.Execute(It.IsAny<GetEstablishmentsByUrnsRequest>())).Returns(() => null);
            var getEstablishmentsByUrnsRequest = new GetEstablishmentsByUrnsRequest { Urns = new int[] { missingEstablishmentUrn } };

            var result = _controller.GetByUrns(getEstablishmentsByUrnsRequest);

            result.Result.Should().BeOfType(typeof(NotFoundResult));
        }

        [Fact]
        public void GetByUrns_WhenGivenCorrectUrns_ReturnsAListOfEstablishments()
        {
            const int URN2 = 23456789;
            var establishmentResponse1 = Builder<EstablishmentResponse>.CreateNew().With(a => a.Ukprn = URN.ToString()).Build();
            var establishmentResponse2 = Builder<EstablishmentResponse>.CreateNew().With(a => a.Ukprn = URN2.ToString()).Build();
            var establishmentsResponse = new List<EstablishmentResponse> { establishmentResponse1, establishmentResponse2 };
            _getEstablishmentsByUrns.Setup(g => g.Execute(It.IsAny<GetEstablishmentsByUrnsRequest>())).Returns(() => establishmentsResponse);
            var getEstablishmentsByUrnsRequest = new GetEstablishmentsByUrnsRequest { Urns = new int[] { URN, URN2 } };

            var result = _controller.GetByUrns(getEstablishmentsByUrnsRequest);

            result.Result.Should().BeEquivalentTo(new OkObjectResult(establishmentsResponse));
        }
    }
}