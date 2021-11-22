using TramsDataApi.DatabaseModels;
using TramsDataApi.Factories;
using TramsDataApi.Gateways;
using TramsDataApi.RequestModels.ApplyToBecome;
using TramsDataApi.ResponseModels.ApplyToBecome;

namespace TramsDataApi.UseCases
{
    public class GetA2BApplication : IUseCase<A2BApplicationByIdRequest, A2BApplicationResponse>
    {
        private readonly IA2BApplicationGateway _applicationGateway;

        public GetA2BApplication(IA2BApplicationGateway applicationGateway)
        {
            _applicationGateway = applicationGateway;
        }


        public A2BApplicationResponse Execute(A2BApplicationByIdRequest request)
        {
            if (request == null) return null;
            
            var application = _applicationGateway.GetByApplicationId(request.ApplicationId);
            A2BApplicationAccount account = null;
            
            //Need to pass in A2BAccountDetails once we know how to source this data
            return application != null 
                ? A2BApplicationResponseFactory.Create(application , account) 
                : null;
        }
    }
}
