using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace TramsDataApi.DatabaseModels
{
    public class ProjectNote
    {
        public int Id { get; set; }
        public string Subject { get; set; }
        public string Note { get; set; }
        public string Author { get; set; }
        public DateTime Date { get; set; }
        [ForeignKey("AcademyConversionProjectId")]
        public int AcademyConversionProjectId { get; set; }
    }
}
