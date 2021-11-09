using System.Collections.Generic;
using TramsDataApi.DatabaseModels;

namespace TramsDataApi.Gateways
{
    public interface IConcernsStatusGateway
    {
        IList<ConcernsStatus> GetStatuses();
    }
}