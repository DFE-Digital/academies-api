using TramsDataApi.DatabaseModels;

namespace TramsDataApi.Gateways
{
    public interface IA2BApplyingSchoolGateway
    {
        A2BApplyingSchool GetByApplyingSchoolId(string applyingSchoolId);
        A2BApplyingSchool CreateA2BApplyingSchool(A2BApplyingSchool applyingSchool);
    }
}