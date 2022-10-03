using AutoFixture;
using FluentAssertions;
using System;
using TramsDataApi.DatabaseModels.Concerns.Case.Management.Actions.Decisions;
using Xunit;

namespace TramsDataApi.Test.DatabaseModels.Concerns
{
    public class CaseDecisionTests
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


            var decisionTypes = new[]
            {
                new DecisionType(Enums.Concerns.DecisionType.NoticeToImprove, "Notice to Improve"),
                new DecisionType(Enums.Concerns.DecisionType.OtherFinancialSupport, "Other financial support")
            };

            var expectation = new
            {
                CrmCaseNumber = fixture.Create<string>(),
                RetrospectiveApproval = true,
                SubmissionRequired = true,
                SubmissionDocumentLink = fixture.Create<string>(),
                ReceivedRequestDate = fixture.Create<DateTimeOffset>(),
                DecisionTypes = decisionTypes,
                TotalAmountRequested = 13.5m,
                SupportingNotes = fixture.Create<string>()
            };

            var sut = new Decision(
                expectation.CrmCaseNumber,
                expectation.RetrospectiveApproval,
                expectation.SubmissionRequired,
                expectation.SubmissionDocumentLink,
                expectation.ReceivedRequestDate,
                expectation.DecisionTypes,
                expectation.TotalAmountRequested,
                expectation.SupportingNotes
            );

            sut.Should().BeEquivalentTo(expectation);
        }
    }
}