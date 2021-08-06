using TramsDataApi.DatabaseModels;
using TramsDataApi.Factories;
using TramsDataApi.Gateways;
using TramsDataApi.RequestModels;
using TramsDataApi.ResponseModels;

namespace TramsDataApi.UseCases
{
    public class GetEstablishment : 
        IGetEstablishmentByUkprn,
        IUseCase<GetEstablishmentByUrnRequest, EstablishmentResponse>
    {
        private readonly IEstablishmentGateway _establishmentGateway;
        private readonly ICensusDataGateway _censusDataGateway;

        public GetEstablishment(IEstablishmentGateway establishmentGateway, ICensusDataGateway censusDataGateway)
        {
            _establishmentGateway = establishmentGateway;
            _censusDataGateway = censusDataGateway;
        }
        
        public EstablishmentResponse Execute(string ukprn)
        {
            var establishment = _establishmentGateway.GetByUkprn(ukprn);
            return BuildResponse(establishment);
        }

        public EstablishmentResponse Execute(GetEstablishmentByUrnRequest request)
        {
            var establishment = _establishmentGateway.GetByUrn(request.URN);
            return BuildResponse(establishment);
        }

        private EstablishmentResponse BuildResponse(Establishment establishment)
        {
            if (establishment == null)
            {
                return null;
            }
            var misEstablishmentData = _establishmentGateway.GetMisEstablishmentByUrn(establishment.Urn);
            var furtherEstablishmentData = _establishmentGateway.GetFurtherEducationEstablishmentByUrn(establishment.Urn);
            var smartData = _establishmentGateway.GetSmartDataByUrn(establishment.Urn);
            var viewAcademyConversion = _establishmentGateway.GetViewAcademyConversionInfoByUrn(establishment.Urn);
            var censusData = _censusDataGateway.GetCensusDataByURN(establishment.Urn.ToString());


            return EstablishmentResponseFactory.Create(establishment, 
                misEstablishmentData, 
                smartData,
                furtherEstablishmentData,
                viewAcademyConversion,
                censusData
                );
        }
    }
}