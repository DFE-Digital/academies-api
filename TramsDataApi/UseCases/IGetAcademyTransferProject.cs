using TramsDataApi.ResponseModels.AcademyTransferProject;

namespace TramsDataApi.UseCases
{
    public interface IGetAcademyTransferProject
    {
        AcademyTransferProjectResponse Execute(int urn);
    }
}