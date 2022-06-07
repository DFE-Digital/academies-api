using TramsDataApi.DatabaseModels;
using TramsDataApi.Enums;
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
                CaseUrn = createSRMARequest.CaseUrn,
                CreatedAt = createSRMARequest.CreatedAt,
                DateOffered = createSRMARequest.DateOffered,
                DateReportSentToTrust = createSRMARequest.DateReportSentToTrust,
                StartDateOfVisit = createSRMARequest.DateVisitStart,
                EndDateOfVisit = createSRMARequest.DateVisitEnd,
                DateAccepted = createSRMARequest.DateAccepted,
                StatusId = (int)createSRMARequest.Status,
                ReasonId = (int?)(createSRMARequest.Reason == SRMAReasonOffered.Unknown ? null : createSRMARequest.Reason),
                Notes = createSRMARequest.Notes,
            };
        }

        public static SRMAResponse CreateResponse(SRMACase model)
        {
            return new SRMAResponse
            {
                Id = model.Id,
                CaseUrn = model.CaseUrn,
                CreatedAt = model.CreatedAt,
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
