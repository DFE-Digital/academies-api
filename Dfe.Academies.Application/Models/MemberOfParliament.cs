namespace Dfe.Academies.Application.Models
{
    public class MemberOfParliament
    {
        public int Id { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public required string Email { get; set; }
        public required string DisplayName { get; set; }
        public required string DisplayNameWithTitle { get; set; }
        public required string Role { get; set; }
        public required string ConstituencyName { get; set; }
    }
}
