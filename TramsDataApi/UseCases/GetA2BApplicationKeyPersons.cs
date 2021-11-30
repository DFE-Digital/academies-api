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

        public A2BApplicationKeyPersonsResponse Execute(int keyPersonId)
        {
            var keyPersons = _keyPersonsGateway.GetByKeyPersonsId(keyPersonId);

            return keyPersons != null 
                ? A2BApplicationKeyPersonsResponseFactory.Create(keyPersons) 
                : null;
        }
    }
}
