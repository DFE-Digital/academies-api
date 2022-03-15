namespace TramsDataApi.ResponseModels
{
    public class AcademyTransferProjectBenefitsResponse
    {
        public IntendedTransferBenefitResponse IntendedTransferBenefits { get; set; }
        public OtherFactorsToConsiderResponse OtherFactorsToConsider { get; set; }
        public bool? IsCompleted { get; set; }
    }
}