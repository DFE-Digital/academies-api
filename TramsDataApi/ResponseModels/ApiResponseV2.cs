using System.Collections.Generic;

namespace TramsDataApi.ResponseModels
{
    public class ApiResponseV2<TResponse> where TResponse : class
    {
        public IEnumerable<TResponse> Data { get; set; }
        public PagingResponse Paging { get; set; }
        
        public ApiResponseV2() => Data = new List<TResponse>();

        public ApiResponseV2(IEnumerable<TResponse> data, PagingResponse pagingResponse)
        {
            Data = data;
            Paging = pagingResponse;
        } 
        
        public ApiResponseV2(TResponse data) => Data = new List<TResponse>{ data };

        /// <summary>
        /// Added this to get a list when pagination not required as in case of Construct API
        /// where all project data is returned
        /// </summary>
        /// <param name="data"></param>
        public ApiResponseV2(IEnumerable<TResponse> data)
        {
            Data = data;
           
        }

    }
}