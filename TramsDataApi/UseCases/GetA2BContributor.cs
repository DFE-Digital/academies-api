using TramsDataApi.Factories;
using TramsDataApi.Gateways;
using TramsDataApi.ResponseModels.ApplyToBecome;

namespace TramsDataApi.UseCases
{
    public class GetA2BContributor : IGetA2BContributor
    {
        private readonly IA2BContributorGateway _gateway;

        public GetA2BContributor(IA2BContributorGateway gateway)
        {
            _gateway = gateway;
        }

        public A2BContributorResponse Execute(string contributorId)
        {
            var contributor = _gateway.GetByContributorId(contributorId);

            return contributorId != null 
                ? A2BContributorResponseFactory.Create(contributor) 
                : null;
        }
    }
}