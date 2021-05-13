using TramsDataApi.Factories;
using TramsDataApi.Gateways;
using TramsDataApi.ResponseModels;

namespace TramsDataApi.UseCases
{
    public class GetEstablishmentByUkprn : IGetEstablishmentByUkprn
    {
        private readonly IEstablishmentGateway _establishmentGateway;

        public GetEstablishmentByUkprn(IEstablishmentGateway establishmentGateway)
        {
            _establishmentGateway = establishmentGateway;
        }
        
        public EstablishmentResponse Execute(string ukprn)
        {
            var establishment = _establishmentGateway.GetByUkprn(ukprn);
            if (establishment == null)
            {
                return null;
            }
            var misEstablishmentData = _establishmentGateway.GetMisEstablishmentByUrn(establishment.Urn);

            return EstablishmentResponseFactory.Create(establishment, misEstablishmentData);
        }
    }
}