using Microsoft.EntityFrameworkCore;
using System.Linq;
using TramsDataApi.DatabaseModels;
using TramsDataApi.Factories;
using TramsDataApi.Gateways;
using TramsDataApi.RequestModels.AcademyConversionProject;
using TramsDataApi.ResponseModels.AcademyConversionProject;

namespace TramsDataApi.UseCases
{
    public class GetAcademyConversionProject : IUseCase<GetAcademyConversionProjectByIdRequest, AcademyConversionProjectResponse>
    {
        private readonly TramsDbContext _tramsDbContext;
        private readonly ITrustGateway _trustGateway;

        public GetAcademyConversionProject(
            TramsDbContext tramsDbContext,
            ITrustGateway trustGateway)
        {
            _tramsDbContext = tramsDbContext;
            _trustGateway = trustGateway;
        }

        public AcademyConversionProjectResponse Execute(GetAcademyConversionProjectByIdRequest request)
        {
            var academyConversionProject = _tramsDbContext.AcademyConversionProjects.SingleOrDefault(p => p.Id == request.Id);
            if (academyConversionProject == null)
            {
                return null;
            }

            Trust trust = null;
            if (!string.IsNullOrEmpty(academyConversionProject.TrustReferenceNumber))
            {
                trust = _trustGateway.GetIfdTrustByGroupId(academyConversionProject.TrustReferenceNumber);
            }

            return AcademyConversionProjectResponseFactory.Create(academyConversionProject, trust);
        }
    }
}
