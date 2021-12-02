using TramsDataApi.Factories;
using TramsDataApi.Gateways;
using TramsDataApi.RequestModels.ApplyToBecome;
using TramsDataApi.ResponseModels.ApplyToBecome;

namespace TramsDataApi.UseCases
{
    public class GetA2BApplicationStatus : IGetA2BApplicationStatus
    {
        private readonly IA2BApplicationStatusGateway _gateway;

        public GetA2BApplicationStatus(IA2BApplicationStatusGateway gateway)
        {
            _gateway = gateway;
        }

        public A2BApplicationStatusResponse Execute(int applicationStatusId)
        {
            var status = _gateway.GetByStatusId(applicationStatusId);

            return status != null 
                ? A2BApplicationStatusResponseFactory.Create(status) 
                : null;
        }
    }
}