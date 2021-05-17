namespace TramsDataApi.RequestModels
{
    public class BenefitConsideredFactorRequest
    {
        public bool ShouldBeConsidered { get; set; }
        public string FurtherSpecification { get; set; }
    }
}