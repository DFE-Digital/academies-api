using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TramsDataApi.ServiceModels.ApplyToBecome
{
	public class FinancialYearServiceModel
	{
		public DateTime? FYEndDate { get; set; }
		public decimal RevenueCarryForward { get; set; }
		public bool? RevenueIsDeficit { get; set; }
		public string RevenueStatusExplained { get; set; }
		//		public Link RevenueRecoveryPlanEvidenceDocument { get; set; }
		public decimal CapitalCarryForward { get; set; }
		public bool? CapitalIsDeficit { get; set; }
		public string CapitalStatusExplained { get; set; }
		//		public Link CapitalRecoveryPlanEvidenceDocument { get; set; } // CML might be the same as the revenue document link?
	}

}
