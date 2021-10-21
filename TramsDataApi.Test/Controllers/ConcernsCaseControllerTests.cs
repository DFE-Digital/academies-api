using FizzWare.NBuilder;
using FluentAssertions;
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
                createConcernsCase.Object
            );
            
            var result = controller.Create(createConcernsCaseRequest);
            
            result.Result.Should().BeEquivalentTo(new CreatedAtActionResult("Create", null, null,concernsCaseResponse));
        }
    }
}