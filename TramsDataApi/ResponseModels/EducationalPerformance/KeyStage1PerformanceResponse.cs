namespace TramsDataApi.ResponseModels.EducationalPerformance
{
    public class KeyStage1PerformanceResponse
    {
        public string Year { get; set; }
        public int? Reading { get; set; }
        public int? Writing { get; set; }
        public int? Maths { get; set; }
    }
}