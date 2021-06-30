using TramsDataApi.DatabaseModels;
using TramsDataApi.ResponseModels.AcademyConversionProject;

namespace TramsDataApi.Factories
{
    public class AcademyConversionProjectNoteResponseFactory
    {
        public static AcademyConversionProjectNoteResponse Create(AcademyConversionProjectNote academyConversionProjectNote)
        {
            return new AcademyConversionProjectNoteResponse
            {
                Subject = academyConversionProjectNote.Subject,
                Note = academyConversionProjectNote.Note,
                Author = academyConversionProjectNote.Author,
                Date = academyConversionProjectNote.Date
            };
        }
    }
}
