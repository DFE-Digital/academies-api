using TramsDataApi.RequestModels.AcademyConversionProject;
using TramsDataApi.ResponseModels.AcademyConversionProject;

namespace TramsDataApi.UseCases
{
    public interface IUpdateAcademyConversionProjectNote
    {
        AcademyConversionProjectNoteResponse Execute(int id, UpdateAcademyConversionProjectNoteRequest request);
    }
}
