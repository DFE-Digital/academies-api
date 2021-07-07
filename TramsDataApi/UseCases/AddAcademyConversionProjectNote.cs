using System;
using System.Linq;
using TimeZoneConverter;
using TramsDataApi.DatabaseModels;
using TramsDataApi.Factories;
using TramsDataApi.RequestModels.AcademyConversionProject;
using TramsDataApi.ResponseModels.AcademyConversionProject;

namespace TramsDataApi.UseCases
{
    public class AddAcademyConversionProjectNote : IAddAcademyConversionProjectNote
    {
        private readonly TramsDbContext _tramsDbContext;

        public AddAcademyConversionProjectNote(TramsDbContext tramsDbContext)
        {
            _tramsDbContext = tramsDbContext;
        }

        public AcademyConversionProjectNoteResponse Execute(int id, AddAcademyConversionProjectNoteRequest request)
        {
            if(!_tramsDbContext.AcademyConversionProjects.Any(p => p.Id == id))
                return null;

            var timeZoneInfo = TZConvert.GetTimeZoneInfo("GMT Standard Time");

            var projectNote = new AcademyConversionProjectNote
            {
                Subject = request.Subject,
                Note = request.Note,
                Author = request.Author,
                Date = TimeZoneInfo.ConvertTimeBySystemTimeZoneId(DateTime.UtcNow, timeZoneInfo.Id),
                AcademyConversionProjectId = id
            };

            _tramsDbContext.AcademyConversionProjectNotes.Add(projectNote);
            _tramsDbContext.SaveChanges();

            return AcademyConversionProjectNoteResponseFactory.Create(projectNote);
        }
    }
}
