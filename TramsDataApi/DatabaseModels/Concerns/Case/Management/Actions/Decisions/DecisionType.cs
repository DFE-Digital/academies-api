namespace TramsDataApi.DatabaseModels.Concerns.Case.Management.Actions.Decisions
{
    public class DecisionType
    {
        public Enums.Concerns.DecisionType DecisionTypeId { get; private set; }

        private DecisionType()
        {
                
        }

        public DecisionType(Enums.Concerns.DecisionType decisionType, int decisionId)
        {
            DecisionTypeId = decisionType;
            DecisionId = decisionId;
        }

        public int DecisionId { get; private set; }
    }
}
