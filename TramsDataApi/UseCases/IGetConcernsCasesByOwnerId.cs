using System.Collections.Generic;
using TramsDataApi.ResponseModels;

namespace TramsDataApi.UseCases
{
    public interface IGetConcernsCasesByOwnerId
    {
        IList<ConcernsCaseResponse> Execute(string ownerId, int? statusUrn, int page, int count);
    }
}