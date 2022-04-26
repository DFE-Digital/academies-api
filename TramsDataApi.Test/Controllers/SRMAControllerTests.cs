using FizzWare.NBuilder;
using FluentAssertions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
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
        private readonly Mock<IUseCase<CreateSRMARequest, SRMAResponse>> _mockCreateSRMAUseCase;
        private readonly Mock<IUseCase<int, ICollection<SRMAResponse>>> _mockGetSRMAsByCaseId;
        private readonly SRMAController controllerSUT;

        public SRMAControllerTests()
        {
            _mockLogger = new Mock<ILogger<SRMAController>>();
            _mockCreateSRMAUseCase = new Mock<IUseCase<CreateSRMARequest, SRMAResponse>>();
            _mockGetSRMAsByCaseId = new Mock<IUseCase<int, ICollection<SRMAResponse>>>();

            controllerSUT = new SRMAController(_mockLogger.Object, _mockCreateSRMAUseCase.Object, _mockGetSRMAsByCaseId.Object);
        }

        [Fact]
        public void Create_ReturnsApiSingleResponseWithNewSRMA()
        {
            var status = Enums.SRMAStatus.Deployed;
            var datetOffered = DateTime.Now.AddDays(-5);

            var response = Builder<SRMAResponse>
                .CreateNew()
                .With(r => r.Status = status)
                .With(r => r.DateOffered = datetOffered)
                .Build();

            var expectedResponse = new ApiSingleResponseV2<SRMAResponse>(response);

            _mockCreateSRMAUseCase
                .Setup(x => x.Execute(It.IsAny<CreateSRMARequest>()))
                .Returns(response);

            var result = controllerSUT.Create(new CreateSRMARequest
            {
                DateOffered = datetOffered,
                Status = status
            });

            result.Result.Should().BeEquivalentTo(new ObjectResult(expectedResponse) {  StatusCode = StatusCodes.Status201Created });
        }

      
    }
}