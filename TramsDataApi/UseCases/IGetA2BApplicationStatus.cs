using TramsDataApi.ResponseModels.ApplyToBecome;

namespace TramsDataApi.UseCases
{
    public interface IGetA2BApplicationStatus
    {
        A2BApplicationStatusResponse Execute(int applicationStatusId);
    }
}