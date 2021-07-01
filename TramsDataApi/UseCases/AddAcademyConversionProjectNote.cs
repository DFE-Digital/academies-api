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

        public AcademyConversionProjectNoteResponse Execute(int id, AddAcademyConversionProjectNoteRequest request)
        {
            var academyConversionProject =
                _tramsDbContext.AcademyConversionProjects.SingleOrDefault(p => p.IfdPipelineId == id);

            if(academyConversionProject == null)
            {
                academyConversionProject = new AcademyConversionProject{IfdPipelineId = id};
                _tramsDbContext.AcademyConversionProjects.Add(academyConversionProject);
                _tramsDbContext.SaveChanges();
                _tramsDbContext.Entry(academyConversionProject).GetDatabaseValues();
            }

            var projectNote = new AcademyConversionProjectNote
            {
                Subject = request.Subject,
                Note = request.Note,
                Author = request.Author,
                Date = DateTime.Now,
                AcademyConversionProjectId = academyConversionProject.Id
            };

            _tramsDbContext.AcademyConversionProjectNotes.Add(projectNote);
            _tramsDbContext.SaveChanges();

            return AcademyConversionProjectNoteResponseFactory.Create(projectNote);
        }
    }
}
