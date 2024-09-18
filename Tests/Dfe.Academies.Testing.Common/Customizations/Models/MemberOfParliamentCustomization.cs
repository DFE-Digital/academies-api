using AutoFixture;
using Dfe.Academies.Application.Common.Models;

namespace Dfe.Academies.Testing.Common.Customizations.Models
{
    public class MemberOfParliamentCustomization : ICustomization
    {
        public string? ConstituencyName { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public string? DisplayName { get; set; }
        public string? DisplayNameWithTitle { get; set; }
        public List<string>? Roles { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public void Customize(IFixture fixture)
        {
            fixture.Customize<MemberOfParliament>(composer => composer
                .With(x => x.ConstituencyName, ConstituencyName ?? fixture.Create<string>())
                .With(x => x.FirstName, FirstName ?? fixture.Create<string>())
                .With(x => x.LastName, LastName ?? fixture.Create<string>())
                .With(x => x.Email, Email ?? fixture.Create<string>())
                .With(x => x.DisplayName, DisplayName ?? fixture.Create<string>())
                .With(x => x.DisplayNameWithTitle, DisplayNameWithTitle ?? fixture.Create<string>())
                .With(x => x.Roles, Roles ?? fixture.Create<List<string>>())
                .With(x => x.UpdatedAt, UpdatedAt ?? fixture.Create<DateTime>()));
        }
    }
}
