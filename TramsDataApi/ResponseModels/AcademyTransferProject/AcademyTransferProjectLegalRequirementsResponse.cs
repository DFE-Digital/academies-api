namespace TramsDataApi.ResponseModels.AcademyTransferProject
{
    public class AcademyTransferProjectLegalRequirementsResponse
    {
        public string TrustAgreement { get; set; }
        public string DiocesanConsent { get; set; }
        public string FoundationConsent { get; set; }
        public bool? IsCompleted { get; set; }
    }
}
