namespace TramsDataApi.DatabaseModels.Concerns.Case.Management.Actions.Decisions
{
    public class DecisionType
    {
        public Enums.Concerns.DecisionType Id { get; private set; }
        public string Name { get; private set; }

        private DecisionType()
        {
                
        }

        public DecisionType(Enums.Concerns.DecisionType decisionType, string name)
        {
            Id = decisionType;
            Name = name;
        }   


    }
}
