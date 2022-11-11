﻿using AutoFixture;
using AutoFixture.Idioms;
using TramsDataApi.ResponseModels.Concerns.Decisions;
using Xunit;

namespace TramsDataApi.Test.ResponseModels.Concerns.Decisions
{
    public class DecisionResponseTests
    {
        [Fact]
        public void Constructor_Guards_Against_Nulls()
        {
            // Arrange
            var fixture = new Fixture();
            var assertion = fixture.Create<GuardClauseAssertion>();

            // Act & Assert
            assertion.Verify(typeof(GetDecisionResponse).GetConstructors());
        }

        [Fact]
        public void Properties_Are_Initialized_By_Constructor()
        {
            // Arrange
            var fixture = new Fixture();
            var assertion = fixture.Create<ConstructorInitializedMemberAssertion>();

            // Act & Assert
            assertion.Verify(typeof(GetDecisionResponse));
        }
        
        [Fact]
        public void Property_Setters_Work_As_Expected()
        {
            // Arrange
            var fixture = new Fixture();
            var assertion = fixture.Create<WritablePropertyAssertion>();

            // Act & Assert
            assertion.Verify(typeof(GetDecisionResponse));
        }
    }
}