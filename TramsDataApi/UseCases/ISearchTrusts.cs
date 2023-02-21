using System.Collections.Generic;
using TramsDataApi.ResponseModels;

namespace TramsDataApi.UseCases
{
    public interface ISearchTrusts
    {
        public (IEnumerable<TrustSummaryResponse>, int) Execute(
            int page = 1,
            int count = 50,
            string groupName = "",
            string ukPrn = "",
            string companiesHouseNumber = "",
            bool includeEstablishments = true);
    }
}