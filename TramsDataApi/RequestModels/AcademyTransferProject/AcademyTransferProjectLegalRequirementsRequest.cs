namespace TramsDataApi.RequestModels.AcademyTransferProject
{
    public class AcademyTransferProjectLegalRequirementsRequest
    {
        public string TrustAgreement{ get; set; }
        public string DiocesanConsent{ get; set; }
        public string FoundationConsent{ get; set; }
        public bool? IsCompleted { get; set; }
    }
}
