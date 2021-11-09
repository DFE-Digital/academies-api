using System.Collections.Generic;
using TramsDataApi.DatabaseModels;
using TramsDataApi.ResponseModels;

namespace TramsDataApi.UseCases
{
    public interface IIndexConcernsStatuses
    {
        public IList<ConcernsStatusResponse> Execute();
    }
}