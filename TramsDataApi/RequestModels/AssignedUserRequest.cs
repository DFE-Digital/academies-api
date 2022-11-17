using System;

namespace TramsDataApi.RequestModels
{
    public class AssignedUserRequest
    {                
        public string FullName { get; set; }
        public string EmailAddress { get; set; }
        public Guid? Id { get; set; }
    }
}