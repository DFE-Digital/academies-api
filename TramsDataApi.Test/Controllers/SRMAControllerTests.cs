using FizzWare.NBuilder;
using FluentAssertions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using TramsDataApi.Controllers.V2;
using TramsDataApi.DatabaseModels;
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
        private readonly Mock<IUseCase<int, SRMAResponse>> _mockGetSRMAById;
        private readonly SRMAController controllerSUT;

        public SRMAControllerTests()
        {
            _mockLogger = new Mock<ILogger<SRMAController>>();
            _mockCreateSRMAUseCase = new Mock<IUseCase<CreateSRMARequest, SRMAResponse>>();
            _mockGetSRMAsByCaseId = new Mock<IUseCase<int, ICollection<SRMAResponse>>>();
            _mockGetSRMAById = new Mock<IUseCase<int, SRMAResponse>>();

            controllerSUT = new SRMAController(_mockLogger.Object, _mockCreateSRMAUseCase.Object, _mockGetSRMAsByCaseId.Object, _mockGetSRMAById.Object);
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

            result.Result.Should().BeEquivalentTo(new ObjectResult(expectedResponse) { StatusCode = StatusCodes.Status201Created });
        }

        [Fact]
        public void GetSRMAsByCaseId_ReturnsMatchingSRMA_WhenGivenCaseId()
        {
            var caseId = 123;

            var matchingSRMA = new SRMACase
            {
                CaseId = caseId,
                Notes = "match"
            };

            var srmas = new List<SRMACase> {
                matchingSRMA,
                new SRMACase {
                    CaseId = 222,
                    Notes = "SRMA 1"
                },
                new SRMACase {
                    CaseId = 456,
                    Notes = "SRMA 2"
                }
            };

            var srmaResponse = Builder<SRMAResponse>
                .CreateNew()
                .With(r => r.CaseId = matchingSRMA.CaseId)
                .With(r => r.Notes = matchingSRMA.Notes)
                .Build();

            var collection = new List<SRMAResponse> { srmaResponse };

            _mockGetSRMAsByCaseId
                .Setup(x => x.Execute(caseId))
                .Returns(collection);

            OkObjectResult controllerResponse = controllerSUT.GetSRMAsByCaseId(caseId).Result as OkObjectResult;

            var  actualResult = controllerResponse.Value as ApiSingleResponseV2<ICollection<SRMAResponse>>;

            actualResult.Data.Should().NotBeNull();
            actualResult.Data.Count.Should().Be(1);
            actualResult.Data.First().CaseId.Should().Be(caseId);
        }

        //[Fact]
        //public void GetSRMAsById_ReturnsMatchingSRMA_WhenGivenSRMAId()
        //{
        //    var srmaId = 123;

        //    var matchingSRMA = new SRMACase
        //    {
        //        Id = srmaId,
        //        Notes = "match"
        //    };

        //    var srmas = new List<SRMACase> {
        //        matchingSRMA,
        //        new SRMACase {
        //            Id = 222,
        //            Notes = "SRMA 1"
        //        },
        //        new SRMACase {
        //            Id = 456,
        //            Notes = "SRMA 2"
        //        }
        //    };

        //    var srmaResponse = Builder<SRMAResponse>
        //        .CreateNew()
        //        .With(r => r.Id = matchingSRMA.Id)
        //        .With(r => r.Notes = matchingSRMA.Notes)
        //        .Build();

        //    _mockGetSRMAById
        //        .Setup(x => x.Execute(srmaId))
        //        .Returns(srmaResponse);

        //    OkObjectResult controllerResponse = controllerSUT.GetSRMAById(srmaId).Result as OkObjectResult;

        //    var actualResult = controllerResponse.Value as ApiSingleResponseV2<SRMAResponse>;

        //    actualResult.Data.Should().NotBeNull();
        //    actualResult.Data.Id.Should().Be(srmaId);
        //}
    }
}