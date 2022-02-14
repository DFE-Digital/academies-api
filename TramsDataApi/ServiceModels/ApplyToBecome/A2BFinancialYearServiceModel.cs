using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TramsDataApi.ServiceModels.ApplyToBecome
{
	public class FinancialYearServiceModel
	{
		public DateTime? FYEndDate { get; set; }
		[Obsolete("pipeline will merge into ActualRevenueCarryForward")]
		public decimal RevenueCarryForward { get; set; }
		[Obsolete("pipeline will merge into RevenueStatus")]
		public string RevenueStatus { get; set; } // "Surplus" / "Deficit"
		public decimal ActualRevenueCarryForward { get; set; } // this should be negative or positive based on RevenueStatus
		public string RevenueStatusExplained { get; set; }
		//		public Link RevenueRecoveryPlanEvidenceDocument { get; set; }
		[Obsolete("pipeline will merge into ActualCapitalCarryForward")]
		public decimal CapitalCarryForward { get; set; }
		[Obsolete("pipeline will merge into ActualCapitalCarryForward")]
		public string CapitalStatus { get; set; } // "Surplus" / "Deficit"
		public decimal ActualCapitalCarryForward { get; set; }
		public string CapitalStatusExplained { get; set; }
		//		public Link CapitalRecoveryPlanEvidenceDocument { get; set; } // CML might be the same as the revenue document link?
	}

}
