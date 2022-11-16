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
        public IEnumerable<int?> Execute(ICollection<string> region)
        {
            var establishments = BuildResponse(region);
            return establishments;
        }
        private IEnumerable<int?> BuildResponse(ICollection<string> region)
        {
            if (region == null)
            {
                return null;
            }
            var establishments = _establishmentGateway.GetEstablishmentURNs().ToList();
            var misEstablishments = establishments.Select(e => _establishmentGateway.GetMisEstablishmentByUrn(e)).ToList();
            if (!misEstablishments.Any()) return null;
            {
                misEstablishments.RemoveAll(r => r == null);
                var matchingEstablishments = misEstablishments.Where(p => region.Contains(p!.Region)).ToList();
                return matchingEstablishments.Select(e => e.Urn).ToList();
            }


        }
    }
}
