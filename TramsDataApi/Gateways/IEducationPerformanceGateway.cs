using System.Collections.Generic;
using TramsDataApi.DatabaseModels;

namespace TramsDataApi.Gateways
{
    public interface IEducationPerformanceGateway
    {
        public Account GetAccountByUrn(string urn);
        public IList<SipPhonics> GetPhonicsByUrn(string urn);
    }
}