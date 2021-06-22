using System.Collections.Generic;
using System.Linq;
using TramsDataApi.DatabaseModels;
using TramsDataApi.ResponseModels.EducationalPerformance;

namespace TramsDataApi.UseCases
{
    public class GetKeyStagePerformanceByUrn : IGetKeyStagePerformanceByUrn
    {
        private readonly LegacyTramsDbContext _legacyTramsDbContext;

        public GetKeyStagePerformanceByUrn(LegacyTramsDbContext legacyTramsDbContext)
        {
            _legacyTramsDbContext = legacyTramsDbContext;
        }

        public EducationalPerformanceResponse Execute(string urn)
        {
            var academy = _legacyTramsDbContext.Account.FirstOrDefault(a => a.SipUrn == urn);
            if (academy == null)
            {
                return null;
            }

            var ks1Responses = _legacyTramsDbContext.SipPhonics.Where(ph => ph.SipUrn == urn)
                .Select(ph => new KeyStage1PerformanceResponse
                {
                    Year = ph.SipYear,
                    Reading = ph.SipKs1readingpercentageresults,
                    Writing = ph.SipKs1writingpercentageresults,
                    Maths = ph.SipKs1mathspercentageresults
                }).ToList();

            return new EducationalPerformanceResponse
            {
                SchoolName = academy.Name,
                KeyStage1Responses = ks1Responses
            };

        }
    }

    
}