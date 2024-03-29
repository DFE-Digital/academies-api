using System.Collections.Generic;
using FizzWare.NBuilder;
using FizzWare.NBuilder.PropertyNaming;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using TramsDataApi.Controllers;
using TramsDataApi.ResponseModels;
using TramsDataApi.UseCases;
using Xunit;

namespace TramsDataApi.Test.Controllers
{
    public class TrustsControllerTests
    {
        private readonly Mock<ILogger<TrustsController>> mockLogger;

        public TrustsControllerTests()
        {
            BuilderSetup.SetDefaultPropertyName(new RandomValuePropertyNamer(new BuilderSettings()));
            mockLogger = new Mock<ILogger<TrustsController>>();
        }
        
        [Fact]
        public void GetTrustsByUkPrn_ReturnsNotFoundResult_WhenNoTrustsFound()
        {
            var getTrustsByUkprn = new Mock<IGetTrustByUkprn>();
            var ukprn = "mockukprn";
            getTrustsByUkprn.Setup(g => g.Execute(ukprn)).Returns(() => null);

            var controller = new TrustsController(getTrustsByUkprn.Object, new Mock<ISearchTrusts>().Object, mockLogger.Object);
            var result = controller.GetTrustByUkprn(ukprn);

            result.Result.Should().BeOfType(typeof(NotFoundResult));
        }

        [Fact]
        public void GetTrustsByUkprn_ReturnsTrustResponse_WhenTrustFound()
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
            var getTrustByUkprn = new Mock<IGetTrustByUkprn>();
            getTrustByUkprn.Setup(g => g.Execute(ukprn)).Returns(trustResponse);
            
            var controller = new TrustsController(getTrustByUkprn.Object, new Mock<ISearchTrusts>().Object, mockLogger.Object);
            var result = controller.GetTrustByUkprn(ukprn);

            result.Result.Should().BeEquivalentTo(new OkObjectResult(trustResponse));
        }
        
        [Fact]
        public void SearchTrusts_ReturnsEmptySetOfTrustSummaries_WhenNoTrustsFound()
        {
            var groupName = "Mockgroupname";
            var ukprn = "Mockurn";
            var companiesHouseNumber = "Mockcompanieshousenumber";

            var searchTrusts = new Mock<ISearchTrusts>();
            searchTrusts.Setup(s => s.Execute(1, 10, groupName, ukprn, companiesHouseNumber, true))
                .Returns((new List<TrustSummaryResponse>(), 0));

            var controller = new TrustsController(new Mock<IGetTrustByUkprn>().Object, searchTrusts.Object, mockLogger.Object);
            var result = controller.SearchTrusts(groupName, ukprn, companiesHouseNumber);

            result.Result.Should().BeEquivalentTo(new OkObjectResult(new List<TrustSummaryResponse>()));
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
            
            var searchTrusts = new Mock<ISearchTrusts>();
            searchTrusts.Setup(s => s.Execute(1, 10, groupName, null, companiesHouseNumber, true))
                .Returns((expectedTrustSummaries, expectedTrustSummaries.Count));

            var controller = new TrustsController(new Mock<IGetTrustByUkprn>().Object, searchTrusts.Object, mockLogger.Object);
            var result = controller.SearchTrusts(groupName, null, companiesHouseNumber);

            result.Result.Should().BeEquivalentTo(new OkObjectResult(expectedTrustSummaries));
        }
        
        
        [Fact]
        public void SearchTrusts_ByUrn_ReturnsListOfTrustSummaries_WhenTrustsAreFound()
        {
            var ukprn = "Mockurn";

            var expectedTrustSummaries = Builder<TrustSummaryResponse>.CreateListOfSize(5)
                .All()
                .With(g => g.Ukprn = ukprn)
                .Build();
            
            var searchTrusts = new Mock<ISearchTrusts>();
            searchTrusts.Setup(s => s.Execute(1, 10, null, ukprn, null, true))
                .Returns((expectedTrustSummaries, expectedTrustSummaries.Count));

            var controller = new TrustsController(new Mock<IGetTrustByUkprn>().Object, searchTrusts.Object, mockLogger.Object);
            var result = controller.SearchTrusts(null, ukprn, null);

            result.Result.Should().BeEquivalentTo(new OkObjectResult(expectedTrustSummaries));
        }

        [Fact]
        public void SearchTrusts_WithNoParams_ReturnsAllTrusts()
        {
            var expectedTrustSummaries = Builder<TrustSummaryResponse>.CreateListOfSize(5).Build();
            
            var searchTrusts = new Mock<ISearchTrusts>();
            searchTrusts.Setup(s => s.Execute(1, 10, null, null, null, true))
                .Returns((expectedTrustSummaries, expectedTrustSummaries.Count));

            var controller = new TrustsController(new Mock<IGetTrustByUkprn>().Object, searchTrusts.Object, mockLogger.Object);
            var result = controller.SearchTrusts(null, null, null);

            result.Result.Should().BeEquivalentTo(new OkObjectResult(expectedTrustSummaries));
        }
    }
}

