using System;
using System.Collections.Generic;
using System.Linq;

namespace TramsDataApi.DatabaseModels.Concerns.Case.Management.Actions.Decisions
{
    [Obsolete("This endpoint is planned to be moved into the Concerns Casework API. If it is accessed by other APIs, please let the Concerns team know.")]
    public class Decision
    {
        private Decision()
        {
            DecisionTypes = new List<DecisionType>();
        }

        public Decision(
            int concernsCaseId,
            string crmCaseNumber,
            bool retrospectiveApproval,
            bool submissionRequired,
            string submissionDocumentLink,
            DateTimeOffset receivedRequestDate,
            DecisionType[] decisionTypes,
            decimal totalAmountRequested,
            string supportingNotes,
            DateTimeOffset createdAt
        )
        {
            ConcernsCaseId = concernsCaseId;
            DecisionTypes = decisionTypes;
            TotalAmountRequested = totalAmountRequested;
            SupportingNotes = supportingNotes;
            ReceivedRequestDate = receivedRequestDate;
            SubmissionDocumentLink = submissionDocumentLink;
            SubmissionRequired = submissionRequired;
            RetrospectiveApproval = retrospectiveApproval;
            CrmCaseNumber = crmCaseNumber;
            CreatedAt = createdAt;
            UpdatedAt = createdAt;
        }

        public int ConcernsCaseId { get;  private set; }
        
        public int DecisionId { get;  private set; } 
        public IList<DecisionType> DecisionTypes { get;  private set; }
        public decimal TotalAmountRequested { get;  private set; }
        public string SupportingNotes { get;  private set; }
        public DateTimeOffset ReceivedRequestDate { get;  private set; }
        public string SubmissionDocumentLink { get;  private set; }
        public bool SubmissionRequired { get;  private set; }
        public bool RetrospectiveApproval { get;  private set; }
        public string CrmCaseNumber { get;  private set; }
        public DateTimeOffset CreatedAt { get;  private set; }
        public DateTimeOffset UpdatedAt { get;  private set; }

    }
}
