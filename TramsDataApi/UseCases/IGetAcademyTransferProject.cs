using TramsDataApi.ResponseModels;

namespace TramsDataApi.UseCases
{
    public interface IGetAcademyTransferProject
    {
        AcademyTransferProjectResponse Execute(string urn);
    }
}