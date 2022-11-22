using System.ComponentModel.DataAnnotations;

namespace TramsDataApi.RequestModels
{
    public class GetTrustsByUkprnsRequest
    {
        [Required]
        public string[] Ukprns { get; set; }
    }
}
