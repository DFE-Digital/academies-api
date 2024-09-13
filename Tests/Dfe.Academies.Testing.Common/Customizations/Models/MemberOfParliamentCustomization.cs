using AutoFixture;
using Dfe.Academies.Application.Common.Models;

namespace Dfe.Academies.Testing.Common.Customizations.Models
{
    public class MemberOfParliamentCustomization : ICustomization
    {
        public void Customize(IFixture fixture)
        {
            fixture.Customize<MemberOfParliament>(composer => composer
                .With(x => x.ConstituencyName, "ExampleConstituency")
                .With(x => x.FirstName, "John")
                .With(x => x.LastName, "Doe")
                .With(x => x.Email, "john.doe@example.com")
                .With(x => x.DisplayName, "John Doe")
                .With(x => x.DisplayNameWithTitle, "Mr. John Doe")
                .With(x => x.Roles, new List<string> { "MP" })
                .With(x => x.UpdatedAt, DateTime.Now));
        }
    }
}
