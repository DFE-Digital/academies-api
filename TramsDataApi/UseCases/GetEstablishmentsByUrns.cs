using System.Collections.Generic;
using System.Linq;
using TramsDataApi.Factories;
using TramsDataApi.Gateways;
using TramsDataApi.RequestModels;
using TramsDataApi.ResponseModels;

namespace TramsDataApi.UseCases
{
    public class GetEstablishmentsByUrns : IGetEstablishmentsByUrns
    {
        private readonly IEstablishmentGateway _establishmentGateway;

        public GetEstablishmentsByUrns(IEstablishmentGateway establishmentGateway)
        {
            _establishmentGateway = establishmentGateway;
        }

        public IList<EstablishmentResponse> Execute(GetEstablishmentsByUrnsRequest request)
        {
            var establishments = _establishmentGateway.GetByUrns(request.Urns);
            var misEstablishments = _establishmentGateway.GetMisEstablishmentsByUrns(request.Urns);
            var smartData = _establishmentGateway.GetSmartDataByUrns(request.Urns);
            var furtherEducationEstablishments = _establishmentGateway.GetFurtherEducationEstablishmentsByUrns(request.Urns);
            var viewAcademyConversions = _establishmentGateway.GetViewAcademyConversionInfoByUrns(request.Urns);

            if (!establishments.Any())
            {
                return null;
            }

            return establishments.Select(establishment =>
                    EstablishmentResponseFactory.Create(
                        establishment,
                        misEstablishments?.FirstOrDefault(misEstablishment => misEstablishment.Urn == establishment.Urn),
                        smartData?.FirstOrDefault(smartData => smartData.Urn == establishment.Urn.ToString()),
                        furtherEducationEstablishments?.FirstOrDefault(furtherEducationEstablishment => furtherEducationEstablishment.ProviderUrn == establishment.Urn),
                        viewAcademyConversions?.FirstOrDefault(viewAcademyConversion => viewAcademyConversion.GeneralDetailsAcademyUrn == establishment.Urn.ToString()),
                        null)
                    )
                .ToList();
        }
    }
}
