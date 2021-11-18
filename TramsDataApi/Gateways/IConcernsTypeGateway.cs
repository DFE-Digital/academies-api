using System.Collections.Generic;
using TramsDataApi.DatabaseModels;

namespace TramsDataApi.Gateways
{
    public interface IConcernsTypeGateway
    {
        ConcernsType GetConcernsTypeByUrn(int urn);
        IList<ConcernsType> GetTypes();
    }
}