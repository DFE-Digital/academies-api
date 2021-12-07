using TramsDataApi.Factories;
using TramsDataApi.Gateways;
using TramsDataApi.RequestModels.ApplyToBecome;
using TramsDataApi.ResponseModels.ApplyToBecome;

namespace TramsDataApi.UseCases
{
    public class CreateA2BApplyingSchool : ICreateA2BApplyingSchool
    {
        private readonly IA2BApplyingSchoolGateway _gateway;

        public CreateA2BApplyingSchool(IA2BApplyingSchoolGateway gateway)
        {
            _gateway = gateway;
        }

        public A2BApplyingSchoolResponse Execute(A2BApplyingSchoolCreateRequest request)
        {
            var applyingSchoolToCreate = A2BApplyingSchoolFactory.Create(request);
            var createdApplyingSchool = _gateway.CreateA2BApplyingSchool(applyingSchoolToCreate);
            return A2BApplyingSchoolResponseFactory.Create(createdApplyingSchool);
        }
        
    }
}