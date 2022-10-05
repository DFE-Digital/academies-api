using AutoFixture;
using FluentAssertions;
using System;
using TramsDataApi.DatabaseModels.Concerns.Case.Management.Actions.Decisions;
using Xunit;

namespace TramsDataApi.Test.DatabaseModels.Concerns
{
    public class DecisionTests
    {
        [Fact]
        public void CanConstruct_Decision()
        {
            var fixture = new Fixture();
            var sut = fixture.Create<Decision>();
            sut.Should().NotBeNull();
        }

        [Fact]
        public void Decision_Properties_SetByConstructor()
        {

            var fixture = new Fixture();
            var decisionId = fixture.Create<int>();

            var decisionTypes = new[]
            {
                new DecisionType(Enums.Concerns.DecisionType.NoticeToImprove, decisionId),
                new DecisionType(Enums.Concerns.DecisionType.OtherFinancialSupport, decisionId)
            };

            var expectation = new
            {
                ConcernsCaseId = fixture.Create<int>(),
                CrmCaseNumber = fixture.Create<string>(),
                RetrospectiveApproval = true,
                SubmissionRequired = true,
                SubmissionDocumentLink = fixture.Create<string>(),
                ReceivedRequestDate = fixture.Create<DateTimeOffset>(),
                DecisionTypes = decisionTypes,
                TotalAmountRequested = 13.5m,
                SupportingNotes = fixture.Create<string>(),
                CurrentDateTime = DateTimeOffset.UtcNow
            };

            var sut = new Decision(
                expectation.ConcernsCaseId,
                expectation.CrmCaseNumber,
                expectation.RetrospectiveApproval,
                expectation.SubmissionRequired,
                expectation.SubmissionDocumentLink,
                expectation.ReceivedRequestDate,
                expectation.DecisionTypes,
                expectation.TotalAmountRequested,
                expectation.SupportingNotes,
                expectation.CurrentDateTime
            );

            sut.Should().BeEquivalentTo(expectation, cfg => cfg.Excluding(e => e.CurrentDateTime));
            sut.CreatedAtDateTimeOffset.Should().Be(expectation.CurrentDateTime);
            sut.UpdatedAtDateTimeOffset.Should().Be(expectation.CurrentDateTime);
            sut.DecisionId.Should().Be(0, "DecisionId should be assigned by the database");
        }
    }
}