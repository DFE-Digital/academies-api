using System.Collections.Generic;
using TramsDataApi.ResponseModels.AcademyConversionProject;

namespace TramsDataApi.UseCases
{
    public interface IGetAcademyConversionProjects
    {
        IEnumerable<AcademyConversionProjectResponse> Execute(int page, int count);
    }
}