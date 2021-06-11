using TramsDataApi.RequestModels.AcademyConversionProject;
using TramsDataApi.ResponseModels.AcademyConversionProject;

namespace TramsDataApi.UseCases
{
    public interface IUpdateAcademyConversionProject
    {
        AcademyConversionProjectResponse Execute(int id, UpdateAcademyConversionProjectRequest request);
    }
}