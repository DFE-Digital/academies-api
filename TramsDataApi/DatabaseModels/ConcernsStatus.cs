using System;
using System.Collections.Generic;

namespace TramsDataApi.DatabaseModels
{
    public class ConcernsStatus
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public int Urn { get; set; }
        
    }
}