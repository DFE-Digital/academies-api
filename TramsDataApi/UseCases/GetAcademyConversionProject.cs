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

        public GetAcademyConversionProject(
            IAcademyConversionProjectGateway academyConversionProjectGateway,
            ITrustGateway trustGateway)
        {
            _academyConversionProjectGateway = academyConversionProjectGateway;
            _trustGateway = trustGateway;
        }

        public AcademyConversionProjectResponse Execute(GetAcademyConversionProjectByIdRequest request)
        {
            var academyConversionProject = _academyConversionProjectGateway.GetById(request.Id);
            if (academyConversionProject == null) return null;

            var trust = string.IsNullOrEmpty(academyConversionProject.TrustReferenceNumber)
                ? null
                : _trustGateway.GetIfdTrustByGroupId(academyConversionProject.TrustReferenceNumber);
         
            return AcademyConversionProjectResponseFactory.Create(academyConversionProject, trust);
        }
    }
}
