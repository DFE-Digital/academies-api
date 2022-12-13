using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using TramsDataApi.DatabaseModels;
using TramsDataApi.Factories.EducationPerformanceFactories;
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
            
            if (academy == null) return null;

            var ks1Responses = _educationPerformanceGateway
                .GetPhonicsByUrn(urn)
                .Select(KeyStage1PerformanceResponseFactory.Create)
                .ToList();

            var educationPerformance = _educationPerformanceGateway
                .GetEducationalPerformanceForAccount(academy)
                .ToList();

            var groupedNationalAverages = _educationPerformanceGateway
                .GetNationalEducationalPerformanceData()
                .GroupBy(epd => epd.SipName);
            
            var nationalAverageEducationPerformances = GroupAverageEducationPerformances(groupedNationalAverages);
            
            var groupedLaAverages = _educationPerformanceGateway
                .GetLocalAuthorityEducationalPerformanceData(academy)
                .GroupBy(epd => epd.SipName);

            var localAuthorityAverageEducationPerformances = GroupAverageEducationPerformances(groupedLaAverages);
    
            var response = new EducationalPerformanceResponse
            {
                SchoolName = academy.Name,
                KeyStage1 = ks1Responses,
                KeyStage2 = new List<KeyStage2PerformanceResponse>(),
                KeyStage4 = new List<KeyStage4PerformanceResponse>(),
                KeyStage5 = new List<KeyStage5PerformanceResponse>()
            };
            
            educationPerformance.GroupBy(a => a.SipName).Select(g => g.First()).ToList().ForEach(epd =>
            {
                response.KeyStage2.Add(KeyStage2PerformanceResponseFactory.Create(
                    epd,
                    nationalAverageEducationPerformances.FirstOrDefault(national => national.SipName == epd.SipName),
                    localAuthorityAverageEducationPerformances.FirstOrDefault(la => la.SipName == epd.SipName)
                ));

                response.KeyStage4.Add(KeyStage4PerformanceResponseFactory.Create(
                    epd,
                    nationalAverageEducationPerformances.FirstOrDefault(national => national.SipName == epd.SipName),
                    localAuthorityAverageEducationPerformances.FirstOrDefault(la => la.SipName == epd.SipName)
                ));

                response.KeyStage5.Add(KeyStage5PerformanceResponseFactory.Create(
                    epd,
                    nationalAverageEducationPerformances.FirstOrDefault(national => national.SipName == epd.SipName),
                    localAuthorityAverageEducationPerformances.FirstOrDefault(la => la.SipName == epd.SipName)
                ));
            });

            return response;
        }

        private static List<SipEducationalperformancedata> GroupAverageEducationPerformances(IEnumerable<IGrouping<string, SipEducationalperformancedata>> enumerable)
        {
            var result = new ConcurrentBag<SipEducationalperformancedata>();
            
            var query = enumerable.AsParallel();
            
            query.ForAll(group =>
            {
                var nationalEducationPerformanceDataForYear = new SipEducationalperformancedata {SipName = group.Key};
                var sipEducationalPerformanceData = group.Aggregate(nationalEducationPerformanceDataForYear, GroupedEducationPerformanceFactory.Create);
                result.Add(sipEducationalPerformanceData);
            });

            return result.ToList();
        } 
    }
}