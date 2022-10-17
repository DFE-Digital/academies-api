using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TramsDataApi.Factories.Concerns.Decisions;
using TramsDataApi.Gateways;
using TramsDataApi.RequestModels.Concerns.Decisions;
using TramsDataApi.ResponseModels.Concerns.Decisions;

namespace TramsDataApi.UseCases.CaseActions.Decisions
{
    [Obsolete("This endpoint is planned to be moved into the Concerns Casework API. If it is accessed by other APIs, please let the Concerns team know.")]
    public class GetDecision: IUseCaseAsync<GetDecisionRequest, GetDecisionResponse>
    {
        private readonly IConcernsCaseGateway _concernsCaseGateway;
        private readonly IGetDecisionResponseFactory _responseFactory;

        public GetDecision(IConcernsCaseGateway concernsCaseGateway, IGetDecisionResponseFactory responseFactory)
        {
            _concernsCaseGateway = concernsCaseGateway ?? throw new ArgumentNullException(nameof(concernsCaseGateway));
            _responseFactory = responseFactory ?? throw new ArgumentNullException(nameof(responseFactory));
        }
        public async Task<GetDecisionResponse> Execute(GetDecisionRequest request, CancellationToken cancellationToken)
        {
            _ = request ?? throw new ArgumentNullException(nameof(request));

            var concernsCase = _concernsCaseGateway.GetConcernsCaseByUrn(request.ConcernsCaseUrn);
            var decision = concernsCase?.Decisions.FirstOrDefault(x => x.DecisionId == request.DecisionId);
            
            return _responseFactory.Create(decision);
        }
    }
}