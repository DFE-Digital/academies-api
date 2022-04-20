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
                var baseline = BaselineTrackerResponseFactory.Create(ifd);

                responses.Add(baseline);
            }

            responses.ForEach(response =>
            {
                var estab = _establishmentGateway.GetByUrn(response.Urn);

                response.UkPrn = estab?.Ukprn;
                response.TrustUID = estab?.TrustsCode;
                response.LA = estab?.LaCode;
                response.Laestab = _establishmentGateway.GetMisEstablishmentByUrn(response.Urn)?.Laestab ?? 0;

                var group = _trustGateway.GetGroupByUkPrn(estab?.Ukprn);
                var trust = _trustGateway.GetIfdTrustByGroupId(group.GroupId);

                // GIAS
                response.NameOfTrust = trust.TrustsTrustName;
                response.SponsorReferenceNumber = trust.LeadSponsor;
                response.SponsorName = trust.TrustsLeadSponsorName;
                response.LeadSponsorId = trust.TrustsLeadSponsorId;
                response.SponsorEmail = trust.TrustContactDetailsTrustContactEmail;
                response.GroupId = group.GroupId;
                response.GroupType = group.GroupType;
                response.TrustCompaniesHouseRef = group.CompaniesHouseNumber;
            });

            return responses;
        }
    }
}
