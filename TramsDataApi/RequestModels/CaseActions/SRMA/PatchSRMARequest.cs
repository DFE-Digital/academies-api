using System;
using System.ComponentModel.DataAnnotations;
using TramsDataApi.DatabaseModels;

namespace TramsDataApi.RequestModels.CaseActions.SRMA
{
    public class PatchSRMARequest
    {
        [Required]
        public int SRMAId { get; set; }

        [Required]
        public Func<SRMACase, SRMACase> Delegate { get; set; } 
    }
}
