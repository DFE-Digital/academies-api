using TramsDataApi.DatabaseModels;
using TramsDataApi.ResponseModels.ApplyToBecome;

namespace TramsDataApi.Factories
{
    public class A2BContributorResponseFactory
    {
        public static A2BContributorResponse Create(A2BContributor request)
        { 
            return request is null ? null : new A2BContributorResponse
            {
                ContributorUserId = request.ContributorUserId,
                ApplicationTypeId = request.ApplicationTypeId,
                ContributorAppIdTest = request.ContributorAppIdTest,
                ContributorUserName = request.ContributorUserName
            };
        }
    }
}