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
using TramsDataApi.ResponseModels;
using TramsDataApi.UseCases;
using Xunit;

namespace TramsDataApi.Test.Controllers
{
    public class TrustsControllerV2Tests
    {
        private readonly Mock<ILogger<TrustsController>> _mockLogger;

        public TrustsControllerV2Tests()
        {
            BuilderSetup.SetDefaultPropertyName(new RandomValuePropertyNamer(new BuilderSettings()));
            _mockLogger = new Mock<ILogger<TrustsController>>();
        }
        
        [Fact]
        public void GetTrustsByUkPrn_ReturnsNotFoundResult_WhenNoTrustsFound()
        {
            var getTrustsByUkprn = new Mock<IGetTrustByUkprn>();
            var ukprn = "mockukprn";
            getTrustsByUkprn.Setup(g => g.Execute(ukprn)).Returns(() => null);

            var controller = new TrustsController(getTrustsByUkprn.Object, new Mock<ISearchTrusts>().Object, _mockLogger.Object);
            var result = controller.GetTrustByUkPrn(ukprn);
            
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
            
            var getTrustByUkPrn = new Mock<IGetTrustByUkprn>();
            getTrustByUkPrn.Setup(g => g.Execute(ukprn)).Returns(trustResponse);
            
            var controller = new TrustsController(getTrustByUkPrn.Object, new Mock<ISearchTrusts>().Object, _mockLogger.Object);
            var result = controller.GetTrustByUkPrn(ukprn);

            var expected = new OkObjectResult(new ApiResponseV2<TrustResponse>(trustResponse));
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

            var searchTrusts = new Mock<ISearchTrusts>();
            searchTrusts.Setup(s => s.Execute(1, 10, groupName, ukprn, companiesHouseNumber))
                .Returns(new List<TrustSummaryResponse>());

            var controller = new TrustsController(new Mock<IGetTrustByUkprn>().Object, searchTrusts.Object, _mockLogger.Object);
            var result = controller.SearchTrusts(groupName, ukprn, companiesHouseNumber, 1, 10);
            
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
            
            var searchTrusts = new Mock<ISearchTrusts>();
            searchTrusts.Setup(s => s.Execute(1, 10, groupName, null, companiesHouseNumber))
                .Returns(expectedTrustSummaries);

            var controller = new TrustsController(new Mock<IGetTrustByUkprn>().Object, searchTrusts.Object, _mockLogger.Object);
            var result = controller.SearchTrusts(groupName, null, companiesHouseNumber, 1, 10);

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
            
            var searchTrusts = new Mock<ISearchTrusts>();
            searchTrusts.Setup(s => s.Execute(1, 10, null, ukprn, null))
                .Returns(expectedTrustSummaries);

            var controller = new TrustsController(new Mock<IGetTrustByUkprn>().Object, searchTrusts.Object, _mockLogger.Object);
            var result = controller.SearchTrusts(null, ukprn, null, 1, 10);
            
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
            var searchTrusts = new Mock<ISearchTrusts>();
            searchTrusts.Setup(s => s.Execute(1, 10, null, null, null))
                .Returns(expectedTrustSummaries);

            var controller = new TrustsController(new Mock<IGetTrustByUkprn>().Object, searchTrusts.Object, _mockLogger.Object);
            var result = controller.SearchTrusts(null, null, null, 1, 10);

            var expected = new OkObjectResult(new ApiResponseV2<TrustSummaryResponse>(expectedTrustSummaries, expectedPaging));
            result.Result.Should().BeEquivalentTo(expected);
        }

        [Fact]
        public void SearchTrusts_WithMultiplePagesOfResults_ReturnsAllTrustsWithPagingResponseForNextPage()
        {
            var expectedTrustSummaries = Builder<TrustSummaryResponse>.CreateListOfSize(20).Build();
            var controllerContext = new ControllerContext { HttpContext = new DefaultHttpContext() };
            
            var expectedPaging = new PagingResponse
            {
                Page = 1,
                RecordCount = 10,
                NextPageUrl = "?page=2&count=10"
            };
            
            var searchTrusts = new Mock<ISearchTrusts>();
            searchTrusts
                .Setup(s => s.Execute(1, 10, null, null, null))
                .Returns(expectedTrustSummaries.Take(10).ToList());
            
            var controller = new TrustsController(new Mock<IGetTrustByUkprn>().Object, searchTrusts.Object, _mockLogger.Object)
            {
                ControllerContext = controllerContext
            };
            var result = controller.SearchTrusts(null, null, null, 1, 10);

            var expected = new OkObjectResult(new ApiResponseV2<TrustSummaryResponse>(expectedTrustSummaries.Take(10), expectedPaging));
            result.Result.Should().BeEquivalentTo(expected);
        }
    }
}

