using System;
using System.Linq;
using TramsDataApi.DatabaseModels;
using TramsDataApi.Factories;
using TramsDataApi.RequestModels.AcademyConversionProject;
using TramsDataApi.ResponseModels.AcademyConversionProject;

namespace TramsDataApi.UseCases
{
    public class UpdateAcademyConversionProjectNotes : IUpdateAcademyConversionProjectNote
    {
        private readonly TramsDbContext _tramsDbContext;

        public UpdateAcademyConversionProjectNotes(TramsDbContext tramsDbContext)
        {
            _tramsDbContext = tramsDbContext;
        }

        public AcademyConversionProjectNoteResponse Execute(int id, UpdateAcademyConversionProjectNoteRequest request)
        {
            var projectNote = new ProjectNote
            {
                Subject = request.Subject,
                Note = request.Note,
                Author = request.Author,
                Date = DateTime.Now
            };

            _tramsDbContext.ProjectNotes.Add(projectNote);
            _tramsDbContext.SaveChanges();

            return AcademyConversionProjectNoteResponseFactory.Create(projectNote);
        }
    }
}
