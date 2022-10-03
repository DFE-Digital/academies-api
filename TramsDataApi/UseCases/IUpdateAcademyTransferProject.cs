using TramsDataApi.RequestModels.AcademyTransferProject;
using TramsDataApi.ResponseModels;

namespace TramsDataApi.UseCases
{
    public interface IUpdateAcademyTransferProject
    {
        AcademyTransferProjectResponse Execute(int urn, AcademyTransferProjectRequest updateRequest);
    }
}