using System.Collections.Generic;
using System.Linq;
using TramsDataApi.Factories;
using TramsDataApi.Gateways;
using TramsDataApi.RequestModels;
using TramsDataApi.ResponseModels;

namespace TramsDataApi.UseCases
{
    public class GetBaselineTrackerList : IUseCase<GetAllBaselineTrackerRequest, IEnumerable<BaselineTrackerResponse>>
    {
        private readonly IAcademyConversionProjectGateway _academyConversionProjectGateway;
        private readonly ITrustGateway _trustGateway;
        private readonly IEstablishmentGateway _establishmentGateway;
        private readonly IIfdPipelineGateway _ifdPipelineGateway;

        public GetBaselineTrackerList(IAcademyConversionProjectGateway academyConversionProjectGateway,
            ITrustGateway trustGateway,
            IEstablishmentGateway establishmentGateway,
            IIfdPipelineGateway ifdPipelineGateway)
        {
            _academyConversionProjectGateway = academyConversionProjectGateway;
            _trustGateway = trustGateway;
            _establishmentGateway = establishmentGateway;
            _ifdPipelineGateway = ifdPipelineGateway;
        }

        public IEnumerable<BaselineTrackerResponse> Execute(GetAllBaselineTrackerRequest request)
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
                .Select(p => BaselineTrackerResponseFactory
                    .Create(p, null, ifdProjects.FirstOrDefault(ifd => ifd.Sk == p.IfdPipelineId)))
                .ToList();

            responses.ForEach(r =>
            {
                var estab = _establishmentGateway.GetByUrn(r.Urn);

                r.UkPrn = estab?.Ukprn;
                r.TrustUID = estab?.TrustsCode;
                r.LA = estab?.LaCode;

                r.Laestab = _establishmentGateway.GetMisEstablishmentByUrn(r.Urn)?.Laestab ?? 0;
            });

            return responses;
        }
    }
}
