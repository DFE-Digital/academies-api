using FizzWare.NBuilder;
using FluentAssertions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using TramsDataApi.Controllers.V2;
using TramsDataApi.RequestModels.ApplyToBecome;
using TramsDataApi.ResponseModels;
using TramsDataApi.ResponseModels.ApplyToBecome;
using TramsDataApi.UseCases;
using Xunit;

namespace TramsDataApi.Test.Controllers
{
    public class A2BSchoolLoanControllerTests
    {
        private readonly Mock<ILogger<A2BSchoolLoanController>> _mockLogger;

        public A2BSchoolLoanControllerTests()
        {
            _mockLogger = new Mock<ILogger<A2BSchoolLoanController>>();

        }

        [Fact]
        public void Create_Returns201_WithCreatedObject_WhenSchoolLoanCreated()
        {
            var request = Builder<A2BSchoolLoanCreateRequest>.CreateNew().Build();
            var expectedSchoolLoanResponse =  new A2BSchoolLoanResponse
            {
                SchoolLoanId = request.SchoolLoanId,
                SchoolLoanAmount = request.SchoolLoanAmount,
                SchoolLoanPurpose = request.SchoolLoanPurpose,
                SchoolLoanProvider = request.SchoolLoanProvider,
                SchoolLoanInterestRate = request.SchoolLoanInterestRate,
                SchoolLoanSchedule = request.SchoolLoanSchedule
            };

            var expectedResponse = new ApiSingleResponseV2<A2BSchoolLoanResponse>(expectedSchoolLoanResponse);
            var expectedResult = new ObjectResult(expectedResponse) {StatusCode = StatusCodes.Status201Created};
            
            var mockUseCase = new Mock<ICreateA2BSchoolLoan>();
            mockUseCase.Setup(u => u.Execute(It.IsAny<A2BSchoolLoanCreateRequest>())).Returns(expectedSchoolLoanResponse);
            
            var controller = new A2BSchoolLoanController(_mockLogger.Object, mockUseCase.Object, new Mock<IGetA2BSchoolLoan>().Object);

            var controllerResponse = controller.Create(request);

            controllerResponse.Result.Should().BeEquivalentTo(expectedResult);
        }
        
        [Fact]
        public void GetSchoolLoanByLoanId_ReturnsApiSingleResponseWithA2BSchoolLoanWhenStatusExists()
        {
            const string loanId = "9002";
            var mockUseCase = new Mock<IGetA2BSchoolLoan>();

            var response = Builder<A2BSchoolLoanResponse>
                .CreateNew()
                .With(r => r.SchoolLoanId = loanId)
                .Build();

            var expectedResponse = new ApiSingleResponseV2<A2BSchoolLoanResponse>(response);

            mockUseCase
                .Setup(x => x.Execute(It.IsAny<string>()))
                .Returns(response);

            var controller = new A2BSchoolLoanController(_mockLogger.Object, new Mock<ICreateA2BSchoolLoan>().Object, mockUseCase.Object);

            var result = controller.GetLoanByLoanId(loanId);

            result.Result.Should().BeEquivalentTo(new OkObjectResult(expectedResponse));
        }
    }
}