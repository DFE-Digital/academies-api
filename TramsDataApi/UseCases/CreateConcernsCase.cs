using TramsDataApi.Factories;
using TramsDataApi.Gateways;
using TramsDataApi.RequestModels;
using TramsDataApi.ResponseModels;

namespace TramsDataApi.UseCases
{
    public class CreateConcernsCase : ICreateConcernsCase
    {
        private readonly IConcernsCaseGateway _concernsCaseGateway;
        private readonly IConcernsStatusGateway _concernsStatusGateway;

        public CreateConcernsCase(IConcernsCaseGateway concernsCaseGateway, IConcernsStatusGateway concernsStatusGateway)
        {
            _concernsCaseGateway = concernsCaseGateway;
            _concernsStatusGateway = concernsStatusGateway;
        }

        public ConcernsCaseResponse Execute(ConcernCaseRequest request)
        {
            var concernsStatus = _concernsStatusGateway.GetStatusByUrn(request.StatusUrn);
            var concernsCaseToCreate = ConcernsCaseFactory.Create(request, concernsStatus);
            var createdConcernsCase = _concernsCaseGateway.SaveConcernsCase(concernsCaseToCreate);
            return ConcernsCaseResponseFactory.Create(createdConcernsCase);
        }
    }
}