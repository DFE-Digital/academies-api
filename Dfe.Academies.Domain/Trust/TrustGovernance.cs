namespace Dfe.Academies.Domain.Trust
{
    public class TrustGovernance
    {
        public long SK { get; set; }
        public long? TrustId { get; set; }
        public long? GovernanceRoleTypeId { get; set; }
        public string GID { get; set; } = null!;
        public string? Title { get; set; }
        public string? Forename1 { get; set; }
        public string? Forename2 { get; set; }
        public string? Surname { get; set; }
        public string? Email { get; set; }
        public string? DateOfAppointment { get; set; }
        public string? DateTermOfOfficeEndsOrEnded { get; set; }
        public string? AppointingBody { get; set; }
        public DateTime? Modified { get; set; }
        public string? ModifiedBy { get; set; }
    }
}
