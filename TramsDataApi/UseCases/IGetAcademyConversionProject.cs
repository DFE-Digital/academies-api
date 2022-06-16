using TramsDataApi.ResponseModels.AcademyConversionProject;

namespace TramsDataApi.UseCases
{
    public interface IGetAcademyConversionProject
    {
        AcademyConversionProjectResponse Execute(int id);
    }
}