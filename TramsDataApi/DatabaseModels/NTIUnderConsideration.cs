using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TramsDataApi.DatabaseModels
{
    [Table("NTIUnderConsideration", Schema = "sdd")]
    public class NTIUnderConsideration
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        public int CaseUrn { get; set; }

        [StringLength(2000)]
        public string Notes { get; set; }

        public int? CloseStatusId { get; set; }
        [ForeignKey(nameof(CloseStatusId))]
        public virtual NTIUnderConsiderationStatus CloseStatus { get; set; }

        public string CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? ClosedAt { get; set; }

        public virtual ICollection<NTIUnderConsiderationReasonMapping> UnderConsiderationReasonsMapping { get; set; }
    }
}