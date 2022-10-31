using System;
using System.Linq;
using TramsDataApi.DatabaseModels.Concerns.Case.Management.Actions.Decisions;
using TramsDataApi.ResponseModels.Concerns.Decisions;

namespace TramsDataApi.Factories.Concerns.Decisions
{
    public class GetDecisionResponseFactory : IGetDecisionResponseFactory
    {
        public GetDecisionResponse Create(int concernsCaseUrn, Decision decision)
        {
            _ = concernsCaseUrn <= 0 ? throw new ArgumentOutOfRangeException(nameof(concernsCaseUrn)) : concernsCaseUrn;
            _ = decision ?? throw new ArgumentNullException(nameof(decision));

            return new GetDecisionResponse()
            {
                ConcernsCaseUrn = concernsCaseUrn,
                ConcernsCaseId = decision.ConcernsCaseId,
                DecisionId = decision.DecisionId,
                DecisionTypes = decision.DecisionTypes.Select(x => x.DecisionTypeId).ToArray(),
                TotalAmountRequested = decision.TotalAmountRequested,
                SupportingNotes =decision.SupportingNotes,
                ReceivedRequestDate = decision.ReceivedRequestDate,
                SubmissionDocumentLink = decision.SubmissionDocumentLink,
                SubmissionRequired = decision.SubmissionRequired,
                RetrospectiveApproval = decision.RetrospectiveApproval,
                CrmCaseNumber = decision.CrmCaseNumber,
                CreatedAt = decision.CreatedAt,
                UpdatedAt = decision.UpdatedAt,
                ClosedAt = decision.ClosedAt,
                DecisionStatus = decision.Status,
                Title = decision.GetTitle()
            };
        }
    }
}