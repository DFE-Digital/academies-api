using System;

namespace TramsDataApi.ResponseModels
{
    public class Version2AApiResponse<T> where T : class
    {
        public T Data { get; set; }

        public Version2AApiResponse(T data)
        {
            Data = data;
        }
    }
}