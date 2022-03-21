namespace TramsDataApi.RequestModels
{
    public class AcademyTransferProjectRationaleRequest
    {
        public string ProjectRationale { get; set; }
        public string TrustSponsorRationale { get; set; }
        public bool? IsCompleted { get; set; }
    }
}