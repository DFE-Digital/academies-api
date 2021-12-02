using TramsDataApi.Factories;
using TramsDataApi.Gateways;
using TramsDataApi.RequestModels.ApplyToBecome;
using TramsDataApi.ResponseModels.ApplyToBecome;

namespace TramsDataApi.UseCases
{
    public class CreateA2BApplicationStatus : ICreateA2BApplicationStatus
    {
        private readonly IA2BApplicationStatusGateway _gateway;

        public CreateA2BApplicationStatus(IA2BApplicationStatusGateway gateway)
        {
            _gateway = gateway;
        }

        public A2BApplicationStatusResponse Execute(A2BApplicationStatusCreateRequest request)
        {
            var statusToCreate = A2BApplicationStatusFactory.Create(request);
            var createdStatus = _gateway.CreateA2BApplicationStatus(statusToCreate);
            return A2BApplicationStatusResponseFactory.Create(createdStatus);
        }
        
    }
}