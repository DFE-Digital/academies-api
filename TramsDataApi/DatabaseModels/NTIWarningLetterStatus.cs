using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TramsDataApi.DatabaseModels
{
    [Table("NTIWarningLetterStatus", Schema = "sdd")]
    public class NTIWarningLetterStatus
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}