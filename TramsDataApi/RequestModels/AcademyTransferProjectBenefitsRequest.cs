namespace TramsDataApi.RequestModels
{
    public class AcademyTransferProjectBenefitsRequest
    {
        public IntendedTransferBenefitRequest IntendedTransferBenefits { get; set; }
        public OtherFactorsToConsiderRequest OtherFactorsToConsider { get; set; }
        public bool? EqualitiesImpactAssessmentConsidered { get; set; }
        public bool? AnyRisks { get; set; }
        public bool? IsCompleted { get; set; }
        
    }
}
