using System.Collections.Generic;
using System.Linq;
using TramsDataApi.DatabaseModels;
using TramsDataApi.Factories;
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
            return _tramsDbContext.AcademyConversionProjectNotes
                .Where(pn => pn.AcademyConversionProjectId == request.Id)
                .Select(pn => AcademyConversionProjectNoteResponseFactory.Create(pn));
        }
    }
}
