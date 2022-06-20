using System.Threading.Tasks;
using TramsDataApi.ResponseModels.AcademyConversionProject;

namespace TramsDataApi.UseCases
{
    public interface IGetAcademyConversionProject
    {
        Task<AcademyConversionProjectResponse> Execute(int id);
    }
}