using System.Collections.Generic;
using System.Linq;
using TramsDataApi.DatabaseModels;

namespace TramsDataApi.Gateways
{
    public class EducationPerformanceGateway : IEducationPerformanceGateway
    {
        
        private readonly LegacyTramsDbContext _dbContext;

        public EducationPerformanceGateway(LegacyTramsDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public Account GetAccountByUrn(string urn)
        {
            return _dbContext.Account.FirstOrDefault(a => a.SipUrn == urn);
            
        }

        public IList<SipPhonics> GetPhonicsByUrn(string urn)
        {
            return _dbContext.SipPhonics.Where(ph => ph.SipUrn == urn).ToList();
        }

        public IList<SipEducationalperformancedata> GetEducationalPerformanceForAccount(Account account)
        {
            var results = _dbContext.SipEducationalperformancedata
                .Where(epd => epd.SipParentaccountid == account.Id)
                .ToList();

            return results;
        }
    }
}