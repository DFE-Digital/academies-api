using System;
using TramsDataApi.Factories.Concerns.Decisions;
using TramsDataApi.Gateways;
using TramsDataApi.RequestModels.Concerns.Decisions;
using TramsDataApi.ResponseModels.Concerns.Decisions;

namespace TramsDataApi.UseCases.CaseActions.Decisions
{
    public class CreateDecision : IUseCase<CreateDecisionRequest, CreateDecisionResponse>
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

        public CreateDecisionResponse Execute(CreateDecisionRequest request)
        {
            _ = request ?? throw new ArgumentNullException(nameof(request));
            var concernsCase = _concernsCaseGateway.GetConcernsCaseByUrn(request.ConcernsCaseUrn)
                          ?? throw new InvalidOperationException($"The concerns case for urn {request.ConcernsCaseUrn}, was not found");

            var decision = _factory.CreateDecision(request);
            concernsCase.AddDecision(decision);

            _concernsCaseGateway.SaveConcernsCase(concernsCase);

            return _createDecisionResponseFactory.Create(concernsCase.Urn, decision.DecisionId);
        }
    }
}
