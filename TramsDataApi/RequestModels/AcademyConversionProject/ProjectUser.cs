using System;

namespace TramsDataApi.RequestModels.AcademyConversionProject
{
    public class AssignedUser
    {
        public AssignedUser()
        {
        }

        public AssignedUser(Guid? id, string fullName, string emailAddress)
        {
            Id = id;
            FullName = fullName;
            EmailAddress = emailAddress;            
        }
        
        public string FullName { get; set; }
        public string EmailAddress { get; set; }
        public Guid? Id { get; set; }
    }
}
