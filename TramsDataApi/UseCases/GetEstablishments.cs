using System.Collections.Generic;
using System.Linq;
using TramsDataApi.DatabaseModels;
using TramsDataApi.Factories;
using TramsDataApi.Gateways;
using TramsDataApi.RequestModels;
using TramsDataApi.ResponseModels;

namespace TramsDataApi.UseCases
{
    public class GetEstablishments : IGetEstablishments
    {
        private readonly IEstablishmentGateway _establishmentGateway;

        public GetEstablishments(IEstablishmentGateway establishmentGateway)
        {
            _establishmentGateway = establishmentGateway;
        }

        public IList<EstablishmentResponse> Execute(string[] trustUids)
        {
            var establishments = _establishmentGateway.GetByTrustUids(trustUids);

            if (!establishments.Any())
            {
                return null;
            }

            return BuildEstablishmentResponses(establishments);
        }

        public IList<EstablishmentResponse> Execute(GetEstablishmentsByUkprnsRequest request)
        {
            var establishments = _establishmentGateway.GetByUkprns(request.Ukprns);

            if (!establishments.Any())
            {
                return null;
            }

            return BuildEstablishmentResponses(establishments);
        }

        public IList<EstablishmentResponse> Execute(GetEstablishmentsByUrnsRequest request)
        {
            var establishments = _establishmentGateway.GetByUrns(request.Urns);

            if (!establishments.Any())
            {
                return null;
            }

            return BuildEstablishmentResponses(establishments);
        }

        private IList<EstablishmentResponse> BuildEstablishmentResponses(IList<Establishment> establishments)
        {
            var establishmentUrns = establishments.Select(establishment => establishment.Urn).ToArray();

            var misEstablishments = _establishmentGateway.GetMisEstablishmentsByUrns(establishmentUrns);
            var smartData = _establishmentGateway.GetSmartDataByUrns(establishmentUrns);
            var furtherEducationEstablishments = _establishmentGateway.GetFurtherEducationEstablishmentsByUrns(establishmentUrns);
            var viewAcademyConversions = _establishmentGateway.GetViewAcademyConversionInfoByUrns(establishmentUrns);

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
