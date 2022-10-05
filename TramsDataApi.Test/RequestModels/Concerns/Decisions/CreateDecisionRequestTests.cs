using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoFixture;
using FluentAssertions;
using TramsDataApi.Enums.Concerns;
using TramsDataApi.RequestModels.Concerns.Decisions;
using Xunit;

namespace TramsDataApi.Test.RequestModels.Concerns.Decisions
{
    public class CreateDecisionRequestTests
    {
        [Fact]
        public void IsValid_When_Invalid_DecisionType_Returns_False()
        {
            var fixture = new Fixture();
            var sut = fixture.Build<CreateDecisionRequest>()
                    .With(x => x.DecisionTypes, new Enums.Concerns.DecisionType [] {0})
                    .Create();

            sut.IsValid().Should().BeFalse();
        }

        [Fact]
        public void IsValid_When_Valid_DecisionType_Returns_True()
        {
            var fixture = new Fixture();
            var sut = fixture.Build<CreateDecisionRequest>()
                .With(x => x.DecisionTypes, new Enums.Concerns.DecisionType [] { DecisionType.EsfaApproval })
                .Create();

            sut.IsValid().Should().BeTrue();
        }
    }
}
