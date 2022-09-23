using System;
using System.Collections.Generic;
using TramsDataApi.DatabaseModels;

namespace TramsDataApi.Gateways
{
    [Obsolete("This is planned to be moved into the Concerns Casework API. If it is accessed by other APIs, please let the Concerns team know.")]
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