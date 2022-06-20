using System;
using System.Collections.Generic;
using TramsDataApi.DatabaseModels;

namespace TramsDataApi.ResponseModels.CaseActions.NTI.UnderConsideration
{
    public class NTIUnderConsiderationResponse
	{
		public long Id { get; set; }
		public int CaseUrn { get; set; }
		public DateTime CreatedAt { get; set; }
		public string Notes { get; set; }

		public DateTime? UpdatedAt { get; set; }
		public DateTime? ClosedAt { get; set; }
		public string CreatedBy { get; set; }

		public ICollection<NTIUnderConsiderationReasonMapping> UnderConsiderationReasonsMapping { get; set; }


		public Enums.NTIUnderConsiderationStatus? ClosedStatus { get; set; }


	}
}
