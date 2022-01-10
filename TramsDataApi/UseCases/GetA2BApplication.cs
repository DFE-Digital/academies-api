using TramsDataApi.DatabaseModels;
using TramsDataApi.Factories;
using TramsDataApi.Gateways;
using TramsDataApi.RequestModels.ApplyToBecome;
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
            A2BApplicationAccount account = null;
            
            //Need to pass in A2BAccountDetails once we know how to source this data
            return application != null 
                ? A2BApplicationResponseFactory.Create(application , account) 
                : null;
        }
    }
}
