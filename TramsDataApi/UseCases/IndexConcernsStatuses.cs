using System;
using System.Collections.Generic;
using System.Linq;
using TramsDataApi.Factories;
using TramsDataApi.Gateways;
using TramsDataApi.ResponseModels;

namespace TramsDataApi.UseCases
{
    [Obsolete("This is planned to be moved into the Concerns Casework API. If it is accessed by other APIs, please let the Concerns team know.")]
    public class IndexConcernsStatuses : IIndexConcernsStatuses
    {
        private IConcernsStatusGateway _concernsStatusGateway;

        public IndexConcernsStatuses(IConcernsStatusGateway concernsStatusGateway)
        {
            _concernsStatusGateway = concernsStatusGateway;
        }
        public IList<ConcernsStatusResponse> Execute()
        {
            var statuses = _concernsStatusGateway.GetStatuses();
            return statuses.Select(ConcernsStatusResponseFactory.Create).ToList();
        }
    }
}