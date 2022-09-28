using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TramsDataApi.DatabaseModels
{
	[Obsolete("This is planned to be moved into the Concerns Casework API. If it is accessed by other APIs, please let the Concerns team know.")]
    [Table("NoticeToImproveConditionMapping", Schema = "sdd")]
	public class NoticeToImproveConditionMapping
    {
		[Key]
		public int Id { get; set; }

        public long NoticeToImproveId { get; set; }
		public virtual NoticeToImprove NoticeToImprove { get; set; }

		public int NoticeToImproveConditionId { get; set; }
		public virtual NoticeToImproveCondition NoticeToImproveCondition { get; set; }
	}
}

