using TramsDataApi.DatabaseModels;

namespace TramsDataApi.Gateways
{
    public interface IConcernsRecordGateway
    {
        ConcernsRecord SaveConcernsCase(ConcernsRecord concernsRecord);
    }
}