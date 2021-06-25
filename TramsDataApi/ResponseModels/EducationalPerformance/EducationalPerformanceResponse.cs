using System.Collections.Generic;

namespace TramsDataApi.ResponseModels.EducationalPerformance
{
    public class EducationalPerformanceResponse
    {
        public string SchoolName { get; set; }
        public List<KeyStage1PerformanceResponse> KeyStage1 { get; set; }
        public List<KeyStage2PerformanceResponse> KeyStage2 { get; set; }
        public List<KeyStage4PerformanceResponse> KeyStage4 { get; set; }
    }
}