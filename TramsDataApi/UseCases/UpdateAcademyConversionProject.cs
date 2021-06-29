using System.Linq;
using Microsoft.EntityFrameworkCore;
using TramsDataApi.DatabaseModels;
using TramsDataApi.Factories;
using TramsDataApi.Gateways;
using TramsDataApi.RequestModels.AcademyConversionProject;
using TramsDataApi.ResponseModels.AcademyConversionProject;

namespace TramsDataApi.UseCases
{
    public class UpdateAcademyConversionProject : IUpdateAcademyConversionProject
    {
        private readonly LegacyTramsDbContext _legacyTramsDbContext;
        private readonly TramsDbContext _tramsDbContext;
        private readonly ITrustGateway _trustGateway;

        public UpdateAcademyConversionProject(LegacyTramsDbContext legacyTramsDbContext, TramsDbContext tramsDbContext, ITrustGateway trustGateway)
        {
            _legacyTramsDbContext = legacyTramsDbContext;
            _tramsDbContext = tramsDbContext;
            _trustGateway = trustGateway;
        }

        public AcademyConversionProjectResponse Execute(int id, UpdateAcademyConversionProjectRequest request)
        {
            var ifdPipeline = _legacyTramsDbContext.IfdPipeline.SingleOrDefault(x => x.Sk == id);
            if (ifdPipeline == null)
            {
                return null;
            }

            var academyConversionProject = _tramsDbContext.AcademyConversionProjects
                                               .Include(p => p.ProjectNotes)
                                               .SingleOrDefault(p => p.IfdPipelineId == id) ??
                                           new AcademyConversionProject{IfdPipelineId = id};

            var updatedIfdPipeline = AcademyConversionProjectFactory.Update(ifdPipeline, request);
            _legacyTramsDbContext.Update(updatedIfdPipeline);

            var updatedProject = AcademyConversionProjectFactory.Update(academyConversionProject, request);
            _tramsDbContext.Update(updatedProject);

            _legacyTramsDbContext.SaveChanges();
            _tramsDbContext.SaveChanges();

            Trust trust = null;
            if (!string.IsNullOrEmpty(ifdPipeline.TrustSponsorManagementTrust))
            {
                trust = _trustGateway.GetIfdTrustByGroupId(ifdPipeline.TrustSponsorManagementTrust);
            }

            return AcademyConversionProjectResponseFactory.Create(updatedIfdPipeline, trust, updatedProject);
        }
    }
}
