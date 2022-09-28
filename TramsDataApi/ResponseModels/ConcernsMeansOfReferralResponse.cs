using System;

namespace TramsDataApi.ResponseModels
{
    [Obsolete("This class is planned to be moved into the Concerns Casework API. If it is accessed by other APIs, please let the Concerns team know.")]
    public class ConcernsMeansOfReferralResponse
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public int Urn { get; set; }
    }
}