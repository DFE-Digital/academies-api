using TramsDataApi.Factories;
using TramsDataApi.Gateways;
using TramsDataApi.ResponseModels.ApplyToBecome;

namespace TramsDataApi.UseCases
{
    public class GetA2BSchoolLease : IGetA2BSchoolLease
    {
        private readonly IA2BSchoolLeaseGateway _gateway;

        public GetA2BSchoolLease(IA2BSchoolLeaseGateway gateway)
        {
            _gateway = gateway;
        }

        public A2BSchoolLeaseResponse Execute(string leaseId)
        {
            var lease = _gateway.GetByLeaseId(leaseId);
            
            return leaseId != null 
                ? A2BSchoolLeaseResponseFactory.Create(lease) 
                : null;
        }
    }
}