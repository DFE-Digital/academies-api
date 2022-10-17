using AutoFixture;
using FluentAssertions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using System.Threading;
using System.Threading.Tasks;
using TramsDataApi.Controllers.V2;
using TramsDataApi.Enums.Concerns;
using TramsDataApi.RequestModels.Concerns.Decisions;
using TramsDataApi.ResponseModels;
using TramsDataApi.ResponseModels.Concerns.Decisions;
using TramsDataApi.UseCases;
using Xunit;

namespace TramsDataApi.Test.Controllers
{
    public class ConcernsCaseDecisionControllerTests
    {
        private readonly Mock<ILogger<ConcernsCaseDecisionController>> _mockLogger = new Mock<ILogger<ConcernsCaseDecisionController>>();

        [Fact]
        public async Task CreateConcernsCaseDecision_Returns201WhenSuccessfullyCreatesAConcernsCase()
        {
            var testBuilder = new TestBuilder();

            var createDecisionRequest = testBuilder.Fixture.Create<CreateDecisionRequest>();
            var createDecisionResponse = testBuilder.Fixture.Create<CreateDecisionResponse>();

            testBuilder.CreateDecisionUseCase.Setup(a => a.Execute(createDecisionRequest, It.IsAny<CancellationToken>())).ReturnsAsync(createDecisionResponse);

            var sut = testBuilder.BuildSut();
            var result = await sut.Create(123, createDecisionRequest, CancellationToken.None);

            var expected = new ApiSingleResponseV2<CreateDecisionResponse>(createDecisionResponse);
            result.Result.Should().BeEquivalentTo(new ObjectResult(expected) { StatusCode = StatusCodes.Status201Created });
        }

        [Fact]
        public async Task CreateConcernsCaseDecision_ReturnsBadRequest_When_CreateDecisionRequest_IsInvalid()
        {
            var testBuilder = new TestBuilder();
            
            var createDecisionRequest = testBuilder.Fixture.Build<CreateDecisionRequest>()
                .With(x => x.DecisionTypes, () => new DecisionType[] { 0 })
                .Create();

            var createDecisionResponse = testBuilder.Fixture.Create<CreateDecisionResponse>();

            testBuilder.CreateDecisionUseCase.Setup(a => a.Execute(createDecisionRequest, It.IsAny<CancellationToken>())).ReturnsAsync(createDecisionResponse);

            var sut = testBuilder.BuildSut();
            var result = await sut.Create(123, createDecisionRequest, CancellationToken.None);

            result.Result.Should().BeEquivalentTo(new BadRequestResult());
        }

        [Fact]
        public async Task GetById_When_Invalid_Urn_Returns_BadRequest()
        {
            var testBuilder = new TestBuilder();
            
            var sut = testBuilder.BuildSut();

            var result = await sut.GetById(0, 123, CancellationToken.None);
            result.Result.Should().BeEquivalentTo(new BadRequestResult());
        }

        [Fact]
        public async Task GetById_When_Invalid_DecisionId_Returns_BadRequest()
        {
            var testBuilder = new TestBuilder();
            
            var sut = testBuilder.BuildSut();

            var result = await sut.GetById(123, 0, CancellationToken.None);
            result.Result.Should().BeEquivalentTo(new BadRequestResult());
        }
        
        [Fact]
        public async Task GetById_When_Valid_DecisionId_Returns_DecisionResponse()
        {
            const int expectedConcernsCaseUrn = 123;
            const int expectedDecisionId = 456;

            var testBuilder = new TestBuilder();

            var expectedDecisionResponse = testBuilder.Fixture.Build<GetDecisionResponse>()
                .With(x => x.DecisionId, expectedDecisionId)
                .Create();

            testBuilder.GetDecisionUseCase.Setup(x => x.Execute(It.Is<GetDecisionRequest>(r => r.ConcernsCaseUrn == expectedConcernsCaseUrn && r.DecisionId == expectedDecisionId), It.IsAny<CancellationToken>())).ReturnsAsync(expectedDecisionResponse);
            
            // Act
            var sut = testBuilder.BuildSut();
            var actionResult = await sut.GetById(expectedConcernsCaseUrn, expectedDecisionId, CancellationToken.None);
            
            // Assert
            var okResult = Assert.IsType<OkObjectResult>(actionResult.Result);
            var expectedOkResult = new OkObjectResult(new ApiSingleResponseV2<GetDecisionResponse>(expectedDecisionResponse));
            okResult.Should().BeEquivalentTo(expectedOkResult);
        }

        private class TestBuilder
        {
            internal Mock<ILogger<ConcernsCaseDecisionController>> MockLogger;
            internal Mock<IUseCaseAsync<CreateDecisionRequest, CreateDecisionResponse>> CreateDecisionUseCase;
            internal Mock<IUseCaseAsync<GetDecisionRequest, GetDecisionResponse>> GetDecisionUseCase;
            internal Fixture Fixture;

            public TestBuilder()
            {
                Fixture = new Fixture();
                MockLogger = new Mock<ILogger<ConcernsCaseDecisionController>>();
                CreateDecisionUseCase = new Mock<IUseCaseAsync<CreateDecisionRequest, CreateDecisionResponse>>();            
                GetDecisionUseCase = new Mock<IUseCaseAsync<GetDecisionRequest, GetDecisionResponse>>();
            }

            internal ConcernsCaseDecisionController BuildSut()
            {
                return new ConcernsCaseDecisionController(MockLogger.Object, CreateDecisionUseCase.Object, GetDecisionUseCase.Object);
            }
        }
    }
}