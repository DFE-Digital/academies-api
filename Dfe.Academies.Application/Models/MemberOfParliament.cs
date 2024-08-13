namespace Dfe.Academies.Application.Models
{
    public class MemberOfParliament
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string DisplayName { get; set; }
        public string DisplayNameWithTitle { get; set; }
        public string Role { get; set; }
        public string ConstituencyName { get; set; }
    }
}
