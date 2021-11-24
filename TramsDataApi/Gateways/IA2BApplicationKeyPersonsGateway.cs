using TramsDataApi.DatabaseModels;

namespace TramsDataApi.Gateways
{
    public interface IA2BApplicationKeyPersonsGateway
    {
        A2BApplicationKeyPersons GetByKeyPersonsId(int keyPersonsId);
        A2BApplicationKeyPersons CreateA2BApplicationKeyPersons(A2BApplicationKeyPersons keyPersons);
    }
}