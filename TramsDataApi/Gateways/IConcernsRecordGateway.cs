using System;
using TramsDataApi.DatabaseModels;

namespace TramsDataApi.Gateways
{
    [Obsolete("This is planned to be moved into the Concerns Casework API. If it is accessed by other APIs, please let the Concerns team know.")]
    public interface IConcernsRecordGateway
    {
        ConcernsRecord SaveConcernsCase(ConcernsRecord concernsRecord);
        ConcernsRecord Update(ConcernsRecord concernsRecord);
        ConcernsRecord GetConcernsRecordByUrn(int urn);
    }
}