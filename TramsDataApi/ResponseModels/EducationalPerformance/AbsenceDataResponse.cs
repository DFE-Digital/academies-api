namespace TramsDataApi.ResponseModels.EducationalPerformance
{
    /// <summary>
    /// Absence Data Response 
    /// </summary>
    public class AbsenceDataResponse
    {
        /// <summary>
        /// Acdemic Year
        /// </summary>
        public string Year { get; set; }

        /// <summary>
        ///Percentage of possible mornings or afternoons recorded as an absence from school for whatever reason,
        ///whether authorised or unauthorised, across the full academic year.
        /// </summary>
        public double? OverallAbsence { get; set; }

        /// <summary>
        ///The percentage of pupils missing 10% or more of the mornings or afternoons they could attend, 
        ///meaning that if a pupil’s overall rate of absence is 10% or higher across the full academic 
        ///year they will be classified as persistently absent.
        /// </summary>
        public double? PersistentAbsence { get; set; }
    }
}