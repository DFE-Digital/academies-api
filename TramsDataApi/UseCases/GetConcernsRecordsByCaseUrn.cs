using System.Collections.Generic;
using System.Linq;
using TramsDataApi.Factories;
using TramsDataApi.Gateways;
using TramsDataApi.ResponseModels;

namespace TramsDataApi.UseCases
{
    public class GetConcernsRecordsByCaseUrn : IGetConcernsRecordsByCaseUrn
    {
        private readonly IConcernsCaseGateway _concernsCaseGateway;

        public GetConcernsRecordsByCaseUrn(
            IConcernsCaseGateway concernsCaseGateway)
        {
            _concernsCaseGateway = concernsCaseGateway;
        }
        public IList<ConcernsRecordResponse> Execute(int caseUrn)
        {
            var concernsCase = _concernsCaseGateway.GetConcernsCaseByUrn(caseUrn);
            return concernsCase?.ConcernsRecords
                .Select(ConcernsRecordResponseFactory.Create).ToList();
        }
    }
}