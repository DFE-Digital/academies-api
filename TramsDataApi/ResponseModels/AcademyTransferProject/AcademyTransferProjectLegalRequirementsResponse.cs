namespace TramsDataApi.ResponseModels.AcademyTransferProject
{
    public class AcademyTransferProjectLegalRequirementsResponse
    {
        public string IncomingTrustAgreement { get; set; }
        public string DiocesanConsent { get; set; }
        public string OutgoingTrustConsent { get; set; }
        public bool? IsCompleted { get; set; }
    }
}
