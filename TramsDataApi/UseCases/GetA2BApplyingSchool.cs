using TramsDataApi.Factories;
using TramsDataApi.Gateways;
using TramsDataApi.ResponseModels.ApplyToBecome;

namespace TramsDataApi.UseCases
{
    public class GetA2BApplyingSchool : IGetA2BApplyingSchool
    {
        private readonly IA2BApplyingSchoolGateway _gateway;

        public GetA2BApplyingSchool(IA2BApplyingSchoolGateway gateway)
        {
            _gateway = gateway;
        }

        public A2BApplyingSchoolResponse Execute(string applyingSchoolId)
        {
            var applyingSchool = _gateway.GetByApplyingSchoolId(applyingSchoolId);

            return applyingSchool != null 
                ? A2BApplyingSchoolResponseFactory.Create(applyingSchool) 
                : null;
        }
    }
}