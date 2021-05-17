using TramsDataApi.RequestModels;
using TramsDataApi.ResponseModels;

namespace TramsDataApi.UseCases
{
    public interface ICreateAcademyTransferProject
    {
        public AcademyTransferProjectResponse Execute(CreateOrUpdateAcademyTransferProjectRequest request);
    }
}