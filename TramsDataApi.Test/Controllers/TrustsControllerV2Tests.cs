using System.Collections.Generic;
using System.Linq;
using FizzWare.NBuilder;
using FizzWare.NBuilder.PropertyNaming;
using FluentAssertions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using TramsDataApi.Controllers.V2;
using TramsDataApi.RequestModels;
using TramsDataApi.ResponseModels;
using TramsDataApi.UseCases;
using Xunit;

namespace TramsDataApi.Test.Controllers
{
    public class TrustsControllerV2Tests
    {
        private readonly TrustsController _controller;
        private readonly Mock<IGetTrustByUkprn> _mockGetTrustByUkprnUseCase;
        private readonly Mock<ISearchTrusts> _mockSearchTrustsUseCase;
        private readonly Mock<IGetTrustsByUkprns> _mockGetTrustsByUkprnsUseCase;
        private readonly Mock<ILogger<TrustsController>> _mockLogger;

        public TrustsControllerV2Tests()
        {
            BuilderSetup.SetDefaultPropertyName(new RandomValuePropertyNamer(new BuilderSettings()));

            _mockGetTrustByUkprnUseCase = new Mock<IGetTrustByUkprn>();
            _mockSearchTrustsUseCase = new Mock<ISearchTrusts>();
            _mockGetTrustsByUkprnsUseCase = new Mock<IGetTrustsByUkprns>();
            _mockLogger = new Mock<ILogger<TrustsController>>();

            _controller = new TrustsController(
                    _mockGetTrustByUkprnUseCase.Object,
                    _mockSearchTrustsUseCase.Object,
                    _mockGetTrustsByUkprnsUseCase.Object,
                    _mockLogger.Object);
        }

        [Fact]
        public void GetTrustsByUkPrn_ReturnsNotFoundResult_WhenNoTrustsFound()
        {
            var ukprn = "mockukprn";
            _mockGetTrustByUkprnUseCase.Setup(g => g.Execute(ukprn)).Returns(() => null);

            var result = _controller.GetTrustByUkPrn(ukprn);

            result.Result.Should().BeOfType(typeof(NotFoundResult));
        }

        [Fact]
        public void GetTrustsByUkPrn_ReturnsTrustResponse_WhenTrustFound()
        {
            var ukprn = "mockukprn";

            var trustResponse = new TrustResponse
            {
                IfdData = new IFDDataResponse(),
                GiasData = new GIASDataResponse
                {
                    GroupId = "Test group ID",
                    GroupName = "Test group name",
                    CompaniesHouseNumber = "Test CH Number",
                    GroupContactAddress = new AddressResponse
                    {
                        Street = "Test street",
                        AdditionalLine = "Test additional line",
                        Locality = "Test locality",
                        Town = "Test town",
                        County = "Test county",
                        Postcode = "P05TC0D"
                    },
                    Ukprn = ukprn
                }
            };

            _mockGetTrustByUkprnUseCase.Setup(g => g.Execute(ukprn)).Returns(trustResponse);

            var result = _controller.GetTrustByUkPrn(ukprn);

            var expected = new OkObjectResult(new ApiSingleResponseV2<TrustResponse>(trustResponse));
            result.Result.Should().BeEquivalentTo(expected);
        }

        [Fact]
        public void SearchTrusts_ReturnsEmptySetOfTrustSummaries_WhenNoTrustsFound()
        {
            var groupName = "Mockgroupname";
            var ukprn = "Mockurn";
            var companiesHouseNumber = "Mockcompanieshousenumber";

            var expectedPagingResponse = new PagingResponse
            {
                Page = 1,
                RecordCount = 0,
                NextPageUrl = null
            };

            _mockSearchTrustsUseCase.Setup(s => s.Execute(1, 10, groupName, ukprn, companiesHouseNumber))
                .Returns((new List<TrustSummaryResponse>(), 0));

            var result = _controller.SearchTrusts(groupName, ukprn, companiesHouseNumber, 1, 10);

            var expected = new OkObjectResult(new ApiResponseV2<TrustSummaryResponse>(new List<TrustSummaryResponse>(), expectedPagingResponse));
            result.Result.Should().BeEquivalentTo(expected);
        }

        [Fact]
        public void SearchTrusts_ByGroupNameAndCompaniesHouseNumber_ReturnsListOfTrustSummaries_WhenTrustsAreFound()
        {
            var groupName = "Mockgroupname";
            var companiesHouseNumber = "Mockcompanieshousenumber";

            var expectedTrustSummaries = Builder<TrustSummaryResponse>.CreateListOfSize(5)
                .All()
                .With(g => g.GroupName = groupName)
                .With(g => g.CompaniesHouseNumber = companiesHouseNumber)
                .Build();

            var expectedPagingResponse = new PagingResponse
            {
                Page = 1,
                RecordCount = 5,
                NextPageUrl = null
            };

            _mockSearchTrustsUseCase.Setup(s => s.Execute(1, 10, groupName, null, companiesHouseNumber))
                .Returns((expectedTrustSummaries, expectedTrustSummaries.Count));

            var result = _controller.SearchTrusts(groupName, null, companiesHouseNumber, 1, 10);

            var expected = new OkObjectResult(new ApiResponseV2<TrustSummaryResponse>(expectedTrustSummaries, expectedPagingResponse));
            result.Result.Should().BeEquivalentTo(expected);
        }


        [Fact]
        public void SearchTrusts_ByUrn_ReturnsListOfTrustSummaries_WhenTrustsAreFound()
        {
            var ukprn = "Mockurn";

            var expectedTrustSummaries = Builder<TrustSummaryResponse>.CreateListOfSize(5)
                .All()
                .With(g => g.Ukprn = ukprn)
                .Build();

            var expectedPagingResponse = new PagingResponse
            {
                Page = 1,
                RecordCount = 5,
                NextPageUrl = null
            };

            _mockSearchTrustsUseCase.Setup(s => s.Execute(1, 10, null, ukprn, null))
                .Returns((expectedTrustSummaries, expectedTrustSummaries.Count));

            var result = _controller.SearchTrusts(null, ukprn, null, 1, 10);

            var expected = new OkObjectResult(new ApiResponseV2<TrustSummaryResponse>(expectedTrustSummaries, expectedPagingResponse));
            result.Result.Should().BeEquivalentTo(expected);
        }

        [Fact]
        public void SearchTrusts_WithNoParams_ReturnsAllTrusts()
        {
            var expectedTrustSummaries = Builder<TrustSummaryResponse>.CreateListOfSize(5).Build();
            var expectedPaging = new PagingResponse
            {
                Page = 1,
                RecordCount = 5,
                NextPageUrl = null
            };
            _mockSearchTrustsUseCase.Setup(s => s.Execute(1, 10, null, null, null))
                .Returns((expectedTrustSummaries, expectedTrustSummaries.Count));

            var result = _controller.SearchTrusts(null, null, null, 1, 10);

            var expected = new OkObjectResult(new ApiResponseV2<TrustSummaryResponse>(expectedTrustSummaries, expectedPaging));
            result.Result.Should().BeEquivalentTo(expected);
        }

        [Fact]
        public void SearchTrusts_WithMultiplePagesOfResults_ReturnsAllTrustsWithPagingResponseForNextPage()
        {
            var expectedTrustSummaries = Builder<TrustSummaryResponse>.CreateListOfSize(20).Build();

            var expectedPaging = new PagingResponse
            {
                Page = 1,
                RecordCount = 20,
                NextPageUrl = "?page=2&count=10"
            };

            _mockSearchTrustsUseCase
                .Setup(s => s.Execute(1, 10, null, null, null))
                .Returns((expectedTrustSummaries.Take(10).ToList(), expectedTrustSummaries.Count));

            _controller.ControllerContext = new ControllerContext { HttpContext = new DefaultHttpContext() };

            var result = _controller.SearchTrusts(null, null, null, 1, 10);

            var expected = new OkObjectResult(new ApiResponseV2<TrustSummaryResponse>(expectedTrustSummaries.Take(10), expectedPaging));
            result.Result.Should().BeEquivalentTo(expected);
        }


        [Fact]
        public void GetByUkprns_WhenNoTrustsAreFound_ReturnsNotFoundResult()
        {
            const string missingTrustUkprn = "12345678";
            _mockGetTrustsByUkprnsUseCase.Setup(g => g.Execute(It.IsAny<GetTrustsByUkprnsRequest>())).Returns(() => null);
            var getTrustsByUkprnsRequest = new GetTrustsByUkprnsRequest { Ukprns = new string[] { missingTrustUkprn } };

            var result = _controller.GetByUkprns(getTrustsByUkprnsRequest);

            result.Result.Should().BeOfType(typeof(NotFoundResult));
        }

        [Fact]
        public void GetByUkprns_WhenGivenCorrectUkprns_ReturnsAListOfTrusts()
        {
            var ukprns = new string[] { "12345678", "23456789" };
            var trustsResponse = Builder<TrustResponse>.CreateListOfSize(ukprns.Length).Build();
            var trustsApiResponse = new ApiResponseV2<TrustResponse>(trustsResponse, null);
            _mockGetTrustsByUkprnsUseCase.Setup(g => g.Execute(It.IsAny<GetTrustsByUkprnsRequest>())).Returns(() => trustsResponse);
            var getTrustsByUrnsRequest = new GetTrustsByUkprnsRequest { Ukprns = ukprns };

            var result = _controller.GetByUkprns(getTrustsByUrnsRequest);

            result.Result.Should().BeEquivalentTo(new OkObjectResult(trustsApiResponse));
            _mockGetTrustsByUkprnsUseCase.Verify(mock => mock.Execute(getTrustsByUrnsRequest), Times.Once());
        }

        [Fact]
        public void GetByUkprns_WhenGetRelatedEstablishmentsIsFalse_ReturnsAListOfTrusts()
        {
            var ukprns = new string[] { "12345678", "23456789" };
            var trustsResponse = Builder<TrustResponse>.CreateListOfSize(ukprns.Length).Build();
            var trustsApiResponse = new ApiResponseV2<TrustResponse>(trustsResponse, null);
            _mockGetTrustsByUkprnsUseCase.Setup(g => g.Execute(It.IsAny<GetTrustsByUkprnsRequest>())).Returns(() => trustsResponse);
            var getTrustsByUrnsRequest = new GetTrustsByUkprnsRequest { Ukprns = ukprns, GetRelatedEstablishments = false };

            var result = _controller.GetByUkprns(getTrustsByUrnsRequest);
            result.Result.Should().BeEquivalentTo(new OkObjectResult(trustsApiResponse));
            _mockGetTrustsByUkprnsUseCase.Verify(mock => mock.Execute(getTrustsByUrnsRequest), Times.Once());
        }
    }
}
