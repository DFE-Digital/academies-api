using System;
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
        private readonly ITrustGateway _trustGateway;
        private readonly IEstablishmentGateway _establishmentGateway;
        private readonly IIfdPipelineGateway _ifdPipelineGateway;

        public GetBaselineTrackerList(ITrustGateway trustGateway,
            IEstablishmentGateway establishmentGateway,
            IIfdPipelineGateway ifdPipelineGateway)
        {
            _trustGateway = trustGateway;
            _establishmentGateway = establishmentGateway;
            _ifdPipelineGateway = ifdPipelineGateway;
        }

        public IEnumerable<BaselineTrackerResponse> Execute(GetAllBaselineTrackerRequest request)
        {
            var responses = new List<BaselineTrackerResponse>();
            
            var ifdProjects = _ifdPipelineGateway.GetPipelineProjects(request.Page, request.Count).ToList();

            foreach (var ifd in ifdProjects)
            {
                int urn = Convert.ToInt32(ifd.GeneralDetailsUrn);

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
