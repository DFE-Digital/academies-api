namespace TramsDataApi.ResponseModels.AcademyTransferProject
{
    public class AcademyTransferProjectBenefitsResponse
    {
        public IntendedTransferBenefitResponse IntendedTransferBenefits { get; set; }
        public OtherFactorsToConsiderResponse OtherFactorsToConsider { get; set; }
        public bool? EqualitiesImpactAssessmentConsidered { get; set; }
        public bool? IsCompleted { get; set; }
        public bool? AnyRisks { get; set; }

    }
}