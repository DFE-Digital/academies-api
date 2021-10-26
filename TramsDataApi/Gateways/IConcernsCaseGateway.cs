using TramsDataApi.DatabaseModels;

namespace TramsDataApi.Gateways
{
    public interface IConcernsCaseGateway
    {
        ConcernsCase SaveConcernsCase(ConcernsCase concernsCase);
        ConcernsCase GetConcernsCaseByTrustUkprn(string trustUkprn);
        ConcernsCase GetConcernsCaseByUrn(string urn);
    }
}