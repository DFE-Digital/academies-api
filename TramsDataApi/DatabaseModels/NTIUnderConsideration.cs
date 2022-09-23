﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TramsDataApi.DatabaseModels
{
    [Obsolete("This is planned to be moved into the Concerns Casework API. If it is accessed by other APIs, please let the Concerns team know.")]
    [Table("NTIUnderConsiderationCase", Schema = "sdd")]
    public class NTIUnderConsideration
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        public int CaseUrn { get; set; }

        [StringLength(2000)]
        public string Notes { get; set; }

        public int? ClosedStatusId { get; set; }
        [ForeignKey(nameof(ClosedStatusId))]
        public virtual NTIUnderConsiderationStatus ClosedStatus { get; set; }

        public string CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? ClosedAt { get; set; }

        public virtual ICollection<NTIUnderConsiderationReasonMapping> UnderConsiderationReasonsMapping { get; set; }
    }
}