using TramsDataApi.DatabaseModels;

namespace TramsDataApi.Gateways
{
    public interface IA2BContributorGateway
    {
        A2BContributor GetByContributorId(string contributorId);
        A2BContributor CreateA2BContributor(A2BContributor contributor);
    }
}