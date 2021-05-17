namespace TramsDataApi.ResponseModels
{
    public class OtherFactorsToConsiderRequest
    {
        public BenefitConsideredFactorRequest HighProfile { get; set; }
        public BenefitConsideredFactorRequest ComplexLandAndBuilding { get; set; }
        public BenefitConsideredFactorRequest FinanceAndDebt { get; set; }
    }
}