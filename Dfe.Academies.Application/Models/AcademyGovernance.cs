namespace Dfe.Academies.Application.Models
{
    public class AcademyGovernance : Person
    {
        public string? UKPRN { get; set; }
        public int? URN { get; set; }
        public string? DateOfAppointment { get; set; }
        public string? DateTermOfOfficeEndsEnded { get; set; }
    }
}
