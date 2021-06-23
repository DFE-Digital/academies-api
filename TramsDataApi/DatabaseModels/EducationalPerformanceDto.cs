namespace TramsDataApi.DatabaseModels
{
    public class EducationalPerformanceDto
    { 
        public string Year { get; set; }
        public decimal? PercentageMeetingExpectedStdInRWM { get; set; }
        public decimal? PercentageMeetingExpectedStdInRWMDisadvantaged { get; set; }
        public decimal? PercentageAchievingHigherStdInRWM { get; set; }
        public decimal? PercentageAchievingHigherStdInRWMDisadvantaged { get; set; }
        public decimal? ProgressScore { get; set; }
        public decimal? ProgressScoreDisadvantaged{ get; set; }
    }
}