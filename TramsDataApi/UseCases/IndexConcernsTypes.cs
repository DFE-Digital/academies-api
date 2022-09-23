using System;
using System.Collections.Generic;
using System.Linq;
using TramsDataApi.Factories;
using TramsDataApi.Gateways;
using TramsDataApi.ResponseModels;

namespace TramsDataApi.UseCases
{
    [Obsolete("This is planned to be moved into the Concerns Casework API. If it is accessed by other APIs, please let the Concerns team know.")]
    public class IndexConcernsTypes : IIndexConcernsTypes
    {
        private IConcernsTypeGateway _concernsTypeGateway;

        public IndexConcernsTypes(IConcernsTypeGateway concernsTypeGateway)
        {
            _concernsTypeGateway = concernsTypeGateway;
        }
        public IList<ConcernsTypeResponse> Execute()
        {
            var types = _concernsTypeGateway.GetTypes();
            return types.Select(ConcernsTypeResponseFactory.Create).ToList();
        }
    }
}