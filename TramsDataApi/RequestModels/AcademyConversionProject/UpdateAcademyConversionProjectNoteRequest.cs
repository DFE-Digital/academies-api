using System;

namespace TramsDataApi.RequestModels.AcademyConversionProject
{
    public class UpdateAcademyConversionProjectNoteRequest
    {
        public string Subject { get; set; }
        public string Note { get; set; }
        public string Author { get; set; }
    }
}
