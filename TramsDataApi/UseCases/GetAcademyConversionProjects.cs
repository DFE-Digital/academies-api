using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using TramsDataApi.DatabaseModels;
using TramsDataApi.Factories;
using TramsDataApi.RequestModels;
using TramsDataApi.ResponseModels.AcademyConversionProject;

namespace TramsDataApi.UseCases
{
    public class GetAcademyConversionProjects : 
        IUseCase<GetAcademyConversionProjectByIdRequest, AcademyConversionProjectResponse>, 
        IUseCase<GetAllAcademyConversionProjectsRequest, IEnumerable<AcademyConversionProjectResponse>>
    {
        private readonly TramsDbContext _tramsDbContext;

        public GetAcademyConversionProjects(TramsDbContext tramsDbContext)
        {
            _tramsDbContext = tramsDbContext;
        }

        public AcademyConversionProjectResponse Execute(GetAcademyConversionProjectByIdRequest request)
        {
            var ifdPipeline = _tramsDbContext.IfdPipeline.AsNoTracking().FirstOrDefault(p => p.Sk == request.Id);
            if (ifdPipeline == null)
            {
                return null;
            }

            return AcademyConversionProjectResponseFactory.Create(ifdPipeline);
        }

        public IEnumerable<AcademyConversionProjectResponse> Execute(GetAllAcademyConversionProjectsRequest request)
        {
            var ifdPipelines = _tramsDbContext.IfdPipeline.Take(request.Count).AsNoTracking().ToList();

            return ifdPipelines.Select(AcademyConversionProjectResponseFactory.Create).ToList();
        }
    }
}
