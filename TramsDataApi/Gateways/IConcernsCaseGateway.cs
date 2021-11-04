using System.Collections.Generic;
using TramsDataApi.DatabaseModels;

namespace TramsDataApi.Gateways
{
    public interface IConcernsCaseGateway
    {
        ConcernsCase SaveConcernsCase(ConcernsCase concernsCase);
        IList<ConcernsCase> GetConcernsCaseByTrustUkprn(string trustUkprn, int page, int count);
        ConcernsCase GetConcernsCaseByUrn(string urn);
    }
}