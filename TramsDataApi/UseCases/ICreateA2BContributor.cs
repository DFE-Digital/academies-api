using TramsDataApi.RequestModels.ApplyToBecome;
using TramsDataApi.ResponseModels.ApplyToBecome;

namespace TramsDataApi.UseCases
{
    public interface ICreateA2BContributor
    {
        A2BContributorResponse Execute(A2BContributorCreateRequest request);
    }
}