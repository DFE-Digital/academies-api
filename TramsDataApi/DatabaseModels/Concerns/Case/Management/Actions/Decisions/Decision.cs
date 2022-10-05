using System;
using System.Collections.Generic;

namespace TramsDataApi.DatabaseModels.Concerns.Case.Management.Actions.Decisions
{
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
            DateTimeOffset createdAtDateTimeOffset
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
            CreatedAtDateTimeOffset = createdAtDateTimeOffset;
            UpdatedAtDateTimeOffset = createdAtDateTimeOffset;
        }

        public int ConcernsCaseId { get;  set; }
        
        public int DecisionId { get;  set; } 
        public IList<DecisionType> DecisionTypes { get;  set; }
        public decimal TotalAmountRequested { get;  set; }
        public string SupportingNotes { get;  set; }
        public DateTimeOffset ReceivedRequestDate { get;  set; }
        public string SubmissionDocumentLink { get;  set; }
        public bool SubmissionRequired { get;  set; }
        public bool RetrospectiveApproval { get;  set; }
        public string CrmCaseNumber { get;  set; }
        public DateTimeOffset CreatedAtDateTimeOffset { get;  set; }
        public DateTimeOffset UpdatedAtDateTimeOffset { get;  set; }

    }
}
