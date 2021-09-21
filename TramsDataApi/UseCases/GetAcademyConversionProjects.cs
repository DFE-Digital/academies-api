using System.Collections.Generic;
using System.Linq;
using TramsDataApi.Factories;
using TramsDataApi.Gateways;
using TramsDataApi.RequestModels.AcademyConversionProject;
using TramsDataApi.ResponseModels.AcademyConversionProject;

namespace TramsDataApi.UseCases
{
    public class GetAcademyConversionProjects : IUseCase<GetAllAcademyConversionProjectsRequest, IEnumerable<AcademyConversionProjectResponse>>
    {
        private readonly IAcademyConversionProjectGateway _academyConversionProjectGateway;
        private readonly ITrustGateway _trustGateway;
        private readonly IEstablishmentGateway _establishmentGateway;
        private readonly IIfdPipelineGateway _ifdPipelineGateway;

        public GetAcademyConversionProjects(
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

        /// <remarks>
        /// May make more sense to add trust and sponsor info into ACP table when an ACP is created so that no need to query trusts table
        /// Just not sure if a trust or sponsor name could change while an ACP is still open
        /// </remarks>
        public IEnumerable<AcademyConversionProjectResponse> Execute(GetAllAcademyConversionProjectsRequest request)
        {
            var ifdProjects = _ifdPipelineGateway.GetPipelineProjects(request.Page, request.Count)
                .ToList();

            var academyConversionProjects = _academyConversionProjectGateway
                .GetByIfdPipelineIds(ifdProjects.Select(i => i.Sk).ToList()).ToList();
            
            var trustRefs = academyConversionProjects
                .Where(acp => !string.IsNullOrEmpty(acp.TrustReferenceNumber))
                .Select(acp => acp.TrustReferenceNumber)
                .ToArray();

            var trusts = _trustGateway
                .GetIfdTrustsByTrustRef(trustRefs)
                .Select(t => new { t.TrustRef, TrustName = t.TrustsTrustName })
                .ToArray();

            var responses = academyConversionProjects
                .Where(p => !string.IsNullOrEmpty(p.SchoolName))
                .Select(p => AcademyConversionProjectResponseFactory.Create(p))
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
