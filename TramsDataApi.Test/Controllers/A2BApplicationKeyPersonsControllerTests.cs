using FizzWare.NBuilder;
using Microsoft.Extensions.Logging;
using Moq;
using FluentAssertions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TramsDataApi.Controllers.V2;
using TramsDataApi.RequestModels.ApplyToBecome;
using TramsDataApi.ResponseModels;
using TramsDataApi.ResponseModels.ApplyToBecome;
using TramsDataApi.UseCases;
using Xunit;

namespace TramsDataApi.Test.Controllers
{
    public class A2BApplicationKeyPersonsControllerTests
    {
        private readonly Mock<ILogger<A2BApplicationKeyPersonsController>> _mockLogger;

        public A2BApplicationKeyPersonsControllerTests()
        {
            _mockLogger = new Mock<ILogger<A2BApplicationKeyPersonsController>>();
        }

        [Fact]
        public void GetKeyPersonsByKeyPersonId_ReturnsApiSingleResponseWithA2BApplicationKeyPersonsWhenKeyPersonsExists()
        {
            var keyPersonId = 10001;
            var mockUseCase = new Mock<IGetA2BApplicationKeyPersons>();

            var response = Builder<A2BApplicationKeyPersonsResponse>
                .CreateNew()
                .With(r => r.KeyPersonId = keyPersonId)
                .Build();

            var expectedResponse = new ApiSingleResponseV2<A2BApplicationKeyPersonsResponse>(response);

            mockUseCase
                .Setup(x => x.Execute(It.IsAny<A2BApplicationKeyPersonsByIdRequest>()))
                .Returns(response);

            var controller = new A2BApplicationKeyPersonsController(_mockLogger.Object, mockUseCase.Object,new Mock<ICreateA2BApplicationKeyPersons>().Object);

            var result = controller.GetApplicationKeyPersonByKeyPersonId(keyPersonId);

            result.Result.Should().BeEquivalentTo(new OkObjectResult(expectedResponse));
        }

        [Fact]
        public void GetKeyPersonsByKeyPersonId_ReturnsNotFound_WhenApplicationKeyPersonsNotFound()
        {
            var expectedResponse = new NotFoundResult();
            var mockUseCase = new Mock<IGetA2BApplicationKeyPersons>();

            var controller = new A2BApplicationKeyPersonsController(_mockLogger.Object, mockUseCase.Object, new Mock<ICreateA2BApplicationKeyPersons>().Object);

            var result = controller.GetApplicationKeyPersonByKeyPersonId(10001);

            result.Result.Should().BeEquivalentTo(expectedResponse);
        }

        [Fact]
        public void Create_Returns201_WithCreatedObject_WhenApplicationKeyPersonsCreated()
        {
            var request = Builder<A2BApplicationKeyPersonsCreateRequest>.CreateNew().Build();
            var expectedKeyPersonsResponse =  new A2BApplicationKeyPersonsResponse
            {
                KeyPersonId = 10001, 
                Name = request.Name,
                KeyPersonDateOfBirth = request.KeyPersonDateOfBirth,
                KeyPersonBiography = request.KeyPersonBiography,
                KeyPersonCeoExecutive = request.KeyPersonCeoExecutive,
                KeyPersonChairOfTrust = request.KeyPersonChairOfTrust,
                KeyPersonFinancialDirector = request.KeyPersonFinancialDirector,
                KeyPersonFinancialDirectorTime = request.KeyPersonFinancialDirectorTime ,
                KeyPersonMember = request.KeyPersonMember,
                KeyPersonOther = request.KeyPersonOther ,
                KeyPersonTrustee = request.KeyPersonTrustee
            };

            var expectedResponse = new ApiSingleResponseV2<A2BApplicationKeyPersonsResponse>(expectedKeyPersonsResponse);
            var expectedResult = new ObjectResult(expectedResponse) {StatusCode = StatusCodes.Status201Created};
            
            var mockUseCase = new Mock<ICreateA2BApplicationKeyPersons>();
            mockUseCase.Setup(u => u.Execute(It.IsAny<A2BApplicationKeyPersonsCreateRequest>())).Returns(expectedKeyPersonsResponse);
            
            var controller = new A2BApplicationKeyPersonsController(_mockLogger.Object, new Mock<IGetA2BApplicationKeyPersons>().Object, mockUseCase.Object);

            var controllerResponse = controller.Create(request);

            controllerResponse.Result.Should().BeEquivalentTo(expectedResult);
        }
    }
}