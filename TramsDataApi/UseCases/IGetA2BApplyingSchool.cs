using TramsDataApi.ResponseModels.ApplyToBecome;

namespace TramsDataApi.UseCases
{
    public interface IGetA2BApplyingSchool
    {
        A2BApplyingSchoolResponse Execute(string applyingSchoolId);
    }
}