using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using TramsDataApi.DatabaseModels;
using TramsDataApi.Factories;
using TramsDataApi.RequestModels.AcademyConversionProject;
using TramsDataApi.ResponseModels.AcademyConversionProject;

namespace TramsDataApi.UseCases
{
    public class GetAcademyConversionProjects :
        IUseCase<GetAcademyConversionProjectByIdRequest, AcademyConversionProjectResponse>,
        IUseCase<GetAllAcademyConversionProjectsRequest, IEnumerable<AcademyConversionProjectResponse>>
    {
        private readonly LegacyTramsDbContext _legacyTramsDbContext;
        private readonly TramsDbContext _tramsDbContext;

        public GetAcademyConversionProjects(LegacyTramsDbContext legacyTramsDbContext, TramsDbContext tramsDbContext)
        {
            _legacyTramsDbContext = legacyTramsDbContext;
            _tramsDbContext = tramsDbContext;
        }

        public AcademyConversionProjectResponse Execute(GetAcademyConversionProjectByIdRequest request)
        {
            var ifdPipeline = _legacyTramsDbContext.IfdPipeline.AsNoTracking().FirstOrDefault(p => p.Sk == request.Id);
            if (ifdPipeline == null)
            {
                return null;
            }

            var academyConversionProject = _tramsDbContext.AcademyConversionProject.SingleOrDefault(p => p.IfdPipelineId == request.Id);

            return AcademyConversionProjectResponseFactory.Create(ifdPipeline, academyConversionProject);
        }

        public IEnumerable<AcademyConversionProjectResponse> Execute(GetAllAcademyConversionProjectsRequest request)
        {
            var ifdPipelines = _legacyTramsDbContext.IfdPipeline.Take(request.Count).AsNoTracking().ToList();

            return ifdPipelines.Select(p => AcademyConversionProjectResponseFactory.Create(p)).ToList();
        }
    }
}
