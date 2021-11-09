using System;

namespace TramsDataApi.ResponseModels
{
    public class ConcernsStatusResponse
    {
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public int Urn { get; set; }
    }
}