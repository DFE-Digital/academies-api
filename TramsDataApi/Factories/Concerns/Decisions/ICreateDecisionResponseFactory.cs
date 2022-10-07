using TramsDataApi.DatabaseModels;
using TramsDataApi.ResponseModels.Concerns.Decisions;

namespace TramsDataApi.Factories.Concerns.Decisions
{
    public interface ICreateDecisionResponseFactory
    {
        public CreateDecisionResponse Create(int concernsCaseUrn, int decisionId);
    }
}