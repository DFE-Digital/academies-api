using System.Collections.Generic;

namespace TramsDataApi.ResponseModels
{
    public class TrustResponse
    {
        public IFDDataResponse IfdData { get; set; }
        public GIASDataResponse GiasData { get; set; }
        public List<EstablishmentResponse> Academies { get; set; }
    }
}