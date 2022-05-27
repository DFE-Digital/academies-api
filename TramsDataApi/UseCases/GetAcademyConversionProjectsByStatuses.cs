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
        private readonly IEstablishmentGateway _establishmentGateway;
        private readonly IIfdPipelineGateway _ifdPipelineGateway;
        
        public GetAcademyConversionProjectsByStatuses(
            IAcademyConversionProjectGateway academyConversionProjectGateway,
            ITrustGateway trustGateway,
            IEstablishmentGateway establishmentGateway,
            IIfdPipelineGateway ifdPipelineGateway)
        {
            _academyConversionProjectGateway = academyConversionProjectGateway;
            _trustGateway = trustGateway;
            _establishmentGateway = establishmentGateway;
            _ifdPipelineGateway = ifdPipelineGateway;
        }

        public IEnumerable<AcademyConversionProjectResponse> Execute(GetAcademyConversionProjectsByStatusesRequest request)
        {

            var ifdProjects = _ifdPipelineGateway.GetPipelineProjectsByStatus(request.Page, request.Count, request.Statuses)
                .ToList();

            var academyConversionProjects = _academyConversionProjectGateway
                .GetByIfdPipelineIds(ifdProjects.Select(i => i.Sk).ToList()).ToList();

            var trustRefs = academyConversionProjects
                .Where(acp => !string.IsNullOrEmpty(acp.TrustReferenceNumber))
                .Select(acp => acp.TrustReferenceNumber)
                .ToArray();

            var trusts = _trustGateway.GetIfdTrustsByTrustRef(trustRefs)
                .Select(t => new {t.TrustRef, TrustName = t.TrustsTrustName})
                .ToArray();

            var responses = academyConversionProjects
                .Where(p => !string.IsNullOrEmpty(p.SchoolName))
                .Select(p => AcademyConversionProjectResponseFactory
                    .Create(p))
                .ToList();
            
            responses.ForEach(r =>
            {
                r.NameOfTrust = trusts.FirstOrDefault(t => t.TrustRef == r.TrustReferenceNumber)?.TrustName;
                r.UkPrn = _establishmentGateway.GetByUrn(r.Urn)?.Ukprn;
                r.Laestab = _establishmentGateway.GetMisEstablishmentByUrn(r.Urn)?.Laestab ?? 0;
            });

            return responses;
        }
    }
}
