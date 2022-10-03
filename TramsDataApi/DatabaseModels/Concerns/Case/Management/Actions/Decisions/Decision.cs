using System;

namespace TramsDataApi.DatabaseModels.Concerns.Case.Management.Actions.Decisions
{
    public class Decision
    {
        private Decision()
        {

        }

        public Decision(
            int concernsCaseId,
            int decisionId,
            string crmCaseNumber,
            bool retrospectiveApproval,
            bool submissionRequired,
            string submissionDocumentLink,
            DateTimeOffset receivedRequestDate,
            DecisionType[] decisionTypes,
            decimal totalAmountRequested,
            string supportingNotes
        )
        {
            ConcernsCaseId = concernsCaseId;
            DecisionId = decisionId;
            DecisionTypes = decisionTypes;
            TotalAmountRequested = totalAmountRequested;
            SupportingNotes = supportingNotes;
            ReceivedRequestDate = receivedRequestDate;
            SubmissionDocumentLink = submissionDocumentLink;
            SubmissionRequired = submissionRequired;
            RetrospectiveApproval = retrospectiveApproval;
            CrmCaseNumber = crmCaseNumber;
        }

        public int ConcernsCaseId { get; set; }
        public int DecisionId { get; private set; }
        public DecisionType[] DecisionTypes { get; private set; }
        public decimal TotalAmountRequested { get; private set; }
        public string SupportingNotes { get; private set; }
        public DateTimeOffset ReceivedRequestDate { get; private set; }
        public string SubmissionDocumentLink { get; private set; }
        public bool SubmissionRequired { get; private set; }
        public bool RetrospectiveApproval { get; private set; }
        public string CrmCaseNumber { get; private set; }
    }
}
