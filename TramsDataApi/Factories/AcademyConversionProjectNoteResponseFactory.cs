using System;
using TramsDataApi.DatabaseModels;
using TramsDataApi.ResponseModels.AcademyConversionProject;

namespace TramsDataApi.Factories
{
    public class AcademyConversionProjectNoteResponseFactory
    {
        public static AcademyConversionProjectNoteResponse Create(ProjectNote projectNote)
        {
            return new AcademyConversionProjectNoteResponse
            {
                Subject = projectNote.Subject,
                Note = projectNote.Note,
                Author = projectNote.Author,
                Date = projectNote.Date
            };
        }
    }
}
