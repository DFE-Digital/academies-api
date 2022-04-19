using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TramsDataApi.DatabaseModels
{
    [Table("SRMACase", Schema = "sdd")]
    public class SRMACase
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public long? Urn { get; set; }
        public int CaseId { get; set; }
        public int StatusId { get; set; }
        public int? CloseStatusId { get; set; }
        public int? ReasonId { get; set; }
        public DateTime DateOffered { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? DateAccepted { get; set; }
        public DateTime? StartDateOfVisit { get; set; }
        public DateTime? EndDateOfVisit { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? ClosedAt { get; set; }
        public string CreatedBy { get; set; }
        public string? Notes { get; set; }

        [ForeignKey(nameof(CaseId))]
        public virtual ConcernsCase ConcernsCase { get; set; }

        [ForeignKey(nameof(ReasonId))]
        public virtual SRMAReason Reason { get; set; }
    }
}