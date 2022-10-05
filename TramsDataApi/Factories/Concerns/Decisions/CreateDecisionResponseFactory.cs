using System;
using TramsDataApi.ResponseModels.Concerns.Decisions;

namespace TramsDataApi.Factories.Concerns.Decisions
{
    [Obsolete("This is planned to be moved into the Concerns Casework API. If it is accessed by other APIs, please let the Concerns team know.")]
    public class CreateDecisionResponseFactory : ICreateDecisionResponseFactory
    {
        public CreateDecisionResponse Create(int concernsCaseUrn, int decisionId)
        {
            _ = concernsCaseUrn <= 0 ? throw new ArgumentOutOfRangeException(nameof(concernsCaseUrn)) : concernsCaseUrn;
            _ = decisionId <= 0 ? throw new ArgumentOutOfRangeException(nameof(decisionId)) : decisionId;


            return new CreateDecisionResponse(concernsCaseUrn, decisionId);
        }
    }
}
