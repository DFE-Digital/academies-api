using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TramsDataApi.DatabaseModels
{
    [Obsolete("This is planned to be moved into the Concerns Casework API. If it is accessed by other APIs, please let the Concerns team know.")]
    [Table("FinancialPlanStatus", Schema = "sdd")]
    public class FinancialPlanStatus
    {
        [Key]
        public long Id { get; set;  }
        [StringLength(255)]
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set;  }
        public DateTime UpdatedAt { get; set; }
        public bool IsClosedStatus { get; set; }
    }
}
