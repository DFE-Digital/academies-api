using System.Collections.Generic;
using System.Threading.Tasks;
using TramsDataApi.ResponseModels.AcademyConversionProject;

namespace TramsDataApi.UseCases
{
    public interface IGetAcademyConversionProjects
    {
        Task<List<AcademyConversionProjectResponse>> Execute(int page, int count);
    }
}