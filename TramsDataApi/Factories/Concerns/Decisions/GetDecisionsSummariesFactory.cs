using System;
using System.Collections.Generic;
using System.Linq;
using TramsDataApi.DatabaseModels.Concerns.Case.Management.Actions.Decisions;
using TramsDataApi.ResponseModels.Concerns.Decisions;

namespace TramsDataApi.Factories.Concerns.Decisions
{
    public class GetDecisionsSummariesFactory : IGetDecisionsSummariesFactory
    {
        public DecisionSummaryResponse[] Create(int concernsCaseUrn, IEnumerable<Decision> decisions)
        {
            _ = concernsCaseUrn > 0 ? concernsCaseUrn : throw new ArgumentOutOfRangeException(nameof(concernsCaseUrn));
            _ = decisions ?? throw new ArgumentNullException(nameof(decisions));

            return decisions.Select(decision => new DecisionSummaryResponse()
            {
                ConcernsCaseUrn = concernsCaseUrn,
                DecisionId = decision.DecisionId, 
                Status = decision.Status,
                CreatedAt = decision.CreatedAt,
                UpdatedAt = decision.UpdatedAt,
                ClosedAt = decision.ClosedAt,
                Title = decision.DecisionTypes.FirstOrDefault()?.DecisionTypeId.ToString() ?? "Not Available",
            }).ToArray();
        }
    }
}
