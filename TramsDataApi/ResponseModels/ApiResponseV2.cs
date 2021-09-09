using System.Collections.Generic;

namespace TramsDataApi.ResponseModels
{
    public class ApiResponseV2<TResponse> where TResponse : class
    {
        public IEnumerable<TResponse> Data { get; set; }

        public ApiResponseV2() => Data = new List<TResponse>();        

        public ApiResponseV2(IEnumerable<TResponse> data) => Data = data;
    }
}