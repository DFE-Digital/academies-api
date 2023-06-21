using System.Collections.Generic;

namespace TramsDataApi.ResponseModels
{
    public class MasterTrustResponse
    {
        public MasterTrustDataResponse TrustData { get; set; }
        public GIASDataResponse GiasData { get; set; }
        public List<EstablishmentResponse> Establishments { get; set; }
    }
}