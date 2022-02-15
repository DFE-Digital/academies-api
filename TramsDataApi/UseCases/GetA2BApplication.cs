using TramsDataApi.Factories;
using TramsDataApi.Factories.A2BApplicationFactories;
using TramsDataApi.Gateways;
using TramsDataApi.ResponseModels.ApplyToBecome;

namespace TramsDataApi.UseCases
{
    public class GetA2BApplication : IGetA2BApplication
    {
        private readonly IA2BApplicationGateway _applicationGateway;

        public GetA2BApplication(IA2BApplicationGateway applicationGateway)
        {
            _applicationGateway = applicationGateway;
        }
        
        public A2BApplicationResponse Execute(string applicationId)
        {
            var application = _applicationGateway.GetByApplicationId(applicationId);
            
            return application != null 
                ? A2BApplicationFactory.Create(application) 
                : null;
        }
    }
}
