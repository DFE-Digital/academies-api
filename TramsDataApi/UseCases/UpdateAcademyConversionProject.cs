using System.Linq;
using TramsDataApi.DatabaseModels;
using TramsDataApi.Factories;
using TramsDataApi.Gateways;
using TramsDataApi.RequestModels.AcademyConversionProject;
using TramsDataApi.ResponseModels.AcademyConversionProject;

namespace TramsDataApi.UseCases
{
    public class UpdateAcademyConversionProject : IUpdateAcademyConversionProject
    {
        private readonly TramsDbContext _tramsDbContext;
        private readonly ITrustGateway _trustGateway;

        public UpdateAcademyConversionProject(TramsDbContext tramsDbContext, ITrustGateway trustGateway)
        {
            _tramsDbContext = tramsDbContext;
            _trustGateway = trustGateway;
        }

        public AcademyConversionProjectResponse Execute(int id, UpdateAcademyConversionProjectRequest request)
        {
            var academyConversionProject = _tramsDbContext.AcademyConversionProjects.SingleOrDefault(p => p.Id == id);
            if (academyConversionProject == null)
            {
                return null;
            }

            var updatedProject = AcademyConversionProjectFactory.Update(academyConversionProject, request);
            _tramsDbContext.AcademyConversionProjects.Update(updatedProject);
            _tramsDbContext.SaveChanges();

            Trust trust = null;
            if (!string.IsNullOrEmpty(academyConversionProject.TrustReferenceNumber))
            {
                trust = _trustGateway.GetIfdTrustByGroupId(academyConversionProject.TrustReferenceNumber);
            }

            return AcademyConversionProjectResponseFactory.Create(updatedProject, trust);
        }
    }
}
