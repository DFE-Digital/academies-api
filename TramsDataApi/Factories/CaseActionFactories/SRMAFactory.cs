using TramsDataApi.DatabaseModels;
using TramsDataApi.RequestModels.CaseActions.SRMA;
using TramsDataApi.ResponseModels.CaseActions.SRMA;

namespace TramsDataApi.Factories.CaseActionFactories
{
    public static class SRMAFactory
    {
        public static SRMACase CreateDBModel(CreateSRMARequest createSRMARequest)
        {
            return new SRMACase
            {
                Id = createSRMARequest.Id,
                DateOffered = createSRMARequest.DateOffered,
                DateReportSentToTrust = createSRMARequest.DateReportSentToTrust,
                StartDateOfVisit = createSRMARequest.DateVisitStart,
                EndDateOfVisit = createSRMARequest.DateVisitEnd,
                DateAccepted = createSRMARequest.DateAccepted,
                StatusId = (int)createSRMARequest.Status,
                ReasonId = (int)createSRMARequest.Reason,
                Notes = createSRMARequest.Notes,
            };
        }

        public static CreateSRMAResponse CreateResponse(SRMACase model)
        {
            return new CreateSRMAResponse
            {
                Id = model.Id,
                DateOffered = model.DateOffered,
                DateReportSentToTrust = model.DateReportSentToTrust,
                DateVisitStart = model.StartDateOfVisit,
                DateVisitEnd = model.EndDateOfVisit,
                DateAccepted = model.DateAccepted,
                Status = (Enums.SRMAStatus)model.StatusId,
                Reason = (Enums.SRMAReasonOffered?)model.ReasonId,
                Notes = model.Notes,
            };
        }
    }
}
