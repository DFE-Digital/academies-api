using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TramsDataApi.DatabaseModels
{
	[Obsolete("This is planned to be moved into the Concerns Casework API. If it is accessed by other APIs, please let the Concerns team know.")]
    [Table("NoticeToImproveReasonMapping", Schema = "sdd")]
	public class NoticeToImproveReasonMapping
    {
		[Key]
		public int Id { get; set; }

        public long NoticeToImproveId { get; set; }
		public virtual NoticeToImprove NoticeToImprove { get; set; }

		public int NoticeToImproveReasonId { get; set; }
		public virtual NoticeToImproveReason NoticeToImproveReason { get; set; }
	}
}

