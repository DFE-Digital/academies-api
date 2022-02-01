using System.ComponentModel.DataAnnotations.Schema;

namespace TramsDataApi.ResponseModels
{
    public class TransferringAcademiesResponse
    {
        public string OutgoingAcademyUkprn { get; set; }
        public string IncomingTrustUkprn { get; set; }
        public string IncomingTrustName { get; set; }
        public string IncomingTrustLeadRscRegion { get; set; }
    }
}