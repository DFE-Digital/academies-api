using System.Collections.Generic;
using TramsDataApi.DatabaseModels;
using TramsDataApi.Gateways;

namespace TramsDataApi.Gateways
{
    public interface IEducationPerformanceGateway
    {
        public Account GetAccountByUrn(string urn);
        public IList<SipPhonics> GetPhonicsByUrn(string urn);
        public IList<SipEducationalperformancedata> GetEducationalPerformanceForAccount(Account account);
        public IList<SipEducationalperformancedata> GetNationalEducationalPerformanceData();
        public IList<SipEducationalperformancedata> GetLocalAuthorityEducationalPerformanceData();
    }
}