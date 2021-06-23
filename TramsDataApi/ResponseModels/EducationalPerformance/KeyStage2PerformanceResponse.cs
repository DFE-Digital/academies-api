namespace TramsDataApi.ResponseModels.EducationalPerformance
{
    public class KeyStage2PerformanceResponse
    {
        public string Year { get; set; }
        public DisadvantagedPupilsResponse PercentageMeetingExpectedStdInRWM { get; set; }
        public DisadvantagedPupilsResponse PercentageAchievingHigherStdInRWM { get; set; }
        public DisadvantagedPupilsResponse ProgressScore { get; set; }
    }
}