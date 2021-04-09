using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace TramsDataApi.DatabaseModels
{
    public partial class Governance
    {
        public string Gid { get; set; }
        public string Urn { get; set; }
        public string Uid { get; set; }
        public string CompaniesHouseNumber { get; set; }
        public string Role { get; set; }
        public string Title { get; set; }
        public string Forename1 { get; set; }
        public string Forename2 { get; set; }
        public string Surname { get; set; }
        public string DateOfAppointment { get; set; }
        public string DateTermOfOfficeEndsEnded { get; set; }
        public string AppointingBody { get; set; }
    }
}
