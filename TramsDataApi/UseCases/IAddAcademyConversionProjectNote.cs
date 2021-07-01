using TramsDataApi.RequestModels.AcademyConversionProject;
using TramsDataApi.ResponseModels.AcademyConversionProject;

namespace TramsDataApi.UseCases
{
    public interface IAddAcademyConversionProjectNote
    {
        AcademyConversionProjectNoteResponse Execute(int id, AddAcademyConversionProjectNoteRequest request);
    }
}
