using System;
using System.Threading;
using System.Threading.Tasks;
using TramsDataApi.Factories.Concerns.Decisions;
using TramsDataApi.Gateways;
using TramsDataApi.RequestModels.Concerns.Decisions;
using TramsDataApi.ResponseModels.Concerns.Decisions;

namespace TramsDataApi.UseCases.CaseActions.Decisions
{
    [Obsolete("This endpoint is planned to be moved into the Concerns Casework API. If it is accessed by other APIs, please let the Concerns team know.")]
    public class CreateDecision : IUseCaseAsync<CreateDecisionRequest, CreateDecisionResponse>
    {
        private readonly IConcernsCaseGateway _concernsCaseGateway;
        private readonly IDecisionFactory _factory;
        private readonly ICreateDecisionResponseFactory _createDecisionResponseFactory;

        public CreateDecision(IConcernsCaseGateway concernsCaseGateway, IDecisionFactory factory, ICreateDecisionResponseFactory createDecisionResponseFactory)
        {
            _concernsCaseGateway = concernsCaseGateway ?? throw new ArgumentNullException(nameof(concernsCaseGateway));
            _factory = factory ?? throw new ArgumentNullException(nameof(factory));
            _createDecisionResponseFactory = createDecisionResponseFactory ?? throw new ArgumentNullException(nameof(createDecisionResponseFactory));
        }

        public async Task<CreateDecisionResponse> Execute(CreateDecisionRequest request, CancellationToken cancellationToken)
        {
            _ = request ?? throw new ArgumentNullException(nameof(request));

            if (!request.IsValid())
            {
                throw new ArgumentException("Request is not valid", nameof(request));
            }

            var concernsCase = _concernsCaseGateway.GetConcernsCaseByUrn(request.ConcernsCaseUrn) ?? throw new InvalidOperationException($"The concerns case for urn {request.ConcernsCaseUrn}, was not found");

            var decision = _factory.CreateDecision(concernsCase.Id, request);
            concernsCase.AddDecision(decision);

            cancellationToken.ThrowIfCancellationRequested();

            _concernsCaseGateway.SaveConcernsCase(concernsCase);

            return _createDecisionResponseFactory.Create(concernsCase.Urn, decision.DecisionId);
        }
    }
}
