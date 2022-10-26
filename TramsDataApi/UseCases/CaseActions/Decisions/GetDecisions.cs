﻿using Microsoft.Extensions.Logging;
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
    public class GetDecisions : IUseCaseAsync<GetDecisionsRequest, DecisionSummaryResponse[]>
    {
        private readonly ILogger<GetDecisions> _logger;
        private readonly IConcernsCaseGateway _gateway;
        private readonly IGetDecisionsSummariesFactory _getDecisionsSummariesFactory;

        public GetDecisions(ILogger<GetDecisions> logger, IConcernsCaseGateway gateway, IGetDecisionsSummariesFactory getDecisionsSummariesFactory)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _gateway = gateway ?? throw new ArgumentNullException(nameof(gateway));
            _getDecisionsSummariesFactory = getDecisionsSummariesFactory ?? throw new ArgumentNullException(nameof(getDecisionsSummariesFactory));
        }

        public async Task<DecisionSummaryResponse[]> Execute(GetDecisionsRequest request, CancellationToken cancellationToken)
        {
            _ = request ?? throw new ArgumentNullException(nameof(request));

            async Task<DecisionSummaryResponse[]> DoWork()
            {
                var concernsCase =  _gateway.GetConcernsCaseByUrn(request.ConcernsCaseUrn);

                if (concernsCase == null)
                {
                    return default(DecisionSummaryResponse[]);
                }

                var result = _getDecisionsSummariesFactory.Create(request.ConcernsCaseUrn, concernsCase.Decisions.AsEnumerable());
                return result;
            }

            return await DoWork();
        }
    }
}