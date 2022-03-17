using System;

namespace TramsDataApi.RequestModels.ApplyToBecome
{
    public class A2BApplicationKeyPersonsServiceModel
    { 
        public string Name {get; set;}
        public DateTime? KeyPersonDateOfBirth {get; set;}
        public string KeyPersonBiography {get; set;}
        public bool? KeyPersonCeoExecutive {get; set;}
        public bool? KeyPersonChairOfTrust {get; set;}
        public bool? KeyPersonFinancialDirector {get; set;}
        public bool? KeyPersonMember {get; set;}
        public bool? KeyPersonOther {get; set;}
        public bool? KeyPersonTrustee {get; set;}
    }
}