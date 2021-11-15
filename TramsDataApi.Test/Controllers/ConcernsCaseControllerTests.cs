using System.Collections.Generic;
using FizzWare.NBuilder;
using FluentAssertions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using TramsDataApi.Controllers;
using TramsDataApi.Controllers.V2;
using TramsDataApi.RequestModels;
using TramsDataApi.ResponseModels;
using TramsDataApi.UseCases;
using Xunit;

namespace TramsDataApi.Test.Controllers
{
    public class ConcernsCaseControllerTests
    {
        private Mock<ILogger<ConcernsCaseController>> mockLogger = new Mock<ILogger<ConcernsCaseController>>();
        
        [Fact]
        public void CreateComcernsCase_Returns201WhenSuccessfullyCreatesAConcernsCase()
        {
            var createConcernsCase = new Mock<ICreateConcernsCase>();
            var createConcernsCaseRequest = Builder<ConcernCaseRequest>
                .CreateNew().Build();

            var concernsCaseResponse = Builder<ConcernsCaseResponse>
                .CreateNew().Build();

            createConcernsCase.Setup(a => a.Execute(createConcernsCaseRequest))
                .Returns(concernsCaseResponse);

            var controller = new ConcernsCaseController(
                mockLogger.Object,
                createConcernsCase.Object, 
                null, 
                null
            );
            
            var result = controller.Create(createConcernsCaseRequest);
            
            var expected = new ApiSingleResponseV2<ConcernsCaseResponse>(concernsCaseResponse);
            
            result.Result.Should().BeEquivalentTo(new ObjectResult(expected) {StatusCode = StatusCodes.Status201Created});
        }
        
        [Fact]
        public void GetConcernsCaseByUrn_ReturnsNotFound_WhenConcernsCaseIsNotFound()
        {
            var urn = 100;
            
            var getConcernsCaseByUrn = new Mock<IGetConcernsCaseByUrn>();
            

            getConcernsCaseByUrn.Setup(a => a.Execute(urn))
                .Returns(() => null);

            var controller = new ConcernsCaseController(
                mockLogger.Object,
                null, 
                getConcernsCaseByUrn.Object, 
                null
            );
            
            var result = controller.GetByUrn(urn);
            result.Result.Should().BeEquivalentTo(new NotFoundResult());
        }
        
        [Fact]
        public void GetConcernsCaseByUrn_Returns200AndTheFoundConcernsCase_WhenSuccessfullyGetsAConcernsCaseByUrn()
        {
            var getConcernsCaseByUrn = new Mock<IGetConcernsCaseByUrn>();
            var urn = 123;

            var concernsCaseResponse = Builder<ConcernsCaseResponse>
                .CreateNew().Build();

            getConcernsCaseByUrn.Setup(a => a.Execute(urn))
                .Returns(concernsCaseResponse);

            var controller = new ConcernsCaseController(
                mockLogger.Object,
                null, 
                getConcernsCaseByUrn.Object, 
                null
            );
            
            var result = controller.GetByUrn(urn);
            
            var expected = new ApiSingleResponseV2<ConcernsCaseResponse>(concernsCaseResponse);
            
            result.Result.Should().BeEquivalentTo(new OkObjectResult(expected));
        }

        [Fact]
        public void GetConcernsCaseByTrustUkprn_Returns200AndTheFoundConcernsCase_WhenSuccessfullyGetsAConcernsCaseByTrustUkprn()
        {
            var getConcernsCaseByTrustUkprn = new Mock<IGetConcernsCaseByTrustUkprn>();
            var trustUkprn = "100008";

            var concernsCaseResponse = Builder<ConcernsCaseResponse>
                .CreateNew().Build();

            getConcernsCaseByTrustUkprn.Setup(a => a.Execute(trustUkprn, 1, 10))
                .Returns(new List<ConcernsCaseResponse>{concernsCaseResponse});

            var controller = new ConcernsCaseController(
                mockLogger.Object,
                null, 
                null, 
                getConcernsCaseByTrustUkprn.Object
            );
            
            var result = controller.GetByTrustUkprn(trustUkprn, 1, 10);
            var expectedPagingResponse = new PagingResponse
            {
                Page = 1,
                RecordCount = 1,
                NextPageUrl = null
            };
            var expected = new ApiResponseV2<ConcernsCaseResponse>(new List<ConcernsCaseResponse>{concernsCaseResponse}, expectedPagingResponse);
            
            result.Result.Should().BeEquivalentTo(new OkObjectResult(expected));
        }
    }
}