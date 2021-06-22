using System.Collections.Generic;

namespace TramsDataApi.ResponseModels.EducationalPerformance
{
    public class EducationalPerformanceResponse
    {
        public string SchoolName { get; set; }
        public List<KeyStage1PerformanceResponse> KeyStage1Responses { get; set; }
    }
}