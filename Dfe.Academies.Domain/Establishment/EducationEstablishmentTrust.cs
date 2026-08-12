namespace Dfe.Academies.Domain.Establishment
{
    public class EducationEstablishmentTrust
    {
        public long SK { get; set; }

        // Foreign keys
        public long TrustId { get; set; }
        public long EducationEstablishmentId { get; set; }
        public string DateJoinedTrust { get; set; } = string.Empty;
    }

}
