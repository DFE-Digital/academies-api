using System.Collections.Generic;
using System.Linq;
using TramsDataApi.Factories;
using TramsDataApi.Gateways;
using TramsDataApi.ResponseModels;

namespace TramsDataApi.UseCases
{
    public class GetEstablishmentsByTrustUid : IGetEstablishmentsByTrustUid
    {
        private readonly IEstablishmentGateway _establishmentGateway;

        public GetEstablishmentsByTrustUid(IEstablishmentGateway establishmentGateway)
        {
            _establishmentGateway = establishmentGateway;
        }
        
        public List<EstablishmentResponse> Execute(string trustUid)
        {
            return _establishmentGateway.GetByTrustUid(trustUid)
                .Select(e => AcademyResponseFactory.Create(e, null))
                .ToList();
        }
    }
}