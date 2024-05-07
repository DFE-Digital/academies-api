using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace TramsDataApi.RequestModels
{
    public class GetEstablishmentsByUkprnsRequest
    {
        [FromQuery(Name = "Ukprn")]
        [Required]
        public string[] Ukprns { get; set; }
    }
}
