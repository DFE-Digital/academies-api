using FizzWare.NBuilder;
using FluentAssertions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using TramsDataApi.Controllers.V2;
using TramsDataApi.RequestModels.CaseActions.SRMA;
using TramsDataApi.ResponseModels;
using TramsDataApi.ResponseModels.CaseActions.SRMA;
using TramsDataApi.UseCases;
using Xunit;

namespace TramsDataApi.Test.Controllers
{
    public class SRMAControllerTests
    {
        private readonly Mock<ILogger<SRMAController>> _mockLogger;

        public SRMAControllerTests()
        {
            _mockLogger = new Mock<ILogger<SRMAController>>();
        }

        [Fact]
        public void Create_ReturnsApiSingleResponseWithNewSRMA()
        {
            var status = Enums.SRMAStatus.Deployed;
            var datetOffered = DateTime.Now.AddDays(-5);

            var mockUseCase = new Mock<IUseCase<CreateSRMARequest, CreateSRMAResponse>>();

            var response = Builder<CreateSRMAResponse>
                .CreateNew()
                .With(r => r.Status = status)
                .With(r => r.DateOffered = datetOffered)
                .Build();

            var expectedResponse = new ApiSingleResponseV2<CreateSRMAResponse>(response);

            mockUseCase
                .Setup(x => x.Execute(It.IsAny<CreateSRMARequest>()))
                .Returns(response);

            var controller = new SRMAController(_mockLogger.Object, mockUseCase.Object);

            var result = controller.Create(new CreateSRMARequest
            {
                DateOffered = datetOffered,
                Status = status
            });

            result.Result.Should().BeEquivalentTo(new ObjectResult(expectedResponse) {  StatusCode = StatusCodes.Status201Created });
        }

      
    }
}