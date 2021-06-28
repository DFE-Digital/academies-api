using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using TramsDataApi.DatabaseModels;
using TramsDataApi.Factories;
using TramsDataApi.RequestModels.AcademyConversionProject;
using TramsDataApi.ResponseModels.AcademyConversionProject;

namespace TramsDataApi.UseCases
{
    public class GetAcademyConversionProjects : IUseCase<GetAllAcademyConversionProjectsRequest, IEnumerable<AcademyConversionProjectResponse>>
    {
        private readonly LegacyTramsDbContext _legacyTramsDbContext;

        public GetAcademyConversionProjects(LegacyTramsDbContext legacyTramsDbContext)
        {
            _legacyTramsDbContext = legacyTramsDbContext;
        }

        public IEnumerable<AcademyConversionProjectResponse> Execute(GetAllAcademyConversionProjectsRequest request)
        {
            var ifdPipelines = _legacyTramsDbContext.IfdPipeline.Take(request.Count).AsNoTracking().ToList();

            return ifdPipelines.Select(p => AcademyConversionProjectResponseFactory.Create(p)).ToList();
        }
    }
}
