using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TramsDataApi.DatabaseModels
{
    [Table("NoticeToImproveReason", Schema = "sdd")]
    public class NoticeToImproveReason
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public virtual ICollection<NoticeToImproveReasonMapping> NoticeToImproveReasonsMapping { get; set; }
    }
}