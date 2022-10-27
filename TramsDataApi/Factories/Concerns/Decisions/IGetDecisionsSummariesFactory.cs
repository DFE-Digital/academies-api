using System.Collections.Generic;
using TramsDataApi.DatabaseModels.Concerns.Case.Management.Actions.Decisions;
using TramsDataApi.ResponseModels.Concerns.Decisions;

namespace TramsDataApi.Factories.Concerns.Decisions
{
    public interface IGetDecisionsSummariesFactory
    {
        public DecisionSummaryResponse[] Create(int concernsCaseUrn, IEnumerable<Decision> decisions);
    }
}