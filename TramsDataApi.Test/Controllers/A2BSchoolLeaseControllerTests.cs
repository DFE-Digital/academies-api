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
    public class A2BSchoolLeaseControllerTests
    {
        private readonly Mock<ILogger<A2BSchoolLeaseController>> _mockLogger;

        public A2BSchoolLeaseControllerTests()
        {
            _mockLogger = new Mock<ILogger<A2BSchoolLeaseController>>();
        }

        [Fact]
        public void Create_Returns201_WithCreatedObject_WhenSchoolLeaseCreated()
        {
            var request = Builder<A2BSchoolLeaseCreateRequest>.CreateNew().Build();
            var expectedSchoolLeaseResponse =  new A2BSchoolLeaseResponse
            {
                SchoolLeaseId = request.SchoolLeaseId,
                SchoolLeaseTerm = request.SchoolLeaseTerm,
                SchoolLeaseRepaymentValue = request.SchoolLeaseRepaymentValue,
                SchoolLeaseInterestRate = request.SchoolLeaseInterestRate,
                SchoolLeasePaymentToDate = request.SchoolLeasePaymentToDate,
                SchoolLeasePurpose = request.SchoolLeasePurpose,
                SchoolLeaseValueOfAssets = request.SchoolLeaseValueOfAssets,
                SchoolLeaseResponsibleForAssets = request.SchoolLeaseResponsibleForAssets
            };

            var expectedResponse = new ApiSingleResponseV2<A2BSchoolLeaseResponse>(expectedSchoolLeaseResponse);
            var expectedResult = new ObjectResult(expectedResponse) {StatusCode = StatusCodes.Status201Created};
            
            var mockUseCase = new Mock<ICreateA2BSchoolLease>();
            mockUseCase.Setup(u => u.Execute(It.IsAny<A2BSchoolLeaseCreateRequest>())).Returns(expectedSchoolLeaseResponse);
            
            var controller = new A2BSchoolLeaseController(_mockLogger.Object, mockUseCase.Object, new Mock<IGetA2BSchoolLease>().Object);

            var controllerResponse = controller.Create(request);

            controllerResponse.Result.Should().BeEquivalentTo(expectedResult);
        }
        
        [Fact]
        public void GetSchoolLeaseByLeaseId_ReturnsApiSingleResponseWithA2BSchoolLeaseWhenStatusExists()
        {
            const string leaseId = "9002";
            var mockUseCase = new Mock<IGetA2BSchoolLease>();

            var response = Builder<A2BSchoolLeaseResponse>
                .CreateNew()
                .With(r => r.SchoolLeaseId = leaseId)
                .Build();

            var expectedResponse = new ApiSingleResponseV2<A2BSchoolLeaseResponse>(response);

            mockUseCase
                .Setup(x => x.Execute(It.IsAny<string>()))
                .Returns(response);

            var controller = new A2BSchoolLeaseController(_mockLogger.Object, new Mock<ICreateA2BSchoolLease>().Object, mockUseCase.Object);

            var result = controller.GetLeaseByLeaseId(leaseId);

            result.Result.Should().BeEquivalentTo(new OkObjectResult(expectedResponse));
        }
    }
}