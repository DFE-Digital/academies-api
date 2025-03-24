
namespace Dfe.Academies.Domain.Establishment
{
    public class EducationEstablishmentLink
    {
        public long SK { get; set; }
        public long? FK_EducationEstablishmentURN { get; set; }
        public long? FK_EducationEstablishmentLinkURN { get; set; } 
        public int? URN { get; set; } 
        public int? LinkURN { get; set; } 
        public string LinkType { get; set; } 
        public DateTime? LinkEstablishedDate { get; set; }
        public DateTime? Modified { get; set; } 
        public string ModifiedBy { get; set; } 
    }
}
