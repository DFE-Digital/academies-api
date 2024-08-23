namespace Dfe.Academies.Application.Common.Models
{
    public class Person
    {
        private ICollection<string>? _roles;

        public int Id { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public required string Email { get; set; }
        public required string DisplayName { get; set; }
        public required string DisplayNameWithTitle { get; set; }
        public string? Phone { get; set; }
        public required ICollection<string> Roles
        {
            get => _roles ??= new List<string>();
            set => _roles = value ?? new List<string>();
        }
        public required DateTime? UpdatedAt { get; set; }

    }
}
