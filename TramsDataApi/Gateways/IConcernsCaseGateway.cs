using System.Collections.Generic;
using TramsDataApi.DatabaseModels;

namespace TramsDataApi.Gateways
{
    public interface IConcernsCaseGateway
    {
        ConcernsCase SaveConcernsCase(ConcernsCase concernsCase);
        IList<ConcernsCase> GetConcernsCaseByTrustUkprn(string trustUkprn, int page, int count);
        ConcernsCase GetConcernsCaseByUrn(int urn);
        ConcernsCase Update(ConcernsCase concernsCase);
        ConcernsCase GetConcernsCaseIncludingRecordsByUrn(int urn);
        IList<ConcernsCase> GetConcernsCasesByOwnerId(string ownerId, int? statusUrn, int page, int count);
    }
}