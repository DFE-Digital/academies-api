using TramsDataApi.RequestModels.ApplyToBecome;
using TramsDataApi.ResponseModels.ApplyToBecome;

namespace TramsDataApi.UseCases
{
    public interface ICreateA2BApplyingSchool
    {
        A2BApplyingSchoolResponse Execute(A2BApplyingSchoolCreateRequest request);
    }
}