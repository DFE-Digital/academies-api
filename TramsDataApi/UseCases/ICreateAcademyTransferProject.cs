using TramsDataApi.RequestModels.AcademyTransferProject;
using TramsDataApi.ResponseModels;

namespace TramsDataApi.UseCases
{
    public interface ICreateAcademyTransferProject
    {
        public AcademyTransferProjectResponse Execute(AcademyTransferProjectRequest request);
    }
}