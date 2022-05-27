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
        private readonly ITrustGateway _trustGateway;

        public UpdateAcademyConversionProject(IAcademyConversionProjectGateway academyConversionProjectGateway, ITrustGateway trustGateway)
        {
            _academyConversionProjectGateway = academyConversionProjectGateway;
            _trustGateway = trustGateway;
        }

        public AcademyConversionProjectResponse Execute(int id, UpdateAcademyConversionProjectRequest request)
        {
            var academyConversionProject = _academyConversionProjectGateway.GetById(id);
            if (academyConversionProject == null)
            {
                return null;
            }

            var updatedProject = AcademyConversionProjectFactory.Update(academyConversionProject, request);
            _academyConversionProjectGateway.Update(updatedProject);

            return AcademyConversionProjectResponseFactory.Create(updatedProject);
        }
    }
}
