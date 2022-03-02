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
        public string KeyPersonFinancialDirectorTime {get; set;}
        public string KeyPersonMember {get; set;}
        public string KeyPersonOther {get; set;}
        public string KeyPersonTrustee {get; set;}
    }
}