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
using TramsDataApi.Factories.CaseActionFactories;
using TramsDataApi.Gateways;
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
        private readonly Mock<IUseCase<PatchSRMARequest, SRMAResponse>> _mockPatchSRMAUseCase;
        private readonly SRMAController controllerSUT;

        public SRMAControllerTests()
        {
            _mockLogger = new Mock<ILogger<SRMAController>>();
            _mockCreateSRMAUseCase = new Mock<IUseCase<CreateSRMARequest, SRMAResponse>>();
            _mockGetSRMAsByCaseId = new Mock<IUseCase<int, ICollection<SRMAResponse>>>();
            _mockGetSRMAById = new Mock<IUseCase<int, SRMAResponse>>();
            _mockPatchSRMAUseCase = new Mock<IUseCase<PatchSRMARequest, SRMAResponse>>();

            controllerSUT = new SRMAController(_mockLogger.Object, _mockCreateSRMAUseCase.Object, _mockGetSRMAsByCaseId.Object, 
                                               _mockGetSRMAById.Object, _mockPatchSRMAUseCase.Object);
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

        [Fact]
        public void GetSRMAsById_ReturnsMatchingSRMA_WhenGivenSRMAId()
        {
            var srmaId = 123;

            var matchingSRMA = new SRMACase
            {
                Id = srmaId,
                Notes = "match"
            };

            var srmas = new List<SRMACase> {
                matchingSRMA,
                new SRMACase {
                    Id = 222,
                    Notes = "SRMA 1"
                },
                new SRMACase {
                    Id = 456,
                    Notes = "SRMA 2"
                }
            };

            var srmaResponse = Builder<SRMAResponse>
                .CreateNew()
                .With(r => r.Id = matchingSRMA.Id)
                .With(r => r.Notes = matchingSRMA.Notes)
                .Build();

            _mockGetSRMAById
                .Setup(x => x.Execute(srmaId))
                .Returns(srmaResponse);

            OkObjectResult controllerResponse = controllerSUT.GetSRMAById(srmaId).Result as OkObjectResult;

            var actualResult = controllerResponse.Value as ApiSingleResponseV2<SRMAResponse>;

            actualResult.Data.Should().NotBeNull();
            actualResult.Data.Id.Should().Be(srmaId);
        }

        [Fact]
        public void UpdateStatus_ReturnsUpdatedSRMA_WhenGivenNewSRMAStatus()
        {
            var srmaId = 123;
            var startingStatus = Enums.SRMAStatus.TrustConsidering;
            var targetStatus = Enums.SRMAStatus.Deployed;

            var srmaModel = new SRMACase
            {
                Id = srmaId,
                StatusId = (int)startingStatus
            };

            SRMACase updatedByDelegate = null;

            _mockPatchSRMAUseCase.Setup(m => m.Execute(It.IsAny<PatchSRMARequest>()))
                 .Callback<PatchSRMARequest>(req =>
                 {
                    updatedByDelegate = req.Delegate(srmaModel);
                 });
                 
            controllerSUT.UpdateStatus(srmaId, targetStatus);

            updatedByDelegate.Should().NotBeNull();
            updatedByDelegate.StatusId.Should().Be((int)targetStatus);
        }


        [Fact]
        public void UpdateReason_ReturnsUpdatedSRMA_WhenGivenNewSRMAReason()
        {
            var srmaId = 123;
            var startingReason = Enums.SRMAReasonOffered.OfferLinked;
            var targetReason = Enums.SRMAReasonOffered.AMSDIntervention;

            var srmaModel = new SRMACase
            {
                Id = srmaId,
                ReasonId = (int)startingReason
            };

            SRMACase updatedByDelegate = null;

            _mockPatchSRMAUseCase.Setup(m => m.Execute(It.IsAny<PatchSRMARequest>()))
                 .Callback<PatchSRMARequest>(req =>
                 {
                     updatedByDelegate = req.Delegate(srmaModel);
                 });

            controllerSUT.UpdateReason(srmaId, targetReason);

            updatedByDelegate.Should().NotBeNull();
            updatedByDelegate.ReasonId.Should().Be((int)targetReason);
        }

        [Fact]
        public void UpdateDateOffered_ReturnsUpdatedSRMA_WhenGivenNewOfferedDate()
        {
            var srmaId = 123;
            var startingOfferedDate = DateTime.Now.AddDays(-10);
            var targetOfferedDate = DateTime.Now.AddDays(-5);

            var srmaModel = new SRMACase
            {
                Id = srmaId,
                DateOffered = startingOfferedDate
            };

            SRMACase updatedByDelegate = null;

            _mockPatchSRMAUseCase.Setup(m => m.Execute(It.IsAny<PatchSRMARequest>()))
                 .Callback<PatchSRMARequest>(req =>
                 {
                     updatedByDelegate = req.Delegate(srmaModel);
                 });

            controllerSUT.UpdateOfferedDate(srmaId, targetOfferedDate);

            updatedByDelegate.Should().NotBeNull();
            updatedByDelegate.DateOffered.Should().Be(targetOfferedDate);
        }

        [Fact]
        public void UpdateNotes_ReturnsUpdatedSRMA_WhenGivenNewNotes()
        {
            var srmaId = 123;
            var startingNotes = "starting notes";
            var targetNotes = "target notes";

            var srmaModel = new SRMACase
            {
                Id = srmaId,
                Notes = startingNotes
            };

            SRMACase updatedByDelegate = null;

            _mockPatchSRMAUseCase.Setup(m => m.Execute(It.IsAny<PatchSRMARequest>()))
                 .Callback<PatchSRMARequest>(req =>
                 {
                     updatedByDelegate = req.Delegate(srmaModel);
                 });

            controllerSUT.UpdateNotes(srmaId, targetNotes);

            updatedByDelegate.Should().NotBeNull();
            updatedByDelegate.Notes.Should().Be(targetNotes);
        }

        [Fact]
        public void UpdateVisitDates_ReturnsUpdatedSRMA_WhenGivenNewDates()
        {
            var srmaId = 123;
            var startingVisitStartDate = DateTime.Now.AddDays(-20);
            
            var targetVisitStartDate = DateTime.Now.AddDays(-10);
            var targetVisitEndDate = DateTime.Now.AddDays(-5);

            var srmaModel = new SRMACase
            {
                Id = srmaId,
                StartDateOfVisit = startingVisitStartDate,
                EndDateOfVisit = null
            };

            SRMACase updatedByDelegate = null;

            _mockPatchSRMAUseCase.Setup(m => m.Execute(It.IsAny<PatchSRMARequest>()))
                 .Callback<PatchSRMARequest>(req =>
                 {
                     updatedByDelegate = req.Delegate(srmaModel);
                 });

            controllerSUT.UpdateVisitDates(srmaId, targetVisitStartDate, targetVisitEndDate);

            updatedByDelegate.Should().NotBeNull();
            updatedByDelegate.StartDateOfVisit.Should().Be(targetVisitStartDate);
            updatedByDelegate.EndDateOfVisit.Should().Be(targetVisitEndDate);
        }

        [Fact]
        public void UpdateDateAccepted_ReturnsUpdatedSRMA_WhenGivenNewDate()
        {
            var srmaId = 123;
            var startingDateAccepted = DateTime.Now.AddDays(-20);

            var targetDateAccepted = DateTime.Now.AddDays(-10);

            var srmaModel = new SRMACase
            {
                Id = srmaId,
                DateAccepted = startingDateAccepted
            };

            SRMACase updatedByDelegate = null;

            _mockPatchSRMAUseCase.Setup(m => m.Execute(It.IsAny<PatchSRMARequest>()))
                 .Callback<PatchSRMARequest>(req =>
                 {
                     updatedByDelegate = req.Delegate(srmaModel);
                 });

            controllerSUT.UpdateDateAccepted(srmaId, targetDateAccepted);

            updatedByDelegate.Should().NotBeNull();
            updatedByDelegate.DateAccepted.Should().Be(targetDateAccepted);
        }


        [Fact]
        public void UpdateDateDateReportSent_ReturnsUpdatedSRMA_WhenGivenNewDate()
        {
            var srmaId = 123;
            var startingDateReportSent = DateTime.Now.AddDays(-20);

            var targetDateReportSent = DateTime.Now.AddDays(-10);

            var srmaModel = new SRMACase
            {
                Id = srmaId,
                DateReportSentToTrust = startingDateReportSent
            };

            SRMACase updatedByDelegate = null;

            _mockPatchSRMAUseCase.Setup(m => m.Execute(It.IsAny<PatchSRMARequest>()))
                 .Callback<PatchSRMARequest>(req =>
                 {
                     updatedByDelegate = req.Delegate(srmaModel);
                 });

            controllerSUT.UpdateDateReportSent(srmaId, targetDateReportSent);

            updatedByDelegate.Should().NotBeNull();
            updatedByDelegate.DateReportSentToTrust.Should().Be(targetDateReportSent);
        }
    }


}