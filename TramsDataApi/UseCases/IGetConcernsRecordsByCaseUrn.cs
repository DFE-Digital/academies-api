using System.Collections.Generic;
using TramsDataApi.ResponseModels;

namespace TramsDataApi.UseCases
{
    public interface IGetConcernsRecordsByCaseUrn
    {
        public IList<ConcernsRecordResponse> Execute(int caseUrn);
    }
}