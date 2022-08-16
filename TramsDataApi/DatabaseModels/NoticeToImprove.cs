using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TramsDataApi.DatabaseModels
{
    [Table("NoticeToImproveCase", Schema = "sdd")]
    public class NoticeToImprove
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        public int CaseUrn { get; set; }
        public int? StatusId { get; set; }
        public DateTime? DateStarted { get; set; }

        [StringLength(2000)]
        public string Notes { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? ClosedAt { get; set; }
        public int? ClosedStatusId { get; set; }


        [ForeignKey(nameof(StatusId))]
        public virtual NTIWarningLetterStatus Status { get; set; }

        [ForeignKey(nameof(ClosedStatusId))]
        public virtual NTIWarningLetterStatus ClosedStatus { get; set; }

        public virtual ICollection<NTIWarningLetterReasonMapping> WarningLetterReasonsMapping { get; set; }
        public virtual ICollection<NTIWarningLetterConditionMapping> WarningLetterConditionsMapping { get; set; }
    }
}