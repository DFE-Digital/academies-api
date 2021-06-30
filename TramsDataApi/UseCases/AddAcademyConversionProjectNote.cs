using System;
using System.Linq;
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

        public AcademyConversionProjectNoteResponse Execute(int academyConversionProjectId, AddAcademyConversionProjectNoteRequest request)
        {
            if(_tramsDbContext.AcademyConversionProjects.SingleOrDefault(p => p.Id == academyConversionProjectId) == null)
                return null;

            var projectNote = new AcademyConversionProjectNote
            {
                Subject = request.Subject,
                Note = request.Note,
                Author = request.Author,
                Date = DateTime.Now,
                AcademyConversionProjectId = academyConversionProjectId
            };

            _tramsDbContext.AcademyConversionProjectNotes.Add(projectNote);
            _tramsDbContext.SaveChanges();

            return AcademyConversionProjectNoteResponseFactory.Create(projectNote);
        }
    }
}
