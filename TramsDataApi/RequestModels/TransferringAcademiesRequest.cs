namespace TramsDataApi.RequestModels
{
    public class TransferringAcademiesRequest
    {
        public string OutgoingAcademyUkprn { get; set; }
        public string IncomingTrustUkprn { get; set; }
    }
}