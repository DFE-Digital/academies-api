using TramsDataApi.Factories;
using TramsDataApi.Gateways;
using TramsDataApi.RequestModels.ApplyToBecome;
using TramsDataApi.ResponseModels.ApplyToBecome;

namespace TramsDataApi.UseCases
{
    public class CreateA2BSchoolLease : ICreateA2BSchoolLease
    {
        private readonly IA2BSchoolLeaseGateway _gateway;

        public CreateA2BSchoolLease(IA2BSchoolLeaseGateway gateway)
        {
            _gateway = gateway;
        }
        public A2BSchoolLeaseResponse Execute(A2BSchoolLeaseCreateRequest request)
        {
            var schoolLeaseToCreate = A2BSchoolLeaseFactory.Create(request);
            var createdSchoolLease = _gateway.CreateA2BSchoolLease(schoolLeaseToCreate);
            return A2BSchoolLeaseResponseFactory.Create(createdSchoolLease);
        }
    }
}