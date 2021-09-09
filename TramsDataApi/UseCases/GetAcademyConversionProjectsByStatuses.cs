using System.Collections.Generic;
using System.Linq;
using TramsDataApi.Factories;
using TramsDataApi.Gateways;
using TramsDataApi.RequestModels.AcademyConversionProject;
using TramsDataApi.ResponseModels.AcademyConversionProject;

namespace TramsDataApi.UseCases
{
    public class GetAcademyConversionProjectsByStatuses : IUseCase<GetAcademyConversionProjectsByStatusesRequest, IEnumerable<AcademyConversionProjectResponse>>
    {
        private readonly IAcademyConversionProjectGateway _academyConversionProjectGateway;
        private readonly ITrustGateway _trustGateway;

        public GetAcademyConversionProjectsByStatuses(
            IAcademyConversionProjectGateway academyConversionProjectGateway,
            ITrustGateway trustGateway)
        {
            _academyConversionProjectGateway = academyConversionProjectGateway;
            _trustGateway = trustGateway;
        }

        public IEnumerable<AcademyConversionProjectResponse> Execute(GetAcademyConversionProjectsByStatusesRequest request)
        {
            var academyConversionProjects = _academyConversionProjectGateway
                .GetByStatuses(request.Count, request.Statuses)
                .ToList();

            var trustRefs = academyConversionProjects
                .Where(acp => !string.IsNullOrEmpty(acp.TrustReferenceNumber))
                .Select(acp => acp.TrustReferenceNumber)
                .ToArray();

            var trusts = _trustGateway.GetIfdTrustsByTrustRef(trustRefs)
                .Select(t => new {t.TrustRef, TrustName = t.TrustsTrustName})
                .ToArray();

            var responses = academyConversionProjects
                .Where(p => !string.IsNullOrEmpty(p.SchoolName))
                .Select(p => AcademyConversionProjectResponseFactory.Create(p))
                .ToList();
            
            foreach (var response in responses)
            {
                response.NameOfTrust = trusts.FirstOrDefault(t => t.TrustRef == response.TrustReferenceNumber)?.TrustName;
            }

            return responses;
        }
    }
}
