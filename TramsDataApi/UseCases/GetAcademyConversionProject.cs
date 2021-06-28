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
        private readonly LegacyTramsDbContext _legacyTramsDbContext;
        private readonly TramsDbContext _tramsDbContext;
        private readonly ITrustGateway _trustGateway;

        public GetAcademyConversionProject(
            LegacyTramsDbContext legacyTramsDbContext, 
            TramsDbContext tramsDbContext,
            ITrustGateway trustGateway)
        {
            _legacyTramsDbContext = legacyTramsDbContext;
            _tramsDbContext = tramsDbContext;
            _trustGateway = trustGateway;
        }

        public AcademyConversionProjectResponse Execute(GetAcademyConversionProjectByIdRequest request)
        {
            var ifdPipeline = _legacyTramsDbContext.IfdPipeline.AsNoTracking().FirstOrDefault(p => p.Sk == request.Id);
            if (ifdPipeline == null)
            {
                return null;
            }

            var academyConversionProject = _tramsDbContext.AcademyConversionProjects.SingleOrDefault(p => p.IfdPipelineId == request.Id);

            Trust trust = null;
            if (!string.IsNullOrEmpty(ifdPipeline.TrustSponsorManagementTrust))
            {
                trust = _trustGateway.GetIfdTrustByGroupId(ifdPipeline.TrustSponsorManagementTrust);
            }

            return AcademyConversionProjectResponseFactory.Create(ifdPipeline, trust, academyConversionProject);
        }
    }
}
