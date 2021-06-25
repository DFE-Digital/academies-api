using System.Linq;
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
            var ks2Response = educationPerformance
                .Select(epd => KeyStage2PerformanceResponseFactory.Create(epd)).ToList();
            
            var ks4Response = educationPerformance
                .Select(epd => KeyStage4PerformanceResponseFactory.Create(epd)).ToList();
            
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