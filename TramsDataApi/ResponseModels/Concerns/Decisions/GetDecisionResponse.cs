﻿using System;
using TramsDataApi.Enums.Concerns;

namespace TramsDataApi.ResponseModels.Concerns.Decisions
{
    public class GetDecisionResponse
    {
        public int ConcernsCaseUrn { get; set; }

        [Obsolete("This will be removed. Prefer the ConcernsCaseUrn instead")]
        public int ConcernsCaseId { get; set; } // To be removed.
        public int DecisionId { get; set; }
        public DecisionType[] DecisionTypes { get; set; }
        public decimal TotalAmountRequested { get; set; }
        public string SupportingNotes { get; set; }
        public DateTimeOffset ReceivedRequestDate { get; set; }
        public string SubmissionDocumentLink { get; set; }
        public bool? SubmissionRequired { get; set; }
        public bool? RetrospectiveApproval { get; set; }
        public string CrmCaseNumber { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
        public DateTimeOffset UpdatedAt { get; set; }
    }
}
