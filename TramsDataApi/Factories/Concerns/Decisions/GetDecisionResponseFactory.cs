using System;
using System.Linq;
using TramsDataApi.DatabaseModels.Concerns.Case.Management.Actions.Decisions;
using TramsDataApi.ResponseModels.Concerns.Decisions;

namespace TramsDataApi.Factories.Concerns.Decisions
{
    public class GetDecisionResponseFactory : IGetDecisionResponseFactory
    {
        public GetDecisionResponse Create(Decision decision)
        {
            _ = decision ?? throw new ArgumentNullException(nameof(decision));
            
            return new GetDecisionResponse()
            {
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
                UpdatedAt = decision.UpdatedAt
            };
        }
    }
}