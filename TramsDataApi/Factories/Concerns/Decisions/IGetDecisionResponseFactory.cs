using TramsDataApi.DatabaseModels.Concerns.Case.Management.Actions.Decisions;
using TramsDataApi.ResponseModels.Concerns.Decisions;

namespace TramsDataApi.Factories.Concerns.Decisions
{
    public interface IGetDecisionResponseFactory
    {
        public GetDecisionResponse Create(Decision decision);
    }
}