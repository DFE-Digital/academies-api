using System;
using TramsDataApi.Enums.Concerns;

namespace TramsDataApi.ResponseModels.Concerns.Decisions
{
    public class DecisionResponse
    {
        public int ConcernsCaseId { get; set; }

        public int DecisionId { get; set; }
        public DecisionType[] DecisionTypes { get; set; }
        public decimal TotalAmountRequested { get; set; }
        public string SupportingNotes { get; set; }
        public DateTimeOffset ReceivedRequestDate { get; set; }
        public string SubmissionDocumentLink { get; set; }
        public bool SubmissionRequired { get; set; }
        public bool RetrospectiveApproval { get; set; }
        public string CrmCaseNumber { get; set; }
        public DateTimeOffset CreatedAtDateTimeOffset { get; set; }
        public DateTimeOffset UpdatedAtDateTimeOffset { get; set; }
    }
}
