using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TramsDataApi.DatabaseModels;
using TramsDataApi.Factories;
using TramsDataApi.Gateways;
using TramsDataApi.ResponseModels;

namespace TramsDataApi.UseCases
{
    public class GetEstablishmentsByRegion : IGetEstablishmentsByRegion
    {
        private readonly IEstablishmentGateway _establishmentGateway;

        public GetEstablishmentsByRegion(IEstablishmentGateway establishmentGateway)
        {
            _establishmentGateway = establishmentGateway;
        }
        public IEnumerable<int> Execute(ICollection<string> region)
        {
            if (region == null) return Enumerable.Empty<int>();
            var URNs = _establishmentGateway.GetURNsByRegion(region);
            var buildResponse = URNs.ToList();
            return buildResponse;
        }
    }
}
