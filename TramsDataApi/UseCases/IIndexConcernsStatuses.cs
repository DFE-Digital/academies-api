using System;
using System.Collections.Generic;
using TramsDataApi.DatabaseModels;
using TramsDataApi.ResponseModels;

namespace TramsDataApi.UseCases
{
    [Obsolete("This is planned to be moved into the Concerns Casework API. If it is accessed by other APIs, please let the Concerns team know.")]
    public interface IIndexConcernsStatuses
    {
        public IList<ConcernsStatusResponse> Execute();
    }
}