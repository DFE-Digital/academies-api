using Dfe.Academies.Application.EducationalPerformance;
using Dfe.Academies.Contracts.V1.EducationalPerformance;
using System.Collections.Generic;

namespace TramsDataApi.ResponseModels.EducationalPerformance
{
    public class EducationalPerformanceResponse
    {
        public string SchoolName { get; set; }
        public List<KeyStage1PerformanceResponse> KeyStage1 { get; set; }
        public List<KeyStage2PerformanceResponse> KeyStage2 { get; set; }
        public List<KeyStage4PerformanceResponse> KeyStage4 { get; set; }
        
        public List<KeyStage5PerformanceResponse> KeyStage5 { get; set; }
        public List<SchoolAbsenceDataDto> AbsenceData { get; set; }


    }
}