using System;

namespace TramsDataApi.ResponseModels
{
    public class AssignedUserResponse
    {
        public string FullName { get; set; }
        public string EmailAddress { get; set; }
        public Guid? Id { get; set; }
    }
}