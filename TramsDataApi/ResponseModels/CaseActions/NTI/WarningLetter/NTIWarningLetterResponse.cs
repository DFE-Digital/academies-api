using System;
using System.Collections.Generic;
using TramsDataApi.DatabaseModels;

namespace TramsDataApi.ResponseModels.CaseActions.NTI.WarningLetter
{
	[Obsolete("This is planned to be moved into the Concerns Casework API. If it is accessed by other APIs, please let the Concerns team know.")]
    public class NTIWarningLetterResponse
	{
		public long Id { get; set; }
		public int CaseUrn { get; set; }
		public DateTime? DateLetterSent { get; set; }
		public int? StatusId { get; set; }
		public DateTime CreatedAt { get; set; }
		public string Notes { get; set; }

		public DateTime? UpdatedAt { get; set; }
		public string CreatedBy { get; set; }

		public ICollection<int> WarningLetterReasonsMapping { get; set; }
		public ICollection<int> WarningLetterConditionsMapping { get; set; }
		public int? ClosedStatusId { get; set; }
		public DateTime? ClosedAt { get; set; }
	}
}
