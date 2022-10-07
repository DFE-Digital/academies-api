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
            var fixture = new Fixture();
            var createDecisionUseCase = new Mock<IUseCaseAsync<CreateDecisionRequest, CreateDecisionResponse>>();
            var createDecisionRequest = fixture.Create<CreateDecisionRequest>();
            var createDecisionResponse = fixture.Create<CreateDecisionResponse>();

            createDecisionUseCase.Setup(a => a.Execute(createDecisionRequest, It.IsAny<CancellationToken>()))
                .ReturnsAsync(createDecisionResponse);

            var controller = new ConcernsCaseDecisionController(_mockLogger.Object, createDecisionUseCase.Object);

            var result = await controller.Create(123, createDecisionRequest, CancellationToken.None);

            var expected = new ApiSingleResponseV2<CreateDecisionResponse>(createDecisionResponse);

            result.Result.Should().BeEquivalentTo(new ObjectResult(expected) { StatusCode = StatusCodes.Status201Created });
        }

        [Fact]
        public async Task CreateConcernsCaseDecision_ReturnsBadRequest_When_CreateDecisionRequest_IsInvalid()
        {
            var fixture = new Fixture();
            var createDecisionUseCase = new Mock<IUseCaseAsync<CreateDecisionRequest, CreateDecisionResponse>>();
            var createDecisionRequest = fixture.Build<CreateDecisionRequest>()
                .With(x => x.DecisionTypes, () => new DecisionType[] { 0 })
                .Create();
            var createDecisionResponse = fixture.Create<CreateDecisionResponse>();

            createDecisionUseCase.Setup(a => a.Execute(createDecisionRequest, It.IsAny<CancellationToken>()))
                .ReturnsAsync(createDecisionResponse);

            var controller = new ConcernsCaseDecisionController(_mockLogger.Object, createDecisionUseCase.Object);

            var result = await controller.Create(123, createDecisionRequest, CancellationToken.None);
            result.Result.Should().BeEquivalentTo(new BadRequestResult());
        }
    }
}