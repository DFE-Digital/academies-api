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
        private readonly ICensusDataGateway _cencusGateway;

        public GetEstablishments(IEstablishmentGateway establishmentGateway, ICensusDataGateway cencusGateway)
        {
            _establishmentGateway = establishmentGateway;
            _cencusGateway = cencusGateway;
        }

        public IList<EstablishmentResponse> Execute(string[] trustUids)
        {
            var establishments = _establishmentGateway.GetByTrustUids(trustUids);

            return BuildEstablishmentResponses(establishments);
        }

        public IList<EstablishmentResponse> Execute(GetEstablishmentsByUrnsRequest request)
        {
            var establishments = _establishmentGateway.GetByUrns(request.Urns);

            return BuildEstablishmentResponses(establishments);
        }

        private IList<EstablishmentResponse> BuildEstablishmentResponses(IList<Establishment> establishments)
        {
            var establishmentUrns = establishments.Select(establishment => establishment.Urn).ToArray();

            if (!establishments.Any())
            {
                return null;
            }

            var misEstablishments = _establishmentGateway.GetMisEstablishmentsByUrns(establishmentUrns);
            var smartData = _establishmentGateway.GetSmartDataByUrns(establishmentUrns);
            var furtherEducationEstablishments = _establishmentGateway.GetFurtherEducationEstablishmentsByUrns(establishmentUrns);
            var viewAcademyConversions = _establishmentGateway.GetViewAcademyConversionInfoByUrns(establishmentUrns);
            var cencusData = _cencusGateway.GetCensusDataByURNs(establishmentUrns.Select(urn => urn.ToString()).ToArray());

            // Avoid any potential duplicate `Establishments`s. This mimics the way that
            // we call `FirstOrDefault` when fetching a single Establishment.
            var distinctEstablishments = establishments.GroupBy(e => e.Urn).Select(g => g.First());

            return distinctEstablishments.Select(establishment =>
                    EstablishmentResponseFactory.Create(
                        establishment,
                        misEstablishments?.FirstOrDefault(misEstablishment => misEstablishment.Urn == establishment.Urn),
                        smartData?.FirstOrDefault(smartData => smartData.Urn == establishment.Urn.ToString()),
                        furtherEducationEstablishments?.FirstOrDefault(furtherEducationEstablishment => furtherEducationEstablishment.ProviderUrn == establishment.Urn),
                        viewAcademyConversions?.FirstOrDefault(viewAcademyConversion => viewAcademyConversion.GeneralDetailsAcademyUrn == establishment.Urn.ToString()),
                        cencusData?.FirstOrDefault(cencusData => cencusData.URN == establishment.Urn.ToString()))
                    )
                .ToList();
        }
    }
}
