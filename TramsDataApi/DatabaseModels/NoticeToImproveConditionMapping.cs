using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TramsDataApi.DatabaseModels
{
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

