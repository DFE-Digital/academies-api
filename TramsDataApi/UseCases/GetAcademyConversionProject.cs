using System.Threading.Tasks;
using TramsDataApi.Factories;
using TramsDataApi.Gateways;
using TramsDataApi.ResponseModels.AcademyConversionProject;

namespace TramsDataApi.UseCases
{
    public class GetAcademyConversionProject : IGetAcademyConversionProject
    {
        private readonly IAcademyConversionProjectGateway _academyConversionProjectGateway;
        private readonly IEstablishmentGateway _establishmentGateway;
       
        public GetAcademyConversionProject(
            IAcademyConversionProjectGateway academyConversionProjectGateway,
            IEstablishmentGateway establishmentGateway)
        {
            _academyConversionProjectGateway = academyConversionProjectGateway;
            _establishmentGateway = establishmentGateway;
        }

        public async Task<AcademyConversionProjectResponse> Execute(int id)
        {
            var academyConversionProject = await _academyConversionProjectGateway.GetById(id);
            if (academyConversionProject == null) return null;
            
            var response = AcademyConversionProjectResponseFactory.Create(academyConversionProject);
            response.UkPrn = _establishmentGateway.GetByUrn(response.Urn)?.Ukprn;
            response.Laestab = _establishmentGateway.GetMisEstablishmentByUrn(response.Urn)?.Laestab ?? 0;

            return response;
        }
    }
}
