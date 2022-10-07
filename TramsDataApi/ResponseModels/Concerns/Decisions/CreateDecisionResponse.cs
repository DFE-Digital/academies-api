using System;

namespace TramsDataApi.ResponseModels.Concerns.Decisions
{
    [Obsolete("This endpoint is planned to be moved into the Concerns Casework API. If it is accessed by other APIs, please let the Concerns team know.")]
    public class CreateDecisionResponse
    {
        public CreateDecisionResponse(int concernsCaseUrn, int decisionId)
        {
            ConcernsCaseUrn = concernsCaseUrn >= 0 ? concernsCaseUrn : throw new ArgumentOutOfRangeException(nameof(concernsCaseUrn), "value must be greater than zero");
            DecisionId = decisionId >= 0 ? decisionId : throw new ArgumentOutOfRangeException(nameof(decisionId), "value must be greater than zero");;
        }
        public int ConcernsCaseUrn { get; private set; }
        public int DecisionId { get; private set; }
    }
}
