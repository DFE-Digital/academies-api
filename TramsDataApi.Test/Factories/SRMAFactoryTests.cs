using FizzWare.NBuilder;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Text;
using TramsDataApi.DatabaseModels;
using TramsDataApi.Factories.CaseActionFactories;
using TramsDataApi.RequestModels.CaseActions.SRMA;
using TramsDataApi.ResponseModels.CaseActions.SRMA;
using Xunit;

namespace TramsDataApi.Test.Factories
{
    public class SRMAFactoryTests
    {
        [Fact]
        public void CreateDBModel_ExpectedSRMACase_WhenCreateSRMARequestProvided()
        {
            var dtNow = DateTime.Now;

            var details = new
            {
                Id = 123,
                CaseId = 567,
                DateOffered = dtNow.AddDays(29),
                DateReportSentToTrust = dtNow.AddDays(28),
                DateVisitStart = dtNow.AddDays(27),
                DateVisitEnd = dtNow.AddDays(26),
                DateAccepted = dtNow.AddDays(25),
                Status = Enums.SRMAStatus.TrustConsidering,
                Reason = Enums.SRMAReasonOffered.RDDIntervention,
                Notes = "notes notes notes"
            };

            var createSRMARequest = Builder<CreateSRMARequest>.CreateNew()
                .With(r => r.Id = details.Id)
                .With(r => r.CaseId = details.CaseId)
                .With(r => r.DateOffered = details.DateOffered)
                .With(r => r.DateReportSentToTrust = details.DateReportSentToTrust)
                .With(r => r.DateVisitStart = details.DateVisitStart)
                .With(r => r.DateVisitEnd = details.DateVisitEnd)
                .With(r => r.DateAccepted = details.DateAccepted)
                .With(r => r.Status = details.Status)
                .With(r => r.Reason = details.Reason)
                .With(r => r.Notes = details.Notes)
                .Build();

            var expectedSRMAModel = new SRMACase
            {
                Id = details.Id,
                CaseId = details.CaseId,
                DateOffered = details.DateOffered,
                DateReportSentToTrust = details.DateReportSentToTrust,
                StartDateOfVisit = details.DateVisitStart,
                EndDateOfVisit = details.DateVisitEnd,
                DateAccepted = details.DateAccepted,
                StatusId = (int)details.Status,
                ReasonId = (int)details.Reason,
                Notes = details.Notes,
            };

            var response = SRMAFactory.CreateDBModel(createSRMARequest);

            response.Should().BeEquivalentTo(expectedSRMAModel);
        }

        [Fact]
        public void CreateResponse_ExpectedSRMAResponse_WhenSRMACaseProvided()
        {
            var dtNow = DateTime.Now;

            var details = new
            {
                Id = 123,
                CaseId = 988,
                DateOffered = dtNow.AddDays(29),
                DateReportSentToTrust = dtNow.AddDays(28),
                DateVisitStart = dtNow.AddDays(27),
                DateVisitEnd = dtNow.AddDays(26),
                DateAccepted = dtNow.AddDays(25),
                Status = Enums.SRMAStatus.TrustConsidering,
                Reason = Enums.SRMAReasonOffered.RDDIntervention,
                Notes = "notes notes notes"
            };

            var srmaModel = Builder<SRMACase>.CreateNew()
                .With(r => r.Id = details.Id)
                .With(r => r.CaseId = details.CaseId)
                .With(r => r.DateOffered = details.DateOffered)
                .With(r => r.DateReportSentToTrust = details.DateReportSentToTrust)
                .With(r => r.StartDateOfVisit = details.DateVisitStart)
                .With(r => r.EndDateOfVisit = details.DateVisitEnd)
                .With(r => r.DateAccepted = details.DateAccepted)
                .With(r => r.StatusId = (int)details.Status)
                .With(r => r.ReasonId = (int)details.Reason)
                .With(r => r.Notes = details.Notes)
                .Build();

            var expectedCreateSRMAResponse = new SRMAResponse
            {
                Id = details.Id,
                CaseId = details.CaseId,
                DateOffered = details.DateOffered,
                DateReportSentToTrust = details.DateReportSentToTrust,
                DateVisitStart = details.DateVisitStart,
                DateVisitEnd = details.DateVisitEnd,
                DateAccepted = details.DateAccepted,
                Status = details.Status,
                Reason = details.Reason,
                Notes = details.Notes,
            };

            var response = SRMAFactory.CreateResponse(srmaModel);

            response.Should().BeEquivalentTo(expectedCreateSRMAResponse);
        }

    }
}
