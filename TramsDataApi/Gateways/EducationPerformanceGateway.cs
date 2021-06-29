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

        public SipEducationalperformancedata GetNationalEducationalPerformanceForYear(string year)
        {
            var result = _dbContext.SipEducationalperformancedata
                .Join(_dbContext.GlobalOptionSetMetadata,
                    gpd => gpd.SipPerformancetype,
                    gom => gom.Option,
                    (gpd, gom) => new {performanceData = gpd, globalMetaData = gom})
                 .Where(data => data.globalMetaData.OptionSetName == "sip_performancetype")
                 .Where(data => data.globalMetaData.LocalizedLabel == "National")
                 .Where(data => data.performanceData.SipName == year)
                .Select(data => data.performanceData)
                .FirstOrDefault();

            return result;
        }
    }
}