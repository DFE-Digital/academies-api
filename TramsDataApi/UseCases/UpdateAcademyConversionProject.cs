using System.Threading.Tasks;
using TramsDataApi.DatabaseModels;
using TramsDataApi.Factories;
using TramsDataApi.Gateways;
using TramsDataApi.RequestModels.AcademyConversionProject;
using TramsDataApi.ResponseModels.AcademyConversionProject;

namespace TramsDataApi.UseCases
{
    public class UpdateAcademyConversionProject : IUpdateAcademyConversionProject
    {
        private readonly IAcademyConversionProjectGateway _academyConversionProjectGateway;

        public UpdateAcademyConversionProject(IAcademyConversionProjectGateway academyConversionProjectGateway, ITrustGateway trustGateway)
        {
            _academyConversionProjectGateway = academyConversionProjectGateway;
        }

        public async Task<AcademyConversionProjectResponse> Execute(int id, UpdateAcademyConversionProjectRequest request)
        {
            AcademyConversionProject academyConversionProject = await _academyConversionProjectGateway.GetById(id);
            if (academyConversionProject == null)
            {
                return null;
            }

            AcademyConversionProject updatedProject = AcademyConversionProjectFactory.Update(academyConversionProject, request);
            await _academyConversionProjectGateway.Update(updatedProject);

            return AcademyConversionProjectResponseFactory.Create(updatedProject);
        }
    }
}
