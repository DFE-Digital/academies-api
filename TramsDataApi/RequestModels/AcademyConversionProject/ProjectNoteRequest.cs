using System;

namespace TramsDataApi.RequestModels.AcademyConversionProject
{
    public class ProjectNoteRequest
    {
        public string Subject { get; set; }
        public string Note { get; set; }
        public string Author { get; set; }
        public DateTime Date { get; set; }
    }
}
