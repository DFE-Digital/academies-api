using TramsDataApi.DatabaseModels;

namespace TramsDataApi.Gateways
{
    public interface IA2BApplyingSchoolGateway
    {
        A2BApplicationApplyingSchool GetByApplyingSchoolId(string applyingSchoolId);
        A2BApplicationApplyingSchool CreateA2BApplyingSchool(A2BApplicationApplyingSchool applyingSchool);
    }
}