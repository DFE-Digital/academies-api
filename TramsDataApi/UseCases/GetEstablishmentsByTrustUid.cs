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
                .Select(e =>
                    EstablishmentResponseFactory.Create(e, _establishmentGateway.GetMisEstablishmentByUrn(e.Urn), _establishmentGateway.GetSmartDataByUrn(e.Urn), _establishmentGateway.GetFurtherEducationEstablishmentByUrn(e.Urn), _establishmentGateway.GetViewAcademyConversionInfoByUrn(e.Urn), null)
                    )
                .ToList();
        }
    }
}