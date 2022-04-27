using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TramsDataApi.Factories;
using TramsDataApi.Gateways;
using TramsDataApi.RequestModels;
using TramsDataApi.ResponseModels;

namespace TramsDataApi.UseCases
{
    public class GetBaselineTrackerListByStatuses : IUseCase<GetAllBaselineTrackerRequestByStatusesRequest, IEnumerable<BaselineTrackerResponse>>
    {
        private readonly ITrustGateway _trustGateway;
        private readonly IEstablishmentGateway _establishmentGateway;
        private readonly IIfdPipelineGateway _ifdPipelineGateway;

        public GetBaselineTrackerListByStatuses(ITrustGateway trustGateway,
            IEstablishmentGateway establishmentGateway,
            IIfdPipelineGateway ifdPipelineGateway)
        {
            _trustGateway = trustGateway;
            _establishmentGateway = establishmentGateway;
            _ifdPipelineGateway = ifdPipelineGateway;
        }

        public IEnumerable<BaselineTrackerResponse> Execute(GetAllBaselineTrackerRequestByStatusesRequest request)
        {
            var responses = new List<BaselineTrackerResponse>();

            var ifdProjects = _ifdPipelineGateway.GetPipelineProjectsByStatus(request.Page, request.Count, request.Statuses).ToList();

            foreach (var ifd in ifdProjects)
            {
                int.TryParse(ifd.GeneralDetailsUrn, out int urn);

                var trust = _trustGateway.GetIfdTrustByRID(ifd.Rid);
                var establishment = _establishmentGateway.GetByUrn(urn);
                var group = _trustGateway.GetGroupByUkPrn(establishment?.Ukprn);
                var misEstablishment = _establishmentGateway.GetMisEstablishmentByUrn(establishment?.Urn ?? 0);

                var baseline = BaselineTrackerResponseFactory.Create(ifd, trust, establishment, group, misEstablishment);

                responses.Add(baseline);
            }

            return responses;
        }
    }
}
