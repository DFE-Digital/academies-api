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
        private readonly TramsDbContext _tramsDbContext;

        public GetAcademyConversionProjects(TramsDbContext tramsDbContext)
        {
            _tramsDbContext = tramsDbContext;
        }

        public IEnumerable<AcademyConversionProjectResponse> Execute(GetAllAcademyConversionProjectsRequest request)
        {
            var ifdPipelines = _tramsDbContext.AcademyConversionProjects.Take(request.Count).AsNoTracking().ToList();

            return ifdPipelines.Select(p => AcademyConversionProjectResponseFactory.Create(p)).ToList();
        }
    }
}
