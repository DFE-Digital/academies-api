namespace TramsDataApi.DatabaseModels.Concerns.Case.Management.Actions.Decisions
{
    public class DecisionType
    {
        public Enums.Concerns.DecisionType DecisionTypeId { get; set; }

        private DecisionType()
        {
                
        }

        public DecisionType(Enums.Concerns.DecisionType decisionType)
        {
            DecisionTypeId = decisionType;
        }

        public int DecisionId { get; set; }
    }
}
