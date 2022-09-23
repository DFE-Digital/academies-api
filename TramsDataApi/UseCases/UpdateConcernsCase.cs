using System;
using TramsDataApi.Factories;
using TramsDataApi.Gateways;
using TramsDataApi.RequestModels;
using TramsDataApi.ResponseModels;

namespace TramsDataApi.UseCases
{
    [Obsolete("This is planned to be moved into the Concerns Casework API. If it is accessed by other APIs, please let the Concerns team know.")]
    public class UpdateConcernsCase : IUpdateConcernsCase
    {
        private readonly IConcernsCaseGateway _concernsCaseGateway;
        
        public UpdateConcernsCase(
            IConcernsCaseGateway concernsCaseGateway)
        {
            _concernsCaseGateway = concernsCaseGateway;
        }
        
        public ConcernsCaseResponse Execute(int urn, ConcernCaseRequest request)
        {
            var currentConcernsCase = _concernsCaseGateway.GetConcernsCaseByUrn(urn);
            var concernsCaseToUpdate = ConcernsCaseFactory.Update(currentConcernsCase, request);
            var updatedConcernsCase = _concernsCaseGateway.Update(concernsCaseToUpdate);
            return ConcernsCaseResponseFactory.Create(updatedConcernsCase);
        }
    }
}