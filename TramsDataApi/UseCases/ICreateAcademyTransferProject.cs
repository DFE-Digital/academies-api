using TramsDataApi.RequestModels.AcademyTransferProject;
using TramsDataApi.ResponseModels.AcademyTransferProject;

namespace TramsDataApi.UseCases
{
    public interface ICreateAcademyTransferProject
    {
        public AcademyTransferProjectResponse Execute(AcademyTransferProjectRequest request);
    }
}