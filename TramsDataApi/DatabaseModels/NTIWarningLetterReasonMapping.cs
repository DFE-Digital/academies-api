using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TramsDataApi.DatabaseModels
{
	[Obsolete("This is planned to be moved into the Concerns Casework API. If it is accessed by other APIs, please let the Concerns team know.")]
    [Table("NTIWarningLetterReasonMapping", Schema = "sdd")]
	public class NTIWarningLetterReasonMapping
	{
		[Key]
		public int Id { get; set; }

        public long NTIWarningLetterId { get; set; }
		public virtual NTIWarningLetter NTIWarningLetter { get; set; }

		public int NTIWarningLetterReasonId { get; set; }
		public virtual NTIWarningLetterReason NTIWarningLetterReason { get; set; }
	}
}

