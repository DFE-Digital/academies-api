using TramsDataApi.DatabaseModels;
using TramsDataApi.Factories;
using TramsDataApi.Gateways;
using TramsDataApi.RequestModels.AcademyConversionProject;
using TramsDataApi.ResponseModels.AcademyConversionProject;

namespace TramsDataApi.UseCases
{
    public class GetAcademyConversionProject : IUseCase<GetAcademyConversionProjectByIdRequest, AcademyConversionProjectResponse>
    {
        private readonly IAcademyConversionProjectGateway _academyConversionProjectGateway;
        private readonly ITrustGateway _trustGateway;
        private readonly IProposedAcademyAdditionalFieldsGateway _additionalFieldsGateway;

        public GetAcademyConversionProject(
            IAcademyConversionProjectGateway academyConversionProjectGateway,
            ITrustGateway trustGateway,
            IProposedAcademyAdditionalFieldsGateway additionalFieldsGateway)
        {
            _academyConversionProjectGateway = academyConversionProjectGateway;
            _trustGateway = trustGateway;
            _additionalFieldsGateway = additionalFieldsGateway;
        }

        public AcademyConversionProjectResponse Execute(GetAcademyConversionProjectByIdRequest request)
        {
            var academyConversionProject = _academyConversionProjectGateway.GetById(request.Id);
            if (academyConversionProject == null) return null;

            var trust = string.IsNullOrEmpty(academyConversionProject.TrustReferenceNumber)
                ? null
                : _trustGateway.GetIfdTrustByGroupId(academyConversionProject.TrustReferenceNumber);
            
            if (academyConversionProject.Urn != null)
            { 
                var addtionalFields = _additionalFieldsGateway.GetByUrn((int)academyConversionProject.Urn);
                return AcademyConversionProjectResponseFactory.Create(academyConversionProject, trust, null, addtionalFields);
            }

            return AcademyConversionProjectResponseFactory.Create(academyConversionProject, trust, null, null);

        }
    }
}
