using TramsDataApi.DatabaseModels;

namespace TramsDataApi.Gateways
{
    public interface IConcernsRecordGateway
    {
        ConcernsRecord SaveConcernsCase(ConcernsRecord concernsRecord);
        ConcernsRecord Update(ConcernsRecord concernsRecord);
        ConcernsRecord GetConcernsRecordByUrn(int urn);
    }
}