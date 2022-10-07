using System;
using System.Linq;

namespace TramsDataApi.RequestModels.Concerns.Decisions
{
    [Obsolete("This endpoint is planned to be moved into the Concerns Casework API. If it is accessed by other APIs, please let the Concerns team know.")]
    public class CreateDecisionRequest
    {
        public int ConcernsCaseUrn { get; set; }
        public int DecisionId { get; set; }
        public Enums.Concerns.DecisionType[] DecisionTypes { get; set; }
        public decimal TotalAmountRequested { get; set; }
        public string SupportingNotes { get; set; }
        public DateTimeOffset ReceivedRequestDate { get; set; }
        public string SubmissionDocumentLink { get; set; }
        public bool SubmissionRequired { get; set; }
        public bool RetrospectiveApproval { get; set; }
        public string CrmCaseNumber { get; set; }

        public bool IsValid()
        {
            return DecisionTypes.All(x => Enum.IsDefined(typeof(Enums.Concerns.DecisionType), x));
        }
    }
}