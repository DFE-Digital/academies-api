﻿using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace TramsDataApi.RequestModels
{
    public class GetTrustsByUkprnsRequest
    {
        [Required]
        [FromQuery(Name = "Ukprn")]
        public string[] Ukprns { get; set; }
    }
}
