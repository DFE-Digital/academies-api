using AutoFixture;
using FluentAssertions;
using TramsDataApi.DatabaseModels.Concerns.Case.Management.Actions.Decisions;
using Xunit;

namespace TramsDataApi.Test.DatabaseModels.Concerns
{
    public class DecisionTypeTests
    {
        [Fact]
        public void CanConstruct_DecisionType()
        {
            var fixture = new Fixture();
            var sut = fixture.Create<DecisionType>();
            sut.Should().NotBeNull();
        }

        [Fact]
        public void DecisionType_Properties_SetByConstructor()
        {
            var fixture = new Fixture();
            var expectedId = Enums.Concerns.DecisionType.EsfaApproval;
            var expectedDecisionId = fixture.Create<int>();
            var sut = new DecisionType(expectedId) { DecisionId = expectedDecisionId };

            sut.DecisionTypeId.Should().Be(expectedId);
            sut.DecisionId.Should().Be(expectedDecisionId);

        }
    }
}
