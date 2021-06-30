using System;
using System.Collections.Generic;
using System.Linq;
using TramsDataApi.DatabaseModels;
using TramsDataApi.RequestModels.AcademyConversionProject;
using TramsDataApi.ResponseModels.AcademyConversionProject;

namespace TramsDataApi.UseCases
{
    public class GetAcademyConversionProjectNotes : IUseCase<GetAcademyConversionProjectNotesByIdRequest, IEnumerable<AcademyConversionProjectNoteResponse>>
    {
        private readonly TramsDbContext _tramsDbContext;

        public GetAcademyConversionProjectNotes(TramsDbContext tramsDbContext)
        {
            _tramsDbContext = tramsDbContext;
        }

        public IEnumerable<AcademyConversionProjectNoteResponse> Execute(GetAcademyConversionProjectNotesByIdRequest request)
        {
            // separate factory method for this mapping to response, for consistency and so it can be unit tested
            return _tramsDbContext.ProjectNotes
                .Where(pn => pn.AcademyConversionProjectId == request.Id)
                .Select(pn => new AcademyConversionProjectNoteResponse
                {
                    Subject = pn.Subject,
                    Note = pn.Note,
                    Author = pn.Author,
                    Date = DateTime.Now
                });
        }
    }
}
