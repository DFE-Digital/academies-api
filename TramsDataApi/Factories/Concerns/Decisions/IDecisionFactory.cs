using TramsDataApi.DatabaseModels.Concerns.Case.Management.Actions.Decisions;
using TramsDataApi.RequestModels.Concerns.Decisions;

namespace TramsDataApi.Factories.Concerns.Decisions
{
    public interface IDecisionFactory
    {
        public Decision CreateDecision(CreateDecisionRequest request);
    }
}
