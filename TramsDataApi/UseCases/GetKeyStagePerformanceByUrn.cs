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

            return new EducationalPerformanceResponse
            {
                SchoolName = academy.Name,
                KeyStage1Responses = ks1Responses
            };

        }
    }

    
}