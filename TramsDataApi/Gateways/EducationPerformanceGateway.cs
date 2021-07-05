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
        
        public IList<SipEducationalperformancedata> GetNationalEducationalPerformanceData()
        {
            var results = _dbContext.SipEducationalperformancedata
                .Join(_dbContext.GlobalOptionSetMetadata,
                    gpd => gpd.SipPerformancetype,
                    gom => gom.Option,
                    (gpd, gom) => new {performanceData = gpd, globalMetaData = gom})
                .Where(data => data.globalMetaData.OptionSetName == "sip_performancetype")
                .Where(data => data.globalMetaData.LocalizedLabel == "National")
                .Select(data => data.performanceData).ToList();

            return results;
        }
        
        public IList<SipEducationalperformancedata> GetLocalAuthorityEducationalPerformanceData()
        {
            var results = _dbContext.SipEducationalperformancedata
                .Join(_dbContext.GlobalOptionSetMetadata,
                    gpd => gpd.SipPerformancetype,
                    gom => gom.Option,
                    (gpd, gom) => new {performanceData = gpd, globalMetaData = gom})
                .Where(data => data.globalMetaData.OptionSetName == "sip_performancetype")
                .Where(data => data.globalMetaData.LocalizedLabel == "Authority")
                .Select(data => data.performanceData).ToList();

            return results;
        }
    }
}