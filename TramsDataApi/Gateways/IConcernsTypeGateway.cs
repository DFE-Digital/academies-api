using System;
using System.Collections.Generic;
using TramsDataApi.DatabaseModels;

namespace TramsDataApi.Gateways
{
    [Obsolete("This is planned to be moved into the Concerns Casework API. If it is accessed by other APIs, please let the Concerns team know.")]
    public interface IConcernsTypeGateway
    {
        ConcernsType GetConcernsTypeByUrn(int urn);
        IList<ConcernsType> GetTypes();
    }
}