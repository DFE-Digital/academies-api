using System;
using System.ComponentModel.DataAnnotations;
using TramsDataApi.DatabaseModels;

namespace TramsDataApi.RequestModels.CaseActions.SRMA
{
    [Obsolete("This is planned to be moved into the Concerns Casework API. If it is accessed by other APIs, please let the Concerns team know.")]
    public class PatchSRMARequest
    {
        [Required]
        public int SRMAId { get; set; }

        [Required]
        public Func<SRMACase, SRMACase> Delegate { get; set; } 
    }
}
