using TramsDataApi.ResponseModels.ApplyToBecome;

namespace TramsDataApi.UseCases
{
    public interface IGetA2BContributor
    {
        A2BContributorResponse Execute(string contributorId);
    }
}