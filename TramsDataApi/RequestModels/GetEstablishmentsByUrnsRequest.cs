using Microsoft.AspNetCore.Mvc;

namespace TramsDataApi.RequestModels
{
    public class GetEstablishmentsByUrnsRequest
    {
        [FromQuery(Name = "Urn")]
        public int[] Urns { get; set; }
    }
}
