using System.Collections.Generic;
using System.Linq;
using TramsDataApi.DatabaseModels;
using TramsDataApi.Gateways;
using TramsDataApi.ResponseModels.EducationalPerformance;

namespace TramsDataApi.UseCases
{
    public class GetKeyStagePerformanceByUrn : IGetKeyStagePerformanceByUrn
    {
        private readonly IEducationPerformanceGateway _educationPerformanceGateway;

        public GetKeyStagePerformanceByUrn(IEducationPerformanceGateway educationPerformanceGateway)
        {
            _educationPerformanceGateway = educationPerformanceGateway;
        }

        public EducationalPerformanceResponse Execute(string urn)
        {
            var academy = _educationPerformanceGateway.GetAccountByUrn(urn);
            if (academy == null)
            {
                return null;
            }

            var ks1Responses = _educationPerformanceGateway.GetPhonicsByUrn(urn)
                .Select(ph => new KeyStage1PerformanceResponse
                {
                    Year = ph.SipYear,
                    Reading = ph.SipKs1readingpercentageresults,
                    Writing = ph.SipKs1writingpercentageresults,
                    Maths = ph.SipKs1mathspercentageresults
                }).ToList();

            var ks2Response = _educationPerformanceGateway.GetEducationalPerformanceForAccount(academy)
                .Select(epd => new KeyStage2PerformanceResponse
                {
                    Year = epd.Year,
                    PercentageMeetingExpectedStdInRWM = new DisadvantagedPupilsResponse
                    {
                        NotDisadvantaged = epd.PercentageMeetingExpectedStdInRWM,
                        Disadvantaged = epd.PercentageMeetingExpectedStdInRWMDisadvantaged
                    },
                    PercentageAchievingHigherStdInRWM = new DisadvantagedPupilsResponse
                    {
                        NotDisadvantaged = epd.PercentageAchievingHigherStdInRWM,
                        Disadvantaged = epd.PercentageAchievingHigherStdInRWMDisadvantaged
                    },
                    ProgressScore = new DisadvantagedPupilsResponse
                    {
                        NotDisadvantaged = epd.ProgressScore,
                        Disadvantaged = epd.ProgressScoreDisadvantaged
                    }
                }).ToList();
            
            return new EducationalPerformanceResponse
            {
                SchoolName = academy.Name,
                KeyStage1 = ks1Responses,
                KeyStage2 = ks2Response
            };

        }
    }

    
}