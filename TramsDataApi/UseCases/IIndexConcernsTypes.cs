using System.Collections.Generic;
using TramsDataApi.ResponseModels;

namespace TramsDataApi.UseCases
{
    public interface IIndexConcernsTypes
    {
        public IList<ConcernsTypeResponse> Execute();
    }
}