namespace Dfe.Academies.Domain.Establishment
{
    public class EducationEstablishmentGovernance
    {
        public long SK { get; set; }
        public long? EducationEstablishmentId { get; set; }
        public long? GovernanceRoleTypeId { get; set; }
        public string? GID { get; set; }
        public string? Title { get; set; }
        public string? Forename1 { get; set; }
        public string? Forename2 { get; set; }
        public string? Surname { get; set; }
        public string? Email { get; set; }
        public string? DateOfAppointment { get; set; }
        public string? DateTermOfOfficeEndsEnded { get; set; }
        public string? AppointingBody { get; set; }
        public DateTime? Modified { get; set; }
        public string? ModifiedBy { get; set; }

        public virtual Establishment? Establishment { get; set; }
        public virtual GovernanceRoleType? GovernanceRoleType { get; set; }
    }

}
