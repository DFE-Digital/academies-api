using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TramsDataApi.DatabaseModels
{
	[Obsolete("This is planned to be moved into the Concerns Casework API. If it is accessed by other APIs, please let the Concerns team know.")]
    [Table("NTIWarningLetterConditionMapping", Schema = "sdd")]
	public class NTIWarningLetterConditionMapping
	{
		[Key]
		public int Id { get; set; }

        public long NTIWarningLetterId { get; set; }
		public virtual NTIWarningLetter NTIWarningLetter { get; set; }

		public int NTIWarningLetterConditionId { get; set; }
		public virtual NTIWarningLetterCondition NTIWarningLetterCondition { get; set; }
	}
}

