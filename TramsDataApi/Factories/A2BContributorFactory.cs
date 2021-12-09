using TramsDataApi.DatabaseModels;
using TramsDataApi.RequestModels.ApplyToBecome;

namespace TramsDataApi.Factories
{
    public static class A2BContributorFactory
    {
        public static A2BContributor Create(A2BContributorCreateRequest request)
        {
            return request == null
                ? null
                : new A2BContributor
                {
                    ContributorUserId = request.ContributorUserId,
                    ApplicationTypeId = request.ApplicationTypeId,
                    ContributorAppIdTest = request.ContributorAppIdTest,
                    ContributorUserName = request.ContributorUserName
                };
        }
    }
}