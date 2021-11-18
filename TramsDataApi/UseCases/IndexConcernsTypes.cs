using System.Collections.Generic;
using System.Linq;
using TramsDataApi.Factories;
using TramsDataApi.Gateways;
using TramsDataApi.ResponseModels;

namespace TramsDataApi.UseCases
{
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