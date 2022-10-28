using AutoFixture;
using FluentAssertions;
using System;
using System.Collections.Generic;
using TramsDataApi.DatabaseModels.Concerns.Case.Management.Actions.Decisions;
using Xunit;

namespace TramsDataApi.Test.DatabaseModels.Concerns
{
    public class DecisionStatusTests
    {
        [Fact]
        public void CanConstruct_DecisionStatus()
        {
            var fixture = new Fixture();
            var sut = fixture.Create<DecisionStatus>();
            sut.Should().NotBeNull();
        }

        [Theory]
        [MemberData(nameof(DecisionStatusTests.EnumValues))]
        public void DecisionStatus_Properties_SetByConstructor(Enums.Concerns.DecisionStatus status)
        {
            var fixture = new Fixture();
            var expectedId = status;
            var expectedDescription = fixture.Create<string>();
            var sut = new DecisionStatus(expectedId) { Name = expectedDescription };

            sut.Id.Should().Be("");
            sut.Name.Should().Be("");
        }

        [Fact]
        public void Given_Invalid_DecisionStatus_Constructor_Throws_Exception()
        {
            Action action = () => new DecisionStatus(0) { Name = "not allowed" };

            action.Should().ThrowExactly<ArgumentOutOfRangeException>().And.ParamName.Should().Be("status");
        }

        public static IEnumerable<object[]> EnumValues()
        {
            foreach (var number in Enum.GetValues(typeof(Enums.Concerns.DecisionStatus)))
            {
                yield return new object[] { number };
            }
        }
    }
}
