using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TramsDataApi.DatabaseModels
{
    [Table("A2BApplication", Schema="sdd")]
    public class A2BApplication
    {
	    public string Name { get; set; }
	    
	    [Key]
	    public string ApplicationId { get; set; }
	    public int? ApplicationType { get; set; }
	    public string FormTrustProposedNameOfTrust { get; set; }
	    public bool? ApplicationSubmitted { get; set; }
		public string ApplicationLeadAuthorId { get; set; }
		public string ApplicationVersion { get; set; }
		public string ApplicationLeadAuthorName { get; set; }
		public string ApplicationLeadEmail { get; set; }
		public string ApplicationRole { get; set; }
		public string ApplicationRoleOtherDescription { get; set; }
		public bool? ChangesToTrust { get; set; }
		public string ChangesToTrustExplained { get; set; }
		public bool? ChangesToLaGovernance { get; set; }
		public string ChangesToLaGovernanceExplained { get; set; }
		public DateTime? FormTrustOpeningDate { get; set; }
		public string TrustApproverName { get; set; }
		public string TrustApproverEmail { get; set; }
		public bool? FormTrustReasonApprovalToConvertAsSat { get; set; }
		public string FormTrustReasonApprovedPerson { get; set; }
		public string FormTrustReasonForming { get; set; }
		public string FormTrustReasonVision { get; set; }
		public string FormTrustReasonGeoAreas { get; set; }
		public string FormTrustReasonFreedom { get; set; }
		public string FormTrustReasonImproveTeaching { get; set; }
		public string FormTrustPlanForGrowth { get; set; }
		public string FormTrustPlansForNoGrowth { get; set; }
		public bool? FormTrustGrowthPlansYesNo { get; set; }
		public string FormTrustImprovementSupport { get; set; }
		public string FormTrustImprovementStrategy { get; set; }
		public string FormTrustImprovementApprovedSponsor { get; set; }
		public string TrustId { get; set; }
		public string ApplicationStatusId { get; set; }
		
        public ICollection<A2BApplicationKeyPersons> KeyPersons { get; set; }
        
        public ICollection<A2BApplicationApplyingSchool> ApplyingSchools { get; set; }
        
        [ForeignKey(nameof(ApplicationType))]
        public virtual A2BApplicationType ApplicationTypeOption { get; set; }
    }
}