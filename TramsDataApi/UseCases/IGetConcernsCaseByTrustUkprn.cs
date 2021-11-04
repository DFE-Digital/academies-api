using System.Collections.Generic;
using TramsDataApi.ResponseModels;

namespace TramsDataApi.UseCases
{
    public interface IGetConcernsCaseByTrustUkprn
    {
        public IList<ConcernsCaseResponse> Execute(string trustUkprn, int page, int count);
    }
}