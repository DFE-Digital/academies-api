using TramsDataApi.Factories;
using TramsDataApi.Gateways;
using TramsDataApi.RequestModels.ApplyToBecome;
using TramsDataApi.ResponseModels.ApplyToBecome;

namespace TramsDataApi.UseCases
{
    public class GetA2BApplicationKeyPersons : IGetA2BApplicationKeyPersons
    {
        private readonly IA2BApplicationKeyPersonsGateway _keyPersonsGateway;

        public GetA2BApplicationKeyPersons(IA2BApplicationKeyPersonsGateway keyPersonsGateway)
        {
            _keyPersonsGateway = keyPersonsGateway;
        }

        public A2BApplicationKeyPersonsResponse Execute(A2BApplicationKeyPersonsByIdRequest request)
        {
            if (request == null) return null;
            
            var keyPersons = _keyPersonsGateway.GetByKeyPersonsId(request.KeyPersonsId);

            return keyPersons != null 
                ? A2BApplicationKeyPersonsResponseFactory.Create(keyPersons) 
                : null;
        }
    }
}
