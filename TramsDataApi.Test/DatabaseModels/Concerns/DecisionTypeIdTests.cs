using AutoFixture;
using FluentAssertions;
using TramsDataApi.DatabaseModels.Concerns.Case.Management.Actions.Decisions;
using Xunit;

namespace TramsDataApi.Test.DatabaseModels.Concerns
{
    public class DecisionTypeIdTests
    {
        [Fact]
        public void CanConstruct_DecisionType()
        {
            var fixture = new Fixture();
            var sut = fixture.Create<DecisionTypeId>();
            sut.Should().NotBeNull();
        }

        [Fact]
        public void DecisionType_Properties_SetByConstructor()
        {
            var fixture = new Fixture();
            const string noticeToImproveNti = "Notice to Improve (NTI)";
            var expectedId = Enums.Concerns.DecisionType.EsfaApproval;
            var sut = new DecisionTypeId(expectedId, noticeToImproveNti);

            sut.Id.Should().Be(expectedId);
            sut.Name.Should().Be(noticeToImproveNti);
        }
    }
}
