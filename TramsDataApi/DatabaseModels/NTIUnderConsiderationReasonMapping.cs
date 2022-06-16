using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TramsDataApi.DatabaseModels
{
    [Table("NTIUnderConsiderationReasonMapping", Schema = "sdd")]
	public class NTIUnderConsiderationReasonMapping
	{
		[Key]
		public int Id { get; set; }

        public long NTIUnderConsiderationId { get; set; }
		public NTIUnderConsideration NTIUnderConsideration { get; set; }

		public int NTIUnderConsiderationReasonId { get; set; }
		public NTIUnderConsiderationReason NTIUnderConsiderationReason { get; set; }
	}
}

