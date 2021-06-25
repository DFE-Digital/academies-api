namespace TramsDataApi.ResponseModels.EducationalPerformance
{
    public class KeyStage4PerformanceResponse
    {
        public string Year { get; set; }
        public DisadvantagedPupilsResponse SipAttainment8score { get; set; }
        public DisadvantagedPupilsResponse SipAttainment8scoreenglish { get; set; }
        public DisadvantagedPupilsResponse SipAttainment8scoremaths { get; set; }
        public DisadvantagedPupilsResponse SipAttainment8scoreebacc { get; set; }
        public DisadvantagedPupilsResponse SipNumberofpupilsprogress8 { get; set; }
        public decimal? SipProgress8upperconfidence { get; set; }
        public decimal? SipProgress8lowerconfidence { get; set; }
        public DisadvantagedPupilsResponse SipProgress8english { get; set; }
        public DisadvantagedPupilsResponse SipProgress8maths { get; set; }
        public DisadvantagedPupilsResponse SipProgress8ebacc { get; set; }
    }
}