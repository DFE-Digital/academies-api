using System;
using TramsDataApi.DatabaseModels.Concerns.Case.Management.Actions.Decisions;
using TramsDataApi.RequestModels.Concerns.Decisions;

namespace TramsDataApi.Factories.Concerns.Decisions
{
    [Obsolete("This endpoint is planned to be moved into the Concerns Casework API. If it is accessed by other APIs, please let the Concerns team know.")]
    public interface IDecisionFactory
    {
        public Decision CreateDecision(int concernsCaseId, CreateDecisionRequest request);
    }
}
