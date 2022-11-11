﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TramsDataApi.DatabaseModels
{
    [Obsolete("This is planned to be moved into the Concerns Casework API. If it is accessed by other APIs, please let the Concerns team know.")]
    [Table("NTIUnderConsiderationReason", Schema = "sdd")]
    public class NTIUnderConsiderationReason
    {
        [Key]
        public int Id { get; set; } 
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public virtual ICollection<NTIUnderConsiderationReasonMapping> UnderConsiderationReasonsMapping { get; set; }
    }
}