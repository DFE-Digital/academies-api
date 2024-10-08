using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;

namespace TramsDataApi.ResponseModels
{
    public static class PagingResponseFactory
    {
        public static PagingResponse Create(int page, int count, int recordCount, HttpRequest request)
        {
            var pagingResponse = new PagingResponse
            {
                RecordCount = recordCount,
                Page = page
            };

            if ((count * page) >= recordCount) return pagingResponse;

            var queryAttributes = request.Query
                .Where(q => q.Key != nameof(page) && q.Key != nameof(count))
                .Select(q => new KeyValuePair<string, string>(q.Key, q.Value));

            var queryBuilder = new QueryBuilder(queryAttributes)
            {
                {nameof(page), $"{page + 1}"}, 
                {nameof(count), $"{count}"}
            };

            pagingResponse.NextPageUrl = $"{request.Path}{queryBuilder}";

            return pagingResponse;
        }

        public static DfE.CoreLibs.Contracts.Academies.V4.PagingResponse CreateV4PagingResponse(int page, int count, int recordCount, HttpRequest request)
        {
            var pagingResponse = new DfE.CoreLibs.Contracts.Academies.V4.PagingResponse
            {
                RecordCount = recordCount,
                Page = page
            };

            if ((count * page) >= recordCount) return pagingResponse;

            var queryAttributes = request.Query
                .Where(q => q.Key != nameof(page) && q.Key != nameof(count))
                .Select(q => new KeyValuePair<string, string>(q.Key, q.Value));

            var queryBuilder = new QueryBuilder(queryAttributes)
            {
                {nameof(page), $"{page + 1}"},
                {nameof(count), $"{count}"}
            };

            pagingResponse.NextPageUrl = $"{request.Path}{queryBuilder}";

            return pagingResponse;
        }
    }
}