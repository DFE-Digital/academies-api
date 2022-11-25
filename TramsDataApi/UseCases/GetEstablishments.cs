using System.Collections.Generic;
using System.Linq;
using TramsDataApi.CensusData;
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
        private readonly ICensusDataGateway _censusGateway;

        public GetEstablishments(IEstablishmentGateway establishmentGateway, ICensusDataGateway censusGateway)
        {
            _establishmentGateway = establishmentGateway;
            _censusGateway = censusGateway;
        }

        public IList<EstablishmentResponse> Execute(string[] trustUids)
        {
            var establishments = _establishmentGateway.GetByTrustUids(trustUids);

            return BuildEstablishmentResponses(GetDistinctEstablishmentsByUrn(establishments));
        }

        public IList<EstablishmentResponse> Execute(GetEstablishmentsByUkprnsRequest request)
        {
            var establishments = _establishmentGateway.GetByUkprns(request.Ukprns);

            return BuildEstablishmentResponses(GetDistinctEstablishmentsByUkprn(establishments));
        }

        public IList<EstablishmentResponse> Execute(GetEstablishmentsByUrnsRequest request)
        {
            var establishments = _establishmentGateway.GetByUrns(request.Urns);

            return BuildEstablishmentResponses(GetDistinctEstablishmentsByUrn(establishments));
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
            IList<CensusDataModel> censusData = _censusGateway.GetCensusDataByURNs(establishmentUrns.Select(urn => urn.ToString()).ToArray());

            return establishments.Select(establishment =>
                    EstablishmentResponseFactory.Create(
                        establishment,
                        misEstablishments?.FirstOrDefault(misEstablishment => misEstablishment.Urn == establishment.Urn),
                        smartData?.FirstOrDefault(smartData => smartData.Urn == establishment.Urn.ToString()),
                        furtherEducationEstablishments?.FirstOrDefault(furtherEducationEstablishment => furtherEducationEstablishment.ProviderUrn == establishment.Urn),
                        viewAcademyConversions?.FirstOrDefault(viewAcademyConversion => viewAcademyConversion.GeneralDetailsAcademyUrn == establishment.Urn.ToString()),
                        censusData?.FirstOrDefault(censusData => censusData.URN == establishment.Urn.ToString()))
                    )
                .ToList();
        }

        private static IList<Establishment> GetDistinctEstablishmentsByUrn(IEnumerable<Establishment> establishments)
        {
            // Avoid any potential duplicate `Establishments`s. This mimics the way that
            // we call `FirstOrDefault` when fetching a single Establishment.
            return establishments.GroupBy(e => e.Urn).Select(g => g.First()).ToList();
        }

        private static IList<Establishment> GetDistinctEstablishmentsByUkprn(IEnumerable<Establishment> establishments)
        {
            // Avoid any potential duplicate `Establishments`s. This mimics the way that
            // we call `FirstOrDefault` when fetching a single Establishment.
            return establishments.GroupBy(e => e.Ukprn).Select(g => g.First()).ToList();
        }
    }
}
