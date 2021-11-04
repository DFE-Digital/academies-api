using System.Collections.Generic;
using TramsDataApi.ResponseModels;

namespace TramsDataApi.UseCases
{
    public interface ISearchTrusts
    {
        public IEnumerable<TrustSummaryResponse> Execute(int page, int count, string groupName, string urn, string companiesHouseNumber);
    }
}