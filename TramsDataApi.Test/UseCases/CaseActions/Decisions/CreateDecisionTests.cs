using AutoFixture;
using FluentAssertions;
using Moq;
using System;
using System.Linq;
using TramsDataApi.DatabaseModels;
using TramsDataApi.DatabaseModels.Concerns.Case.Management.Actions.Decisions;
using TramsDataApi.Factories.Concerns.Decisions;
using TramsDataApi.Gateways;
using TramsDataApi.RequestModels.Concerns.Decisions;
using TramsDataApi.ResponseModels.Concerns.Decisions;
using TramsDataApi.UseCases;
using TramsDataApi.UseCases.CaseActions.Decisions;
using Xunit;

namespace TramsDataApi.Test.UseCases.CaseActions.Decisions
{
    public class CreateDecisionTests
    {
        [Fact]
        public void CreateDecision_Implements_IUseCase()
        {
            typeof(CreateDecision).Should().BeAssignableTo<IUseCase<CreateDecisionRequest, CreateDecisionResponse>>();
        }

        [Fact]
        public void Execute_Throws_Exception_If_Request_IsNull()
        {
            var sut = new CreateDecision(Mock.Of<IConcernsCaseGateway>(), Mock.Of<IDecisionFactory>(), Mock.Of<ICreateDecisionResponseFactory>());

            Action action = () => sut.Execute(null);
            action.Should().Throw<ArgumentNullException>();

        }

        [Fact]
        public void Execute_When_Concerns_Case_NotFound_Throws_Exception()
        {
            var fixture = CreateFixture();

            var mockGateway = new Mock<IConcernsCaseGateway>();
            mockGateway.Setup(x => x.GetConcernsCaseByUrn(It.IsAny<int>()))
                .Returns(default(ConcernsCase));

            var request = fixture.Create<CreateDecisionRequest>();

            var sut = new CreateDecision(mockGateway.Object, Mock.Of<IDecisionFactory>(), Mock.Of<ICreateDecisionResponseFactory>());
            Action action = () => sut.Execute(request);

            action.Should().Throw<InvalidOperationException>().And.Message.Should()
                .Contain($"The concerns case for urn {request.ConcernsCaseUrn}, was not found");
        }
        
        [Fact]
        public void Execute_Adds_Decision()
        {
            var fixture = CreateFixture();

            var fakeConcernsCase = fixture.Create<ConcernsCase>();

            var request = fixture.Create<CreateDecisionRequest>();
            var fakeNewDecision = fixture.Create<Decision>();

            var mockGateway = new Mock<IConcernsCaseGateway>();
            mockGateway.Setup(x => x.GetConcernsCaseByUrn(request.ConcernsCaseUrn))
                .Returns(fakeConcernsCase);


            var mockDecisionFactory = new Mock<IDecisionFactory>();
            mockDecisionFactory.Setup(x => x.CreateDecision(fakeConcernsCase.Id, request))
                .Returns(fakeNewDecision);

            var fakeResponse = new CreateDecisionResponse(fakeConcernsCase.Urn, fixture.Create<int>());
            var mockResponseFactory = new Mock<ICreateDecisionResponseFactory>();
            mockResponseFactory.Setup(x => x.Create(fakeConcernsCase.Urn, fakeNewDecision.DecisionId))
                .Returns(fakeResponse);

            mockGateway.Setup(x => x.SaveConcernsCase(It.Is<ConcernsCase>(cc => cc.Decisions.First() == fakeNewDecision))).Returns(fakeConcernsCase);

            var sut = new CreateDecision(mockGateway.Object, mockDecisionFactory.Object, mockResponseFactory.Object);

            var result = sut.Execute(request);

            mockGateway.Verify(x => x.SaveConcernsCase(fakeConcernsCase), Times.Once);
            result.Should().Be(fakeResponse);
        }

        private static Fixture CreateFixture()
        {
            var fixture = new Fixture();
            fixture.Behaviors.Remove(new ThrowingRecursionBehavior());
            fixture.Behaviors.Add(new OmitOnRecursionBehavior());
            return fixture;
        }
    }
}
