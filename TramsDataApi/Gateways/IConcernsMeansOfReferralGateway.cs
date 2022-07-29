using System.Collections.Generic;
using TramsDataApi.DatabaseModels;

namespace TramsDataApi.Gateways
{
    public interface IConcernsMeansOfReferralGateway
    {
        IList<ConcernsMeansOfReferral> GetMeansOfReferrals();
        ConcernsMeansOfReferral GetMeansOfReferralByUrn(long urn);
    }
}