﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TramsDataApi.DatabaseModels
{
    [Obsolete("This is planned to be moved into the Concerns Casework API. If it is accessed by other APIs, please let the Concerns team know.")]
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
        public string SumissionDecisionId { get; set; }
        public DateTime? DateNTILifted { get; set; }
        public DateTime? DateNTIClosed { get; set; }

        [ForeignKey(nameof(StatusId))]
        public virtual NoticeToImproveStatus Status { get; set; }

        [ForeignKey(nameof(ClosedStatusId))]
        public virtual NoticeToImproveStatus ClosedStatus { get; set; }

        public virtual ICollection<NoticeToImproveReasonMapping> NoticeToImproveReasonsMapping { get; set; }
        public virtual ICollection<NoticeToImproveConditionMapping> NoticeToImproveConditionsMapping { get; set; }
    }
}