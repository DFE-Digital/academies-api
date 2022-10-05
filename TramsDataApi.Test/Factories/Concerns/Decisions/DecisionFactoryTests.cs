using AutoFixture;
using FluentAssertions;
using TramsDataApi.Factories.Concerns.Decisions;
using TramsDataApi.RequestModels.Concerns.Decisions;
using Xunit;

namespace TramsDataApi.Test.Factories.Concerns.Decisions
{
    public class DecisionFactoryTests
    {
        [Fact]
        public void DecisionFactory_Create_CreatesDecision()
        {
            var fixture = new Fixture();
            var input = fixture.Create<CreateDecisionRequest>();

            var sut = new DecisionFactory();
            var decision = sut.CreateDecision(input);

            decision.Should().BeEquivalentTo(input,
                cfg => cfg.Excluding(x => x.ConcernsCaseUrn).Excluding(x => x.DecisionTypes));


            for (int i = 0; i < input.DecisionTypes.Length; i++)
            {
                decision.DecisionTypes[i].DecisionTypeId.Should().Be(input.DecisionTypes[i]);
            }
        }
    }
}
