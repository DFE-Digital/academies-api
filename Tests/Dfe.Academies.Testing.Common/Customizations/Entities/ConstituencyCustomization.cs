using AutoFixture;
using Dfe.Academies.Domain.Constituencies;
using Dfe.Academies.Domain.ValueObjects;

namespace Dfe.Academies.Testing.Common.Customizations.Entities
{
    public class ConstituencyCustomization : ICustomization
    {
        public void Customize(IFixture fixture)
        {
            fixture.Customize<Constituency>(composer => composer.FromFactory(() =>
            {
                var constituencyId = fixture.Create<ConstituencyId>();
                var memberId = fixture.Create<MemberId>();

                return new Constituency(
                    constituencyId,
                    memberId,
                    fixture.Create<string>(),
                    "Doe, John",
                    "John Doe",
                    "Mr. John Doe MP",
                    fixture.Create<DateTime>(),
                    DateOnly.FromDateTime(fixture.Create<DateTime>().Date),
                    fixture.Create<MemberContactDetails>()
                );
            }));
        }
    }
}
