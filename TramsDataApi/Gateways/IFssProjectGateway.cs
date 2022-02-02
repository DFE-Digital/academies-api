using System.Collections.Generic;
using TramsDataApi.DatabaseModels;

namespace TramsDataApi.Gateways
{
    public interface IFssProjectGateway
    {
        IList<FssProject> GetAll(int page, int count);
    }
}
