using System.Collections.Generic;
using System.Linq;
using TramsDataApi.DatabaseModels;

namespace TramsDataApi.UseCases
{
    public class GetKeyStagePerformanceByUkprn : IGetKeyStagePerformanceByUkprn
    {
        private readonly LegacyTramsDbContext _legacyTramsDbContext;

        public GetKeyStagePerformanceByUkprn(LegacyTramsDbContext legacyTramsDbContext)
        {
            _legacyTramsDbContext = legacyTramsDbContext;
        }

        public List<SipPhonics> Execute(string year)
        {
            return _legacyTramsDbContext.SipPhonics.Where(ph => ph.SipYear == year).ToList();
        }
    }
}