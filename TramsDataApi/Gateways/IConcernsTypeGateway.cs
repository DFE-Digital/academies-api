using TramsDataApi.DatabaseModels;

namespace TramsDataApi.Gateways
{
    public interface IConcernsTypeGateway
    {
        ConcernsType GetConcernsTypeByUrn(int urn);
    }
}