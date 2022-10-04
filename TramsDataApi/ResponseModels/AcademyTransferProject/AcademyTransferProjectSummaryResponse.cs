using System.Collections.Generic;

namespace TramsDataApi.ResponseModels.AcademyTransferProject
{
    public class AcademyTransferProjectSummaryResponse
    {
        public string ProjectUrn { get; set; }
        public string ProjectReference { get; set; }
        public string OutgoingTrustUkprn { get; set; }
        public string OutgoingTrustName { get; set; }
        public string OutgoingTrustLeadRscRegion { get; set; }
        public List<TransferringAcademiesResponse> TransferringAcademies { get; set; }
    }
}