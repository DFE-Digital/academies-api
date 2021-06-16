using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using TramsDataApi.DatabaseModels;
using TramsDataApi.Factories;
using TramsDataApi.RequestModels.AcademyConversionProject;
using TramsDataApi.ResponseModels.AcademyConversionProject;

namespace TramsDataApi.UseCases
{
    public class UpdateAcademyConversionProject : IUpdateAcademyConversionProject
    {
        private readonly LegacyTramsDbContext _legacyTramsDbContext;
        private readonly TramsDbContext _tramsDbContext;

        public UpdateAcademyConversionProject(LegacyTramsDbContext legacyTramsDbContext, TramsDbContext tramsDbContext)
        {
            _legacyTramsDbContext = legacyTramsDbContext;
            _tramsDbContext = tramsDbContext;
        }

        public AcademyConversionProjectResponse Execute(int id, UpdateAcademyConversionProjectRequest request)
        {
            var ifdPipeline = _legacyTramsDbContext.IfdPipeline.SingleOrDefault(x => x.Sk == id);
            if (ifdPipeline == null)
            {
                return null;
            }

            var academyConversionProject = _tramsDbContext.AcademyConversionProject.SingleOrDefault(p => p.IfdPipelineId == id) ??
                                           new AcademyConversionProject{IfdPipelineId = id};

            var updatedIfdPipeline = AcademyConversionProjectFactory.Update(ifdPipeline, request);
            _legacyTramsDbContext.Update(updatedIfdPipeline);

            var updatedProject = AcademyConversionProjectFactory.Update(academyConversionProject, request);
            _tramsDbContext.Update(updatedProject);

            _legacyTramsDbContext.SaveChanges();
            _tramsDbContext.SaveChanges();

            return AcademyConversionProjectResponseFactory.Create(updatedIfdPipeline, updatedProject);
        }
    }
}
