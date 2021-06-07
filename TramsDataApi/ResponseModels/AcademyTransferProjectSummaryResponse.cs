using System.Collections.Generic;

namespace TramsDataApi.ResponseModels
{
    public class AcademyTransferProjectSummaryResponse
    {
        public string ProjectUrn { get; set; }
        public string ProjectNumber { get; set; }
        public string OutgoingTrustUkprn { get; set; }
        public List<TransferringAcademiesResponse> TransferringAcademies { get; set; }
    }
}