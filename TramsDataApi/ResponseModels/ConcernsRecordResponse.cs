using System;

namespace TramsDataApi.ResponseModels
{
    [Obsolete("This class is planned to be moved into the Concerns Casework API. If it is accessed by other APIs, please let the Concerns team know.")]
    public class ConcernsRecordResponse
    {
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public DateTime ReviewAt { get; set; }
        public DateTime ClosedAt { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Reason { get; set; }
        public int RatingUrn { get; set; }
        public int Urn { get; set; }
        public int StatusUrn { get; set; }
        public int TypeUrn { get; set; }
        public int CaseUrn { get; set; }
        public int? MeansOfReferralUrn { get; set; }
    }
}