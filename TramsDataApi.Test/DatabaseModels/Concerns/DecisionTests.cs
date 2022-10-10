using AutoFixture;
using FluentAssertions;
using System;
using System.Linq;
using TramsDataApi.DatabaseModels.Concerns.Case.Management.Actions.Decisions;
using Xunit;

namespace TramsDataApi.Test.DatabaseModels.Concerns
{
    public class DecisionTests
    {
        [Fact]
        public void Can_Create_New_Decision()
        {
            var fixture = new Fixture();
            var sut = CreateRandomDecision(fixture);
            sut.Should().NotBeNull();
        }

        private Decision CreateRandomDecision(Fixture fixture)
        {
            return Decision.CreateNew(
                concernsCaseId: fixture.Create<int>(),
                crmCaseNumber: fixture.Create<string>().Substring(0, 20),
                retrospectiveApproval: fixture.Create<bool?>(),
                submissionRequired: fixture.Create<bool?>(),
                submissionDocumentLink: fixture.Create<string>(),
                receivedRequestDate: fixture.Create<DateTimeOffset>(),
                decisionTypes: fixture.CreateMany<DecisionType>().ToArray(),
                totalAmountRequested: fixture.Create<decimal>(),
                supportingNotes: fixture.Create<string>(),
                createdAt: fixture.Create<DateTimeOffset>());
        }

        [Theory]
        [InlineData(0, 10000, "caseNumber", "notes", "link", "concernsCaseId")]
        [InlineData(110, -1000, "caseNumber", "notes", "link", "totalAmountRequested")]
        [InlineData(110, 1000, "_maxString_", "notes", "link", "crmCaseNumber")]
        [InlineData(110, 1000, "caseNumber", "_maxString_", "link", "supportingNotes")]
        [InlineData(110, 1000, "caseNumber", "notes", "_maxString_", "submissionDocumentLink")]
        public void CreateNew_With_Invalid_Arguments_Throws_Exception(int caseId, decimal amountRequested, string crmCaseNumber, string supportingNotes, string submissionDocumentLink, string expectedParamName)
        {
            crmCaseNumber = crmCaseNumber == "_maxString_" ? Large2100CharString : crmCaseNumber;
            supportingNotes = supportingNotes == "_maxString_" ? Large2100CharString : supportingNotes;
            submissionDocumentLink = submissionDocumentLink == "_maxString_" ? Large2100CharString : submissionDocumentLink;

            Action act = () => Decision.CreateNew(caseId, crmCaseNumber, null, null, submissionDocumentLink, DateTimeOffset.UtcNow,
                Array.Empty<DecisionType>(), amountRequested, supportingNotes, DateTimeOffset.Now);

            act.Should().Throw<ArgumentException>().And.ParamName.Should().Be(expectedParamName);
        }

        private const string Large2100CharString = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nunc sollicitudin eu quam pellentesque faucibus. Pellentesque ligula enim, rhoncus vitae auctor nec, rhoncus nec mauris. Fusce porta hendrerit interdum. Praesent nec orci purus. Class aptent taciti sociosqu ad litora torquent per conubia nostra, per inceptos himenaeos. Praesent imperdiet nunc posuere eleifend pretium. Nullam aliquam lectus in augue lobortis euismod.\r\n\r\nMauris euismod nibh ac felis consequat, a fermentum arcu tempor. In accumsan tortor dolor. Donec mattis pulvinar mi, a cursus lectus pharetra sed. Nulla facilisi. Duis vulputate metus in scelerisque malesuada. Proin varius elit et lacus iaculis vestibulum. Praesent posuere dapibus est, feugiat aliquet felis.\r\n\r\nMorbi nec laoreet metus. Donec pretium magna sed sem commodo, porttitor volutpat ex lacinia. Sed sed hendrerit enim, ac feugiat dui. Nam eleifend quis ex vel faucibus. Nullam maximus convallis nibh eget placerat. Aliquam aliquam euismod venenatis. Ut sed lorem mattis, hendrerit massa a, tempus eros. Fusce sollicitudin lacinia justo, ut mattis elit pretium quis. Morbi sit amet arcu pretium, aliquam augue ut, auctor lectus.\r\n\r\nEtiam in urna at magna pretium suscipit. Donec varius lacinia tortor quis finibus. Donec justo sapien, maximus quis enim sit amet, sagittis convallis augue. Curabitur a diam in arcu accumsan molestie in nec sem. Cras pretium leo sit amet orci commodo porttitor. Aliquam sit amet nibh id erat pellentesque convallis. Morbi ultrices consequat molestie. Nam posuere condimentum massa eu ultricies. Ut dignissim, sem vitae blandit auctor, metus lacus accumsan elit, eget ornare quam tortor sed felis. Quisque vel leo lectus. Sed nec porta sapien. Etiam congue in magna vitae blandit. Vivamus varius, augue eget mollis molestie, purus mi rhoncus quam, a sodales elit ipsum sit amet sem. Nullam laoreet sem nibh, nec vestibulum nisi fermentum non.\r\n\r\nIn lacus augue, efficitur sed fermentum nec, hendrerit eu magna. Suspendisse molestie erat risus, in ultrices dui gravida sit amet. Pellentesque fermentum ornare finibus. Integer iaculis orci aliquam.";


        [Fact]
        public void CreateNew_Sets_Properties()
        {

            var fixture = new Fixture();
            var decisionId = fixture.Create<int>();

            var decisionTypes = new[]
            {
                new DecisionType(Enums.Concerns.DecisionType.NoticeToImprove) { DecisionId = decisionId },
                new DecisionType(Enums.Concerns.DecisionType.OtherFinancialSupport){ DecisionId = decisionId }
            };

            var expectation = new
            {
                ConcernsCaseId = fixture.Create<int>(),
                CrmCaseNumber = fixture.Create<string>().Substring(0, 20),
                RetrospectiveApproval = true,
                SubmissionRequired = true,
                SubmissionDocumentLink = fixture.Create<string>(),
                ReceivedRequestDate = fixture.Create<DateTimeOffset>(),
                DecisionTypes = decisionTypes,
                TotalAmountRequested = 13.5m,
                SupportingNotes = fixture.Create<string>(),
                CurrentDateTime = DateTimeOffset.UtcNow
            };

            var sut = Decision.CreateNew(
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
            sut.CreatedAt.Should().Be(expectation.CurrentDateTime);
            sut.UpdatedAt.Should().Be(expectation.CurrentDateTime);
            sut.DecisionId.Should().Be(0, "DecisionId should be assigned by the database");
        }

        [Fact]
        public void CreateNew_Sets_Status_To_InProgress()
        {
            var fixture = new Fixture();
            var sut = CreateRandomDecision(fixture);
            sut.Status.Should().Be(Enums.Concerns.DecisionStatus.InProgress);
        }
    }
}