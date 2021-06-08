using System.Linq;
using TramsDataApi.DatabaseModels;
using TramsDataApi.RequestModels.AcademyConversionProject;

namespace TramsDataApi.UseCases
{
    public class UpdateAcademyConversionProject : IUseCase<UpdateAcademyConversionProjectRequest, bool>
    {
        private readonly LegacyTramsDbContext _LegacyTramsDbContext;

        public UpdateAcademyConversionProject(LegacyTramsDbContext legacyTramsDbContext)
        {
            _LegacyTramsDbContext = legacyTramsDbContext;
        }

        public bool Execute(UpdateAcademyConversionProjectRequest request)
        {
            var ifdPipeline = _LegacyTramsDbContext.IfdPipeline.SingleOrDefault(x => x.Sk == request.Id);
            if (ifdPipeline == null)
            {
                return false;
            }

            ifdPipeline.ProjectTemplateInformationRationaleForProject = request.RationaleForProject;
            ifdPipeline.ProjectTemplateInformationRationaleForSponsor = request.RationaleForSponsor;

            _LegacyTramsDbContext.SaveChanges();

            return true;
        }
    }
}
