
using TramsDataApi.Factories;
using TramsDataApi.Gateways;
using TramsDataApi.RequestModels.ApplyToBecome;
using TramsDataApi.ResponseModels.ApplyToBecome;

namespace TramsDataApi.UseCases
{
    public class CreateA2BApplicationKeyPersons : ICreateA2BApplicationKeyPersons
    {
        private readonly IA2BApplicationKeyPersonsGateway _gateway;

        public CreateA2BApplicationKeyPersons(IA2BApplicationKeyPersonsGateway gateway)
        {
            _gateway = gateway;
        }

        public A2BApplicationKeyPersonsResponse Execute(A2BApplicationKeyPersonsCreateRequest request)
        {
            var keyPersonsToCreate = A2BApplicationKeyPersonsFactory.Create(request);
            var createdKeyPersons = _gateway.CreateA2BApplicationKeyPersons(keyPersonsToCreate);
            return A2BApplicationKeyPersonsResponseFactory.Create(createdKeyPersons);
        }
        
    }
}