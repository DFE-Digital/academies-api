using TramsDataApi.Factories;
using TramsDataApi.Gateways;
using TramsDataApi.RequestModels.ApplyToBecome;
using TramsDataApi.ResponseModels.ApplyToBecome;

namespace TramsDataApi.UseCases
{
    public class CreateA2BContributor : ICreateA2BContributor
    {
        private readonly IA2BContributorGateway _gateway;

        public CreateA2BContributor(IA2BContributorGateway gateway)
        {
            _gateway = gateway;
        }

        public A2BContributorResponse Execute(A2BContributorCreateRequest request)
        {
            var contributorToCreate = A2BContributorFactory.Create(request);
            var createdContributor = _gateway.CreateA2BContributor(contributorToCreate);
            return A2BContributorResponseFactory.Create(createdContributor);
        }
    }
}