using System.Collections.Generic;
using System.Linq;
using TramsDataApi.DatabaseModels;
using TramsDataApi.Factories;
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
                .Select(ph => KeyStage1PerformanceResponseFactory.Create(ph)).ToList();

            var educationPerformance = _educationPerformanceGateway.GetEducationalPerformanceForAccount(academy);

            var groupedNationalAverages =
                _educationPerformanceGateway.GetNationalEducationalPerformanceData().GroupBy(epd => epd.SipName);

            var nationalAverageEducationPerformances = new List<SipEducationalperformancedata>();

            foreach (var group in groupedNationalAverages)
            {
                var nationalEducationPerformanceDataForYear = new SipEducationalperformancedata
                {
                    SipName = group.Key
                };
                foreach (var nationalEducationalPerformanceData in group)
                {
                    nationalEducationPerformanceDataForYear =
                        GroupedEducationPerformanceFactory.Create(nationalEducationPerformanceDataForYear,
                            nationalEducationalPerformanceData);
                }

                nationalAverageEducationPerformances.Add(nationalEducationPerformanceDataForYear);
            }


            var ks2Response = educationPerformance
                .Select(epd => KeyStage2PerformanceResponseFactory.Create(epd, null)).ToList();

            
            var ks4Response = educationPerformance
                .Select(epd => KeyStage4PerformanceResponseFactory
                    .Create(epd, nationalAverageEducationPerformances
                        .FirstOrDefault(national => national.SipName == epd.SipName))).ToList();
            
            return new EducationalPerformanceResponse
            {
                SchoolName = academy.Name,
                KeyStage1 = ks1Responses,
                KeyStage2 = ks2Response,
                KeyStage4 = ks4Response
            };

        }
    }

    
}