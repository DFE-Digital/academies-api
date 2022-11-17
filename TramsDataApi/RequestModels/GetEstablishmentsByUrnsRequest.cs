using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace TramsDataApi.RequestModels
{
    public class GetEstablishmentsByUrnsRequest
    {
        [FromQuery(Name = "Urn")]
        [Required]
        public int[] Urns { get; set; }
    }
}
