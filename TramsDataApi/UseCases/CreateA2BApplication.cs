using TramsDataApi.Factories;
using TramsDataApi.Gateways;
using TramsDataApi.RequestModels;
using TramsDataApi.RequestModels.ApplyToBecome;
using TramsDataApi.ResponseModels;
using TramsDataApi.ResponseModels.ApplyToBecome;

namespace TramsDataApi.UseCases
{
    public class CreateA2BApplication : ICreateA2BApplication
    {
        private readonly IA2BApplicationGateway _gateway;

        public CreateA2BApplication(IA2BApplicationGateway gateway)
        {
            _gateway = gateway;
        }

        public A2BApplicationResponse Execute(A2BApplicationCreateRequest request)
        {
            var applicationToCreate = A2BApplicationFactory.Create(request);
            var createdApplication = _gateway.CreateA2BApplication(applicationToCreate);
            return A2BApplicationResponseFactory.Create(createdApplication, null);
        }
        
    }
}