namespace TramsDataApi.RequestModels.ApplyToBecome
{
    public class A2BApplicationKeyPersonsCreateRequest
    { 
        public string Name {get; set;}
        public string KeyPersonDateOfBirth {get; set;}
        public string KeyPersonBiography {get; set;}
        public string KeyPersonCeoExecutive {get; set;}
        public string KeyPersonChairOfTrust {get; set;}
        public string KeyPersonFinancialDirector {get; set;}
        public string KeyPersonFinancialDirectorTime {get; set;}
        public string KeyPersonMember {get; set;}
        public string KeyPersonOther {get; set;}
        public string KeyPersonTrustee {get; set;}
    }
}