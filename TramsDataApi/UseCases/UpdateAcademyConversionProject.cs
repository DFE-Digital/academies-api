using System.Linq;
using TramsDataApi.DatabaseModels;
using TramsDataApi.Factories;
using TramsDataApi.RequestModels.AcademyConversionProject;
using TramsDataApi.ResponseModels.AcademyConversionProject;

namespace TramsDataApi.UseCases
{
    public class UpdateAcademyConversionProject : IUseCase<UpdateAcademyConversionProjectRequest, AcademyConversionProjectResponse>
    {
        private readonly LegacyTramsDbContext _legacyTramsDbContext;

        public UpdateAcademyConversionProject(LegacyTramsDbContext legacyTramsDbContext)
        {
            _legacyTramsDbContext = legacyTramsDbContext;
        }

        public AcademyConversionProjectResponse Execute(UpdateAcademyConversionProjectRequest request)
        {
            var ifdPipeline = _legacyTramsDbContext.IfdPipeline.SingleOrDefault(x => x.Sk == request.Id);
            if (ifdPipeline == null)
            {
                return null;
            }

            var updatedProject = AcademyConversionProjectFactory.Update(ifdPipeline, request);

            _legacyTramsDbContext.Update(updatedProject);
            _legacyTramsDbContext.SaveChanges();

            return AcademyConversionProjectResponseFactory.Create(updatedProject);
        }
    }
}
