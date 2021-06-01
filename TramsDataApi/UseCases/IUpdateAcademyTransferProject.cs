using TramsDataApi.RequestModels;
using TramsDataApi.ResponseModels;

namespace TramsDataApi.UseCases
{
    public interface IUpdateAcademyTransferProject
    {
        AcademyTransferProjectResponse Execute(string urn, AcademyTransferProjectRequest updateRequest);
    }
}