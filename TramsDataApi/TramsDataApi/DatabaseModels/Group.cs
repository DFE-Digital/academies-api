using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace TramsDataApi.DatabaseModels
{
    [Table("Group", Schema = "gias")]
    public partial class Group
    {
        [Column("Group UID")]
        public string GroupUid { get; set; }
        
        [Column("Group ID")]
        public string GroupId { get; set; }
        
        [Column("Group Name")]
        public string GroupName { get; set; }
        
        [Column("Companies House Number")]
        public string CompaniesHouseNumber { get; set; }
        
        [Column("Group Type (code)")]
        public string GroupTypeCode { get; set; }
        
        [Column("Group Type")]
        public string GroupType { get; set; }
        
        [Column("Closed Date")]
        public string ClosedDate { get; set; }
        
        [Column("Group Status (code)")]
        public string GroupStatusCode { get; set; }
        
        [Column("Group Status")]
        public string GroupStatus { get; set; }
        
        [Column("Group Contact Street")]
        public string GroupContactStreet { get; set; }
        
        [Column("Group Contact Locality")]
        public string GroupContactLocality { get; set; }
        
        [Column("Group Contact Address 3")]
        public string GroupContactAddress3 { get; set; }
        
        [Column("Group Contact Town")]
        public string GroupContactTown { get; set; }
        
        [Column("Group Contact County")]
        public string GroupContactCounty { get; set; }
        
        [Column("Group Contact Postcode")]
        public string GroupContactPostcode { get; set; }
        
        [Column("Head of Group Title")]
        public string HeadOfGroupTitle { get; set; }
        
        [Column("Head of Group First Name")]
        public string HeadOfGroupFirstName { get; set; }
        
        [Column("Head of Group Last Name")]
        public string HeadOfGroupLastName { get; set; }
        
        [Column("UKPRN")]
        public string Ukprn { get; set; }
        
        [Column("Incorporated on (open date)")]
        public string IncorporatedOnOpenDate { get; set; }
        
        [Column("Open date")]
        public string OpenDate { get; set; }
    }
}
