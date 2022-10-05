using System;

namespace TramsDataApi.RequestModels.Concerns.Decisions
{
    public class CreateDecisionRequest
    {
        public int ConcernsCaseUrn { get; set; }
        public int ConcernsCaseId { get; set; }
        public Enums.Concerns.DecisionType[] DecisionTypes { get; set; }
        public decimal TotalAmountRequested { get; set; }
        public string SupportingNotes { get; set; }
        public DateTimeOffset ReceivedRequestDate { get; set; }
        public string SubmissionDocumentLink { get; set; }
        public bool SubmissionRequired { get; set; }
        public bool RetrospectiveApproval { get; set; }
        public string CrmCaseNumber { get; set; }
    }
}
