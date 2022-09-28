using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TramsDataApi.DatabaseModels
{
	[Obsolete("This is planned to be moved into the Concerns Casework API. If it is accessed by other APIs, please let the Concerns team know.")]
    [Table("NTIUnderConsiderationReasonMapping", Schema = "sdd")]
	public class NTIUnderConsiderationReasonMapping
	{
		[Key]
		public int Id { get; set; }

        public long NTIUnderConsiderationId { get; set; }
		public virtual NTIUnderConsideration NTIUnderConsideration { get; set; }

		public int NTIUnderConsiderationReasonId { get; set; }
		public virtual NTIUnderConsiderationReason NTIUnderConsiderationReason { get; set; }
	}
}

