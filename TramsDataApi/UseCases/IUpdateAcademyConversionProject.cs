using System.Threading.Tasks;
using TramsDataApi.RequestModels.AcademyConversionProject;
using TramsDataApi.ResponseModels.AcademyConversionProject;

namespace TramsDataApi.UseCases
{
    public interface IUpdateAcademyConversionProject
    {
        Task<AcademyConversionProjectResponse> Execute(int id, UpdateAcademyConversionProjectRequest request);
    }
}